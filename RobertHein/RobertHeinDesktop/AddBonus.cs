using Models.Entities;
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
using Models.Entities.Bonus;

namespace RobertHeinDesktop
{
    public partial class AddBonus : Form
    {
        Product product;
        BonusManager BM;
        Bonuses bonus;
        bool editMode = false;
        public AddBonus(BonusManager bm,Product product, Bonuses? bonus = null)
        {
            if (bonus != null)
            {
                this.bonus = bonus;
                editMode = true;
            }
            this.product = product;
            BM = bm;
            InitializeComponent();
            cbTypes.DataSource = Enum.GetValues(typeof(BonusType));
        }
        private void AddBonus_Load(object sender, EventArgs e)
        {
            if (editMode)
            {
                btnAdd.Text = "Update";
                cbTypes.Enabled = false;
            }
            lblProduct.Text = $"Product: {product.Name} Price: {product.Price}€";
            dtpStartDate.Value = Convert.ToDateTime(bonus.StartDate.ToString());
            dtpEndDate.Value = Convert.ToDateTime(bonus.EndDate.ToString());
            if (bonus != null)
            {
                if (bonus.GetType() == typeof(PercentageDiscount))
                {
                    cbTypes.SelectedIndex = 0;
                    nudBonus.Value = (decimal)((PercentageDiscount)bonus).Percentage;
                }
                else if (bonus.GetType() == typeof(QuantityDiscount))
                {
                    cbTypes.SelectedIndex = 1;
                    nudBonus.Value = (decimal)((QuantityDiscount)bonus).Quantity;
                    nudPrice.Value = (decimal)((QuantityDiscount)bonus).Price;
                }
                else if (bonus.GetType() == typeof(SecondHalfPrice))
                {
                    cbTypes.SelectedIndex = 2;
                }
                else if (bonus.GetType() == typeof(XForThePriceOfY))
                {
                    cbTypes.SelectedIndex = 3;
                    nudBonus.Value = (decimal)((XForThePriceOfY)bonus).NumberOfItems;
                    nudPrice.Value = (decimal)((XForThePriceOfY)bonus).Price;
                }
            }
        }
        private void cbTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblBonus.Visible = true;
            nudBonus.Visible = true;
            nudPrice.Enabled = false;
            if(cbTypes.SelectedItem.ToString() == "Percentage")
            {
                lblBonus.Text = "Value (%)";
                nudBonus.DecimalPlaces = 0;
                nudBonus.Increment = 1;
            }
            else if (cbTypes.SelectedItem.ToString() == "Quantity")
            {
                lblBonus.Text = "Quantity:";
                nudBonus.DecimalPlaces = 3;
                nudBonus.Increment = 0.001M;
                nudPrice.Enabled = true;
            }
            else if (cbTypes.SelectedItem.ToString() == "SecondHalfPrice")
            {
                lblBonus.Visible = false;
                nudBonus.Visible = false;
            }
            else if (cbTypes.SelectedItem.ToString() == "XForY")
            {
                lblBonus.Text = "Quantity:";
                nudBonus.DecimalPlaces = 0;
                nudBonus.Increment = 1;
                nudPrice.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DateOnly StartDate = DateOnly.Parse(dtpStartDate.Value.ToShortDateString());
            DateOnly EndDate = DateOnly.Parse(dtpEndDate.Value.ToShortDateString());

            if (editMode)
            {
                if (cbTypes.SelectedItem.ToString() == "Percentage")
                {
                    PercentageDiscount pd = bonus as PercentageDiscount;
                    pd.Percentage = (double)nudBonus.Value;
                    pd.StartDate = StartDate;
                    pd.EndDate = EndDate;
                    BM.UpdateBonus(pd);
                }
                else if (cbTypes.SelectedItem.ToString() == "Quantity")
                {
                    QuantityDiscount qd = bonus as QuantityDiscount;
                    qd.Quantity = (double)nudBonus.Value;
                    qd.Price = (float)nudPrice.Value;
                    qd.StartDate = StartDate;
                    qd.EndDate = EndDate;
                    BM.UpdateBonus(qd);
                }
                else if (cbTypes.SelectedItem.ToString() == "SecondHalfPrice")
                {
                    SecondHalfPrice shp = bonus as SecondHalfPrice;
                    shp.StartDate = StartDate;
                    shp.EndDate = EndDate;
                    BM.UpdateBonus(shp);
                }
                else if (cbTypes.SelectedItem.ToString() == "XForY")
                {
                    XForThePriceOfY x4y = bonus as XForThePriceOfY;
                    x4y.NumberOfItems = (int)nudBonus.Value;
                    x4y.Price = (float)nudPrice.Value;
                    x4y.StartDate = StartDate;
                    x4y.EndDate = EndDate;
                    BM.UpdateBonus(x4y);
                }
                
            }
            else
            {
                if (cbTypes.SelectedItem.ToString() == "Percentage")
                {
                    BM.AddBonus(new PercentageDiscount(product, StartDate, EndDate, (double)nudBonus.Value));
                }
                else if (cbTypes.SelectedItem.ToString() == "Quantity")
                {
                    BM.AddBonus(new QuantityDiscount(product, StartDate, EndDate, (float)nudPrice.Value,
                        (double)nudBonus.Value));
                }
                else if (cbTypes.SelectedItem.ToString() == "SecondHalfPrice")
                {
                    BM.AddBonus(new SecondHalfPrice(product, StartDate, EndDate));
                }
                else if (cbTypes.SelectedItem.ToString() == "XForY")
                {
                    BM.AddBonus(new XForThePriceOfY(product, StartDate, EndDate, (float)nudPrice.Value,
                        (int)nudBonus.Value));
                }
            }

            MessageBox.Show("Bonus added");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to cancel?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        
    }
}
