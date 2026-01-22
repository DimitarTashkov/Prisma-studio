using HotelOazis.Extensions;
using HotelOazis.Models;
using HotelOazis.Services.Interfaces;
using HotelOazis.Utilities;
using System.Drawing;
using System.Windows.Forms;

namespace HotelOazis.Forms
{
    public partial class Index : Form
    {
        private readonly IUserService userService;
        private readonly IRoomService roomService;
        private readonly IFacilityService facilityService;
        private readonly IReviewService reviewService;
        private User activeUser;

        public Index(IUserService userService)
        {
            this.userService = userService;
            activeUser = userService.GetLoggedInUserAsync();
            roomService = ServiceLocator.GetService<IRoomService>();
            facilityService = ServiceLocator.GetService<IFacilityService>();
            reviewService = ServiceLocator.GetService<IReviewService>();

            InitializeComponent();
            ApplyCustomStyles(); // Приложи стилизация
        }

        private void Index_Load(object sender, EventArgs e)
        {
            roundPictureBox1.ImageLocation = activeUser.AvatarUrl;
            bool isAdmin = AuthorizationHelper.IsAuthorized();
            welcomeMessage.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            welcomeMessage.Cursor = Cursors.Default;



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

        private void roomsButton_Click(object sender, EventArgs e)
        {
            Rooms roomsForm = new Rooms(roomService, userService);
            Program.SwitchMainForm(roomsForm);
        }

        private void servicesButton_Click(object sender, EventArgs e)
        {
            Services servicesForm = new Services(facilityService, userService);
            Program.SwitchMainForm(servicesForm);
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

        // === Променен дизайн ===
        private void ApplyCustomStyles()
        {
            this.BackColor = Color.FromArgb(230, 240, 250); // Лек син фон

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = Color.FromArgb(70, 130, 180); // Стилен син
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Cursor = Cursors.Hand;
                    btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(100, 149, 237); // По-светло синьо
                    btn.MouseLeave += (s, e) => btn.BackColor = Color.FromArgb(70, 130, 180);
                }
                else if (ctrl is Label lbl)
                {
                    lbl.BackColor = Color.FromArgb(70, 130, 180); // Стилен син
                    lbl.FlatStyle = FlatStyle.Flat;
                    lbl.ForeColor = Color.White;
                    lbl.Cursor = Cursors.Hand;
                    lbl.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.MouseEnter += (s, e) => lbl.BackColor = Color.FromArgb(100, 149, 237); // По-светло синьо
                    lbl.MouseLeave += (s, e) => lbl.BackColor = Color.FromArgb(70, 130, 180);
                }
            }


        }

        private void aboutUs_Click(object sender, EventArgs e)
        {
            AboutUs aboutUsForm = new AboutUs();
            Program.SwitchMainForm(aboutUsForm);
        }

        private void contactUs_Click(object sender, EventArgs e)
        {
            ContactUs contactUsForm = new ContactUs();
            Program.SwitchMainForm(contactUsForm);
        }
    }
}
