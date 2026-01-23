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
        private bool isAuthorized;

        public Orders(ISessionService sessionService, IShopService shopService, IUserService userService)
        {
            InitializeComponent();
            _sessionService = sessionService;
            _shopService = shopService;
            _userService = userService;
            activeUser = _userService.GetLoggedInUserAsync();
            isAuthorized = AuthorizationHelper.IsAuthorized();

            if (isAuthorized)
                this.Text = "Admin Dashboard - All Records";
            else
                this.Text = $"My History - {activeUser.Username}";

            // Зареждаме данните
            LoadSessions();
            LoadOrders();
        }
        private void LoadSessions()
        {
            // Взимаме данните според ролята
            List<PhotoSession> sessions;

            if (isAuthorized)
            {
                sessions = _sessionService.GetAllUpcomingSessions(); // Админ вижда всичко
            }
            else
            {
                sessions = _sessionService.GetUserSessions(activeUser.Id); // Клиент вижда своето
            }

            // Мапваме към таблицата (dgvSessions)
            var displayList = sessions.Select(s => new
            {
                Date = s.SessionDate.ToString("dd.MM.yyyy"),
                Time = s.StartTime.ToString(@"hh\:mm"),
                Service = s.PhotoService.Name,
                Price = $"{s.PhotoService.Price:F0} BGN",
                Notes = s.Notes,
                Client = s.User.Username // Полезно за Админа
            }).ToList();

            dgvSessions.DataSource = displayList;
        }

        private void LoadOrders()
        {
            List<Order> orders;

            if (isAuthorized)
            {
                orders = _shopService.GetAllOrders(); // Трябва да имаш този метод в ShopService
            }
            else
            {
                orders = _shopService.GetUserOrders(activeUser.Id);
            }

            // Мапваме към таблицата (dgvOrders)
            var displayList = orders.Select(o => new
            {
                OrderNum = o.Id.ToString().Substring(0, 8), // Показваме кратка версия на ID
                Date = o.OrderDate.ToString("dd.MM.yyyy HH:mm"),
                Total = $"{o.TotalAmount:F2} BGN",
                Address = o.DeliveryAddress,
                Client = o.User.Username
            }).ToList();

            dgvOrders.DataSource = displayList;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var mainForm = new Index(_userService);
            Program.SwitchMainForm(mainForm);
        }
    }
}
