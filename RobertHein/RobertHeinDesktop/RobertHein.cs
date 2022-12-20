using DataAccessLayer.Production;
using Models.Managers;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models.Entities;
using Models.Entities.Bonus;
using Models.Enums;

namespace RobertHeinDesktop
{
    public partial class RobertHein : Form
    {
        private ProductManager _productManager = new ProductManager(new ProductRepository());
        private CategoryManager _categoryManager = new CategoryManager(new CategoryRepository());
        private BonusManager _bonusManager = new BonusManager(new BonusRepository());
        private BonusCardManager _bonusCardManager = new BonusCardManager(new BonusCardRepository());
        private CustomerManager _customerManager = new CustomerManager(new CustomerRepository());
        private OrderManager _orderManager;

        private DataTable _productTable = new DataTable();
        private DataTable _bonusTable = new DataTable();
        public RobertHein()
        {
            InitializeComponent();
            _orderManager = new OrderManager(new OrderRepository(), _productManager.GetAll(), _customerManager.GetCustomers(), _bonusCardManager.GetAllBonusCards());


        }
        
        public void ProductDataTableMaker(string category = "All")
        {
            _productTable.Clear();
            _productTable.Columns.Clear();
            bool onlyActive = cbActiveItems.Checked;
            var productSource = new BindingSource();
            ImageConverter converter = new ImageConverter();
            
            
            _productTable.Columns.Add("ID", typeof(int));
            _productTable.Columns.Add("Name", typeof(string));
            _productTable.Columns.Add("Category", typeof(string));
            _productTable.Columns.Add("Price (€)", typeof(float));
            _productTable.Columns.Add("Quantity in stock", typeof(int));
            _productTable.Columns.Add("Units",typeof(string));
            _productTable.Columns.Add("Unit Description", typeof(string));
            _productTable.Columns.Add("Image", typeof(Image));
            _productTable.Columns.Add("Discontinued", typeof(bool));

            if (category == "All")
            {
                foreach (var product in _productManager.GetAll(onlyActive))
                {
                    Image image = (Image)converter.ConvertFrom(product.Image);
                    _productTable.Rows.Add(product.Id, product.Name, product.Category.Name, product.Price, product.Stock,
                        product.Unit.ToString(), product.UnitExtension, image, product.IsDiscontinued);
                }
            }
            else
            {
                foreach (var product in _productManager.GetAll(onlyActive))
                {
                    if (product.Category.Name == category)
                    {
                        Image image = (Image)converter.ConvertFrom(product.Image);
                        _productTable.Rows.Add(product.Id, product.Name, product.Category.Name, product.Price, product.Stock, product.Unit.ToString(), product.UnitExtension, image, product.IsDiscontinued);
                    }
                }
            }

            productSource.DataSource = _productTable;
            dgvProducts.DataSource = productSource;

            dgvBonus.DataSource = productSource;
        }

        public void CategoryCbLoad()
        {
            cbProductCategories.Items.Add("All");
            foreach (var cat in _categoryManager.GetAllCategories())
            {
                cbProductCategories.Items.Add(cat.Name.Trim());
            }
            cbProductCategories.SelectedIndex = 0;
        }

        public void BonusDataTableMaker(string type = "All")
        {
            bool onlyActive = cbActiveBonuses.Checked;
            var bonusSource = new BindingSource();
            
            _bonusTable.Clear();
            _bonusTable.Columns.Clear();
            
            _bonusTable.Columns.Add("ID", typeof(int));
            _bonusTable.Columns.Add("Name", typeof(string));
            _bonusTable.Columns.Add("Category", typeof(string));
            _bonusTable.Columns.Add("Quantity in stock", typeof(int));
            _bonusTable.Columns.Add("Start Date", typeof(DateOnly));
            _bonusTable.Columns.Add("End Date", typeof(DateOnly));
            _bonusTable.Columns.Add("Price (€)",typeof(float));
            _bonusTable.Columns.Add("Percentage", typeof(float));
            _bonusTable.Columns.Add("Quantity", typeof(double));
            _bonusTable.Columns.Add("Second Half Price", typeof(bool));
            _bonusTable.Columns.Add("Number of items", typeof(int));

            foreach (var bonus in _bonusManager.GetBonuses())
            {
                
                if (onlyActive)
                {
                    if(bonus.StartDate <= DateOnly.Parse(DateTime.Now.ToShortDateString()) && bonus.EndDate >= DateOnly.Parse(DateTime.Now.ToShortDateString()))
                    {
                        if (type == "All")
                        {

                            switch (bonus.GetType())
                            {
                                case var _ when bonus.GetType() == typeof(PercentageDiscount):
                                    _bonusTable.Rows.Add(bonus.Id, bonus.Product.Name, bonus.Product.Category.Name,
                                        bonus.Product.Stock, bonus.StartDate, bonus.EndDate, bonus.Price,
                                        ((PercentageDiscount)bonus).Percentage, 0, false, 0);
                                    break;
                                case var _ when bonus.GetType() == typeof(QuantityDiscount):
                                    _bonusTable.Rows.Add(bonus.Id, bonus.Product.Name, bonus.Product.Category.Name,
                                        bonus.Product.Stock, bonus.StartDate, bonus.EndDate, bonus.Price, 0,
                                        ((QuantityDiscount)bonus).Quantity, false, 0);
                                    break;
                                case var _ when bonus.GetType() == typeof(SecondHalfPrice):
                                    _bonusTable.Rows.Add(bonus.Id, bonus.Product.Name, bonus.Product.Category.Name,
                                        bonus.Product.Stock, bonus.StartDate, bonus.EndDate, bonus.Price, 0, 0, true,
                                        0);
                                    break;
                                case var _ when bonus.GetType() == typeof(XForThePriceOfY):
                                    _bonusTable.Rows.Add(bonus.Id, bonus.Product.Name, bonus.Product.Category.Name,
                                        bonus.Product.Stock, bonus.StartDate, bonus.EndDate, bonus.Price, 0, 0, false,
                                        ((XForThePriceOfY)bonus).NumberOfItems);
                                    break;
                            }
                        }
                        else if (type == "Percentage")
                        {
                            if (bonus.GetType() == typeof(PercentageDiscount))
                            {
                                _bonusTable.Rows.Add(bonus.Id, bonus.Product.Name, bonus.Product.Category.Name,
                                    bonus.Product.Stock, bonus.StartDate, bonus.EndDate, bonus.Price,
                                    ((PercentageDiscount)bonus).Percentage, 0, false, 0);
                            }
                        }
                        else if (type == "Quantity")
                        {
                            if (bonus.GetType() == typeof(QuantityDiscount))
                            {
                                _bonusTable.Rows.Add(bonus.Id, bonus.Product.Name, bonus.Product.Category.Name,
                                    bonus.Product.Stock, bonus.StartDate, bonus.EndDate, bonus.Price, 0,
                                    ((QuantityDiscount)bonus).Quantity, false, 0);
                            }
                        }
                        else if (type == "SecondHalfPrice")
                        {
                            if (bonus.GetType() == typeof(SecondHalfPrice))
                            {
                                _bonusTable.Rows.Add(bonus.Id, bonus.Product.Name, bonus.Product.Category.Name,
                                    bonus.Product.Stock, bonus.StartDate, bonus.EndDate, bonus.Price, 0, 0, true,
                                    0);
                            }
                        }
                        else if (type == "XForY")
                        {
                            if (bonus.GetType() == typeof(XForThePriceOfY))
                            {
                                _bonusTable.Rows.Add(bonus.Id, bonus.Product.Name, bonus.Product.Category.Name,
                                    bonus.Product.Stock, bonus.StartDate, bonus.EndDate, bonus.Price, 0, 0, false,
                                    ((XForThePriceOfY)bonus).NumberOfItems);
                            }
                        }
                    }
                }
                else
                {
                    if (type == "All")
                    {
                        switch (bonus.GetType())
                        {
                            case var _ when bonus.GetType() == typeof(PercentageDiscount):
                                _bonusTable.Rows.Add(bonus.Id, bonus.Product.Name, bonus.Product.Category.Name, bonus.Product.Stock,
                                    bonus.StartDate, bonus.EndDate, bonus.Price, ((PercentageDiscount)bonus).Percentage, 0,
                                    false, 0);
                                break;
                            case var _ when bonus.GetType() == typeof(QuantityDiscount):
                                _bonusTable.Rows.Add(bonus.Id, bonus.Product.Name, bonus.Product.Category.Name, bonus.Product.Stock,
                                    bonus.StartDate, bonus.EndDate, bonus.Price, 0, ((QuantityDiscount)bonus).Quantity,
                                    false, 0);
                                break;
                            case var _ when bonus.GetType() == typeof(SecondHalfPrice):
                                _bonusTable.Rows.Add(bonus.Id, bonus.Product.Name, bonus.Product.Category.Name, bonus.Product.Stock,
                                    bonus.StartDate, bonus.EndDate, bonus.Price, 0, 0, true, 0);
                                break;
                            case var _ when bonus.GetType() == typeof(XForThePriceOfY):
                                _bonusTable.Rows.Add(bonus.Id, bonus.Product.Name, bonus.Product.Category.Name, bonus.Product.Stock,
                                    bonus.StartDate, bonus.EndDate, bonus.Price, 0, 0, false,
                                    ((XForThePriceOfY)bonus).NumberOfItems);
                                break;
                        }
                    }
                    else if (type == "Percentage") 
                    {
                            if (bonus.GetType() == typeof(PercentageDiscount))
                            {
                                _bonusTable.Rows.Add(bonus.Id, bonus.Product.Name, bonus.Product.Category.Name,
                                    bonus.Product.Stock, bonus.StartDate, bonus.EndDate, bonus.Price,
                                    ((PercentageDiscount)bonus).Percentage, 0, false, 0);
                            }
                    }
                    else if (type == "Quantity")
                    {
                            if (bonus.GetType() == typeof(QuantityDiscount))
                            {
                                _bonusTable.Rows.Add(bonus.Id, bonus.Product.Name, bonus.Product.Category.Name,
                                    bonus.Product.Stock, bonus.StartDate, bonus.EndDate, bonus.Price, 0,
                                    ((QuantityDiscount)bonus).Quantity, false, 0);
                            }
                    }
                    else if (type == "SecondHalfPrice") 
                    {
                        if (bonus.GetType() == typeof(SecondHalfPrice))
                        {
                            _bonusTable.Rows.Add(bonus.Id, bonus.Product.Name, bonus.Product.Category.Name, bonus.Product.Stock,
                                bonus.StartDate, bonus.EndDate, bonus.Price, 0, 0, true, 0);
                        }
                    }
                    else if (type == "XForY")
                    {
                        if (bonus.GetType() == typeof(XForThePriceOfY))
                        {
                            _bonusTable.Rows.Add(bonus.Id, bonus.Product.Name, bonus.Product.Category.Name,bonus.Product.Stock, bonus.StartDate, bonus.EndDate, bonus.Price, 0, 0, false, ((XForThePriceOfY)bonus).NumberOfItems);
                        }
                    }
                }
            }

            bonusSource.DataSource = _bonusTable;
            dgvBonus.DataSource = bonusSource;
        }
        
        public void BonusCbLoad()
        {
            cbBonusType.Items.Add("All");
            //add all the TypeOfBonus enums to the combobox
            foreach (var type in Enum.GetValues(typeof(BonusType)))
            {
                cbBonusType.Items.Add(type);
            }
            
            cbBonusType.SelectedIndex = 0;
        }
        private void RobertHein_Load(object sender, EventArgs e)
        {
            ProductDataTableMaker();
            CategoryCbLoad();
            BonusDataTableMaker();
            BonusCbLoad();
        }


        //Product

        private void lblCategory_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct(_productManager, _categoryManager);
            addProduct.ShowDialog();
            _productManager.Refresh();
            ProductDataTableMaker();
        }

        private void btnCategoryManager_Click(object sender, EventArgs e)
        {
            ManageCategories manageCategories = new ManageCategories(_categoryManager);
            manageCategories.ShowDialog();
            CategoryCbLoad();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try{
                int id = (int)dgvProducts.SelectedRows[0].Cells[0].Value;
                Product product = _productManager.GetProductById(id);
                AddProduct addProduct = new AddProduct(_productManager, _categoryManager, product);
                addProduct.ShowDialog();
                _productManager.Refresh();
                ProductDataTableMaker();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select a product to edit");
            }
            
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (int)dgvProducts.SelectedRows[0].Cells[0].Value;
                Product product = _productManager.GetProductById(id);
                if (product.IsDiscontinued)
                {
                    _productManager.ReenableProduct(product);
                    _productManager.Refresh();
                    ProductDataTableMaker();
                }
                else
                {
                    _productManager.DiscontinueProduct(product);
                    _productManager.Refresh();
                    ProductDataTableMaker();
                }
            }
            catch
            {
                MessageBox.Show("Please select a product to discountinue");
            }
        }

        private void cbProductCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProductCategories.SelectedIndex == 0)
            {
                ProductDataTableMaker();
            }
            else
            {
                ProductDataTableMaker(cbProductCategories.SelectedItem.ToString());
            }
        }

        private void cbActiveItems_CheckedChanged(object sender, EventArgs e)
        {
            ProductDataTableMaker(cbProductCategories.SelectedItem.ToString());
        }
        private void tbProductSearch_TextChanged(object sender, EventArgs e)
        {

            try
            {
                _productTable.DefaultView.RowFilter = string.Format("Name LIKE '%{0}%'", tbProductSearch.Text);
            }
            catch (Exception exception)
            {
            }
        }
        // Bonus
        private void btnCreateBonus_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (int)dgvProducts.SelectedRows[0].Cells[0].Value;
                Product product = _productManager.GetProductById(id);
                AddBonus addBonus = new AddBonus(_bonusManager, product);
                addBonus.ShowDialog();
                _bonusManager.Refresh();
                BonusDataTableMaker();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select a product (From the products tab) to add a bonus to");
            }
        }

        private void cbActiveBonuses_CheckedChanged(object sender, EventArgs e)
        {
            BonusDataTableMaker();
        }

        private void tbSearchBonus_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _bonusTable.DefaultView.RowFilter = String.Format("Name LIKE '%{0}%'", tbSearchBonus.Text);
            }
            catch (Exception ex)
            {
            }
        }

        private void btnEditBonus_Click(object sender, EventArgs e)
        {
            Bonuses bonus = _bonusManager.GetBonusById((int)dgvBonus.SelectedRows[0].Cells[0].Value);
            AddBonus addBonus = new AddBonus(_bonusManager,bonus.Product, bonus);
            addBonus.ShowDialog();
            _bonusManager.Refresh();
            BonusDataTableMaker();
        }

        private void btnDeleteBonus_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this bonus?", "Delete Bonus", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Bonuses bonus = _bonusManager.GetBonusById((int)dgvBonus.SelectedRows[0].Cells[0].Value);
                _bonusManager.DeleteBonus(bonus);
                BonusDataTableMaker();
            }
        }

        private void cbBonusType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBonusType.SelectedIndex == 0)
            {
                BonusDataTableMaker();
            }
            else
            {
                BonusDataTableMaker(cbBonusType.SelectedItem.ToString());
            }
        }
    }
}
