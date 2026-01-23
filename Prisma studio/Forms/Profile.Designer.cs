namespace Prisma_studio.Forms
{
    partial class Profile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Profile));
            logoutButton = new Button();
            saveButton = new Button();
            deleteButton = new Button();
            navigationButton = new Button();
            profilePicture = new Prisma_studio.Utilities.RoundPictureBox();
            editButton = new Button();
            uploadButton = new Button();
            ageField = new TextBox();
            ageLabel = new Label();
            emailField = new TextBox();
            emailLabel = new Label();
            passwordField = new TextBox();
            passwordLabel = new Label();
            usernameField = new TextBox();
            usernameLabel = new Label();
            logo = new PictureBox();
            profileLabel = new Label();
            formPanel = new Panel();
            pfpErrors = new Label();
            emailErrors = new Label();
            passwordErrors = new Label();
            usernameErrors = new Label();
            roundPictureBox1 = new Prisma_studio.Utilities.RoundPictureBox();
            menu = new MenuStrip();
            Home = new ToolStripMenuItem();
            Rooms = new ToolStripMenuItem();
            Services = new ToolStripMenuItem();
            Reviews = new ToolStripMenuItem();
            Users = new ToolStripMenuItem();
            Reservations = new ToolStripMenuItem();
            MyReservations = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)profilePicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            formPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)roundPictureBox1).BeginInit();
            menu.SuspendLayout();
            SuspendLayout();
            // 
            // logoutButton
            // 
            resources.ApplyResources(logoutButton, "logoutButton");
            logoutButton.BackColor = Color.Red;
            logoutButton.Name = "logoutButton";
            logoutButton.UseVisualStyleBackColor = false;
            logoutButton.Click += logoutButton_Click;
            // 
            // saveButton
            // 
            resources.ApplyResources(saveButton, "saveButton");
            saveButton.BackColor = Color.LightGreen;
            saveButton.Name = "saveButton";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click;
            // 
            // deleteButton
            // 
            resources.ApplyResources(deleteButton, "deleteButton");
            deleteButton.BackColor = Color.Red;
            deleteButton.Name = "deleteButton";
            deleteButton.UseVisualStyleBackColor = false;
            deleteButton.Click += deleteButton_Click;
            // 
            // navigationButton
            // 
            resources.ApplyResources(navigationButton, "navigationButton");
            navigationButton.BackColor = Color.DarkOrange;
            navigationButton.Name = "navigationButton";
            navigationButton.UseVisualStyleBackColor = false;
            navigationButton.Click += navigationButton_Click;
            // 
            // profilePicture
            // 
            resources.ApplyResources(profilePicture, "profilePicture");
            profilePicture.Name = "profilePicture";
            profilePicture.TabStop = false;
            // 
            // editButton
            // 
            resources.ApplyResources(editButton, "editButton");
            editButton.BackColor = Color.LightGray;
            editButton.Name = "editButton";
            editButton.UseVisualStyleBackColor = false;
            editButton.Click += editButton_Click;
            // 
            // uploadButton
            // 
            resources.ApplyResources(uploadButton, "uploadButton");
            uploadButton.Name = "uploadButton";
            uploadButton.UseVisualStyleBackColor = true;
            // 
            // ageField
            // 
            resources.ApplyResources(ageField, "ageField");
            ageField.BackColor = Color.LightGray;
            ageField.ForeColor = Color.DimGray;
            ageField.Name = "ageField";
            // 
            // ageLabel
            // 
            resources.ApplyResources(ageLabel, "ageLabel");
            ageLabel.BackColor = Color.Transparent;
            ageLabel.Name = "ageLabel";
            // 
            // emailField
            // 
            resources.ApplyResources(emailField, "emailField");
            emailField.BackColor = Color.LightGray;
            emailField.ForeColor = Color.DimGray;
            emailField.Name = "emailField";
            // 
            // emailLabel
            // 
            resources.ApplyResources(emailLabel, "emailLabel");
            emailLabel.BackColor = Color.Transparent;
            emailLabel.Name = "emailLabel";
            // 
            // passwordField
            // 
            resources.ApplyResources(passwordField, "passwordField");
            passwordField.BackColor = Color.LightGray;
            passwordField.ForeColor = Color.DimGray;
            passwordField.Name = "passwordField";
            // 
            // passwordLabel
            // 
            resources.ApplyResources(passwordLabel, "passwordLabel");
            passwordLabel.BackColor = Color.Transparent;
            passwordLabel.Name = "passwordLabel";
            // 
            // usernameField
            // 
            resources.ApplyResources(usernameField, "usernameField");
            usernameField.BackColor = Color.LightGray;
            usernameField.ForeColor = Color.DimGray;
            usernameField.Name = "usernameField";
            // 
            // usernameLabel
            // 
            resources.ApplyResources(usernameLabel, "usernameLabel");
            usernameLabel.BackColor = Color.Transparent;
            usernameLabel.Name = "usernameLabel";
            // 
            // logo
            // 
            resources.ApplyResources(logo, "logo");
            logo.BackColor = Color.Transparent;
            logo.BackgroundImage = Prisma_studio.Properties.Resources.logo;
            logo.Name = "logo";
            logo.TabStop = false;
            // 
            // profileLabel
            // 
            resources.ApplyResources(profileLabel, "profileLabel");
            profileLabel.BackColor = Color.Transparent;
            profileLabel.Name = "profileLabel";
            // 
            // formPanel
            // 
            resources.ApplyResources(formPanel, "formPanel");
            formPanel.BackColor = SystemColors.Control;
            formPanel.BackgroundImage = Prisma_studio.Properties.Resources.gradient_img__4_;
            formPanel.Controls.Add(pfpErrors);
            formPanel.Controls.Add(emailErrors);
            formPanel.Controls.Add(passwordErrors);
            formPanel.Controls.Add(usernameErrors);
            formPanel.Controls.Add(logoutButton);
            formPanel.Controls.Add(saveButton);
            formPanel.Controls.Add(deleteButton);
            formPanel.Controls.Add(navigationButton);
            formPanel.Controls.Add(profilePicture);
            formPanel.Controls.Add(editButton);
            formPanel.Controls.Add(uploadButton);
            formPanel.Controls.Add(ageField);
            formPanel.Controls.Add(ageLabel);
            formPanel.Controls.Add(emailField);
            formPanel.Controls.Add(emailLabel);
            formPanel.Controls.Add(passwordField);
            formPanel.Controls.Add(passwordLabel);
            formPanel.Controls.Add(usernameField);
            formPanel.Controls.Add(usernameLabel);
            formPanel.Controls.Add(logo);
            formPanel.Controls.Add(profileLabel);
            formPanel.Name = "formPanel";
            // 
            // pfpErrors
            // 
            resources.ApplyResources(pfpErrors, "pfpErrors");
            pfpErrors.BackColor = Color.Transparent;
            pfpErrors.ForeColor = Color.Red;
            pfpErrors.Name = "pfpErrors";
            // 
            // emailErrors
            // 
            resources.ApplyResources(emailErrors, "emailErrors");
            emailErrors.BackColor = Color.Transparent;
            emailErrors.ForeColor = Color.Red;
            emailErrors.Name = "emailErrors";
            // 
            // passwordErrors
            // 
            resources.ApplyResources(passwordErrors, "passwordErrors");
            passwordErrors.BackColor = Color.Transparent;
            passwordErrors.ForeColor = Color.Red;
            passwordErrors.Name = "passwordErrors";
            // 
            // usernameErrors
            // 
            resources.ApplyResources(usernameErrors, "usernameErrors");
            usernameErrors.BackColor = Color.Transparent;
            usernameErrors.ForeColor = Color.Red;
            usernameErrors.Name = "usernameErrors";
            // 
            // roundPictureBox1
            // 
            resources.ApplyResources(roundPictureBox1, "roundPictureBox1");
            roundPictureBox1.Name = "roundPictureBox1";
            roundPictureBox1.TabStop = false;
            roundPictureBox1.Click += roundPictureBox1_Click;
            // 
            // menu
            // 
            resources.ApplyResources(menu, "menu");
            menu.BackColor = SystemColors.ScrollBar;
            menu.ImageScalingSize = new Size(20, 20);
            menu.Items.AddRange(new ToolStripItem[] { Home, Rooms, Services, Reviews, Users, Reservations, MyReservations });
            menu.Name = "menu";
            // 
            // Home
            // 
            resources.ApplyResources(Home, "Home");
            Home.Name = "Home";
            Home.Click += menu_ItemClicked;
            // 
            // Rooms
            // 
            resources.ApplyResources(Rooms, "Rooms");
            Rooms.ForeColor = SystemColors.ActiveCaptionText;
            Rooms.Name = "Rooms";
            Rooms.Padding = new Padding(4, 0, 4, 5);
            Rooms.Click += menu_ItemClicked;
            // 
            // Services
            // 
            resources.ApplyResources(Services, "Services");
            Services.ForeColor = SystemColors.ActiveCaptionText;
            Services.Name = "Services";
            Services.Padding = new Padding(4, 0, 4, 5);
            Services.Click += menu_ItemClicked;
            // 
            // Reviews
            // 
            resources.ApplyResources(Reviews, "Reviews");
            Reviews.ForeColor = SystemColors.ActiveCaptionText;
            Reviews.Name = "Reviews";
            Reviews.Padding = new Padding(4, 0, 4, 5);
            Reviews.Click += menu_ItemClicked;
            // 
            // Users
            // 
            resources.ApplyResources(Users, "Users");
            Users.ForeColor = SystemColors.MenuText;
            Users.Name = "Users";
            Users.Padding = new Padding(4, 0, 4, 5);
            Users.Click += menu_ItemClicked;
            // 
            // Reservations
            // 
            resources.ApplyResources(Reservations, "Reservations");
            Reservations.Name = "Reservations";
            Reservations.Padding = new Padding(0);
            Reservations.Click += menu_ItemClicked;
            // 
            // MyReservations
            // 
            resources.ApplyResources(MyReservations, "MyReservations");
            MyReservations.ForeColor = SystemColors.ActiveCaptionText;
            MyReservations.Name = "MyReservations";
            MyReservations.Padding = new Padding(0, 0, 0, 5);
            MyReservations.Click += menu_ItemClicked;
            // 
            // Profile
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Prisma_studio.Properties.Resources.appbackground;
            Controls.Add(roundPictureBox1);
            Controls.Add(menu);
            Controls.Add(formPanel);
            Name = "Profile";
            Load += Profile_Load;
            ((System.ComponentModel.ISupportInitialize)profilePicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            formPanel.ResumeLayout(false);
            formPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)roundPictureBox1).EndInit();
            menu.ResumeLayout(false);
            menu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button logoutButton;
        private Button saveButton;
        private Button deleteButton;
        private Button navigationButton;
        private Prisma_studio.Utilities.RoundPictureBox profilePicture;
        private Button editButton;
        private Button uploadButton;
        private TextBox ageField;
        private Label ageLabel;
        private TextBox emailField;
        private Label emailLabel;
        private TextBox passwordField;
        private Label passwordLabel;
        private TextBox usernameField;
        private Label usernameLabel;
        private PictureBox logo;
        private Label profileLabel;
        private Panel formPanel;
        private Label pfpErrors;
        private Label emailErrors;
        private Label passwordErrors;
        private Label usernameErrors;
        private Prisma_studio.Utilities.RoundPictureBox roundPictureBox1;
        private MenuStrip menu;
        private ToolStripMenuItem Home;
        private ToolStripMenuItem Rooms;
        private ToolStripMenuItem Services;
        private ToolStripMenuItem Reviews;
        private ToolStripMenuItem Users;
        private ToolStripMenuItem Reservations;
        private ToolStripMenuItem MyReservations;
    }
}