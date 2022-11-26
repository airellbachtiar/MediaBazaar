
namespace Media_Bazaar.Forms
{
    partial class ProductForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelProductID = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnOutOfStock = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.rtbxDescription = new System.Windows.Forms.RichTextBox();
            this.tbxDepotLocation = new System.Windows.Forms.TextBox();
            this.tbxStoreStock = new System.Windows.Forms.TextBox();
            this.tbxDepotStock = new System.Windows.Forms.TextBox();
            this.tbxPriceWithoutVAT = new System.Windows.Forms.TextBox();
            this.tbxSellingPrice = new System.Windows.Forms.TextBox();
            this.tbxHeight = new System.Windows.Forms.TextBox();
            this.tbxWidth = new System.Windows.Forms.TextBox();
            this.tbxLength = new System.Windows.Forms.TextBox();
            this.tbxBrand = new System.Windows.Forms.TextBox();
            this.tbxProductName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.cbCategory);
            this.panel2.Controls.Add(this.labelProductID);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.btnOutOfStock);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Controls.Add(this.rtbxDescription);
            this.panel2.Controls.Add(this.tbxDepotLocation);
            this.panel2.Controls.Add(this.tbxStoreStock);
            this.panel2.Controls.Add(this.tbxDepotStock);
            this.panel2.Controls.Add(this.tbxPriceWithoutVAT);
            this.panel2.Controls.Add(this.tbxSellingPrice);
            this.panel2.Controls.Add(this.tbxHeight);
            this.panel2.Controls.Add(this.tbxWidth);
            this.panel2.Controls.Add(this.tbxLength);
            this.panel2.Controls.Add(this.tbxBrand);
            this.panel2.Controls.Add(this.tbxProductName);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(13, 13);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(614, 400);
            this.panel2.TabIndex = 14;
            // 
            // labelProductID
            // 
            this.labelProductID.AutoSize = true;
            this.labelProductID.Location = new System.Drawing.Point(3, 11);
            this.labelProductID.Name = "labelProductID";
            this.labelProductID.Size = new System.Drawing.Size(66, 15);
            this.labelProductID.TabIndex = 43;
            this.labelProductID.Text = "Product ID:";
            this.labelProductID.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(250)))));
            this.btnAdd.Location = new System.Drawing.Point(288, 358);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 36);
            this.btnAdd.TabIndex = 37;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnOutOfStock
            // 
            this.btnOutOfStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(250)))));
            this.btnOutOfStock.Location = new System.Drawing.Point(2, 357);
            this.btnOutOfStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOutOfStock.Name = "btnOutOfStock";
            this.btnOutOfStock.Size = new System.Drawing.Size(168, 36);
            this.btnOutOfStock.TabIndex = 40;
            this.btnOutOfStock.Text = "Mark product as out of stock";
            this.btnOutOfStock.UseVisualStyleBackColor = false;
            this.btnOutOfStock.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(250)))));
            this.btnCancel.Location = new System.Drawing.Point(494, 358);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 36);
            this.btnCancel.TabIndex = 39;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(250)))));
            this.btnEdit.Location = new System.Drawing.Point(391, 358);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(95, 36);
            this.btnEdit.TabIndex = 38;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // rtbxDescription
            // 
            this.rtbxDescription.Location = new System.Drawing.Point(318, 223);
            this.rtbxDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtbxDescription.Name = "rtbxDescription";
            this.rtbxDescription.Size = new System.Drawing.Size(271, 102);
            this.rtbxDescription.TabIndex = 36;
            this.rtbxDescription.Text = "";
            // 
            // tbxDepotLocation
            // 
            this.tbxDepotLocation.Location = new System.Drawing.Point(435, 124);
            this.tbxDepotLocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxDepotLocation.Name = "tbxDepotLocation";
            this.tbxDepotLocation.Size = new System.Drawing.Size(154, 23);
            this.tbxDepotLocation.TabIndex = 34;
            // 
            // tbxStoreStock
            // 
            this.tbxStoreStock.Location = new System.Drawing.Point(435, 82);
            this.tbxStoreStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxStoreStock.Name = "tbxStoreStock";
            this.tbxStoreStock.Size = new System.Drawing.Size(154, 23);
            this.tbxStoreStock.TabIndex = 33;
            // 
            // tbxDepotStock
            // 
            this.tbxDepotStock.Location = new System.Drawing.Point(435, 37);
            this.tbxDepotStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxDepotStock.Name = "tbxDepotStock";
            this.tbxDepotStock.Size = new System.Drawing.Size(154, 23);
            this.tbxDepotStock.TabIndex = 32;
            // 
            // tbxPriceWithoutVAT
            // 
            this.tbxPriceWithoutVAT.Location = new System.Drawing.Point(130, 303);
            this.tbxPriceWithoutVAT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxPriceWithoutVAT.Name = "tbxPriceWithoutVAT";
            this.tbxPriceWithoutVAT.Size = new System.Drawing.Size(154, 23);
            this.tbxPriceWithoutVAT.TabIndex = 31;
            // 
            // tbxSellingPrice
            // 
            this.tbxSellingPrice.Location = new System.Drawing.Point(130, 258);
            this.tbxSellingPrice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxSellingPrice.Name = "tbxSellingPrice";
            this.tbxSellingPrice.Size = new System.Drawing.Size(154, 23);
            this.tbxSellingPrice.TabIndex = 30;
            // 
            // tbxHeight
            // 
            this.tbxHeight.Location = new System.Drawing.Point(130, 217);
            this.tbxHeight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxHeight.Name = "tbxHeight";
            this.tbxHeight.Size = new System.Drawing.Size(154, 23);
            this.tbxHeight.TabIndex = 29;
            // 
            // tbxWidth
            // 
            this.tbxWidth.Location = new System.Drawing.Point(130, 171);
            this.tbxWidth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxWidth.Name = "tbxWidth";
            this.tbxWidth.Size = new System.Drawing.Size(154, 23);
            this.tbxWidth.TabIndex = 28;
            // 
            // tbxLength
            // 
            this.tbxLength.Location = new System.Drawing.Point(130, 129);
            this.tbxLength.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxLength.Name = "tbxLength";
            this.tbxLength.Size = new System.Drawing.Size(154, 23);
            this.tbxLength.TabIndex = 27;
            // 
            // tbxBrand
            // 
            this.tbxBrand.Location = new System.Drawing.Point(130, 84);
            this.tbxBrand.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxBrand.Name = "tbxBrand";
            this.tbxBrand.Size = new System.Drawing.Size(154, 23);
            this.tbxBrand.TabIndex = 26;
            // 
            // tbxProductName
            // 
            this.tbxProductName.Location = new System.Drawing.Point(130, 37);
            this.tbxProductName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxProductName.Name = "tbxProductName";
            this.tbxProductName.Size = new System.Drawing.Size(154, 23);
            this.tbxProductName.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(315, 204);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 15);
            this.label12.TabIndex = 24;
            this.label12.Text = "Description";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(315, 173);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 15);
            this.label11.TabIndex = 23;
            this.label11.Text = "Category";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(315, 127);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 15);
            this.label10.TabIndex = 22;
            this.label10.Text = "Depot Location";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(315, 86);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 15);
            this.label9.TabIndex = 21;
            this.label9.Text = "Store Stock";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(315, 41);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 15);
            this.label8.TabIndex = 20;
            this.label8.Text = "Depot Stock";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 305);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 15);
            this.label7.TabIndex = 19;
            this.label7.Text = "Price without VAT (€)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 260);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = "Selling Price (€)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 220);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "Height (cm)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 173);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "Width (cm)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 132);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Length (cm)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Brand";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Product Name";
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(435, 171);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(154, 23);
            this.cbCategory.TabIndex = 44;
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(634, 418);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ProductForm";
            this.Text = "ProductForm";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.RichTextBox rtbxDescription;
        private System.Windows.Forms.TextBox tbxDepotLocation;
        private System.Windows.Forms.TextBox tbxStoreStock;
        private System.Windows.Forms.TextBox tbxDepotStock;
        private System.Windows.Forms.TextBox tbxPriceWithoutVAT;
        private System.Windows.Forms.TextBox tbxSellingPrice;
        private System.Windows.Forms.TextBox tbxHeight;
        private System.Windows.Forms.TextBox tbxWidth;
        private System.Windows.Forms.TextBox tbxLength;
        private System.Windows.Forms.TextBox tbxBrand;
        private System.Windows.Forms.TextBox tbxProductName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelProductID;
        private System.Windows.Forms.Button btnOutOfStock;
        private System.Windows.Forms.ComboBox cbCategory;
    }
}