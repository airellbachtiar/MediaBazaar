
namespace Media_Bazaar.Forms
{
    partial class DepartmentForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabAddNewDepartment = new System.Windows.Forms.TabPage();
            this.btnAddNewDepartment = new System.Windows.Forms.Button();
            this.rtbxDescription = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.tabOverview = new System.Windows.Forms.TabPage();
            this.dgvDepartments = new System.Windows.Forms.DataGridView();
            this.departmentid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditDepartmentPage = new System.Windows.Forms.Button();
            this.tabEditDepartment = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddTab = new System.Windows.Forms.Button();
            this.btnOverview = new System.Windows.Forms.Button();
            this.tbEditDepartmentName = new System.Windows.Forms.TextBox();
            this.tbEditDepartmentDescription = new System.Windows.Forms.TextBox();
            this.btnEditDepartment = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDepId = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabAddNewDepartment.SuspendLayout();
            this.tabOverview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).BeginInit();
            this.tabEditDepartment.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl);
            this.panel2.Controls.Add(this.btnAddTab);
            this.panel2.Controls.Add(this.btnOverview);
            this.panel2.Location = new System.Drawing.Point(13, 12);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(804, 426);
            this.panel2.TabIndex = 14;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabAddNewDepartment);
            this.tabControl.Controls.Add(this.tabOverview);
            this.tabControl.Controls.Add(this.tabEditDepartment);
            this.tabControl.Location = new System.Drawing.Point(3, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(561, 420);
            this.tabControl.TabIndex = 42;
            // 
            // tabAddNewDepartment
            // 
            this.tabAddNewDepartment.Controls.Add(this.btnAddNewDepartment);
            this.tabAddNewDepartment.Controls.Add(this.rtbxDescription);
            this.tabAddNewDepartment.Controls.Add(this.label1);
            this.tabAddNewDepartment.Controls.Add(this.label12);
            this.tabAddNewDepartment.Controls.Add(this.tbxName);
            this.tabAddNewDepartment.Location = new System.Drawing.Point(4, 24);
            this.tabAddNewDepartment.Name = "tabAddNewDepartment";
            this.tabAddNewDepartment.Padding = new System.Windows.Forms.Padding(3);
            this.tabAddNewDepartment.Size = new System.Drawing.Size(553, 392);
            this.tabAddNewDepartment.TabIndex = 0;
            this.tabAddNewDepartment.Text = "New Department";
            this.tabAddNewDepartment.UseVisualStyleBackColor = true;
            // 
            // btnAddNewDepartment
            // 
            this.btnAddNewDepartment.Location = new System.Drawing.Point(141, 309);
            this.btnAddNewDepartment.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddNewDepartment.Name = "btnAddNewDepartment";
            this.btnAddNewDepartment.Size = new System.Drawing.Size(139, 36);
            this.btnAddNewDepartment.TabIndex = 43;
            this.btnAddNewDepartment.Text = "Add new department";
            this.btnAddNewDepartment.UseVisualStyleBackColor = true;
            this.btnAddNewDepartment.Click += new System.EventHandler(this.btnAddNewDepartment_Click);
            // 
            // rtbxDescription
            // 
            this.rtbxDescription.Location = new System.Drawing.Point(141, 166);
            this.rtbxDescription.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rtbxDescription.Name = "rtbxDescription";
            this.rtbxDescription.Size = new System.Drawing.Size(226, 104);
            this.rtbxDescription.TabIndex = 37;
            this.rtbxDescription.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 111);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(138, 148);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 15);
            this.label12.TabIndex = 24;
            this.label12.Text = "Description";
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(213, 108);
            this.tbxName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(154, 23);
            this.tbxName.TabIndex = 25;
            // 
            // tabOverview
            // 
            this.tabOverview.Controls.Add(this.dgvDepartments);
            this.tabOverview.Controls.Add(this.btnEditDepartmentPage);
            this.tabOverview.Location = new System.Drawing.Point(4, 24);
            this.tabOverview.Name = "tabOverview";
            this.tabOverview.Padding = new System.Windows.Forms.Padding(3);
            this.tabOverview.Size = new System.Drawing.Size(553, 392);
            this.tabOverview.TabIndex = 1;
            this.tabOverview.Text = "Overview";
            this.tabOverview.UseVisualStyleBackColor = true;
            // 
            // dgvDepartments
            // 
            this.dgvDepartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.departmentid,
            this.departmentname,
            this.description});
            this.dgvDepartments.Location = new System.Drawing.Point(6, 6);
            this.dgvDepartments.Name = "dgvDepartments";
            this.dgvDepartments.RowTemplate.Height = 25;
            this.dgvDepartments.Size = new System.Drawing.Size(420, 380);
            this.dgvDepartments.TabIndex = 40;
            // 
            // departmentid
            // 
            this.departmentid.HeaderText = "ID";
            this.departmentid.Name = "departmentid";
            // 
            // departmentname
            // 
            this.departmentname.HeaderText = "Department";
            this.departmentname.Name = "departmentname";
            // 
            // description
            // 
            this.description.HeaderText = "Description";
            this.description.Name = "description";
            // 
            // btnEditDepartmentPage
            // 
            this.btnEditDepartmentPage.Location = new System.Drawing.Point(433, 290);
            this.btnEditDepartmentPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEditDepartmentPage.Name = "btnEditDepartmentPage";
            this.btnEditDepartmentPage.Size = new System.Drawing.Size(113, 48);
            this.btnEditDepartmentPage.TabIndex = 39;
            this.btnEditDepartmentPage.Text = "Edit Department";
            this.btnEditDepartmentPage.UseVisualStyleBackColor = true;
            this.btnEditDepartmentPage.Click += new System.EventHandler(this.btnEditDepartmentPage_Click);
            // 
            // tabEditDepartment
            // 
            this.tabEditDepartment.Controls.Add(this.lblDepId);
            this.tabEditDepartment.Controls.Add(this.label4);
            this.tabEditDepartment.Controls.Add(this.btnEditDepartment);
            this.tabEditDepartment.Controls.Add(this.tbEditDepartmentDescription);
            this.tabEditDepartment.Controls.Add(this.tbEditDepartmentName);
            this.tabEditDepartment.Controls.Add(this.label3);
            this.tabEditDepartment.Controls.Add(this.label2);
            this.tabEditDepartment.Location = new System.Drawing.Point(4, 24);
            this.tabEditDepartment.Name = "tabEditDepartment";
            this.tabEditDepartment.Size = new System.Drawing.Size(553, 392);
            this.tabEditDepartment.TabIndex = 2;
            this.tabEditDepartment.Text = "Edit Department";
            this.tabEditDepartment.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "DepartmentDescription:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "DepartmentName:";
            // 
            // btnAddTab
            // 
            this.btnAddTab.Location = new System.Drawing.Point(643, 27);
            this.btnAddTab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddTab.Name = "btnAddTab";
            this.btnAddTab.Size = new System.Drawing.Size(127, 53);
            this.btnAddTab.TabIndex = 41;
            this.btnAddTab.Text = "Add";
            this.btnAddTab.UseVisualStyleBackColor = true;
            this.btnAddTab.Click += new System.EventHandler(this.btnAddTab_Click);
            // 
            // btnOverview
            // 
            this.btnOverview.Location = new System.Drawing.Point(643, 101);
            this.btnOverview.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnOverview.Name = "btnOverview";
            this.btnOverview.Size = new System.Drawing.Size(127, 51);
            this.btnOverview.TabIndex = 38;
            this.btnOverview.Text = "Overview";
            this.btnOverview.UseVisualStyleBackColor = true;
            this.btnOverview.Click += new System.EventHandler(this.btnOverview_Click);
            // 
            // tbEditDepartmentName
            // 
            this.tbEditDepartmentName.Location = new System.Drawing.Point(211, 106);
            this.tbEditDepartmentName.Name = "tbEditDepartmentName";
            this.tbEditDepartmentName.Size = new System.Drawing.Size(100, 23);
            this.tbEditDepartmentName.TabIndex = 2;
            // 
            // tbEditDepartmentDescription
            // 
            this.tbEditDepartmentDescription.Location = new System.Drawing.Point(211, 191);
            this.tbEditDepartmentDescription.Multiline = true;
            this.tbEditDepartmentDescription.Name = "tbEditDepartmentDescription";
            this.tbEditDepartmentDescription.Size = new System.Drawing.Size(129, 61);
            this.tbEditDepartmentDescription.TabIndex = 3;
            // 
            // btnEditDepartment
            // 
            this.btnEditDepartment.Location = new System.Drawing.Point(364, 220);
            this.btnEditDepartment.Name = "btnEditDepartment";
            this.btnEditDepartment.Size = new System.Drawing.Size(102, 32);
            this.btnEditDepartment.TabIndex = 4;
            this.btnEditDepartment.Text = "Edit Department";
            this.btnEditDepartment.UseVisualStyleBackColor = true;
            this.btnEditDepartment.Click += new System.EventHandler(this.btnEditDepartment_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "DepartmentID:";
            // 
            // lblDepId
            // 
            this.lblDepId.AutoSize = true;
            this.lblDepId.Location = new System.Drawing.Point(211, 74);
            this.lblDepId.Name = "lblDepId";
            this.lblDepId.Size = new System.Drawing.Size(105, 15);
            this.lblDepId.TabIndex = 6;
            this.lblDepId.Text = "DepartmentName:";
            // 
            // DepartmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "DepartmentForm";
            this.Text = "DepartmentForm";
            this.panel2.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabAddNewDepartment.ResumeLayout(false);
            this.tabAddNewDepartment.PerformLayout();
            this.tabOverview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).EndInit();
            this.tabEditDepartment.ResumeLayout(false);
            this.tabEditDepartment.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAddTab;
        private System.Windows.Forms.Button btnEditDepartmentPage;
        private System.Windows.Forms.Button btnOverview;
        private System.Windows.Forms.RichTextBox rtbxDescription;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabAddNewDepartment;
        private System.Windows.Forms.Button btnAddNewDepartment;
        private System.Windows.Forms.TabPage tabOverview;
        private System.Windows.Forms.TabPage tabEditDepartment;
        private System.Windows.Forms.DataGridView dgvDepartments;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentid;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentname;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEditDepartment;
        private System.Windows.Forms.TextBox tbEditDepartmentDescription;
        private System.Windows.Forms.TextBox tbEditDepartmentName;
        private System.Windows.Forms.Label lblDepId;
        private System.Windows.Forms.Label label4;
    }
}