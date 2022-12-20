using Models.Enums;
using BusinessLogicLayer.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models.Entities;

namespace RobertHeinDesktop
{
    public partial class AddProduct : Form
    {
        bool editMode = false;
        Product Product;
        string ProductName;
        float ProductPrice;
        int ProductStock;
        Units ProductUnit;
        string UnitExtension;
        byte[] ProductImage;

        private ProductManager PM;
        private CategoryManager CM;
        
        public AddProduct(ProductManager pm, CategoryManager cm, Product? product = null)
        {
            InitializeComponent();
            PM = pm;
            CM = cm;
            if (product != null)
            {
                Product = product;
                editMode = true;
                ProductName = product.Name;
                ProductPrice = product.Price;
                ProductStock = product.Stock;
                ProductUnit = product.Unit;
                UnitExtension = product.UnitExtension;
                ProductImage = product.Image;
                
            }
        }
        private void AddProduct_Load(object sender, EventArgs e)
        {
            cbCategory.DataSource = CM.GetAllCategories();
            cbCategory.DisplayMember = "Name";
            cbCategory.ValueMember = "Id";
            cbUnit.DataSource = Enum.GetValues(typeof(Units));

            if (editMode)
            {
                tbProductName.Text = ProductName;
                nudPrice.Value = (decimal)ProductPrice;
                nudAmountInStock.Value = ProductStock;
                cbUnit.SelectedItem = ProductUnit;
                tbUnitExtension.Text = UnitExtension;
                pbProductImage.Image = Image.FromStream(new System.IO.MemoryStream(ProductImage));
                btnAdd.Text = "Save";
            }
        }

        

        private void pbProductImage_Click(object sender, EventArgs e)
        {
            //select image from file
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pbProductImage.Image = new Bitmap(open.FileName);
                ProductImage = System.IO.File.ReadAllBytes(open.FileName);
            }
            
        }

        private void cbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if selected item is Kilogram or Gram, then set the tbUnitExtension to enabled
            if (cbUnit.SelectedItem.ToString() == "Kilogram" || cbUnit.SelectedItem.ToString() == "Gram")
            {
                tbUnitExtension.Enabled = true;
            }
            else
            {
                tbUnitExtension.Enabled = false;
                tbUnitExtension.Text = "";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (editMode)
            {
                var result = MessageBox.Show("Are you sure you want to cancel?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                var result = MessageBox.Show("Are you sure you want to cancel?\n(Clicking 'No' will clear the form)", "Cancel", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
                else if (result == DialogResult.No)
                {
                    tbProductName.Text = "";
                    cbCategory.SelectedIndex = 0;
                    nudPrice.Value = (decimal)0.01;
                    nudAmountInStock.Value = 0;
                    cbUnit.SelectedIndex = 0;
                    tbUnitExtension.Text = "";
                    pbProductImage.Image = null;
                }
            }
            
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductName = tbProductName.Text; 
            ProductPrice = (float)nudPrice.Value;
            ProductStock = (int)nudAmountInStock.Value;
            ProductUnit = (Units)cbUnit.SelectedItem;
            UnitExtension = tbUnitExtension.Text;
            Category category = cbCategory.SelectedItem as Category;
            if (editMode)
            {
                    
                Product.Name = ProductName;
                Product.Category = category;
                Product.Price = ProductPrice;
                Product.Unit = ProductUnit;
                if (!String.IsNullOrEmpty(UnitExtension))
                {
                    Product.UnitExtension = UnitExtension;
                }
                Product.Image = ProductImage;

                PM.UpdateProduct(Product);
                var result = MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {

                
                if (String.IsNullOrEmpty(UnitExtension))
                {
                    Product product = new Product(category, ProductName, ProductPrice, ProductStock, ProductUnit, ProductImage, false);
                    PM.AddProduct(product);
                    var result = MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
                else
                {
                    Product product = new Product(category, ProductName, ProductPrice, ProductStock, ProductUnit, UnitExtension, ProductImage, false);
                    PM.AddProduct(product);
                    var result = MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
            }
        }
    }
}
