namespace Prisma_studio.Forms
{
    partial class ManageServices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageServices));
            btnBack = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            btnNew = new Button();
            pictureBox1 = new PictureBox();
            pbImage = new Button();
            txtDescription = new TextBox();
            label5 = new Label();
            numDuration = new NumericUpDown();
            label4 = new Label();
            numPrice = new NumericUpDown();
            label3 = new Label();
            txtName = new TextBox();
            label1 = new Label();
            MyReservations = new ToolStripMenuItem();
            Reservations = new ToolStripMenuItem();
            Users = new ToolStripMenuItem();
            Reviews = new ToolStripMenuItem();
            Services = new ToolStripMenuItem();
            Store = new ToolStripMenuItem();
            Home = new ToolStripMenuItem();
            label2 = new Label();
            menu = new MenuStrip();
            dgvServices = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDuration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServices).BeginInit();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Orange;
            btnBack.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = SystemColors.ControlText;
            btnBack.Location = new Point(870, 500);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 40);
            btnBack.TabIndex = 44;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(752, 500);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 40);
            btnDelete.TabIndex = 43;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Lime;
            btnSave.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(633, 500);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 40);
            btnSave.TabIndex = 42;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnNew
            // 
            btnNew.BackColor = SystemColors.ActiveBorder;
            btnNew.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNew.Location = new Point(517, 500);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(100, 40);
            btnNew.TabIndex = 41;
            btnNew.Text = "Clear/New";
            btnNew.UseVisualStyleBackColor = false;
            btnNew.Click += btnNew_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(783, 112);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 150);
            pictureBox1.TabIndex = 40;
            pictureBox1.TabStop = false;
            // 
            // pbImage
            // 
            pbImage.BackColor = SystemColors.ActiveBorder;
            pbImage.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            pbImage.ImeMode = ImeMode.NoControl;
            pbImage.Location = new Point(783, 300);
            pbImage.Margin = new Padding(3, 4, 3, 4);
            pbImage.Name = "pbImage";
            pbImage.Size = new Size(154, 34);
            pbImage.TabIndex = 39;
            pbImage.Text = "Upload image";
            pbImage.UseVisualStyleBackColor = false;
            pbImage.Click += btnBrowse_Click;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(547, 371);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(405, 91);
            txtDescription.TabIndex = 38;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(574, 328);
            label5.Name = "label5";
            label5.Size = new Size(120, 28);
            label5.TabIndex = 37;
            label5.Text = "Description:";
            // 
            // numDuration
            // 
            numDuration.Location = new Point(546, 284);
            numDuration.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numDuration.Name = "numDuration";
            numDuration.Size = new Size(150, 27);
            numDuration.TabIndex = 36;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(574, 253);
            label4.Name = "label4";
            label4.Size = new Size(96, 28);
            label4.TabIndex = 35;
            label4.Text = "Duration:";
            // 
            // numPrice
            // 
            numPrice.DecimalPlaces = 2;
            numPrice.Location = new Point(546, 209);
            numPrice.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(150, 27);
            numPrice.TabIndex = 34;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(587, 178);
            label3.Name = "label3";
            label3.Size = new Size(61, 28);
            label3.TabIndex = 33;
            label3.Text = "Price:";
            // 
            // txtName
            // 
            txtName.Location = new Point(547, 133);
            txtName.Name = "txtName";
            txtName.Size = new Size(149, 27);
            txtName.TabIndex = 32;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(587, 102);
            label1.Name = "label1";
            label1.Size = new Size(71, 28);
            label1.TabIndex = 30;
            label1.Text = "Name:";
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
            // Reservations
            // 
            Reservations.Font = new Font("Verdana", 12F, FontStyle.Bold);
            Reservations.Name = "Reservations";
            Reservations.Size = new Size(172, 34);
            Reservations.Text = "Reservations";
            Reservations.Visible = false;
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
            // Services
            // 
            Services.ForeColor = SystemColors.ActiveCaptionText;
            Services.Name = "Services";
            Services.Padding = new Padding(4, 0, 4, 5);
            Services.Size = new Size(118, 34);
            Services.Text = "Services";
            // 
            // Store
            // 
            Store.ForeColor = SystemColors.ActiveCaptionText;
            Store.Name = "Store";
            Store.Padding = new Padding(4, 0, 4, 5);
            Store.Size = new Size(84, 34);
            Store.Text = "Store";
            // 
            // Home
            // 
            Home.Name = "Home";
            Home.Size = new Size(91, 34);
            Home.Text = "Home";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(353, 43);
            label2.Name = "label2";
            label2.Size = new Size(293, 38);
            label2.TabIndex = 31;
            label2.Text = "Service management";
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
            menu.Size = new Size(982, 42);
            menu.TabIndex = 29;
            menu.Text = "Menu";
            // 
            // dgvServices
            // 
            dgvServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServices.Location = new Point(0, 102);
            dgvServices.MultiSelect = false;
            dgvServices.Name = "dgvServices";
            dgvServices.ReadOnly = true;
            dgvServices.RowHeadersWidth = 51;
            dgvServices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServices.Size = new Size(500, 450);
            dgvServices.TabIndex = 28;
            dgvServices.SelectionChanged += dgvServices_SelectionChanged;
            // 
            // ManageServices
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.appbackground;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(982, 553);
            Controls.Add(btnBack);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(btnNew);
            Controls.Add(pictureBox1);
            Controls.Add(pbImage);
            Controls.Add(txtDescription);
            Controls.Add(label5);
            Controls.Add(numDuration);
            Controls.Add(label4);
            Controls.Add(numPrice);
            Controls.Add(label3);
            Controls.Add(txtName);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(menu);
            Controls.Add(dgvServices);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ManageServices";
            Text = "ManageServices";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDuration).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            menu.ResumeLayout(false);
            menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServices).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private Button btnDelete;
        private Button btnSave;
        private Button btnNew;
        private PictureBox pictureBox1;
        private Button pbImage;
        private TextBox txtDescription;
        private Label label5;
        private NumericUpDown numDuration;
        private Label label4;
        private NumericUpDown numPrice;
        private Label label3;
        private TextBox txtName;
        private Label label1;
        private ToolStripMenuItem MyReservations;
        private ToolStripMenuItem Reservations;
        private ToolStripMenuItem Users;
        private ToolStripMenuItem Reviews;
        private ToolStripMenuItem Services;
        private ToolStripMenuItem Store;
        private ToolStripMenuItem Home;
        private Label label2;
        private MenuStrip menu;
        private DataGridView dgvServices;
    }
}