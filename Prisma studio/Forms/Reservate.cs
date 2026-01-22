using HotelOazis.DTOs.Reservation;
using HotelOazis.Extensions;
using HotelOazis.Models;
using HotelOazis.Services.Interfaces;
using HotelOazis.Utilities;
using static HotelOazis.Utilities.DynamicContentTranslator.EntitiesTranslation;

namespace HotelOazis.Forms
{
    public partial class Reservate : Form
    {
        private readonly IFacilityService facilityService;
        private readonly IUserService userService;
        private readonly IReviewService reviewService;
        private readonly IRoomService roomService;
        private readonly ReservationInputModel model;
        private User activeUser;

        public Reservate(IRoomService roomService, ReservationInputModel model)
        {
            InitializeComponent();
            this.model = model;
            this.roomService = roomService;
            this.userService = ServiceLocator.GetService<IUserService>();
            this.facilityService = ServiceLocator.GetService<IFacilityService>();
            this.reviewService = ServiceLocator.GetService<IReviewService>();

            LoadUserDataAsync();
            ApplyStyles();
        }

        private void LoadUserDataAsync()
        {
            activeUser = userService.GetLoggedInUserAsync();
            roundPictureBox1.ImageLocation = activeUser?.AvatarUrl;
        }

        private void ApplyStyles()
        {
            this.BackColor = Color.FromArgb(245, 245, 245);

            // Стилове за DatePicker
            checkInDatePicker.Font = new Font("Segoe UI", 11);
            checkOutDatePicker.Font = new Font("Segoe UI", 11);

            // Стилове за бутони
            reservateBtn.BackColor = Color.FromArgb(39, 174, 96);
            reservateBtn.ForeColor = Color.White;
            reservateBtn.FlatStyle = FlatStyle.Flat;
            reservateBtn.FlatAppearance.BorderSize = 0;
            reservateBtn.Font = new Font("Segoe UI", 13, FontStyle.Regular);
            reservateBtn.MouseEnter += (s, e) => reservateBtn.BackColor = Color.FromArgb(33, 154, 82);
            reservateBtn.MouseLeave += (s, e) => reservateBtn.BackColor = Color.FromArgb(39, 174, 96);

            cancel.BackColor = Color.FromArgb(149, 165, 166);
            cancel.ForeColor = Color.White;
            cancel.FlatStyle = FlatStyle.Flat;
            cancel.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            cancel.MouseEnter += (s, e) => cancel.BackColor = Color.FromArgb(127, 140, 141);
            cancel.MouseLeave += (s, e) => cancel.BackColor = Color.FromArgb(149, 165, 166);

            fromLabel.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            fromLabel.ForeColor = Color.FromArgb(44, 62, 80);
            toLabel.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            toLabel.ForeColor = Color.FromArgb(44, 62, 80);
        }
        private void cancel_Click(object sender, EventArgs e)
        {
            Rooms roomsForm = new Rooms(roomService, userService);
            Program.SwitchMainForm(roomsForm);
        }

        private async void reservateBtn_Click(object sender, EventArgs e)
        {
            DateTime checkInDate = checkInDatePicker.Value;
            DateTime checkOutDate = checkOutDatePicker.Value;

            bool isReserved = await roomService.IsRoomReservedBetweenDatesAsync(model.RoomId, checkInDate, checkOutDate);
            if (isReserved)
            {
                MessageBox.Show(RoomIsAlreadyReservated, Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (checkInDate >= checkOutDate)
            {
                MessageBox.Show(InvalidCheckOutDate, Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            model.CheckInDate = checkInDate;
            model.CheckOutDate = checkOutDate;

            bool isCreated = await roomService.ReserveRoomAsync(model);
            if (isCreated)
            {
                MessageBox.Show(CreatedSuccessfully, Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reservations roomsForm = new Reservations(userService, roomService);
                Program.SwitchMainForm(roomsForm);
            }
            else
            {
                MessageBox.Show(CreateFailed, Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Rooms roomsForm = new Rooms(roomService, userService);
            Program.SwitchMainForm(roomsForm);
        }

        private void Reservate_Load(object sender, EventArgs e)
        {
            bool isAdmin = AuthorizationHelper.IsAuthorized();

            if (isAdmin)
            {
                Users.Visible = true;
                Reservations.Visible = true;
            }

            roundPictureBox1.ImageLocation = activeUser.AvatarUrl;
        }

        private void menu_ItemClicked(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            string formName = item.Name;
            Form form = new Form();

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
                    form = new Reservations(userService, roomService);
                    break;
                case "Reservations":
                    form = new Reservations(userService, roomService);
                    break;
                case "Home":
                    form = new Index(userService);
                    break;
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