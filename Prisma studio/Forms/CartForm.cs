using Prisma_studio.Data.Models;
using Prisma_studio.Extensions;
using Prisma_studio.Models;
using Prisma_studio.Services;
using Prisma_studio.Services.Interfaces;
using Prisma_studio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prisma_studio.Forms
{
    public partial class CartForm : Form
    {
        private readonly IShopService shopService;
        private readonly IUserService userService; // Добавен, както поиска
        private readonly ISessionService sessionService;
        private readonly IPhotoServiceManager serviceManager;
        User? activeUser;

        public CartForm(IShopService shopService, IUserService userService)
        {
            InitializeComponent();
            this.shopService = shopService;

            // Настройки на UI
            // this.Text = "Вашата количка";

            LoadCartItems();
            this.userService = userService;
            activeUser = this.userService.GetLoggedInUserAsync();
            roundPictureBox1.ImageLocation = activeUser?.AvatarUrl;
            this.sessionService = ServiceLocator.GetService<ISessionService>();
            this.serviceManager = ServiceLocator.GetService<IPhotoServiceManager>();
        }

        private void CartForm_Load(object sender, EventArgs e)
        {
            bool isAdmin = AuthorizationHelper.IsAuthorized();

            if (isAdmin)
            {
                Users.Visible = true;
                Management.Visible = true;
            }
        }
        private void LoadCartItems()
        {
            flowPanelCart.Controls.Clear();
            decimal totalSum = 0;

            // Проверка дали количката е празна
            if (ShopForm.ShoppingCart.Count == 0)
            {
                Label lblEmpty = new Label();
                lblEmpty.Text = "Cart is empty.";
                lblEmpty.AutoSize = true;
                lblEmpty.Font = new Font("Segoe UI", 12, FontStyle.Italic);
                flowPanelCart.Controls.Add(lblEmpty);
                UpdateTotal(0);
                return;
            }

            // Обхождаме продуктите в количката
            foreach (var item in ShopForm.ShoppingCart)
            {
                Guid productId = item.Key;
                int quantity = item.Value;

                var product = shopService.GetProductById(productId);
                if (product != null)
                {
                    Panel row = CreateCartRow(product, quantity);
                    flowPanelCart.Controls.Add(row);

                    totalSum += (product.Price * quantity);
                }
            }

            UpdateTotal(totalSum);
        }

        private Panel CreateCartRow(Product product, int quantity)
        {
            // Ред в количката (панел)
            Panel panel = new Panel();
            panel.Size = new Size(550, 80); // Широк и нисък
            panel.BackColor = Color.White;
            panel.Margin = new Padding(5);
            panel.BorderStyle = BorderStyle.FixedSingle;

            // 1. Малка снимка
            PictureBox pb = new PictureBox();
            pb.Size = new Size(60, 60);
            pb.Location = new Point(10, 10);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            if (!string.IsNullOrEmpty(product.ImageUrl) && System.IO.File.Exists(product.ImageUrl))
            {
                pb.Image = Image.FromFile(product.ImageUrl);
            }
            else
            {
                pb.BackColor = Color.LightGray;
            }
            panel.Controls.Add(pb);

            // 2. Име
            Label lblName = new Label();
            lblName.Text = product.Name;
            lblName.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblName.Location = new Point(80, 20);
            lblName.AutoSize = true;
            panel.Controls.Add(lblName);

            // 3. Количество и Ед. цена
            Label lblQty = new Label();
            lblQty.Text = $"{quantity} бр. x {product.Price:F2} euro.";
            lblQty.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lblQty.Location = new Point(80, 45);
            lblQty.AutoSize = true;
            panel.Controls.Add(lblQty);

            // 4. Общо за реда
            Label lblRowTotal = new Label();
            lblRowTotal.Text = $"{(quantity * product.Price):F2} euro.";
            lblRowTotal.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblRowTotal.ForeColor = Color.Purple;
            lblRowTotal.Location = new Point(350, 30);
            lblRowTotal.AutoSize = true;
            panel.Controls.Add(lblRowTotal);

            // 5. Бутон за премахване (X)
            Button btnRemove = new Button();
            btnRemove.Text = "X";
            btnRemove.ForeColor = Color.Red;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Size = new Size(30, 30);
            btnRemove.Location = new Point(500, 25);

            btnRemove.Click += (s, e) =>
            {
                RemoveFromCart(product.Id);
            };

            panel.Controls.Add(btnRemove);

            return panel;
        }

        private void RemoveFromCart(Guid productId)
        {
            if (ShopForm.ShoppingCart.ContainsKey(productId))
            {
                ShopForm.ShoppingCart.Remove(productId);
                LoadCartItems(); // Презареждаме списъка
            }
        }

        private void UpdateTotal(decimal amount)
        {
            // Увери се, че имаш lblTotal в дизайнера
            lblTotal.Text = $"Total: {amount:F2} euro.";
            btnOrder.Enabled = amount > 0;
        }

        // --- ДЕЙСТВИЯ ---

        private void btnOrder_Click(object sender, EventArgs e)
        {
            try
            {

                // Проверка за всеки случай
                if (activeUser == null)
                {
                    MessageBox.Show("Not logged in, please log in!");
                    return;
                }

                // Извикваме сървиса да запише поръчката в базата
                // За адрес и телефон може да вземеш от User обекта или да сложиш TextBox-ове в тази форма
                if(textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Please enter delivery address and phone number.", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string address = textBox1.Text; // Може да сложиш txtAddress.Text
                string phone = textBox2.Text;

                Guid orderId = shopService.CreateOrder(activeUser.Id, ShopForm.ShoppingCart, address, phone);

                string invoiceText = GenerateInvoiceText(orderId, address, phone);

                ShopForm.ShoppingCart.Clear();
                MessageBox.Show(invoiceText, "Order receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // Връщаме се в магазина (или в профила)
                var shopForm = new ShopForm(shopService);
                Program.SwitchMainForm(shopForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in purchasing: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string GenerateInvoiceText(Guid orderId, string address, string phone)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("=================================");
            sb.AppendLine("       OFFICIAL INVOICE");
            sb.AppendLine("=================================");
            sb.AppendLine($"Order ID: {orderId}");
            sb.AppendLine($"Date: {DateTime.Now}");
            sb.AppendLine($"Client: {activeUser.Username}");
            sb.AppendLine($"Phone: {phone}");
            sb.AppendLine($"Address: {address}");
            sb.AppendLine("---------------------------------");
            sb.AppendLine("ITEMS PURCHASED:");
            sb.AppendLine("");

            decimal grandTotal = 0;

            foreach (var item in ShopForm.ShoppingCart)
            {
                var product = shopService.GetProductById(item.Key);
                if (product != null)
                {
                    decimal lineTotal = product.Price * item.Value;
                    grandTotal += lineTotal;

                    // Формат: Име (нов ред) Кол x Цена = Общо
                    sb.AppendLine($"• {product.Name}");
                    sb.AppendLine($"   {item.Value} x {product.Price:F2} BGN = {lineTotal:F2} BGN");
                }
            }

            sb.AppendLine("---------------------------------");
            sb.AppendLine($"TOTAL PAID: {grandTotal:F2} BGN");
            sb.AppendLine("=================================");
            sb.AppendLine("Thank you for shopping with us!");

            return sb.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Връщаме се обратно в Магазина, за да продължим пазаруването
            var shopForm = new ShopForm(shopService);
            Program.SwitchMainForm(shopForm);
        }
        private void menu_ItemClicked(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            string formName = item.Name;
            Form form = new Index(userService);

            switch (formName)
            {
                case "Store":
                    form = new ShopForm(shopService);
                    break;
                case "Services":
                    form = new BookSessionForm(sessionService, userService);
                    break;
                case "Profile":
                    form = new Profile(userService, activeUser.Id);
                    break;
                case "Users":
                    form = new Users(userService);
                    break;
                case "MyReservations":
                    form = new Orders(sessionService, shopService, userService);
                    break;
                case "manageProducts":
                    form = new ManageProducts(shopService);
                    break;
                case "manageServices":
                    form = new ManageServices(serviceManager);
                    break;
                case "Home":
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
