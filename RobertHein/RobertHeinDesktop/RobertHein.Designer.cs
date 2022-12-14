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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RobertHein));
            this.tcRobert = new System.Windows.Forms.TabControl();
            this.tpProducts = new System.Windows.Forms.TabPage();
            this.tpBonus = new System.Windows.Forms.TabPage();
            this.tpOrders = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDisable = new System.Windows.Forms.Button();
            this.cbProductCategories = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblCategory2 = new System.Windows.Forms.Label();
            this.cbBonusCategories = new System.Windows.Forms.ComboBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnCreateBonus = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.btnCompleteOrder = new System.Windows.Forms.Button();
            this.btnChangeStatus = new System.Windows.Forms.Button();
            this.tcRobert.SuspendLayout();
            this.tpProducts.SuspendLayout();
            this.tpBonus.SuspendLayout();
            this.tpOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // tcRobert
            // 
            this.tcRobert.Controls.Add(this.tpProducts);
            this.tcRobert.Controls.Add(this.tpBonus);
            this.tcRobert.Controls.Add(this.tpOrders);
            this.tcRobert.Location = new System.Drawing.Point(12, 12);
            this.tcRobert.Name = "tcRobert";
            this.tcRobert.SelectedIndex = 0;
            this.tcRobert.Size = new System.Drawing.Size(776, 439);
            this.tcRobert.TabIndex = 0;
            // 
            // tpProducts
            // 
            this.tpProducts.Controls.Add(this.lblCategory);
            this.tpProducts.Controls.Add(this.cbProductCategories);
            this.tpProducts.Controls.Add(this.btnDisable);
            this.tpProducts.Controls.Add(this.btnEdit);
            this.tpProducts.Controls.Add(this.btnAdd);
            this.tpProducts.Controls.Add(this.dataGridView1);
            this.tpProducts.Location = new System.Drawing.Point(4, 22);
            this.tpProducts.Name = "tpProducts";
            this.tpProducts.Padding = new System.Windows.Forms.Padding(3);
            this.tpProducts.Size = new System.Drawing.Size(768, 413);
            this.tpProducts.TabIndex = 0;
            this.tpProducts.Text = "Products";
            this.tpProducts.UseVisualStyleBackColor = true;
            // 
            // tpBonus
            // 
            this.tpBonus.Controls.Add(this.comboBox1);
            this.tpBonus.Controls.Add(this.label1);
            this.tpBonus.Controls.Add(this.label2);
            this.tpBonus.Controls.Add(this.textBox2);
            this.tpBonus.Controls.Add(this.btnCreateBonus);
            this.tpBonus.Controls.Add(this.dataGridView2);
            this.tpBonus.Controls.Add(this.cbBonusCategories);
            this.tpBonus.Controls.Add(this.lblCategory2);
            this.tpBonus.Controls.Add(this.lblSearch);
            this.tpBonus.Controls.Add(this.textBox1);
            this.tpBonus.Controls.Add(this.listBox1);
            this.tpBonus.Location = new System.Drawing.Point(4, 22);
            this.tpBonus.Name = "tpBonus";
            this.tpBonus.Padding = new System.Windows.Forms.Padding(3);
            this.tpBonus.Size = new System.Drawing.Size(768, 413);
            this.tpBonus.TabIndex = 1;
            this.tpBonus.Text = "Bonuses";
            this.tpBonus.UseVisualStyleBackColor = true;
            // 
            // tpOrders
            // 
            this.tpOrders.Controls.Add(this.btnChangeStatus);
            this.tpOrders.Controls.Add(this.btnCompleteOrder);
            this.tpOrders.Controls.Add(this.dataGridView3);
            this.tpOrders.Location = new System.Drawing.Point(4, 22);
            this.tpOrders.Name = "tpOrders";
            this.tpOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tpOrders.Size = new System.Drawing.Size(768, 413);
            this.tpOrders.TabIndex = 2;
            this.tpOrders.Text = "Orders";
            this.tpOrders.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 85);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(756, 293);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(7, 385);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(89, 385);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDisable
            // 
            this.btnDisable.Location = new System.Drawing.Point(170, 385);
            this.btnDisable.Name = "btnDisable";
            this.btnDisable.Size = new System.Drawing.Size(75, 23);
            this.btnDisable.TabIndex = 3;
            this.btnDisable.Text = "Discontinue";
            this.btnDisable.UseVisualStyleBackColor = true;
            // 
            // cbProductCategories
            // 
            this.cbProductCategories.FormattingEnabled = true;
            this.cbProductCategories.Location = new System.Drawing.Point(641, 58);
            this.cbProductCategories.Name = "cbProductCategories";
            this.cbProductCategories.Size = new System.Drawing.Size(121, 21);
            this.cbProductCategories.TabIndex = 4;
            this.cbProductCategories.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(583, 61);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(52, 13);
            this.lblCategory.TabIndex = 5;
            this.lblCategory.Text = "Categoty:";
            this.lblCategory.Click += new System.EventHandler(this.lblCategory_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 67);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(224, 277);
            this.listBox1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(69, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(161, 20);
            this.textBox1.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(6, 44);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(44, 13);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Search:";
            // 
            // lblCategory2
            // 
            this.lblCategory2.AutoSize = true;
            this.lblCategory2.Location = new System.Drawing.Point(6, 18);
            this.lblCategory2.Name = "lblCategory2";
            this.lblCategory2.Size = new System.Drawing.Size(52, 13);
            this.lblCategory2.TabIndex = 3;
            this.lblCategory2.Text = "Category:";
            // 
            // cbBonusCategories
            // 
            this.cbBonusCategories.FormattingEnabled = true;
            this.cbBonusCategories.Location = new System.Drawing.Point(69, 14);
            this.cbBonusCategories.Name = "cbBonusCategories";
            this.cbBonusCategories.Size = new System.Drawing.Size(161, 21);
            this.cbBonusCategories.TabIndex = 4;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(262, 67);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(500, 277);
            this.dataGridView2.TabIndex = 5;
            // 
            // btnCreateBonus
            // 
            this.btnCreateBonus.Location = new System.Drawing.Point(154, 351);
            this.btnCreateBonus.Name = "btnCreateBonus";
            this.btnCreateBonus.Size = new System.Drawing.Size(75, 23);
            this.btnCreateBonus.TabIndex = 6;
            this.btnCreateBonus.Text = "Add bonus";
            this.btnCreateBonus.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(601, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(161, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(538, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Category:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(538, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Search:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(601, 41);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(161, 20);
            this.textBox2.TabIndex = 7;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(6, 6);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(756, 350);
            this.dataGridView3.TabIndex = 0;
            // 
            // btnCompleteOrder
            // 
            this.btnCompleteOrder.Location = new System.Drawing.Point(668, 362);
            this.btnCompleteOrder.Name = "btnCompleteOrder";
            this.btnCompleteOrder.Size = new System.Drawing.Size(94, 23);
            this.btnCompleteOrder.TabIndex = 1;
            this.btnCompleteOrder.Text = "Complete Order";
            this.btnCompleteOrder.UseVisualStyleBackColor = true;
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.Location = new System.Drawing.Point(575, 362);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Size = new System.Drawing.Size(87, 23);
            this.btnChangeStatus.TabIndex = 2;
            this.btnChangeStatus.Text = "Change Status";
            this.btnChangeStatus.UseVisualStyleBackColor = true;
            // 
            // RobertHein
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tcRobert);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RobertHein";
            this.Text = "RobertHein";
            this.tcRobert.ResumeLayout(false);
            this.tpProducts.ResumeLayout(false);
            this.tpProducts.PerformLayout();
            this.tpBonus.ResumeLayout(false);
            this.tpBonus.PerformLayout();
            this.tpOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tpBonus;
        private System.Windows.Forms.TabPage tpOrders;
        private System.Windows.Forms.Label lblCategory2;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnCreateBonus;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ComboBox cbBonusCategories;
        private System.Windows.Forms.Button btnChangeStatus;
        private System.Windows.Forms.Button btnCompleteOrder;
        private System.Windows.Forms.DataGridView dataGridView3;
    }
}

