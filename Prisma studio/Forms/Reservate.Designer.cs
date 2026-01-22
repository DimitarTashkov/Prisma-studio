namespace HotelOazis.Forms
{
    partial class Reservate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reservate));
            formPanel = new Panel();
            checkOutDatePicker = new DateTimePicker();
            checkInDatePicker = new DateTimePicker();
            cancel = new Label();
            reservateBtn = new Button();
            toLabel = new Label();
            fromLabel = new Label();
            logo = new PictureBox();
            roundPictureBox1 = new Fitness.Utilities.RoundPictureBox();
            menu = new MenuStrip();
            Home = new ToolStripMenuItem();
            Rooms = new ToolStripMenuItem();
            Services = new ToolStripMenuItem();
            Reviews = new ToolStripMenuItem();
            Users = new ToolStripMenuItem();
            Reservations = new ToolStripMenuItem();
            MyReservations = new ToolStripMenuItem();
            formPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)roundPictureBox1).BeginInit();
            menu.SuspendLayout();
            SuspendLayout();
            // 
            // formPanel
            // 
            formPanel.BackColor = Color.White;
            resources.ApplyResources(formPanel, "formPanel");
            formPanel.Controls.Add(checkOutDatePicker);
            formPanel.Controls.Add(checkInDatePicker);
            formPanel.Controls.Add(cancel);
            formPanel.Controls.Add(reservateBtn);
            formPanel.Controls.Add(toLabel);
            formPanel.Controls.Add(fromLabel);
            formPanel.Controls.Add(logo);
            formPanel.Name = "formPanel";
            // 
            // checkOutDatePicker
            // 
            resources.ApplyResources(checkOutDatePicker, "checkOutDatePicker");
            checkOutDatePicker.Name = "checkOutDatePicker";
            // 
            // checkInDatePicker
            // 
            resources.ApplyResources(checkInDatePicker, "checkInDatePicker");
            checkInDatePicker.Name = "checkInDatePicker";
            // 
            // cancel
            // 
            resources.ApplyResources(cancel, "cancel");
            cancel.BackColor = Color.Transparent;
            cancel.Cursor = Cursors.Hand;
            cancel.ForeColor = Color.Blue;
            cancel.Name = "cancel";
            cancel.Click += cancel_Click;
            // 
            // reservateBtn
            // 
            reservateBtn.BackColor = Color.LightGreen;
            resources.ApplyResources(reservateBtn, "reservateBtn");
            reservateBtn.Name = "reservateBtn";
            reservateBtn.UseVisualStyleBackColor = false;
            reservateBtn.Click += reservateBtn_Click;
            // 
            // toLabel
            // 
            resources.ApplyResources(toLabel, "toLabel");
            toLabel.BackColor = Color.Transparent;
            toLabel.Name = "toLabel";
            // 
            // fromLabel
            // 
            resources.ApplyResources(fromLabel, "fromLabel");
            fromLabel.BackColor = Color.Transparent;
            fromLabel.Name = "fromLabel";
            // 
            // logo
            // 
            logo.BackColor = Color.Transparent;
            resources.ApplyResources(logo, "logo");
            logo.Name = "logo";
            logo.TabStop = false;
            // 
            // roundPictureBox1
            // 
            resources.ApplyResources(roundPictureBox1, "roundPictureBox1");
            roundPictureBox1.Name = "roundPictureBox1";
            roundPictureBox1.TabStop = false;
            // 
            // menu
            // 
            menu.BackColor = SystemColors.ScrollBar;
            resources.ApplyResources(menu, "menu");
            menu.Items.AddRange(new ToolStripItem[] { Home, Rooms, Services, Reviews, Users, Reservations, MyReservations });
            menu.Name = "menu";
            // 
            // Home
            // 
            Home.Name = "Home";
            resources.ApplyResources(Home, "Home");
            Home.Click += menu_ItemClicked;
            // 
            // Rooms
            // 
            Rooms.ForeColor = SystemColors.ActiveCaptionText;
            Rooms.Name = "Rooms";
            Rooms.Padding = new Padding(4, 0, 4, 5);
            resources.ApplyResources(Rooms, "Rooms");
            Rooms.Click += menu_ItemClicked;
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
            // Reservate
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(roundPictureBox1);
            Controls.Add(menu);
            Controls.Add(formPanel);
            Name = "Reservate";
            Load += Reservate_Load;
            formPanel.ResumeLayout(false);
            formPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ((System.ComponentModel.ISupportInitialize)roundPictureBox1).EndInit();
            menu.ResumeLayout(false);
            menu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel formPanel;
        private Label cancel;
        private Button reservateBtn;
        private Label toLabel;
        private Label fromLabel;
        private PictureBox logo;
        private DateTimePicker checkOutDatePicker;
        private DateTimePicker checkInDatePicker;
        private Fitness.Utilities.RoundPictureBox roundPictureBox1;
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