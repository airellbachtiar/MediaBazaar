
namespace Media_Bazaar.Forms
{
    partial class CategoryForm
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
            this.tbctrlCategory = new System.Windows.Forms.TabControl();
            this.tabAddCategory = new System.Windows.Forms.TabPage();
            this.btnAddNewCategory = new System.Windows.Forms.Button();
            this.tbAddCategoryName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabEditCategory = new System.Windows.Forms.TabPage();
            this.btnEditOldCategory = new System.Windows.Forms.Button();
            this.tbEditSelectedName = new System.Windows.Forms.TextBox();
            this.lblSelectedID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvCategory = new System.Windows.Forms.DataGridView();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnEditCategory = new System.Windows.Forms.Button();
            this.CategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbctrlCategory.SuspendLayout();
            this.tabAddCategory.SuspendLayout();
            this.tabEditCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // tbctrlCategory
            // 
            this.tbctrlCategory.Controls.Add(this.tabAddCategory);
            this.tbctrlCategory.Controls.Add(this.tabEditCategory);
            this.tbctrlCategory.Location = new System.Drawing.Point(13, 13);
            this.tbctrlCategory.Name = "tbctrlCategory";
            this.tbctrlCategory.SelectedIndex = 0;
            this.tbctrlCategory.Size = new System.Drawing.Size(605, 425);
            this.tbctrlCategory.TabIndex = 0;
            // 
            // tabAddCategory
            // 
            this.tabAddCategory.Controls.Add(this.btnAddNewCategory);
            this.tabAddCategory.Controls.Add(this.tbAddCategoryName);
            this.tabAddCategory.Controls.Add(this.label1);
            this.tabAddCategory.Location = new System.Drawing.Point(4, 24);
            this.tabAddCategory.Name = "tabAddCategory";
            this.tabAddCategory.Padding = new System.Windows.Forms.Padding(3);
            this.tabAddCategory.Size = new System.Drawing.Size(597, 397);
            this.tabAddCategory.TabIndex = 0;
            this.tabAddCategory.Text = "Add New Category";
            this.tabAddCategory.UseVisualStyleBackColor = true;
            // 
            // btnAddNewCategory
            // 
            this.btnAddNewCategory.Location = new System.Drawing.Point(244, 157);
            this.btnAddNewCategory.Name = "btnAddNewCategory";
            this.btnAddNewCategory.Size = new System.Drawing.Size(100, 46);
            this.btnAddNewCategory.TabIndex = 2;
            this.btnAddNewCategory.Text = "New Category";
            this.btnAddNewCategory.UseVisualStyleBackColor = true;
            this.btnAddNewCategory.Click += new System.EventHandler(this.btnAddNewCategory_Click);
            // 
            // tbAddCategoryName
            // 
            this.tbAddCategoryName.Location = new System.Drawing.Point(244, 84);
            this.tbAddCategoryName.Name = "tbAddCategoryName";
            this.tbAddCategoryName.Size = new System.Drawing.Size(100, 23);
            this.tbAddCategoryName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // tabEditCategory
            // 
            this.tabEditCategory.Controls.Add(this.btnEditOldCategory);
            this.tabEditCategory.Controls.Add(this.tbEditSelectedName);
            this.tabEditCategory.Controls.Add(this.lblSelectedID);
            this.tabEditCategory.Controls.Add(this.label3);
            this.tabEditCategory.Controls.Add(this.label2);
            this.tabEditCategory.Controls.Add(this.dgvCategory);
            this.tabEditCategory.Location = new System.Drawing.Point(4, 24);
            this.tabEditCategory.Name = "tabEditCategory";
            this.tabEditCategory.Padding = new System.Windows.Forms.Padding(3);
            this.tabEditCategory.Size = new System.Drawing.Size(597, 397);
            this.tabEditCategory.TabIndex = 1;
            this.tabEditCategory.Text = "Edit Category";
            this.tabEditCategory.UseVisualStyleBackColor = true;
            // 
            // btnEditOldCategory
            // 
            this.btnEditOldCategory.Location = new System.Drawing.Point(337, 282);
            this.btnEditOldCategory.Name = "btnEditOldCategory";
            this.btnEditOldCategory.Size = new System.Drawing.Size(208, 35);
            this.btnEditOldCategory.TabIndex = 5;
            this.btnEditOldCategory.Text = "Edit Category";
            this.btnEditOldCategory.UseVisualStyleBackColor = true;
            this.btnEditOldCategory.Click += new System.EventHandler(this.btnEditOldCategory_Click);
            // 
            // tbEditSelectedName
            // 
            this.tbEditSelectedName.Location = new System.Drawing.Point(445, 167);
            this.tbEditSelectedName.Name = "tbEditSelectedName";
            this.tbEditSelectedName.Size = new System.Drawing.Size(100, 23);
            this.tbEditSelectedName.TabIndex = 4;
            // 
            // lblSelectedID
            // 
            this.lblSelectedID.AutoSize = true;
            this.lblSelectedID.Location = new System.Drawing.Point(445, 105);
            this.lblSelectedID.Name = "lblSelectedID";
            this.lblSelectedID.Size = new System.Drawing.Size(0, 15);
            this.lblSelectedID.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(337, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "SelectedName:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(337, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "SelectedID:";
            // 
            // dgvCategory
            // 
            this.dgvCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CategoryID,
            this.CategoryName});
            this.dgvCategory.Location = new System.Drawing.Point(6, 6);
            this.dgvCategory.Name = "dgvCategory";
            this.dgvCategory.RowTemplate.Height = 25;
            this.dgvCategory.Size = new System.Drawing.Size(254, 385);
            this.dgvCategory.TabIndex = 0;
            this.dgvCategory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategory_CellClick);
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Location = new System.Drawing.Point(654, 37);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(106, 50);
            this.btnAddCategory.TabIndex = 1;
            this.btnAddCategory.Text = "Add Category";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // btnEditCategory
            // 
            this.btnEditCategory.Location = new System.Drawing.Point(654, 124);
            this.btnEditCategory.Name = "btnEditCategory";
            this.btnEditCategory.Size = new System.Drawing.Size(106, 50);
            this.btnEditCategory.TabIndex = 2;
            this.btnEditCategory.Text = "Edit Category";
            this.btnEditCategory.UseVisualStyleBackColor = true;
            this.btnEditCategory.Click += new System.EventHandler(this.btnEditCategory_Click);
            // 
            // CategoryID
            // 
            this.CategoryID.HeaderText = "CategoryID";
            this.CategoryID.Name = "CategoryID";
            // 
            // CategoryName
            // 
            this.CategoryName.HeaderText = "CategoryName";
            this.CategoryName.Name = "CategoryName";
            // 
            // CategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEditCategory);
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.tbctrlCategory);
            this.Name = "CategoryForm";
            this.Text = "CategoryForm";
            this.tbctrlCategory.ResumeLayout(false);
            this.tabAddCategory.ResumeLayout(false);
            this.tabAddCategory.PerformLayout();
            this.tabEditCategory.ResumeLayout(false);
            this.tabEditCategory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbctrlCategory;
        private System.Windows.Forms.TabPage tabAddCategory;
        private System.Windows.Forms.TabPage tabEditCategory;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnEditCategory;
        private System.Windows.Forms.Button btnAddNewCategory;
        private System.Windows.Forms.TextBox tbAddCategoryName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEditOldCategory;
        private System.Windows.Forms.TextBox tbEditSelectedName;
        private System.Windows.Forms.Label lblSelectedID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
    }
}