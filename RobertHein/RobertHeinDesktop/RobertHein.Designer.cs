namespace RobertHeinDesktop
{
    partial class RobertHein
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RobertHein));
            this.tcRobert = new System.Windows.Forms.TabControl();
            this.tpProducts = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.tbProductSearch = new System.Windows.Forms.TextBox();
            this.cbActiveItems = new System.Windows.Forms.CheckBox();
            this.btnCategoryManager = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cbProductCategories = new System.Windows.Forms.ComboBox();
            this.btnDisable = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tpBonus = new System.Windows.Forms.TabPage();
            this.cbBonusType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSearchBonus = new System.Windows.Forms.TextBox();
            this.cbActiveBonuses = new System.Windows.Forms.CheckBox();
            this.dgvBonus = new System.Windows.Forms.DataGridView();
            this.btnDeleteBonus = new System.Windows.Forms.Button();
            this.btnEditBonus = new System.Windows.Forms.Button();
            this.btnCreateBonus = new System.Windows.Forms.Button();
            this.tpOrders = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnChangeStatus = new System.Windows.Forms.Button();
            this.btnCompleteOrder = new System.Windows.Forms.Button();
            this.tcRobert.SuspendLayout();
            this.tpProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.tpBonus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonus)).BeginInit();
            this.tpOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tcRobert
            // 
            this.tcRobert.Controls.Add(this.tpProducts);
            this.tcRobert.Controls.Add(this.tpBonus);
            this.tcRobert.Controls.Add(this.tpOrders);
            this.tcRobert.Location = new System.Drawing.Point(14, 12);
            this.tcRobert.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tcRobert.Name = "tcRobert";
            this.tcRobert.SelectedIndex = 0;
            this.tcRobert.Size = new System.Drawing.Size(905, 509);
            this.tcRobert.TabIndex = 0;
            // 
            // tpProducts
            // 
            this.tpProducts.Controls.Add(this.label3);
            this.tpProducts.Controls.Add(this.tbProductSearch);
            this.tpProducts.Controls.Add(this.cbActiveItems);
            this.tpProducts.Controls.Add(this.btnCategoryManager);
            this.tpProducts.Controls.Add(this.dgvProducts);
            this.tpProducts.Controls.Add(this.lblCategory);
            this.tpProducts.Controls.Add(this.cbProductCategories);
            this.tpProducts.Controls.Add(this.btnDisable);
            this.tpProducts.Controls.Add(this.btnEdit);
            this.tpProducts.Controls.Add(this.btnAdd);
            this.tpProducts.Location = new System.Drawing.Point(4, 24);
            this.tpProducts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tpProducts.Name = "tpProducts";
            this.tpProducts.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tpProducts.Size = new System.Drawing.Size(897, 481);
            this.tpProducts.TabIndex = 0;
            this.tpProducts.Text = "Products";
            this.tpProducts.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(694, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Search:";
            // 
            // tbProductSearch
            // 
            this.tbProductSearch.Location = new System.Drawing.Point(749, 59);
            this.tbProductSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbProductSearch.Name = "tbProductSearch";
            this.tbProductSearch.Size = new System.Drawing.Size(140, 23);
            this.tbProductSearch.TabIndex = 9;
            this.tbProductSearch.TextChanged += new System.EventHandler(this.tbProductSearch_TextChanged);
            // 
            // cbActiveItems
            // 
            this.cbActiveItems.AutoSize = true;
            this.cbActiveItems.Location = new System.Drawing.Point(7, 61);
            this.cbActiveItems.Name = "cbActiveItems";
            this.cbActiveItems.Size = new System.Drawing.Size(119, 19);
            this.cbActiveItems.TabIndex = 8;
            this.cbActiveItems.Text = "Only Active items";
            this.cbActiveItems.UseVisualStyleBackColor = true;
            this.cbActiveItems.CheckedChanged += new System.EventHandler(this.cbActiveItems_CheckedChanged);
            // 
            // btnCategoryManager
            // 
            this.btnCategoryManager.Location = new System.Drawing.Point(764, 446);
            this.btnCategoryManager.Name = "btnCategoryManager";
            this.btnCategoryManager.Size = new System.Drawing.Size(124, 23);
            this.btnCategoryManager.TabIndex = 7;
            this.btnCategoryManager.Text = "Manage Categories";
            this.btnCategoryManager.UseVisualStyleBackColor = true;
            this.btnCategoryManager.Click += new System.EventHandler(this.btnCategoryManager_Click);
            // 
            // dgvProducts
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProducts.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProducts.Location = new System.Drawing.Point(8, 96);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowTemplate.Height = 25;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(880, 329);
            this.dgvProducts.TabIndex = 6;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(683, 33);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(58, 15);
            this.lblCategory.TabIndex = 5;
            this.lblCategory.Text = "Categoty:";
            this.lblCategory.Click += new System.EventHandler(this.lblCategory_Click);
            // 
            // cbProductCategories
            // 
            this.cbProductCategories.FormattingEnabled = true;
            this.cbProductCategories.Location = new System.Drawing.Point(749, 30);
            this.cbProductCategories.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbProductCategories.Name = "cbProductCategories";
            this.cbProductCategories.Size = new System.Drawing.Size(140, 23);
            this.cbProductCategories.TabIndex = 4;
            this.cbProductCategories.SelectedIndexChanged += new System.EventHandler(this.cbProductCategories_SelectedIndexChanged);
            // 
            // btnDisable
            // 
            this.btnDisable.Location = new System.Drawing.Point(198, 444);
            this.btnDisable.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDisable.Name = "btnDisable";
            this.btnDisable.Size = new System.Drawing.Size(88, 27);
            this.btnDisable.TabIndex = 3;
            this.btnDisable.Text = "Toggle";
            this.btnDisable.UseVisualStyleBackColor = true;
            this.btnDisable.Click += new System.EventHandler(this.btnDisable_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(104, 444);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(88, 27);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(8, 444);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 27);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tpBonus
            // 
            this.tpBonus.Controls.Add(this.cbBonusType);
            this.tpBonus.Controls.Add(this.label2);
            this.tpBonus.Controls.Add(this.label1);
            this.tpBonus.Controls.Add(this.tbSearchBonus);
            this.tpBonus.Controls.Add(this.cbActiveBonuses);
            this.tpBonus.Controls.Add(this.dgvBonus);
            this.tpBonus.Controls.Add(this.btnDeleteBonus);
            this.tpBonus.Controls.Add(this.btnEditBonus);
            this.tpBonus.Controls.Add(this.btnCreateBonus);
            this.tpBonus.Location = new System.Drawing.Point(4, 24);
            this.tpBonus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tpBonus.Name = "tpBonus";
            this.tpBonus.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tpBonus.Size = new System.Drawing.Size(897, 481);
            this.tpBonus.TabIndex = 1;
            this.tpBonus.Text = "Bonuses";
            this.tpBonus.UseVisualStyleBackColor = true;
            // 
            // cbBonusType
            // 
            this.cbBonusType.FormattingEnabled = true;
            this.cbBonusType.Location = new System.Drawing.Point(749, 30);
            this.cbBonusType.Name = "cbBonusType";
            this.cbBonusType.Size = new System.Drawing.Size(140, 23);
            this.cbBonusType.TabIndex = 15;
            this.cbBonusType.SelectedIndexChanged += new System.EventHandler(this.cbBonusType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(705, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Type:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(694, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Search:";
            // 
            // tbSearchBonus
            // 
            this.tbSearchBonus.Location = new System.Drawing.Point(749, 59);
            this.tbSearchBonus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbSearchBonus.Name = "tbSearchBonus";
            this.tbSearchBonus.Size = new System.Drawing.Size(140, 23);
            this.tbSearchBonus.TabIndex = 13;
            this.tbSearchBonus.TextChanged += new System.EventHandler(this.tbSearchBonus_TextChanged);
            // 
            // cbActiveBonuses
            // 
            this.cbActiveBonuses.AutoSize = true;
            this.cbActiveBonuses.Location = new System.Drawing.Point(7, 61);
            this.cbActiveBonuses.Name = "cbActiveBonuses";
            this.cbActiveBonuses.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbActiveBonuses.Size = new System.Drawing.Size(90, 19);
            this.cbActiveBonuses.TabIndex = 12;
            this.cbActiveBonuses.Text = ":Only Active";
            this.cbActiveBonuses.UseVisualStyleBackColor = true;
            this.cbActiveBonuses.CheckedChanged += new System.EventHandler(this.cbActiveBonuses_CheckedChanged);
            // 
            // dgvBonus
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBonus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBonus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBonus.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBonus.Location = new System.Drawing.Point(8, 96);
            this.dgvBonus.Name = "dgvBonus";
            this.dgvBonus.ReadOnly = true;
            this.dgvBonus.RowTemplate.Height = 25;
            this.dgvBonus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBonus.Size = new System.Drawing.Size(880, 329);
            this.dgvBonus.TabIndex = 11;
            // 
            // btnDeleteBonus
            // 
            this.btnDeleteBonus.Location = new System.Drawing.Point(201, 444);
            this.btnDeleteBonus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDeleteBonus.Name = "btnDeleteBonus";
            this.btnDeleteBonus.Size = new System.Drawing.Size(88, 27);
            this.btnDeleteBonus.TabIndex = 6;
            this.btnDeleteBonus.Text = "Delete bonus";
            this.btnDeleteBonus.UseVisualStyleBackColor = true;
            this.btnDeleteBonus.Click += new System.EventHandler(this.btnDeleteBonus_Click);
            // 
            // btnEditBonus
            // 
            this.btnEditBonus.Location = new System.Drawing.Point(105, 444);
            this.btnEditBonus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEditBonus.Name = "btnEditBonus";
            this.btnEditBonus.Size = new System.Drawing.Size(88, 27);
            this.btnEditBonus.TabIndex = 6;
            this.btnEditBonus.Text = "Edit bonus";
            this.btnEditBonus.UseVisualStyleBackColor = true;
            this.btnEditBonus.Click += new System.EventHandler(this.btnEditBonus_Click);
            // 
            // btnCreateBonus
            // 
            this.btnCreateBonus.Location = new System.Drawing.Point(9, 444);
            this.btnCreateBonus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCreateBonus.Name = "btnCreateBonus";
            this.btnCreateBonus.Size = new System.Drawing.Size(88, 27);
            this.btnCreateBonus.TabIndex = 6;
            this.btnCreateBonus.Text = "Add bonus";
            this.btnCreateBonus.UseVisualStyleBackColor = true;
            this.btnCreateBonus.Click += new System.EventHandler(this.btnCreateBonus_Click);
            // 
            // tpOrders
            // 
            this.tpOrders.Controls.Add(this.dataGridView2);
            this.tpOrders.Controls.Add(this.btnChangeStatus);
            this.tpOrders.Controls.Add(this.btnCompleteOrder);
            this.tpOrders.Location = new System.Drawing.Point(4, 24);
            this.tpOrders.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tpOrders.Name = "tpOrders";
            this.tpOrders.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tpOrders.Size = new System.Drawing.Size(897, 481);
            this.tpOrders.TabIndex = 2;
            this.tpOrders.Text = "Orders";
            this.tpOrders.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(7, 76);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.Size = new System.Drawing.Size(882, 336);
            this.dataGridView2.TabIndex = 3;
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.Location = new System.Drawing.Point(671, 418);
            this.btnChangeStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Size = new System.Drawing.Size(102, 27);
            this.btnChangeStatus.TabIndex = 2;
            this.btnChangeStatus.Text = "Change Status";
            this.btnChangeStatus.UseVisualStyleBackColor = true;
            // 
            // btnCompleteOrder
            // 
            this.btnCompleteOrder.Location = new System.Drawing.Point(779, 418);
            this.btnCompleteOrder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCompleteOrder.Name = "btnCompleteOrder";
            this.btnCompleteOrder.Size = new System.Drawing.Size(110, 27);
            this.btnCompleteOrder.TabIndex = 1;
            this.btnCompleteOrder.Text = "Complete Order";
            this.btnCompleteOrder.UseVisualStyleBackColor = true;
            // 
            // RobertHein
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.tcRobert);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "RobertHein";
            this.Text = "RobertHein";
            this.Load += new System.EventHandler(this.RobertHein_Load);
            this.tcRobert.ResumeLayout(false);
            this.tpProducts.ResumeLayout(false);
            this.tpProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.tpBonus.ResumeLayout(false);
            this.tpBonus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonus)).EndInit();
            this.tpOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcRobert;
        private System.Windows.Forms.TabPage tpProducts;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cbProductCategories;
        private System.Windows.Forms.Button btnDisable;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TabPage tpBonus;
        private System.Windows.Forms.TabPage tpOrders;
        private System.Windows.Forms.Button btnCreateBonus;
        private System.Windows.Forms.Button btnChangeStatus;
        private System.Windows.Forms.Button btnCompleteOrder;
        private DataGridView dgvProducts;
        private Button btnCategoryManager;
        private CheckBox cbActiveItems;
        private DataGridView dgvBonus;
        private CheckBox cbActiveBonuses;
        private DataGridView dataGridView2;
        private Label label3;
        private TextBox tbProductSearch;
        private Label label1;
        private TextBox tbSearchBonus;
        private Button btnDeleteBonus;
        private Button btnEditBonus;
        private ComboBox cbBonusType;
        private Label label2;
    }
}

