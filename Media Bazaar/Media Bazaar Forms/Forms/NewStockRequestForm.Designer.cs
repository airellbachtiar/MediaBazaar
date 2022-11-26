
namespace Media_Bazaar.Forms
{
    partial class NewStockRequestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewStockRequestForm));
            this.btnRequest = new System.Windows.Forms.Button();
            this.lblProduct = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.boxStoreStock = new System.Windows.Forms.NumericUpDown();
            this.boxDepotStock = new System.Windows.Forms.NumericUpDown();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSelectedProduct = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listViewProducts = new System.Windows.Forms.ListView();
            this.columnId = new System.Windows.Forms.ColumnHeader();
            this.columnName = new System.Windows.Forms.ColumnHeader();
            this.columnStockStore = new System.Windows.Forms.ColumnHeader();
            this.columnStockDepot = new System.Windows.Forms.ColumnHeader();
            this.boxSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.boxStoreStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxDepotStock)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRequest
            // 
            this.btnRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(250)))));
            this.btnRequest.Location = new System.Drawing.Point(666, 515);
            this.btnRequest.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(119, 47);
            this.btnRequest.TabIndex = 0;
            this.btnRequest.Text = "Request";
            this.btnRequest.UseVisualStyleBackColor = false;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(16, 216);
            this.lblProduct.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(63, 20);
            this.lblProduct.TabIndex = 2;
            this.lblProduct.Text = "Product:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Request Store Stock:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 155);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Request Depot Stock:";
            // 
            // boxStoreStock
            // 
            this.boxStoreStock.Location = new System.Drawing.Point(200, 100);
            this.boxStoreStock.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.boxStoreStock.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.boxStoreStock.Name = "boxStoreStock";
            this.boxStoreStock.Size = new System.Drawing.Size(160, 27);
            this.boxStoreStock.TabIndex = 6;
            // 
            // boxDepotStock
            // 
            this.boxDepotStock.Location = new System.Drawing.Point(200, 155);
            this.boxDepotStock.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.boxDepotStock.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.boxDepotStock.Name = "boxDepotStock";
            this.boxDepotStock.Size = new System.Drawing.Size(160, 27);
            this.boxDepotStock.TabIndex = 7;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(16, 47);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(130, 20);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "New stock request";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.lblSelectedProduct);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.listViewProducts);
            this.groupBox1.Controls.Add(this.boxSearch);
            this.groupBox1.Controls.Add(this.lblTitle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.boxStoreStock);
            this.groupBox1.Controls.Add(this.lblProduct);
            this.groupBox1.Controls.Add(this.boxDepotStock);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnRequest);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(793, 572);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stock request";
            // 
            // lblSelectedProduct
            // 
            this.lblSelectedProduct.AutoSize = true;
            this.lblSelectedProduct.Location = new System.Drawing.Point(514, 529);
            this.lblSelectedProduct.Name = "lblSelectedProduct";
            this.lblSelectedProduct.Size = new System.Drawing.Size(0, 20);
            this.lblSelectedProduct.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(394, 528);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Selected product:";
            // 
            // listViewProducts
            // 
            this.listViewProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(250)))));
            this.listViewProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnId,
            this.columnName,
            this.columnStockStore,
            this.columnStockDepot});
            this.listViewProducts.FullRowSelect = true;
            this.listViewProducts.HideSelection = false;
            this.listViewProducts.Location = new System.Drawing.Point(16, 295);
            this.listViewProducts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listViewProducts.Name = "listViewProducts";
            this.listViewProducts.Size = new System.Drawing.Size(371, 265);
            this.listViewProducts.TabIndex = 13;
            this.listViewProducts.UseCompatibleStateImageBehavior = false;
            this.listViewProducts.View = System.Windows.Forms.View.Details;
            this.listViewProducts.SelectedIndexChanged += new System.EventHandler(this.ListViewSelectedIndexChanged);
            // 
            // columnId
            // 
            this.columnId.Text = "Id";
            this.columnId.Width = 30;
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 117;
            // 
            // columnStockStore
            // 
            this.columnStockStore.Text = "Store stock";
            this.columnStockStore.Width = 85;
            // 
            // columnStockDepot
            // 
            this.columnStockDepot.Text = "Depot stock";
            this.columnStockDepot.Width = 95;
            // 
            // boxSearch
            // 
            this.boxSearch.Location = new System.Drawing.Point(16, 255);
            this.boxSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.boxSearch.Name = "boxSearch";
            this.boxSearch.PlaceholderText = "Search by product id or name";
            this.boxSearch.Size = new System.Drawing.Size(343, 27);
            this.boxSearch.TabIndex = 11;
            this.boxSearch.TextChanged += new System.EventHandler(this.BoxSearchTextChanged);
            // 
            // NewStockRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(818, 589);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "NewStockRequestForm";
            this.Text = "StockRequestForm";
            ((System.ComponentModel.ISupportInitialize)(this.boxStoreStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxDepotStock)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown boxStoreStock;
        private System.Windows.Forms.NumericUpDown boxDepotStock;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox boxSearch;
        private System.Windows.Forms.ListView listViewProducts;
        private System.Windows.Forms.ColumnHeader columnId;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnStockStore;
        private System.Windows.Forms.ColumnHeader columnStockDepot;
        private System.Windows.Forms.Label lblSelectedProduct;
        private System.Windows.Forms.Label label4;
    }
}