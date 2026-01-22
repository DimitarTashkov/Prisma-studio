namespace HotelOazis.Forms
{
    partial class Reservations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reservations));
            reservationsContainer = new FlowLayoutPanel();
            roundPictureBox1 = new Fitness.Utilities.RoundPictureBox();
            menu = new MenuStrip();
            Home = new ToolStripMenuItem();
            Rooms = new ToolStripMenuItem();
            Services = new ToolStripMenuItem();
            Reviews = new ToolStripMenuItem();
            Users = new ToolStripMenuItem();
            Reservation = new ToolStripMenuItem();
            MyReservations = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)roundPictureBox1).BeginInit();
            menu.SuspendLayout();
            SuspendLayout();
            // 
            // reservationsContainer
            // 
            resources.ApplyResources(reservationsContainer, "reservationsContainer");
            reservationsContainer.Name = "reservationsContainer";
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
            menu.Items.AddRange(new ToolStripItem[] { Home, Rooms, Services, Reviews, Users, Reservation, MyReservations });
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
            // Reservation
            // 
            resources.ApplyResources(Reservation, "Reservation");
            Reservation.Name = "Reservation";
            Reservation.Click += menu_ItemClicked;
            // 
            // MyReservations
            // 
            resources.ApplyResources(MyReservations, "MyReservations");
            MyReservations.ForeColor = SystemColors.ActiveCaptionText;
            MyReservations.Name = "MyReservations";
            MyReservations.Padding = new Padding(4, 0, 4, 5);
            MyReservations.Click += menu_ItemClicked;
            // 
            // Reservations
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(roundPictureBox1);
            Controls.Add(menu);
            Controls.Add(reservationsContainer);
            Name = "Reservations";
            Load += Reservations_Load;
            ((System.ComponentModel.ISupportInitialize)roundPictureBox1).EndInit();
            menu.ResumeLayout(false);
            menu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel reservationsContainer;
        private Fitness.Utilities.RoundPictureBox roundPictureBox1;
        private MenuStrip menu;
        private ToolStripMenuItem Home;
        private ToolStripMenuItem Rooms;
        private ToolStripMenuItem Services;
        private ToolStripMenuItem Reviews;
        private ToolStripMenuItem Users;
        private ToolStripMenuItem Reservation;
        private ToolStripMenuItem MyReservations;
    }
}