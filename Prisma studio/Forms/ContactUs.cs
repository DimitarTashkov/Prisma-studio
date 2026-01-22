using HotelOazis.Extensions;
using HotelOazis.Models;
using HotelOazis.Services.Interfaces;
using HotelOazis.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelOazis.Forms
{
    public partial class ContactUs : Form
    {
        private readonly IUserService userService;
        private readonly IRoomService roomService;
        private readonly IFacilityService facilityService;
        private readonly IReviewService reviewService;
        private User activeUser;
        public ContactUs()
        {
            this.userService = ServiceLocator.GetService<IUserService>();
            activeUser = userService.GetLoggedInUserAsync();
            roomService = ServiceLocator.GetService<IRoomService>();
            facilityService = ServiceLocator.GetService<IFacilityService>();
            reviewService = ServiceLocator.GetService<IReviewService>();
            InitializeComponent();
        }

        private void ContactUs_Load(object sender, EventArgs e)
        {
            roundPictureBox1.ImageLocation = activeUser.AvatarUrl;
            bool isAdmin = AuthorizationHelper.IsAuthorized();

            if (isAdmin)
            {
                Users.Visible = true;
                Reservations.Visible = true;
            }
        }

        private void roundPictureBox1_Click(object sender, EventArgs e)
        {
            Profile profileForm = new Profile(userService, activeUser.Id);
            Program.SwitchMainForm(profileForm);
        }
        private void menu_ItemClicked(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            string formName = item.Name;
            Form form;

            switch (formName)
            {
                case "Rooms":
                    form = new Rooms(roomService, userService);
                    break;
                case "Services":
                    form = new Services(facilityService, userService);
                    break;
                case "Reviews":
                    form = new Reviews(reviewService, userService);
                    break;
                case "Profile":
                    form = new Profile(userService, activeUser.Id);
                    break;
                case "Users":
                    form = new Users(userService);
                    break;
                case "MyReservations":
                case "Reservations":
                    form = new Reservations(userService, roomService);
                    break;
                case "Home":
                default:
                    form = new Index(userService);
                    break;
            }
            Program.SwitchMainForm(form);
        }
    }
}
