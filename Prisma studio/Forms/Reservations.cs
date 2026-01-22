using Fitness.Utilities;
using HotelOazis.Extensions;
using HotelOazis.Models;
using HotelOazis.Services.Interfaces;
using HotelOazis.Utilities;
using static HotelOazis.Utilities.DynamicContentTranslator.EntitiesTranslation;

namespace HotelOazis.Forms
{
    public partial class Reservations : Form
    {
        private readonly IFacilityService facilityService;
        private readonly IUserService userService;
        private readonly IReviewService reviewService;
        private readonly IRoomService roomService;
        private User activeUser;

        private static bool isAuthorized;

        public Reservations(IUserService userService, IRoomService roomService)
        {
            InitializeComponent();
            this.userService = userService;
            this.roomService = roomService;
            this.facilityService = ServiceLocator.GetService<IFacilityService>();
            this.reviewService = ServiceLocator.GetService<IReviewService>();

            LoadUserDataAsync();
            ApplyStyles();
        }

        private  void LoadUserDataAsync()
        {
            activeUser =  userService.GetLoggedInUserAsync();
            roundPictureBox1.ImageLocation = activeUser?.AvatarUrl;
        }

        private void ApplyStyles()
        {
            this.BackColor = Color.FromArgb(245, 245, 245);

        }

        private async void Reservations_Load(object sender, EventArgs e)
        {
            bool isAdmin = AuthorizationHelper.IsAuthorized();

            if (isAdmin)
            {
                Users.Visible = true;
                Reservation.Visible = true;
            }

            roundPictureBox1.ImageLocation = activeUser.AvatarUrl;
            var reservations = await roomService.GetReservationsAsync();

            int yOffset = 70; // Позициониране на първата резервация

            foreach (var reservation in reservations)
            {
                int daysReserved = (reservation.CheckOutDate - reservation.CheckInDate).Days+1; 
                decimal totalPrice = reservation.PricePerNight * daysReserved;

                Panel reservationPanel = new Panel
                {
                    Size = new Size(700, 150),
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle,
                    Location = new Point((this.Width - 700) / 2, yOffset),
                    Padding = new Padding(10)
                };

                RoundPictureBox userAvatar = new RoundPictureBox
                {
                    Size = new Size(50, 50),
                    ImageLocation = reservation.PictureLocation,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(10, 10)
                };
                reservationPanel.Controls.Add(userAvatar);

                Label roomInfoLabel = new Label
                {
                    Text = $"{RoomNumber} {reservation.RoomNumber} ({reservation.RoomType})",
                    Font = new Font("Segoe UI", 14, FontStyle.Bold),
                    ForeColor = Color.FromArgb(44, 62, 80),
                    AutoSize = true,
                    Location = new Point(70, 10)
                };
                reservationPanel.Controls.Add(roomInfoLabel);

                Label daysReservedLabel = new Label
                {
                    Text = $"{DaysReserved} {daysReserved}",
                    Font = new Font("Segoe UI", 12),
                    ForeColor = Color.FromArgb(44, 62, 80),
                    AutoSize = true,
                    Location = new Point(70, 40)
                };
                reservationPanel.Controls.Add(daysReservedLabel);

                Label priceLabel = new Label
                {
                    Text = $"{Price} {totalPrice} lv.",
                    Font = new Font("Segoe UI", 12),
                    ForeColor = Color.FromArgb(44, 62, 80),
                    AutoSize = true,
                    Location = new Point(70, 60)
                };
                reservationPanel.Controls.Add(priceLabel);

                Label checkInLabel = new Label
                {
                    Text = $"{CheckIn} {reservation.CheckInDate:yyyy-MM-dd}",
                    Font = new Font("Segoe UI", 12),
                    ForeColor = Color.FromArgb(44, 62, 80),
                    AutoSize = true,
                    Location = new Point(70, 80)
                };
                reservationPanel.Controls.Add(checkInLabel);

                Label checkOutLabel = new Label
                {
                    Text = $"{CheckOut} {reservation.CheckOutDate:yyyy-MM-dd}",
                    Font = new Font("Segoe UI", 12),
                    ForeColor = Color.FromArgb(44, 62, 80),
                    AutoSize = true,
                    Location = new Point(70, 100)
                };
                reservationPanel.Controls.Add(checkOutLabel);

                Label reservedByLabel = new Label
                {
                    Text = $"{ReservedBy} {reservation.Username}",
                    Font = new Font("Segoe UI", 12),
                    ForeColor = Color.FromArgb(44, 62, 80),
                    AutoSize = true,
                    Location = new Point(70, 120)
                };
                reservationPanel.Controls.Add(reservedByLabel);

                Button cancelButton = new Button
                {
                    Text = $"{Cancel}",
                    BackColor = Color.FromArgb(231, 76, 60),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10),
                    Size = new Size(100, 30),
                    Location = new Point(580, 110),
                    Cursor = Cursors.Hand
                };
                cancelButton.Click += async (s, ev) =>
                {
                    var confirm = MessageBox.Show(string.Format(ConfirmationMessage), Confirmation, MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        bool success = await roomService.CancelReservationAsync(reservation.Id);
                        if (success)
                        {
                            MessageBox.Show(DeletionSuccessful, Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reservationsContainer.Controls.Remove(reservationPanel);
                        }
                        else
                        {
                            MessageBox.Show(DeletionFailed, Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                };
                reservationPanel.Controls.Add(cancelButton);

                reservationsContainer.Controls.Add(reservationPanel);
                yOffset += 160; // Увеличаване на отстоянието за следващата резервация
            }
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
                case "Reservation":
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