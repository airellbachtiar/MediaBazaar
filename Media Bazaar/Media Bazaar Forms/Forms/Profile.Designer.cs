
namespace Media_Bazaar.Forms
{
    partial class Profile
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
            this.btnUpdateInfo = new System.Windows.Forms.Button();
            this.tbctrlProfile = new System.Windows.Forms.TabControl();
            this.tabProfile = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkChangePassword = new System.Windows.Forms.CheckBox();
            this.tbNewPassword = new System.Windows.Forms.TextBox();
            this.tbOldPassword = new System.Windows.Forms.TextBox();
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
            this.tbDepartment = new System.Windows.Forms.TextBox();
            this.tbJob = new System.Windows.Forms.TextBox();
            this.tbBSN = new System.Windows.Forms.TextBox();
            this.tbContactPhone = new System.Windows.Forms.TextBox();
            this.tbPhoneNumber = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbSurname = new System.Windows.Forms.TextBox();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.tabContract = new System.Windows.Forms.TabPage();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblHourrate = new System.Windows.Forms.Label();
            this.dgvPreviousContracts = new System.Windows.Forms.DataGridView();
            this.ContractType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HourRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblContractType = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnContract = new System.Windows.Forms.Button();
            this.tbctrlProfile.SuspendLayout();
            this.tabProfile.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabContract.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreviousContracts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdateInfo
            // 
            this.btnUpdateInfo.Location = new System.Drawing.Point(445, 333);
            this.btnUpdateInfo.Name = "btnUpdateInfo";
            this.btnUpdateInfo.Size = new System.Drawing.Size(97, 38);
            this.btnUpdateInfo.TabIndex = 0;
            this.btnUpdateInfo.Text = "Change Info";
            this.btnUpdateInfo.UseVisualStyleBackColor = true;
            this.btnUpdateInfo.Click += new System.EventHandler(this.btnUpdateInfo_Click);
            // 
            // tbctrlProfile
            // 
            this.tbctrlProfile.Controls.Add(this.tabProfile);
            this.tbctrlProfile.Controls.Add(this.tabContract);
            this.tbctrlProfile.Location = new System.Drawing.Point(12, 12);
            this.tbctrlProfile.Name = "tbctrlProfile";
            this.tbctrlProfile.SelectedIndex = 0;
            this.tbctrlProfile.Size = new System.Drawing.Size(581, 426);
            this.tbctrlProfile.TabIndex = 1;
            // 
            // tabProfile
            // 
            this.tabProfile.Controls.Add(this.panel1);
            this.tabProfile.Location = new System.Drawing.Point(4, 24);
            this.tabProfile.Name = "tabProfile";
            this.tabProfile.Padding = new System.Windows.Forms.Padding(3);
            this.tabProfile.Size = new System.Drawing.Size(573, 398);
            this.tabProfile.TabIndex = 0;
            this.tabProfile.Text = "Profile";
            this.tabProfile.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkChangePassword);
            this.panel1.Controls.Add(this.tbNewPassword);
            this.panel1.Controls.Add(this.tbOldPassword);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbDepartment);
            this.panel1.Controls.Add(this.tbJob);
            this.panel1.Controls.Add(this.tbBSN);
            this.panel1.Controls.Add(this.tbContactPhone);
            this.panel1.Controls.Add(this.tbPhoneNumber);
            this.panel1.Controls.Add(this.tbUsername);
            this.panel1.Controls.Add(this.tbSurname);
            this.panel1.Controls.Add(this.tbFirstName);
            this.panel1.Controls.Add(this.btnUpdateInfo);
            this.panel1.Location = new System.Drawing.Point(7, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 385);
            this.panel1.TabIndex = 1;
            // 
            // chkChangePassword
            // 
            this.chkChangePassword.AutoSize = true;
            this.chkChangePassword.Location = new System.Drawing.Point(24, 316);
            this.chkChangePassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkChangePassword.Name = "chkChangePassword";
            this.chkChangePassword.Size = new System.Drawing.Size(120, 19);
            this.chkChangePassword.TabIndex = 22;
            this.chkChangePassword.Text = "Change Password";
            this.chkChangePassword.UseVisualStyleBackColor = true;
            this.chkChangePassword.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // tbNewPassword
            // 
            this.tbNewPassword.Location = new System.Drawing.Point(167, 342);
            this.tbNewPassword.Name = "tbNewPassword";
            this.tbNewPassword.Size = new System.Drawing.Size(100, 23);
            this.tbNewPassword.TabIndex = 20;
            // 
            // tbOldPassword
            // 
            this.tbOldPassword.Location = new System.Drawing.Point(167, 282);
            this.tbOldPassword.Name = "tbOldPassword";
            this.tbOldPassword.PasswordChar = '*';
            this.tbOldPassword.Size = new System.Drawing.Size(100, 23);
            this.tbOldPassword.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 344);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 15);
            this.label10.TabIndex = 18;
            this.label10.Text = "New Password";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 282);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 15);
            this.label9.TabIndex = 17;
            this.label9.Text = "Password";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 242);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "Department";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "Job";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "BSN";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "ContactPerson Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "PhoneNumber";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Surname";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "FirstName";
            // 
            // tbDepartment
            // 
            this.tbDepartment.Enabled = false;
            this.tbDepartment.Location = new System.Drawing.Point(167, 240);
            this.tbDepartment.Name = "tbDepartment";
            this.tbDepartment.Size = new System.Drawing.Size(100, 23);
            this.tbDepartment.TabIndex = 8;
            // 
            // tbJob
            // 
            this.tbJob.Enabled = false;
            this.tbJob.Location = new System.Drawing.Point(167, 211);
            this.tbJob.Name = "tbJob";
            this.tbJob.Size = new System.Drawing.Size(100, 23);
            this.tbJob.TabIndex = 7;
            // 
            // tbBSN
            // 
            this.tbBSN.Enabled = false;
            this.tbBSN.Location = new System.Drawing.Point(167, 182);
            this.tbBSN.Name = "tbBSN";
            this.tbBSN.Size = new System.Drawing.Size(100, 23);
            this.tbBSN.TabIndex = 6;
            // 
            // tbContactPhone
            // 
            this.tbContactPhone.Location = new System.Drawing.Point(167, 153);
            this.tbContactPhone.Name = "tbContactPhone";
            this.tbContactPhone.Size = new System.Drawing.Size(100, 23);
            this.tbContactPhone.TabIndex = 5;
            // 
            // tbPhoneNumber
            // 
            this.tbPhoneNumber.Location = new System.Drawing.Point(167, 124);
            this.tbPhoneNumber.Name = "tbPhoneNumber";
            this.tbPhoneNumber.Size = new System.Drawing.Size(100, 23);
            this.tbPhoneNumber.TabIndex = 4;
            // 
            // tbUsername
            // 
            this.tbUsername.Enabled = false;
            this.tbUsername.Location = new System.Drawing.Point(167, 94);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(100, 23);
            this.tbUsername.TabIndex = 3;
            // 
            // tbSurname
            // 
            this.tbSurname.Location = new System.Drawing.Point(167, 66);
            this.tbSurname.Name = "tbSurname";
            this.tbSurname.Size = new System.Drawing.Size(100, 23);
            this.tbSurname.TabIndex = 2;
            // 
            // tbFirstName
            // 
            this.tbFirstName.Enabled = false;
            this.tbFirstName.Location = new System.Drawing.Point(167, 37);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(100, 23);
            this.tbFirstName.TabIndex = 1;
            // 
            // tabContract
            // 
            this.tabContract.Controls.Add(this.lblEndDate);
            this.tabContract.Controls.Add(this.lblStartDate);
            this.tabContract.Controls.Add(this.lblHourrate);
            this.tabContract.Controls.Add(this.dgvPreviousContracts);
            this.tabContract.Controls.Add(this.label16);
            this.tabContract.Controls.Add(this.label15);
            this.tabContract.Controls.Add(this.label14);
            this.tabContract.Controls.Add(this.label13);
            this.tabContract.Controls.Add(this.lblContractType);
            this.tabContract.Controls.Add(this.label11);
            this.tabContract.Location = new System.Drawing.Point(4, 24);
            this.tabContract.Name = "tabContract";
            this.tabContract.Padding = new System.Windows.Forms.Padding(3);
            this.tabContract.Size = new System.Drawing.Size(573, 398);
            this.tabContract.TabIndex = 1;
            this.tabContract.Text = "Contract";
            this.tabContract.UseVisualStyleBackColor = true;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(118, 145);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(77, 15);
            this.lblEndDate.TabIndex = 12;
            this.lblEndDate.Text = "ContractType";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(118, 108);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(77, 15);
            this.lblStartDate.TabIndex = 11;
            this.lblStartDate.Text = "ContractType";
            // 
            // lblHourrate
            // 
            this.lblHourrate.AutoSize = true;
            this.lblHourrate.Location = new System.Drawing.Point(118, 72);
            this.lblHourrate.Name = "lblHourrate";
            this.lblHourrate.Size = new System.Drawing.Size(77, 15);
            this.lblHourrate.TabIndex = 10;
            this.lblHourrate.Text = "ContractType";
            // 
            // dgvPreviousContracts
            // 
            this.dgvPreviousContracts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreviousContracts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ContractType,
            this.HourRate,
            this.StartDate,
            this.EndDate});
            this.dgvPreviousContracts.Location = new System.Drawing.Point(25, 177);
            this.dgvPreviousContracts.Name = "dgvPreviousContracts";
            this.dgvPreviousContracts.RowTemplate.Height = 25;
            this.dgvPreviousContracts.Size = new System.Drawing.Size(514, 176);
            this.dgvPreviousContracts.TabIndex = 9;
            // 
            // ContractType
            // 
            this.ContractType.HeaderText = "ContractType";
            this.ContractType.Name = "ContractType";
            // 
            // HourRate
            // 
            this.HourRate.HeaderText = "HourRate";
            this.HourRate.Name = "HourRate";
            // 
            // StartDate
            // 
            this.StartDate.HeaderText = "StartDate";
            this.StartDate.Name = "StartDate";
            // 
            // EndDate
            // 
            this.EndDate.HeaderText = "EndDate";
            this.EndDate.Name = "EndDate";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(25, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(96, 15);
            this.label16.TabIndex = 8;
            this.label16.Text = "Current Contract";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(25, 145);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 15);
            this.label15.TabIndex = 7;
            this.label15.Text = "EndDate:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(25, 108);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 15);
            this.label14.TabIndex = 6;
            this.label14.Text = "StartDate:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(25, 72);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 15);
            this.label13.TabIndex = 5;
            this.label13.Text = "Hourrate:";
            // 
            // lblContractType
            // 
            this.lblContractType.AutoSize = true;
            this.lblContractType.Location = new System.Drawing.Point(118, 36);
            this.lblContractType.Name = "lblContractType";
            this.lblContractType.Size = new System.Drawing.Size(77, 15);
            this.lblContractType.TabIndex = 4;
            this.lblContractType.Text = "ContractType";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 15);
            this.label11.TabIndex = 3;
            this.label11.Text = "ContractType:";
            // 
            // btnProfile
            // 
            this.btnProfile.Location = new System.Drawing.Point(624, 36);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(122, 66);
            this.btnProfile.TabIndex = 1;
            this.btnProfile.Text = "Show Profile";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnContract
            // 
            this.btnContract.Location = new System.Drawing.Point(624, 134);
            this.btnContract.Name = "btnContract";
            this.btnContract.Size = new System.Drawing.Size(122, 66);
            this.btnContract.TabIndex = 2;
            this.btnContract.Text = "Show Contract";
            this.btnContract.UseVisualStyleBackColor = true;
            this.btnContract.Click += new System.EventHandler(this.btnContract_Click);
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnContract);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.tbctrlProfile);
            this.Name = "Profile";
            this.Text = "Profile";
            this.tbctrlProfile.ResumeLayout(false);
            this.tabProfile.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabContract.ResumeLayout(false);
            this.tabContract.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreviousContracts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUpdateInfo;
        private System.Windows.Forms.TabControl tbctrlProfile;
        private System.Windows.Forms.TabPage tabProfile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDepartment;
        private System.Windows.Forms.TextBox tbJob;
        private System.Windows.Forms.TextBox tbBSN;
        private System.Windows.Forms.TextBox tbContactPhone;
        private System.Windows.Forms.TextBox tbPhoneNumber;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbSurname;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.TabPage tabContract;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnContract;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbNewPassword;
        private System.Windows.Forms.TextBox tbOldPassword;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkChangePassword;
        private System.Windows.Forms.DataGridView dgvPreviousContracts;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractType;
        private System.Windows.Forms.DataGridViewTextBoxColumn HourRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblContractType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblHourrate;
    }
}