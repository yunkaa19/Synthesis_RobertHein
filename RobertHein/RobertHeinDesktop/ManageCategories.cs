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
    public partial class ManageCategories : Form
    {
        bool isAdd = false;
        bool isEdit = false;
        CategoryManager cm;
        public ManageCategories(CategoryManager categoryManager)
        {
            cm = categoryManager;
            InitializeComponent();
            panel.Visible = false;
            this.Size = new Size(296, 287);
        }

        private void ManageCategories_Load(object sender, EventArgs e)
        {
            lbCategories.DataSource = cm.GetAllCategories();
            lbCategories.DisplayMember = "Name";
            lbCategories.ValueMember = "Id";
            
            cbParentCategories.DataSource = cm.GetAllCategories();
            cbParentCategories.DisplayMember = "Name";
            cbParentCategories.ValueMember = "Id";
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isAdd == false)
            {
                this.Size = new Size(296, 407);
                panel.Visible = true;
                isAdd = true;
                //cbParentCategories.SelectedIndex = 0;
                tbCategory.Text = "";
                cbxSubCategory.Checked = false;
            }
            
            else
            {
                this.Size = new Size(296, 287);
                panel.Visible = false;
                isAdd = false;
            }
            

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(isEdit == false)
            {
                if(cbxSubCategory.Checked == false)
                {
                    Category category = new Category(tbCategory.Text);
                    cm.AddCategory(category);
                    this.Size = new Size(296, 287);
                    panel.Visible = false;
                    isAdd = false;
                    
                    
                }
                else
                {
                    Category category = new Category(tbCategory.Text, (cbParentCategories.SelectedItem as Category).Id);
                    cm.AddCategory(category);
                    this.Size = new Size(296, 287);
                    panel.Visible = false;
                    isAdd = false;
                }
            }
            else
            {
                Category Edit = lbCategories.SelectedItem as Category;
                Edit.Name = tbCategory.Text;
                if (cbxSubCategory.Checked == false)
                {
                    Edit.ParentId = null;
                }
                else
                {
                    Edit.ParentId = (cbParentCategories.SelectedItem as Category).Id;
                }
                cm.UpdateCategory(Edit);
            }
            cm.Refresh();
            lbCategories.DataSource = cm.GetAllCategories();
            lbCategories.DisplayMember = "Name";
            lbCategories.ValueMember = "Id";
            
            cbParentCategories.DataSource = cm.GetAllCategories();
            cbParentCategories.DisplayMember = "Name";
            cbParentCategories.ValueMember = "Id";
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to cancel?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes && isAdd == true)
            {
                this.Size = new Size(296, 287);
                panel.Visible = false;
                isAdd = false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Category ToEdit = lbCategories.SelectedItem as Category;
            if (isEdit == false)
            {
                this.Size = new Size(296, 407);
                panel.Visible = true;
                isEdit = true;
                tbCategory.Text = ToEdit.Name;
                cbxSubCategory.Checked = ToEdit.ParentId != null;
                if (cbxSubCategory.Checked == true)
                {
                    cbParentCategories.SelectedValue = ToEdit.ParentId;
                }
            }
            else
            {
                this.Size = new Size(296, 287);
                panel.Visible = false;
                isEdit = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            cbParentCategories.Enabled = cbxSubCategory.Checked;
        }
    }
}
