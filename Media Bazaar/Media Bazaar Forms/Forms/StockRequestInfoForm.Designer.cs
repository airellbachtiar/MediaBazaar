
namespace Media_Bazaar.Forms
{
    partial class StockRequestInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockRequestInfoForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageOrder = new System.Windows.Forms.TabPage();
            this.btnOrderConfirm = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPageDelivery = new System.Windows.Forms.TabPage();
            this.btnConfirmDelivery = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.BoxDepotStockDelivered = new System.Windows.Forms.NumericUpDown();
            this.boxStoreStockDelivered = new System.Windows.Forms.NumericUpDown();
            this.tabPageHandle = new System.Windows.Forms.TabPage();
            this.btnConfirmHandled = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPageFinished = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.lblStateInfo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblProductName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.boxStoreStock = new System.Windows.Forms.NumericUpDown();
            this.lblProductId = new System.Windows.Forms.Label();
            this.boxDepotStock = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageOrder.SuspendLayout();
            this.tabPageDelivery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoxDepotStockDelivered)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxStoreStockDelivered)).BeginInit();
            this.tabPageHandle.SuspendLayout();
            this.tabPageFinished.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxStoreStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxDepotStock)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Controls.Add(this.lblStateInfo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblState);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.lblProductName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.boxStoreStock);
            this.groupBox1.Controls.Add(this.lblProductId);
            this.groupBox1.Controls.Add(this.boxDepotStock);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(705, 572);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stock request";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(250)))));
            this.btnClose.Location = new System.Drawing.Point(605, 532);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 29);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageOrder);
            this.tabControl1.Controls.Add(this.tabPageDelivery);
            this.tabControl1.Controls.Add(this.tabPageHandle);
            this.tabControl1.Controls.Add(this.tabPageFinished);
            this.tabControl1.Location = new System.Drawing.Point(16, 358);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(548, 207);
            this.tabControl1.TabIndex = 15;
            this.tabControl1.TabIndexChanged += new System.EventHandler(this.TabIndexChangedTabControl);
            // 
            // tabPageOrder
            // 
            this.tabPageOrder.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageOrder.Controls.Add(this.btnOrderConfirm);
            this.tabPageOrder.Controls.Add(this.label6);
            this.tabPageOrder.Location = new System.Drawing.Point(4, 29);
            this.tabPageOrder.Name = "tabPageOrder";
            this.tabPageOrder.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOrder.Size = new System.Drawing.Size(540, 174);
            this.tabPageOrder.TabIndex = 0;
            this.tabPageOrder.Text = "Order";
            // 
            // btnOrderConfirm
            // 
            this.btnOrderConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(250)))));
            this.btnOrderConfirm.Location = new System.Drawing.Point(6, 139);
            this.btnOrderConfirm.Name = "btnOrderConfirm";
            this.btnOrderConfirm.Size = new System.Drawing.Size(94, 29);
            this.btnOrderConfirm.TabIndex = 1;
            this.btnOrderConfirm.Text = "Confirm";
            this.btnOrderConfirm.UseVisualStyleBackColor = false;
            this.btnOrderConfirm.Click += new System.EventHandler(this.btnOrderConfirm_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(467, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "When the stock has been ordered click the confirm button to confirm.";
            // 
            // tabPageDelivery
            // 
            this.tabPageDelivery.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageDelivery.Controls.Add(this.btnConfirmDelivery);
            this.tabPageDelivery.Controls.Add(this.label8);
            this.tabPageDelivery.Controls.Add(this.label7);
            this.tabPageDelivery.Controls.Add(this.BoxDepotStockDelivered);
            this.tabPageDelivery.Controls.Add(this.boxStoreStockDelivered);
            this.tabPageDelivery.Location = new System.Drawing.Point(4, 29);
            this.tabPageDelivery.Name = "tabPageDelivery";
            this.tabPageDelivery.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDelivery.Size = new System.Drawing.Size(540, 174);
            this.tabPageDelivery.TabIndex = 1;
            this.tabPageDelivery.Text = "Delivery";
            // 
            // btnConfirmDelivery
            // 
            this.btnConfirmDelivery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(250)))));
            this.btnConfirmDelivery.Location = new System.Drawing.Point(6, 139);
            this.btnConfirmDelivery.Name = "btnConfirmDelivery";
            this.btnConfirmDelivery.Size = new System.Drawing.Size(94, 29);
            this.btnConfirmDelivery.TabIndex = 11;
            this.btnConfirmDelivery.Text = "Confirm";
            this.btnConfirmDelivery.UseVisualStyleBackColor = false;
            this.btnConfirmDelivery.Click += new System.EventHandler(this.btnConfirmDelivery_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 51);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(158, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "Depot stock delivered:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "Store stock delivered:";
            // 
            // BoxDepotStockDelivered
            // 
            this.BoxDepotStockDelivered.Location = new System.Drawing.Point(176, 49);
            this.BoxDepotStockDelivered.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BoxDepotStockDelivered.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.BoxDepotStockDelivered.Name = "BoxDepotStockDelivered";
            this.BoxDepotStockDelivered.Size = new System.Drawing.Size(160, 27);
            this.BoxDepotStockDelivered.TabIndex = 8;
            // 
            // boxStoreStockDelivered
            // 
            this.boxStoreStockDelivered.Location = new System.Drawing.Point(176, 7);
            this.boxStoreStockDelivered.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.boxStoreStockDelivered.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.boxStoreStockDelivered.Name = "boxStoreStockDelivered";
            this.boxStoreStockDelivered.Size = new System.Drawing.Size(160, 27);
            this.boxStoreStockDelivered.TabIndex = 7;
            // 
            // tabPageHandle
            // 
            this.tabPageHandle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageHandle.Controls.Add(this.btnConfirmHandled);
            this.tabPageHandle.Controls.Add(this.label10);
            this.tabPageHandle.Controls.Add(this.label9);
            this.tabPageHandle.Location = new System.Drawing.Point(4, 29);
            this.tabPageHandle.Name = "tabPageHandle";
            this.tabPageHandle.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHandle.Size = new System.Drawing.Size(540, 174);
            this.tabPageHandle.TabIndex = 2;
            this.tabPageHandle.Text = "Handle";
            // 
            // btnConfirmHandled
            // 
            this.btnConfirmHandled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(250)))));
            this.btnConfirmHandled.Location = new System.Drawing.Point(6, 139);
            this.btnConfirmHandled.Name = "btnConfirmHandled";
            this.btnConfirmHandled.Size = new System.Drawing.Size(94, 29);
            this.btnConfirmHandled.TabIndex = 2;
            this.btnConfirmHandled.Text = "Confirm";
            this.btnConfirmHandled.UseVisualStyleBackColor = false;
            this.btnConfirmHandled.Click += new System.EventHandler(this.btnConfirmHandled_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(169, 20);
            this.label10.TabIndex = 1;
            this.label10.Text = "click the confirm button.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(486, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "When all the stock has been received and is back in the store and depot ";
            // 
            // tabPageFinished
            // 
            this.tabPageFinished.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.tabPageFinished.Controls.Add(this.label11);
            this.tabPageFinished.Location = new System.Drawing.Point(4, 29);
            this.tabPageFinished.Name = "tabPageFinished";
            this.tabPageFinished.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFinished.Size = new System.Drawing.Size(540, 174);
            this.tabPageFinished.TabIndex = 3;
            this.tabPageFinished.Text = "Finished";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(380, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "This stock request is handled. There is nothing left to do.";
            // 
            // lblStateInfo
            // 
            this.lblStateInfo.AutoSize = true;
            this.lblStateInfo.Location = new System.Drawing.Point(16, 322);
            this.lblStateInfo.Name = "lblStateInfo";
            this.lblStateInfo.Size = new System.Drawing.Size(125, 20);
            this.lblStateInfo.TabIndex = 14;
            this.lblStateInfo.Text = "State information";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(517, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Handled";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(200, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Open";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 285);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Progress so far:";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(16, 233);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(137, 20);
            this.lblState.TabIndex = 10;
            this.lblState.Text = "Stock request state:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(200, 285);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(383, 29);
            this.progressBar1.TabIndex = 9;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(16, 89);
            this.lblProductName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(104, 20);
            this.lblProductName.TabIndex = 8;
            this.lblProductName.Text = "Product name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 133);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Requested store stock:";
            // 
            // boxStoreStock
            // 
            this.boxStoreStock.Enabled = false;
            this.boxStoreStock.Location = new System.Drawing.Point(200, 129);
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
            // lblProductId
            // 
            this.lblProductId.AutoSize = true;
            this.lblProductId.Location = new System.Drawing.Point(16, 55);
            this.lblProductId.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblProductId.Name = "lblProductId";
            this.lblProductId.Size = new System.Drawing.Size(80, 20);
            this.lblProductId.TabIndex = 2;
            this.lblProductId.Text = "Product id:";
            this.lblProductId.Click += new System.EventHandler(this.lblProductId_Click);
            // 
            // boxDepotStock
            // 
            this.boxDepotStock.Enabled = false;
            this.boxDepotStock.Location = new System.Drawing.Point(200, 184);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 185);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Requested depot stock:";
            // 
            // StockRequestInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(725, 618);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StockRequestInfoForm";
            this.Text = "StockRequestInfoForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageOrder.ResumeLayout(false);
            this.tabPageOrder.PerformLayout();
            this.tabPageDelivery.ResumeLayout(false);
            this.tabPageDelivery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoxDepotStockDelivered)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxStoreStockDelivered)).EndInit();
            this.tabPageHandle.ResumeLayout(false);
            this.tabPageHandle.PerformLayout();
            this.tabPageFinished.ResumeLayout(false);
            this.tabPageFinished.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxStoreStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxDepotStock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown boxStoreStock;
        private System.Windows.Forms.Label lblProductId;
        private System.Windows.Forms.NumericUpDown boxDepotStock;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblStateInfo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageOrder;
        private System.Windows.Forms.TabPage tabPageDelivery;
        private System.Windows.Forms.TabPage tabPageHandle;
        private System.Windows.Forms.Button btnOrderConfirm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnConfirmDelivery;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown BoxDepotStockDelivered;
        private System.Windows.Forms.NumericUpDown boxStoreStockDelivered;
        private System.Windows.Forms.Button btnConfirmHandled;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPageFinished;
        private System.Windows.Forms.Label label11;
    }
}