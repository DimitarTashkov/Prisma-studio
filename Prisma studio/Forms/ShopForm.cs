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
    public partial class ShopForm : Form
    {
        private readonly IShopService shopService;
        private readonly IUserService userService;
        private readonly ISessionService sessionService;
        private readonly IPhotoServiceManager serviceManager;
        private User? activeUser;

        // Виртуалната количка (пази ID на продукт и бройка)
        public static Dictionary<Guid, int> ShoppingCart = new Dictionary<Guid, int>();
        public ShopForm(IShopService shopService)
        {
            InitializeComponent();
            this.shopService = shopService;
            userService = ServiceLocator.GetService<IUserService>();
            sessionService = ServiceLocator.GetService<ISessionService>();
            serviceManager = ServiceLocator.GetService<IPhotoServiceManager>();
            activeUser = userService.GetLoggedInUserAsync();

            // Настройки на UI
            // Ако имаш lblTitle в дизайнера:
            // lblTitle.Text = "Магазин за фото аксесоари";

            UpdateCartButton();
            LoadProducts();
        }

        private void ShopForm_Load(object sender, EventArgs e)
        {
            bool isAdmin = AuthorizationHelper.IsAuthorized();

            if (isAdmin)
            {
                Users.Visible = true;
                Management.Visible = true;
            }
        }
        private void LoadProducts()
        {
            // Изчистваме старите контроли от flow панела
            flowPanelProducts.Controls.Clear();

            // Взимаме всички продукти
            var products = shopService.GetAllProducts();

            if (products.Count == 0)
            {
                Label lblEmpty = new Label();
                lblEmpty.Text = "Sorry, we are out of products for now.";
                lblEmpty.AutoSize = true;
                lblEmpty.Font = new Font("Segoe UI", 12, FontStyle.Italic);
                lblEmpty.ForeColor = Color.Gray;
                lblEmpty.Margin = new Padding(20);
                flowPanelProducts.Controls.Add(lblEmpty);
                return;
            }

            foreach (var product in products)
            {
                Panel productCard = CreateProductCard(product);
                flowPanelProducts.Controls.Add(productCard);
            }
        }

        private Panel CreateProductCard(Product product)
        {
            // --- Дизайн на картата (запазен от преди) ---
            Panel panel = new Panel();
            panel.Size = new Size(200, 300);
            panel.BackColor = Color.White;
            panel.Margin = new Padding(15);
            panel.BorderStyle = BorderStyle.FixedSingle;

            // Снимка
            PictureBox pb = new PictureBox();
            pb.Size = new Size(180, 150);
            pb.Location = new Point(10, 10);
            pb.SizeMode = PictureBoxSizeMode.Zoom;

            if (!string.IsNullOrEmpty(product.ImageUrl) && File.Exists(product.ImageUrl))
            {
                pb.Image = Image.FromFile(product.ImageUrl);
            }
            else
            {
                pb.BackColor = Color.LightGray;
            }
            panel.Controls.Add(pb);

            // Име
            Label lblName = new Label();
            lblName.Text = product.Name;
            lblName.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblName.Location = new Point(10, 170);
            lblName.AutoSize = true;
            lblName.MaximumSize = new Size(180, 40);
            panel.Controls.Add(lblName);

            // Цена
            Label lblPrice = new Label();
            lblPrice.Text = $"{product.Price:F2} euro.";
            lblPrice.ForeColor = Color.Purple;
            lblPrice.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblPrice.Location = new Point(10, 215);
            lblPrice.AutoSize = true;
            panel.Controls.Add(lblPrice);

            // Наличност
            Label lblStock = new Label();
            if (product.StockQuantity > 0)
            {
                lblStock.Text = $"Available: {product.StockQuantity} pc.";
                lblStock.ForeColor = Color.Green;
            }
            else
            {
                lblStock.Text = "Unavailable";
                lblStock.ForeColor = Color.Red;
                lblStock.Font = new Font(lblStock.Font, FontStyle.Bold);
            }
            lblStock.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            lblStock.Location = new Point(10, 240);
            lblStock.AutoSize = true;
            panel.Controls.Add(lblStock);

            // Бутон "Купи"
            Button btnBuy = new Button();
            btnBuy.Text = product.StockQuantity > 0 ? "Add" : "None";
            btnBuy.Enabled = product.StockQuantity > 0;
            btnBuy.BackColor = product.StockQuantity > 0 ? Color.Black : Color.Gray;
            btnBuy.ForeColor = Color.White;
            btnBuy.FlatStyle = FlatStyle.Flat;
            btnBuy.Size = new Size(180, 35);
            btnBuy.Location = new Point(10, 260);
            btnBuy.Cursor = Cursors.Hand;

            btnBuy.Click += (s, e) => {
                AddToCart(product);
            };

            panel.Controls.Add(btnBuy);

            return panel;
        }

        private void AddToCart(Product product)
        {
            int currentQuantityInCart = ShoppingCart.ContainsKey(product.Id) ? ShoppingCart[product.Id] : 0;

            if (currentQuantityInCart + 1 > product.StockQuantity)
            {
                MessageBox.Show("Insufficient quantity!", "Error");
                return;
            }

            if (ShoppingCart.ContainsKey(product.Id))
            {
                ShoppingCart[product.Id]++;
            }
            else
            {
                ShoppingCart.Add(product.Id, 1);
            }

            UpdateCartButton();
            MessageBox.Show($"{product.Name} added in cart!");
        }

        private void UpdateCartButton()
        {
            int totalItems = ShoppingCart.Values.Sum();
            btnCart.Text = $"Cart ({totalItems})";
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            if (ShoppingCart.Count == 0)
            {
                MessageBox.Show("Cart is empty.");
                return;
            }

            // Отиваме към CartForm
            // Подаваме същия сървис, за да има връзка с базата
            var cartForm = new CartForm(shopService,userService);
            Program.SwitchMainForm(cartForm);
        }
        private void menu_ItemClicked(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            string formName = item.Name;
            Form form;

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
