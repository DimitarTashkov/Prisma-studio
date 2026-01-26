using Prisma_studio.Data.Models;
using Prisma_studio.Extensions;
using Prisma_studio.Models;
using Prisma_studio.Services;
using Prisma_studio.Services.Interfaces;
using Prisma_studio.Utilities;
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
    public partial class ManageServices : Form
    {
        private readonly IPhotoServiceManager serviceManager;

        private Guid? _selectedServiceId = null;
        private string _selectedImagePath = null;
        private readonly IUserService userService;
        private readonly IShopService shopService = ServiceLocator.GetService<IShopService>();
        private readonly ISessionService sessionService = ServiceLocator.GetService<ISessionService>();
        private User? activeUser;

        public ManageServices(IPhotoServiceManager serviceManager)
        {
            InitializeComponent();
            this.serviceManager = serviceManager;
            userService = ServiceLocator.GetService<IUserService>();
            activeUser = userService.GetLoggedInUserAsync();
            bool isAdmin = AuthorizationHelper.IsAuthorized();

            if (isAdmin)
            {
                Users.Visible = true;
                Management.Visible = true;
            }
            // UI Setup

            LoadGrid();
        }
        private void LoadGrid()
        {
            var services = serviceManager.GetAllServices();

            // Mapping (English Columns)
            dgvServices.DataSource = services.Select(s => new
            {
                ID = s.Id,
                Name = s.Name,
                Price = s.Price,
                Duration = s.DurationMinutes // "Duration" instead of "Минути"
            }).ToList();

            if (dgvServices.Columns["ID"] != null)
                dgvServices.Columns["ID"].Visible = false;
        }

        private void dgvServices_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count > 0)
            {
                var selectedId = (Guid)dgvServices.SelectedRows[0].Cells["ID"].Value;
                var service = serviceManager.GetServiceById(selectedId);
                FillForm(service);
            }
        }

        private void FillForm(PhotoService service)
        {
            _selectedServiceId = service.Id;

            txtName.Text = service.Name;
            numPrice.Value = service.Price;
            numDuration.Value = service.DurationMinutes;
            txtDescription.Text = service.Description;

            if (!string.IsNullOrEmpty(service.ImageUrl) && File.Exists(service.ImageUrl))
            {
                pbImage.Image = Image.FromFile(service.ImageUrl);
                _selectedImagePath = service.ImageUrl;
            }
            else
            {
                pbImage.Image = null;
                _selectedImagePath = null;
            }
        }

        // --- BUTTONS ---

        private void btnNew_Click(object sender, EventArgs e)
        {
            _selectedServiceId = null;
            _selectedImagePath = null;

            txtName.Text = "";
            txtDescription.Text = "";
            numPrice.Value = 0;
            numDuration.Value = 30; // Default
            pbImage.Image = null;

            dgvServices.ClearSelection();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pbImage.Image = Image.FromFile(ofd.FileName);
                    _selectedImagePath = ofd.FileName;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Service Name is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Image logic
            string finalImagePath = _selectedImagePath;
            if (_selectedImagePath != null && !_selectedImagePath.Contains("PhotosStorage"))
            {
                string storageFolder = Path.Combine(Application.StartupPath, "PhotosStorage");
                if (!Directory.Exists(storageFolder)) Directory.CreateDirectory(storageFolder);

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(_selectedImagePath);
                string destPath = Path.Combine(storageFolder, fileName);

                File.Copy(_selectedImagePath, destPath, true);
                finalImagePath = destPath;
            }

            try
            {
                if (_selectedServiceId == null)
                {
                    // --- CREATE ---
                    var newService = new PhotoService
                    {
                        Id = Guid.NewGuid(),
                        Name = txtName.Text,
                        Price = numPrice.Value,
                        DurationMinutes = (int)numDuration.Value,
                        Description = txtDescription.Text,
                        ImageUrl = finalImagePath
                    };
                    serviceManager.AddService(newService);
                    MessageBox.Show("Service added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // --- UPDATE ---
                    var serviceToUpdate = new PhotoService
                    {
                        Id = _selectedServiceId.Value,
                        Name = txtName.Text,
                        Price = numPrice.Value,
                        DurationMinutes = (int)numDuration.Value,
                        Description = txtDescription.Text,
                        ImageUrl = finalImagePath
                    };
                    serviceManager.UpdateService(serviceToUpdate);
                    MessageBox.Show("Service updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadGrid();
                btnNew.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving service: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedServiceId == null) return;

            if (MessageBox.Show("Are you sure you want to delete this service?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                serviceManager.DeleteService(_selectedServiceId.Value);
                LoadGrid();
                btnNew.PerformClick();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var main = new Index(userService);
            Program.SwitchMainForm(main);
        }
        private void menu_ItemClicked(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            string formName = item.Name;
            Form form;

            switch (formName)
            {
                case "Store":
                    form = new ShopForm(shopService);
                    break;
                case "Services":
                    form = new BookSessionForm(sessionService, userService);
                    break;
                case "Profile":
                    form = new Profile(userService, activeUser.Id);
                    break;
                case "Users":
                    form = new Users(userService);
                    break;
                case "MyReservations":
                    form = new Orders(sessionService, shopService, userService);
                    break;
                case "manageProducts":
                    form = new ManageProducts(shopService);
                    break;
                case "manageservice":
                    form = new ManageServices(serviceManager);
                    break;
                case "Home":
                default:
                    form = new Index(userService);
                    break;
            }
            Program.SwitchMainForm(form);
        }
        private void roundPictureBox1_Click(object sender, EventArgs e)
        {
            Profile profileForm = new Profile(userService, activeUser.Id);
            Program.SwitchMainForm(profileForm);
        }
    }
}
