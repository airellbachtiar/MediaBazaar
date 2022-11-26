using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Media_Bazaar_Logic.Class;
using Media_Bazaar_Logic.Controllers;
using Media_Bazaar_Logic.DAL;
using Media_Bazaar_Logic.Enums;
using Media_Bazaar_Logic.Parsers;
using Contract = Media_Bazaar_Logic.Class.Contract;
using Media_Bazaar_Logic.ExportData;

namespace Media_Bazaar.Forms.Employee
{
    public partial class EmployeeOverlay : Form
    {

        
        
        User mainuser;
        ContractController ccontroller;
        User selecteduser;

        public EmployeeOverlay(User mainuser)
        {
            InitializeComponent();
            this.mainuser = mainuser;
            this.selecteduser = new User();
            UpdateComboBox();
            
            this.ccontroller = new ContractController();

            foreach (TabPage t in TBControlUser.TabPages)
            {
                TBControlUser.TabPages.Remove(t);
            }
            TBControlUser.TabPages.Add(tabOverview);

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (TBControlUser.SelectedTab.Name != "tabNewUser")
            {
                foreach (TabPage t in TBControlUser.TabPages)
                {
                    TBControlUser.TabPages.Remove(t);
                }
                TBControlUser.TabPages.Add(tabNewUser);
                
            }
        }

        


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            UpdateGUIUser();
        }

        public void UpdateGUIUser()
        {

            this.dgvEmployee.Rows.Clear();
            List<User> users;

            if (chckActive.Checked)
            {

                users = UserController.GetAllActiveUsersByDepartment(DepartmentController.GetDepartmentIDByName(cbxDepartmentOverview.Text));

            }
            else
            {

                users = UserController.GetAllInActiveUsersByDepartment(DepartmentController.GetDepartmentIDByName(cbxDepartmentOverview.Text));

            }

            foreach (User user in users)
            {
                dgvEmployee.Rows.Add(user.BSN, user.FirstName, user.SurName);
            }
        }



        private void btnOverview_Click(object sender, EventArgs e)
        {
            if (TBControlUser.SelectedTab.Name != "tabOverview")
            {
                foreach (TabPage t in TBControlUser.TabPages)
                {
                    TBControlUser.TabPages.Remove(t);
                }
                TBControlUser.TabPages.Add(tabOverview);
                UpdateGUIUser();





            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {

            if (dgvEmployee.SelectedRows.Count > 0)
            {

                int selectedindex = dgvEmployee.SelectedCells[0].RowIndex;
                DataGridViewRow selected = dgvEmployee.Rows[selectedindex];

                int BSN = Convert.ToInt32(selected.Cells["BSN"].Value);

                if (TBControlUser.SelectedTab.Name != "tabEditUser")
                {
                    foreach (TabPage t in TBControlUser.TabPages)
                    {
                        TBControlUser.TabPages.Remove(t);
                    }
                    TBControlUser.TabPages.Add(tabEditUser);
                    selecteduser = UserController.GetUserByBSN(BSN);
                    UpdateUserInfo();

                    Department dep = DepartmentController.GetDepartmentByID(selecteduser.Department);

                    cbxEditDepartment.SelectedItem = dep.DepartmentName;
                }

            }
            else
            {
                MessageBox.Show("Please select an employee in the list");
            }



        }

        public void UpdateUserInfo()
        {
            tbEditBSN.Text = Convert.ToString(selecteduser.BSN);
            tbxEditContactPerson.Text = Convert.ToString(selecteduser.ContactPerson);
            tbxEditPhoneNumber.Text = Convert.ToString(selecteduser.PhoneNumber);
            tbxEditFirstName.Text = selecteduser.FirstName;
            tbxEditSurname.Text = selecteduser.SurName;
            tbxEditUsername.Text = selecteduser.UserName;
            tbxEditFunction.Text = selecteduser.Job;
            tbxEditEmail.Text = selecteduser.Email;
            rtbxEditNote.Text = selecteduser.Note;


        }


        public void UpdateComboBox()
        {

            this.cbRole.Items.Clear();
            this.cbRole.Items.Add("Employee");
            this.cbRole.Items.Add("Manager");
            this.cbRole.Items.Add("Admin");

            this.cbxContract.Items.Clear();
            this.cbxContract.Items.Add("FullTime");
            this.cbxContract.Items.Add("PartTime");
            this.cbxContract.Items.Add("Flex");

            this.cbNewContractType.Items.Clear();
            this.cbNewContractType.Items.Add("FullTime");
            this.cbNewContractType.Items.Add("PartTime");
            this.cbNewContractType.Items.Add("Flex");


            cbxDepartmentOverview.Items.Clear();
            cbxNewDepartment.Items.Clear();
            cbxEditDepartment.Items.Clear();
            List<Department> departments;
            departments = DepartmentController.GetAllDepartments();
            foreach (Department department in departments)
            {
                cbxNewDepartment.Items.Add(department.DepartmentName);
                cbxDepartmentOverview.Items.Add(department.DepartmentName);
                cbxEditDepartment.Items.Add(department.DepartmentName);
            }

            Department dep = DepartmentController.GetDepartmentByID(mainuser.Department);

            cbxDepartmentOverview.SelectedItem = dep.DepartmentName;
            cbxNewDepartment.SelectedItem = dep.DepartmentName;

            if (mainuser.Role == RoleType.Manager)
            {
                cbRole.SelectedIndex = 0;
                cbRole.Enabled = false;
                cbxNewDepartment.Enabled = false;
                cbxEditDepartment.Enabled = false;
                cbxDepartmentOverview.Enabled = false;



            }
            else if (mainuser.Role == RoleType.Admin)
            {
                cbRole.SelectedIndex = 0;
                cbRole.Enabled = true;
                cbxNewDepartment.Enabled = true;
                cbxDepartmentOverview.Enabled = true;
                cbxEditDepartment.Enabled = true;


            }
        }


       




        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                if(tbxAddBSN.Text.Length != 9)
                {
                    MessageBox.Show("BSN is not correct");
                }
                else
                {

                    if(tbAddPhoneNumber.Text.Length != 10)
                    {
                        MessageBox.Show("Phone Number is incorrect");
                    }
                    else
                    {
                        UserController.CreateNewUser(
                        tbAddFirstName.Text,
                        tbAddSurname.Text,
                        tbAddUsername.Text,
                        tbxPassword.Text,
                        Convert.ToInt32(tbAddPhoneNumber.Text),
                        Convert.ToInt32(tbAddContactPerson.Text),
                        tbAddEmail.Text,
                        Convert.ToInt32(tbxAddBSN.Text),
                        (RoleType)Enum.Parse(typeof(RoleType), cbRole.Text),
                        tbAddFunction.Text,
                        DepartmentController.GetDepartmentIDByName(cbxNewDepartment.Text),
                        tbxAddNote.Text
                        );

                        ccontroller.CreateNewContract(
                        Convert.ToInt32(tbxAddBSN.Text),
                        (ContractType)Enum.Parse(typeof(ContractType), cbxContract.Text),
                        Convert.ToDouble(tbHourRate.Text),
                        datetimeStartDate.Value,
                        datetimeEndDate.Value
                        );



                        string result = cbRole.Text + " added to the system.";

                        // 
                        User newAddedUser = UserController.GetUserByBSN(Convert.ToInt32(tbxAddBSN.Text));
                        Contract contract = ContractParser.DataSetToUser(ContractDAL.GetContractByID(newAddedUser.ID), 0);
                        SchedulerController.AddUserAvail(newAddedUser.ID, (((int)contract.Contracttype) + 1));


                        tbAddPhoneNumber.Text = "";
                        tbAddContactPerson.Text = "";
                        tbAddEmail.Text = "";
                        tbAddFirstName.Text = "";
                        tbAddSurname.Text = "";
                        tbxAddBSN.Text = "";
                        tbxAddNote.Text = "";
                        tbAddUsername.Text = "";
                        tbxPassword.Text = "";

                        MessageBox.Show(result);





                    }
                }

                

               

            }
            catch
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbEditBSN.Text.Length != 9)
                {
                    MessageBox.Show("BSN is not correct");
                }
                else
                {

                    if (tbxEditPhoneNumber.Text.Length != 10)
                    {
                        MessageBox.Show("Phone Number is incorrect");
                    }
                    else
                    {


                        int phone = Convert.ToInt32(tbxEditPhoneNumber.Text);
                        int contact = Convert.ToInt32(tbxEditContactPerson.Text);
                        string email = tbxEditEmail.Text;
                        string function = tbxEditFunction.Text;
                        string note = rtbxEditNote.Text;
                        int bsn = Convert.ToInt32(tbEditBSN.Text);
                        int department = DepartmentController.GetDepartmentIDByName(cbxEditDepartment.Text);

                        UserController.EditUser(bsn, phone, contact, email, function, note, department);
                        MessageBox.Show("Update Succesfull");

                    }
                }
            }
            catch
            {

                MessageBox.Show("Fill in the correct fields");
            }
            
        }

        private void btnContract_Click(object sender, EventArgs e)
        {
            if (TBControlUser.SelectedTab.Name != "tabContract")
            {
                foreach (TabPage t in TBControlUser.TabPages)
                {
                    TBControlUser.TabPages.Remove(t);
                }
                TBControlUser.TabPages.Add(tabContract);
                updateInfoContract();





            }
        }

        private void btnFireEmployee_Click(object sender, EventArgs e)
        {
            int id = selecteduser.ID;
            
            List<Contract> contracts;
            contracts = ccontroller.GetContractsByID(id);
            DateTime latestcontract = DateTime.Now;

            foreach (Contract contract in contracts)
            {
                
                latestcontract = contract.StartDate;
            }




            ccontroller.FireEmployee(selecteduser.ID,dtpFireDate.Value,latestcontract);
            updateInfoContract();
            MessageBox.Show("User Contract Terminated");
        }

        private void btnNewContract_Click(object sender, EventArgs e)
        {

            double hourrate = Convert.ToDouble(tbNewHourRate.Text);

            try
            {
                ccontroller.CreateNewContract(
                selecteduser.BSN,
                (ContractType)Enum.Parse(typeof(ContractType), cbNewContractType.Text),
                hourrate,
                dtpNewStartDate.Value,
                dtpNewEndDate.Value
                );
                MessageBox.Show("Succesfully added a new contract");
                updateInfoContract();
            }
            catch
            {
                MessageBox.Show("Something went wrong");
            }
            
        }

        private void updateInfoContract()
        {

            int id = selecteduser.ID;
            this.dgvPreviousContracts.Rows.Clear();
            List<Contract> contracts;
            contracts = ccontroller.GetContractsByID(id);


            foreach (Contract contract in contracts)
            {
                dgvPreviousContracts.Rows.Add(contract.Contracttype, contract.HourRate, contract.StartDate.ToString("MM-dd-yyyy"), contract.EndDate.ToString("MM-dd-yyyy"));

                lblContractType.Text = Convert.ToString(contract.Contracttype);
                lblEndDate.Text = Convert.ToString(contract.EndDate.ToString("MM-dd-yyyy"));
                lblHourrate.Text = Convert.ToString(contract.HourRate);
                lblStartDate.Text = Convert.ToString(contract.StartDate.ToString("MM-dd-yyyy"));
            }






        }

        private void cbxDepartmentOverview_SelectedIndexChanged(object sender, EventArgs e)
        {

            UpdateGUIUser();


        }

        private void chckActive_CheckedChanged(object sender, EventArgs e)
        {
            UpdateGUIUser();
        }

        private void btnExportDataUser_Click(object sender, EventArgs e)
        {
            ExportData.Export(new UserExportData());
        }
    }
}
