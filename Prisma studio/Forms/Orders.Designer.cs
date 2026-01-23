namespace Prisma_studio.Forms
{
    partial class Orders
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
            menu = new MenuStrip();
            Home = new ToolStripMenuItem();
            Store = new ToolStripMenuItem();
            Services = new ToolStripMenuItem();
            Reviews = new ToolStripMenuItem();
            Users = new ToolStripMenuItem();
            Reservations = new ToolStripMenuItem();
            MyReservations = new ToolStripMenuItem();
            tabHistory = new TabControl();
            tabPage1 = new TabPage();
            dgvSessions = new DataGridView();
            tabPage2 = new TabPage();
            dgvOrders = new DataGridView();
            btnBack = new Button();
            menu.SuspendLayout();
            tabHistory.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSessions).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            SuspendLayout();
            // 
            // menu
            // 
            menu.BackColor = SystemColors.ScrollBar;
            menu.BackgroundImageLayout = ImageLayout.Stretch;
            menu.Font = new Font("Verdana", 12F, FontStyle.Bold);
            menu.ImageScalingSize = new Size(20, 20);
            menu.Items.AddRange(new ToolStripItem[] { Home, Store, Services, Reviews, Users, Reservations, MyReservations });
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Padding = new Padding(7, 1, 0, 7);
            menu.Size = new Size(914, 42);
            menu.TabIndex = 12;
            menu.Text = "Menu";
            // 
            // Home
            // 
            Home.Name = "Home";
            Home.Size = new Size(91, 34);
            Home.Text = "Home";
            // 
            // Store
            // 
            Store.ForeColor = SystemColors.ActiveCaptionText;
            Store.Name = "Store";
            Store.Padding = new Padding(4, 0, 4, 5);
            Store.Size = new Size(84, 34);
            Store.Text = "Store";
            // 
            // Services
            // 
            Services.ForeColor = SystemColors.ActiveCaptionText;
            Services.Name = "Services";
            Services.Padding = new Padding(4, 0, 4, 5);
            Services.Size = new Size(118, 34);
            Services.Text = "Services";
            // 
            // Reviews
            // 
            Reviews.BackgroundImageLayout = ImageLayout.Center;
            Reviews.Font = new Font("Verdana", 12F, FontStyle.Bold);
            Reviews.ForeColor = SystemColors.ActiveCaptionText;
            Reviews.Name = "Reviews";
            Reviews.Padding = new Padding(4, 0, 4, 5);
            Reviews.Size = new Size(70, 34);
            Reviews.Text = "Cart";
            // 
            // Users
            // 
            Users.Font = new Font("Verdana", 12F, FontStyle.Bold);
            Users.ForeColor = SystemColors.MenuText;
            Users.Name = "Users";
            Users.Padding = new Padding(4, 0, 4, 5);
            Users.Size = new Size(87, 34);
            Users.Text = "Users";
            Users.Visible = false;
            // 
            // Reservations
            // 
            Reservations.Font = new Font("Verdana", 12F, FontStyle.Bold);
            Reservations.Name = "Reservations";
            Reservations.Size = new Size(172, 34);
            Reservations.Text = "Reservations";
            Reservations.Visible = false;
            // 
            // MyReservations
            // 
            MyReservations.Font = new Font("Verdana", 12F, FontStyle.Bold);
            MyReservations.ForeColor = SystemColors.ActiveCaptionText;
            MyReservations.Name = "MyReservations";
            MyReservations.Padding = new Padding(4, 0, 4, 5);
            MyReservations.Size = new Size(203, 34);
            MyReservations.Text = "My reservations";
            // 
            // tabHistory
            // 
            tabHistory.Controls.Add(tabPage1);
            tabHistory.Controls.Add(tabPage2);
            tabHistory.Location = new Point(0, 45);
            tabHistory.Name = "tabHistory";
            tabHistory.SelectedIndex = 0;
            tabHistory.Size = new Size(914, 520);
            tabHistory.TabIndex = 13;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgvSessions);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(906, 487);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "My Sessions";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvSessions
            // 
            dgvSessions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSessions.Dock = DockStyle.Fill;
            dgvSessions.Location = new Point(3, 3);
            dgvSessions.Name = "dgvSessions";
            dgvSessions.ReadOnly = true;
            dgvSessions.RowHeadersWidth = 51;
            dgvSessions.Size = new Size(900, 481);
            dgvSessions.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvOrders);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(906, 487);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "My Orders";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvOrders
            // 
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Dock = DockStyle.Fill;
            dgvOrders.Location = new Point(3, 3);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersWidth = 51;
            dgvOrders.Size = new Size(900, 481);
            dgvOrders.TabIndex = 0;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.DarkOrange;
            btnBack.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = SystemColors.ControlText;
            btnBack.Location = new Point(12, 571);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 25;
            btnBack.Text = "<-Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // Orders
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.appbackground;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(914, 600);
            Controls.Add(btnBack);
            Controls.Add(tabHistory);
            Controls.Add(menu);
            DoubleBuffered = true;
            Name = "Orders";
            Text = "Orders";
            menu.ResumeLayout(false);
            menu.PerformLayout();
            tabHistory.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSessions).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menu;
        private ToolStripMenuItem Home;
        private ToolStripMenuItem Store;
        private ToolStripMenuItem Services;
        private ToolStripMenuItem Reviews;
        private ToolStripMenuItem Users;
        private ToolStripMenuItem Reservations;
        private ToolStripMenuItem MyReservations;
        private TabControl tabHistory;
        private TabPage tabPage1;
        private DataGridView dgvSessions;
        private TabPage tabPage2;
        private DataGridView dgvOrders;
        private Button btnBack;
    }
}