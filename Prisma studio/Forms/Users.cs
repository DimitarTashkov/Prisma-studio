using Prisma_studio.Utilities;
using Prisma_studio.Common.Constants;
using Prisma_studio.Extensions;
using Prisma_studio.Models;
using Prisma_studio.Services.Interfaces;
using static Prisma_studio.Utilities.DynamicContentTranslator.EntitiesTranslation;
using Prisma_studio;

namespace Prisma_studio.Forms
{
    public partial class Users : Form
    {
        private readonly IFacilityService facilityService;
        private readonly IUserService userService;
        private readonly IReviewService reviewService;
        private readonly IRoomService roomService;
        private User activeUser;

        public Users(IUserService userService)
        {
            InitializeComponent();
            this.userService = userService;
            this.facilityService = ServiceLocator.GetService<IFacilityService>();
            this.reviewService = ServiceLocator.GetService<IReviewService>();
            this.roomService = ServiceLocator.GetService<IRoomService>();
            activeUser = userService.GetLoggedInUserAsync();
        }

        private async void Users_Load(object sender, EventArgs e)
        {
            roundPictureBox1.ImageLocation = activeUser.AvatarUrl;

            var users = await userService.GetUsersAsync();
            int index = 0;

            foreach (var user in users)
            {
                var userContainer = new FlowLayoutPanel
                {
                    Name = $"userContainer{index}",
                    Size = new Size(725, 120),
                    Margin = new Padding(8),
                    BackColor = Color.LightGray
                };

                var userAvatar = new RoundPictureBox
                {
                    Name = $"userAvatar{index}",
                    Size = new Size(50, 50),
                    ImageLocation = user.AvatarUrl,
                    Margin = new Padding(0, 5, 30, 0),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                var username = new Label
                {
                    Name = $"username{index}",
                    Text = user.Username,
                    Font = FontsPicker.DetailsFont,
                    Margin = new Padding(25, 5, 25, 0)
                };

                var password = new Label
                {
                    Name = $"password{index}",
                    Font = FontsPicker.DetailsFont,
                    Margin = new Padding(0, 5, 20, 0),
                    Text = new string('*', 10)
                };

                var email = new Label
                {
                    Name = $"email{index}",
                    Text = user.Email,
                    MaximumSize = new Size(100, 0),
                    AutoSize = true,
                    Font = FontsPicker.DetailsFont,
                    Margin = new Padding(0, 5, 20, 0)
                };

                var age = new Label
                {
                    Name = $"age{index}",
                    Text = user.Age.ToString(),
                    Font = FontsPicker.DetailsFont,
                    Margin = new Padding(0, 5, 0, 0)
                };

                var isAdminBox = new ComboBox
                {
                    Name = $"isAuthorized{index}",
                    Font = FontsPicker.DetailsFont,
                    Margin = new Padding(0, 5, 20, 0),
                };

                isAdminBox.Items.AddRange(new object[] { "True", "False" });
                isAdminBox.SelectedIndex = await userService.IsUserAdminAsync(user.Id) ? 0 : 1;

                isAdminBox.DropDownClosed += async (sender, e) =>
                {
                    bool isAdmin = isAdminBox.SelectedItem?.ToString() == "True";
                    if (isAdmin)
                        await userService.MakeUserAdminAsync(user.Id);
                    else
                        await userService.RemoveAdminRoleAsync(user.Id);
                };

                var edit = new Button
                {
                    Name = $"edit{index}",
                    Text = DynamicContentTranslator.EntitiesTranslation.Update,
                    Font = FontsPicker.DetailsFont,
                    BackColor = Color.Cyan,
                    AutoSize = true,
                    Margin = new Padding(330, 0, 0, 0)
                };

                edit.Click += (s, e) =>
                {
                    var profileForm = new Profile(userService, user.Id);
                    Program.SwitchMainForm(profileForm);
                };

                var delete = new Button
                {
                    Name = $"delete{index}",
                    Text = Delete,
                    Font = FontsPicker.DetailsFont,
                    BackColor = Color.Salmon,
                    AutoSize = true,
                    Margin = new Padding(330, 10, 0, 0)
                };

                delete.Click += async (s, e) =>
                {
                    var confirmResult = MessageBox.Show(ProfileDeleteWarning, Confirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmResult == DialogResult.Yes)
                    {
                        var success = await userService.DeleteUserAsync(user.Id);
                        if (success)
                        {
                            usersContainer.Controls.Remove(userContainer);
                        }
                    }
                };

                userContainer.Controls.Add(username);
                userContainer.Controls.Add(password);
                userContainer.Controls.Add(email);
                userContainer.Controls.Add(age);
                userContainer.Controls.Add(userAvatar);
                userContainer.Controls.Add(isAdminBox);
                userContainer.Controls.Add(edit);
                userContainer.Controls.Add(delete);

                usersContainer.Controls.Add(userContainer);

                index++;
            }
        }

        private void menu_ItemClicked(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            Form form = item?.Name switch
            {
                "Rooms" => new Rooms(roomService, userService),
                "Services" => new Services(facilityService, userService),
                "Reviews" => new Reviews(reviewService, userService),
                "Profile" => new Profile(userService, activeUser.Id),
                "User" => new Users(userService),
                "MyReservations" => new Reservations(userService, roomService),
                "Reservations" => new Reservations(userService, roomService),
                "Home" => new Index(userService),
                _ => new Index(userService),
            };
            Program.SwitchMainForm(form);
        }

        private void roundPictureBox1_Click(object sender, EventArgs e)
        {
            var profileForm = new Profile(userService, activeUser.Id);
            Program.SwitchMainForm(profileForm);
        }
    }
}}