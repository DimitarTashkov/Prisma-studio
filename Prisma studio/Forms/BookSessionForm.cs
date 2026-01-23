using Prisma_studio.Data.Models;
using Prisma_studio.Extensions;
using Prisma_studio.Models;
using Prisma_studio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prisma_studio.Forms
{
    public partial class BookSessionForm : Form
    {
        private readonly ISessionService _sessionService;
        private readonly IUserService _userService;
        private readonly IPhotoServiceManager _photoManager;

        // 2. Data fields
        private User activeUser;
        private List<PhotoService> loadedServices;

        public BookSessionForm(ISessionService sessionService, IUserService userService)
        {
            InitializeComponent();
            _sessionService = sessionService;
            _userService = userService;

            // Get the third service manually using ServiceLocator
            _photoManager = ServiceLocator.GetService<IPhotoServiceManager>();
            activeUser = _userService.GetLoggedInUserAsync();
            dtpDate.MinDate = DateTime.Today; // Disable past dates
            LoadServices();
        }
        private void LoadServices()
        {
            loadedServices = _photoManager.GetAllServices();

            // If no services exist
            if (loadedServices.Count == 0)
            {
                MessageBox.Show("No services available.");
                btnBook.Enabled = false;
                return;
            }

            cmbServices.Items.Clear();
            foreach (var service in loadedServices)
            {
                // Display Name and Price
                cmbServices.Items.Add($"{service.Name} - {service.Price:F0} BGN");
            }

            // Select first item by default
            cmbServices.SelectedIndex = 0;
        }

        // Logic to find free slots
        private void UpdateAvailableSlots()
        {
            cmbTime.Items.Clear();
            btnBook.Enabled = false;

            if (cmbServices.SelectedIndex == -1) return;

            // Get selected service and date
            var selectedService = loadedServices[cmbServices.SelectedIndex];
            DateTime selectedDate = dtpDate.Value.Date;

            try
            {
                // Call Service to get slots
                List<TimeSpan> freeSlots = _sessionService.GetAvailableSlots(selectedDate, selectedService.DurationMinutes);

                if (freeSlots.Count == 0)
                {
                    cmbTime.Items.Add("No free slots");
                    cmbTime.Enabled = false;
                }
                else
                {
                    foreach (var slot in freeSlots)
                    {
                        // Format time (e.g., 14:00)
                        cmbTime.Items.Add(slot.ToString(@"hh\:mm"));
                    }
                    cmbTime.Enabled = true;
                    cmbTime.SelectedIndex = 0;
                    btnBook.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking schedule: " + ex.Message);
            }
        }

        // --- EVENTS ---

        private void cmbServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAvailableSlots();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateAvailableSlots();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            // 1. Check User
            if (activeUser == null)
            {
                MessageBox.Show("Please log in to book a session!");

                var login = new Login(_userService);
                Program.SwitchMainForm(login);
                return;
            }

            // 2. Validate Selection
            if (cmbServices.SelectedIndex == -1 || cmbTime.SelectedIndex == -1 || !cmbTime.Enabled)
            {
                MessageBox.Show("Please select a valid time.");
                return;
            }

            // 3. Prepare Data
            var selectedService = loadedServices[cmbServices.SelectedIndex];
            TimeSpan selectedTime = TimeSpan.Parse(cmbTime.SelectedItem.ToString());
            DateTime date = dtpDate.Value.Date;
            string notes = txtNotes.Text;

            // 4. Save to Database
            try
            {
                bool success = _sessionService.BookSession(activeUser.Id, selectedService.Id, date, selectedTime, notes);

                if (success)
                {
                    MessageBox.Show("Session booked successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Go back to Main Menu (Index)
                    var mainForm = new Index(_userService);
                    Program.SwitchMainForm(mainForm);
                }
                else
                {
                    MessageBox.Show("This slot was just taken. Please choose another.");
                    UpdateAvailableSlots(); // Refresh
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var mainForm = new Index(_userService);
            Program.SwitchMainForm(mainForm);
        }

        private void BookSessionForm_Load(object sender, EventArgs e)
        {

        }
    }
}
