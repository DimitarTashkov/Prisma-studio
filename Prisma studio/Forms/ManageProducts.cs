using Prisma_studio.Data.Models;
using Prisma_studio.Extensions;
using Prisma_studio.Services.Interfaces;
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
    public partial class ManageProducts : Form
    {
        private readonly IShopService _shopService;

        // Тук пазим ID-то на продукта, който редактираме в момента.
        // Ако е null => значи правим НОВ продукт.
        private Guid? _selectedProductId = null;
        private string _selectedImagePath = null; // Пазим пътя до новата снимка
        private readonly IUserService _userService;

        public ManageProducts(IShopService shopService)
        {
            InitializeComponent();
            _shopService = shopService;
            _userService = ServiceLocator.GetService<IUserService>();
        }
        private void LoadGrid()
        {
            var products = _shopService.GetAllProducts();

            // Мапваме към Grid-а
            dgvProducts.DataSource = products.Select(p => new
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Quantity = p.StockQuantity
            }).ToList();

            // Скриваме ID колоната, че е грозна
            if (dgvProducts.Columns["Id"] != null)
                dgvProducts.Columns["Id"].Visible = false;
        }

        // --- ЛОГИКА ЗА ИЗБОР ОТ ТАБЛИЦАТА ---

        // Свържи това събитие със SelectionChanged на грида!
        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                // Взимаме ID-то от скритата колона или от обекта
                var selectedId = (Guid)dgvProducts.SelectedRows[0].Cells["Id"].Value;

                // Дърпаме целия продукт от базата
                var product = _shopService.GetProductById(selectedId);
                FillForm(product);
            }
        }

        private void FillForm(Product product)
        {
            _selectedProductId = product.Id; // Влизаме в режим РЕДАКЦИЯ

            txtName.Text = product.Name;
            numPrice.Value = product.Price;
            numStock.Value = product.StockQuantity;
            txtDescription.Text = product.Description;

            // Зареждане на снимка
            if (!string.IsNullOrEmpty(product.ImageUrl) && File.Exists(product.ImageUrl))
            {
                pbImage.Image = Image.FromFile(product.ImageUrl);
                _selectedImagePath = product.ImageUrl;
            }
            else
            {
                pbImage.Image = null;
                _selectedImagePath = null;
            }
        }

        // --- БУТОНИ ---

        private void btnNew_Click(object sender, EventArgs e)
        {
            // Изчистваме всичко, за да въведем нов продукт
            _selectedProductId = null; // Влизаме в режим СЪЗДАВАНЕ
            _selectedImagePath = null;

            txtName.Text = "";
            txtDescription.Text = "";
            numPrice.Value = 0;
            numStock.Value = 0;
            pbImage.Image = null;

            // Махаме селекцията от грида
            dgvProducts.ClearSelection();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Показваме я временно
                    pbImage.Image = Image.FromFile(ofd.FileName);
                    // Запомняме откъде идва файла, за да го копираме после при Save
                    _selectedImagePath = ofd.FileName;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Валидация
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Product Name is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Обработка на снимката (Копиране в папка Images)
            string finalImagePath = _selectedImagePath;

            // Ако е избрана нова снимка, копираме я в папка на приложението
            if (_selectedImagePath != null && !_selectedImagePath.Contains("PhotosStorage"))
            {
                string storageFolder = Path.Combine(Application.StartupPath, "PhotosStorage");
                if (!Directory.Exists(storageFolder)) Directory.CreateDirectory(storageFolder);

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(_selectedImagePath);
                string destPath = Path.Combine(storageFolder, fileName);

                File.Copy(_selectedImagePath, destPath, true);
                finalImagePath = destPath;
            }

            try
            {
                if (_selectedProductId == null)
                {
                    // --- CREATE (НОВ) ---
                    var newProduct = new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = txtName.Text,
                        Price = numPrice.Value,
                        StockQuantity = (int)numStock.Value,
                        Description = txtDescription.Text,
                        ImageUrl = finalImagePath
                    };
                    _shopService.AddProduct(newProduct);
                    MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // --- UPDATE (РЕДАКЦИЯ) ---
                    var productToUpdate = new Product
                    {
                        Id = _selectedProductId.Value,
                        Name = txtName.Text,
                        Price = numPrice.Value,
                        StockQuantity = (int)numStock.Value,
                        Description = txtDescription.Text,
                        ImageUrl = finalImagePath
                    };
                    _shopService.UpdateProduct(productToUpdate);
                    MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadGrid(); // Обновяваме таблицата
                btnNew.PerformClick(); // Чистим полетата
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedProductId == null) return;

            var res = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                _shopService.DeleteProduct(_selectedProductId.Value);
                LoadGrid();
                btnNew.PerformClick();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var main = new Index(_userService); // Връщаме се
            Program.SwitchMainForm(main);
        }
    }
}
