using Prisma_studio.Data.Models;
using Prisma_studio.Models;
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
    public partial class Orders : Form
    {
        private readonly ISessionService _sessionService;
        private readonly IShopService _shopService;
        private readonly IUserService _userService;
        private User? activeUser;
        private bool isAdmin;

        public Orders(ISessionService sessionService, IShopService shopService, IUserService userService)
        {
            InitializeComponent();
            _sessionService = sessionService;
            _shopService = shopService;
            _userService = userService;
            activeUser = _userService.GetLoggedInUserAsync();
            isAdmin = AuthorizationHelper.IsAuthorized();

            if (isAdmin)
                this.Text = "Admin Dashboard - All Records";
            else
                this.Text = $"My History - {activeUser.Username}";

            // 3. Setup Grids (Add buttons if Admin)
            SetupGrids();

            // Зареждаме данните
            LoadSessions();
            LoadOrders();
        }
        private void SetupGrids()
        {
            // --- SESSIONS GRID CONFIG ---
            dgvSessions.AutoGenerateColumns = false; // We will handle columns manually or via DataSource mapping
            dgvSessions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Ако е Админ, добавяме бутони за действие
            if (isAdmin)
            {
                // Button: Confirm
                DataGridViewButtonColumn btnConfirm = new DataGridViewButtonColumn();
                btnConfirm.Name = "Confirm";
                btnConfirm.Text = "Confirm";
                btnConfirm.UseColumnTextForButtonValue = true;
                btnConfirm.HeaderText = "Action";
                btnConfirm.FlatStyle = FlatStyle.Popup;
                btnConfirm.DefaultCellStyle.BackColor = Color.LightGreen;
                dgvSessions.Columns.Add(btnConfirm);

                // Button: Decline
                DataGridViewButtonColumn btnDecline = new DataGridViewButtonColumn();
                btnDecline.Name = "Decline";
                btnDecline.Text = "Decline";
                btnDecline.UseColumnTextForButtonValue = true;
                btnDecline.HeaderText = "Action";
                btnDecline.FlatStyle = FlatStyle.Popup;
                btnDecline.DefaultCellStyle.BackColor = Color.LightSalmon;
                dgvSessions.Columns.Add(btnDecline);

                // Attach Event
                dgvSessions.CellContentClick += DgvSessions_CellContentClick;
            }

            // --- ORDERS GRID CONFIG ---
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (isAdmin)
            {
                // Button: Complete
                DataGridViewButtonColumn btnComplete = new DataGridViewButtonColumn();
                btnComplete.Name = "Complete";
                btnComplete.Text = "Mark Completed";
                btnComplete.UseColumnTextForButtonValue = true;
                btnComplete.HeaderText = "Status";
                btnComplete.DefaultCellStyle.BackColor = Color.LightBlue;
                dgvOrders.Columns.Add(btnComplete);

                // Attach Event
                dgvOrders.CellContentClick += DgvOrders_CellContentClick;
            }
        }

        private void LoadSessions()
        {
            dgvSessions.DataSource = null; // Reset

            List<PhotoSession> sessions;
            if (isAdmin) sessions = _sessionService.GetAllUpcomingSessions();
            else sessions = _sessionService.GetUserSessions(activeUser.Id);

            // Mapping
            dgvSessions.DataSource = sessions.Select(s => new
            {
                ID = s.Id,
                Date = s.SessionDate.ToString("dd.MM.yyyy"),
                Time = s.StartTime.ToString(@"hh\:mm"),
                Service = s.PhotoService.Name,
                Client = s.User.Username,
                Status = s.IsConfirmed ? "Confirmed" : "Pending" // Показваме статус
            }).ToList();

            // Hide ID column
            if (dgvSessions.Columns["ID"] != null) dgvSessions.Columns["ID"].Visible = false;
        }

        private void LoadOrders()
        {
            dgvOrders.DataSource = null; // Reset

            List<Order> orders;
            if (isAdmin) orders = _shopService.GetAllOrders();
            else orders = _shopService.GetUserOrders(activeUser.Id);

            // Mapping
            dgvOrders.DataSource = orders.Select(o => new
            {
                OrderID = o.Id,
                Date = o.OrderDate.ToString("dd.MM.yyyy"),
                Client = o.User.Username,
                Total = $"{o.TotalAmount:F2} BGN",
                Address = o.DeliveryAddress
            }).ToList();

            if (dgvOrders.Columns["OrderID"] != null) dgvOrders.Columns["OrderID"].Visible = false;
        }

        // --- ADMIN ACTIONS (EVENTS) ---

        private void DgvSessions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if a button was clicked
            if (e.RowIndex >= 0 && isAdmin)
            {
                // Get the Session ID (hidden column)
                var sessionId = (Guid)dgvSessions.Rows[e.RowIndex].Cells["ID"].Value;
                string colName = dgvSessions.Columns[e.ColumnIndex].Name;

                if (colName == "Confirm")
                {
                    _sessionService.ConfirmSession(sessionId);
                    MessageBox.Show("Session Confirmed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSessions(); // Refresh grid
                }
                else if (colName == "Decline")
                {
                    if (MessageBox.Show("Are you sure you want to decline/cancel this session?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _sessionService.DeclineSession(sessionId);
                        LoadSessions(); // Refresh grid
                    }
                }
            }
        }

        private void DgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && isAdmin)
            {
                var orderId = (Guid)dgvOrders.Rows[e.RowIndex].Cells["OrderID"].Value;
                string colName = dgvOrders.Columns[e.ColumnIndex].Name;

                if (colName == "Complete")
                {
                    if (MessageBox.Show("Mark this order as completed and shipped?", "Order Processing", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _shopService.CompleteOrder(orderId);
                        MessageBox.Show("Order marked as completed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadOrders(); // Refresh grid
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var mainForm = new Index(_userService);
            Program.SwitchMainForm(mainForm);
        }
    }
}
