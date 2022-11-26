
namespace Media_Bazaar.Forms
{
    partial class SellProductForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.numericUpDownStore = new System.Windows.Forms.NumericUpDown();
            this.btnSell = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownDepot = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDepot)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sell";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProductName.Location = new System.Drawing.Point(50, 9);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(157, 31);
            this.lblProductName.TabIndex = 1;
            this.lblProductName.Text = "Product name";
            // 
            // numericUpDownStore
            // 
            this.numericUpDownStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(250)))));
            this.numericUpDownStore.Location = new System.Drawing.Point(109, 96);
            this.numericUpDownStore.Name = "numericUpDownStore";
            this.numericUpDownStore.Size = new System.Drawing.Size(193, 27);
            this.numericUpDownStore.TabIndex = 2;
            // 
            // btnSell
            // 
            this.btnSell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(250)))));
            this.btnSell.Location = new System.Drawing.Point(109, 171);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(193, 29);
            this.btnSell.TabIndex = 3;
            this.btnSell.Text = "Sell";
            this.btnSell.UseVisualStyleBackColor = false;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "How much were sold?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Store stock";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Depot stock";
            // 
            // numericUpDownDepot
            // 
            this.numericUpDownDepot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(219)))), ((int)(((byte)(250)))));
            this.numericUpDownDepot.Location = new System.Drawing.Point(109, 129);
            this.numericUpDownDepot.Name = "numericUpDownDepot";
            this.numericUpDownDepot.Size = new System.Drawing.Size(193, 27);
            this.numericUpDownDepot.TabIndex = 7;
            // 
            // SellProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(392, 223);
            this.Controls.Add(this.numericUpDownDepot);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.numericUpDownStore);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.label1);
            this.Name = "SellProductForm";
            this.Text = "Sell product";
            this.Load += new System.EventHandler(this.SellProductForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDepot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.NumericUpDown numericUpDownStore;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownDepot;
    }
}