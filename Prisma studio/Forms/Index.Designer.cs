namespace Prisma_studio.Forms
{
    partial class Index
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Index));
            footer = new Button();
            serviceButton = new Button();
            roomsButton = new Button();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            menu = new MenuStrip();
            Home = new ToolStripMenuItem();
            Store = new ToolStripMenuItem();
            Services = new ToolStripMenuItem();
            Reviews = new ToolStripMenuItem();
            Users = new ToolStripMenuItem();
            Reservations = new ToolStripMenuItem();
            MyReservations = new ToolStripMenuItem();
            aboutUs = new Label();
            contactUs = new Label();
            welcomeMessage = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menu.SuspendLayout();
            SuspendLayout();
            // 
            // footer
            // 
            footer.BackColor = Color.Transparent;
            resources.ApplyResources(footer, "footer");
            footer.Name = "footer";
            footer.UseVisualStyleBackColor = false;
            // 
            // serviceButton
            // 
            serviceButton.BackColor = SystemColors.ButtonFace;
            resources.ApplyResources(serviceButton, "serviceButton");
            serviceButton.Name = "serviceButton";
            serviceButton.UseVisualStyleBackColor = false;
            serviceButton.Click += servicesButton_Click;
            // 
            // roomsButton
            // 
            roomsButton.BackColor = SystemColors.ButtonFace;
            resources.ApplyResources(roomsButton, "roomsButton");
            roomsButton.Name = "roomsButton";
            roomsButton.UseVisualStyleBackColor = false;
            roomsButton.Click += roomsButton_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.photography;
            resources.ApplyResources(pictureBox2, "pictureBox2");
            pictureBox2.Name = "pictureBox2";
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.store;
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // menu
            // 
            menu.BackColor = SystemColors.ScrollBar;
            resources.ApplyResources(menu, "menu");
            menu.ImageScalingSize = new Size(20, 20);
            menu.Items.AddRange(new ToolStripItem[] { Home, Store, Services, Reviews, Users, Reservations, MyReservations });
            menu.Name = "menu";
            // 
            // Home
            // 
            Home.Name = "Home";
            resources.ApplyResources(Home, "Home");
            Home.Click += menu_ItemClicked;
            // 
            // Store
            // 
            Store.ForeColor = SystemColors.ActiveCaptionText;
            Store.Name = "Store";
            Store.Padding = new Padding(4, 0, 4, 5);
            resources.ApplyResources(Store, "Store");
            Store.Click += menu_ItemClicked;
            // 
            // Services
            // 
            Services.ForeColor = SystemColors.ActiveCaptionText;
            Services.Name = "Services";
            Services.Padding = new Padding(4, 0, 4, 5);
            resources.ApplyResources(Services, "Services");
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
            Reservations.Click += menu_ItemClicked;
            // 
            // MyReservations
            // 
            resources.ApplyResources(MyReservations, "MyReservations");
            MyReservations.ForeColor = SystemColors.ActiveCaptionText;
            MyReservations.Name = "MyReservations";
            MyReservations.Padding = new Padding(4, 0, 4, 5);
            MyReservations.Click += menu_ItemClicked;
            // 
            // aboutUs
            // 
            resources.ApplyResources(aboutUs, "aboutUs");
            aboutUs.BackColor = Color.Transparent;
            aboutUs.ForeColor = Color.White;
            aboutUs.Name = "aboutUs";
            aboutUs.Click += aboutUs_Click;
            // 
            // contactUs
            // 
            resources.ApplyResources(contactUs, "contactUs");
            contactUs.BackColor = Color.Transparent;
            contactUs.ForeColor = Color.White;
            contactUs.Name = "contactUs";
            contactUs.Click += contactUs_Click;
            // 
            // welcomeMessage
            // 
            welcomeMessage.BackColor = Color.Transparent;
            resources.ApplyResources(welcomeMessage, "welcomeMessage");
            welcomeMessage.Name = "welcomeMessage";
            // 
            // Index
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.gradient_img__4_;
            Controls.Add(welcomeMessage);
            Controls.Add(contactUs);
            Controls.Add(aboutUs);
            Controls.Add(footer);
            Controls.Add(serviceButton);
            Controls.Add(roomsButton);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(menu);
            DoubleBuffered = true;
            Name = "Index";
            Load += Index_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menu.ResumeLayout(false);
            menu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button footer;
        private Button serviceButton;
        private Button roomsButton;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private MenuStrip menu;
        private ToolStripMenuItem Store;
        private ToolStripMenuItem Services;
        private ToolStripMenuItem Reviews;
        private ToolStripMenuItem Users;
        private ToolStripMenuItem MyReservations;
        private ToolStripMenuItem Reservations;
        private ToolStripMenuItem Home;
        private Label aboutUs;
        private Label contactUs;
        private Label welcomeMessage;
    }
}