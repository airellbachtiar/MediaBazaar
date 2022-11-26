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
using Contract = Media_Bazaar_Logic.Class.Contract;

namespace Media_Bazaar.Forms
{

    


    public partial class Profile : Form
    {

        User mainuser;
        UserController ucontroller;
        ContractController ccontroller;

        public Profile(User user)
        {
            mainuser = user;
            InitializeComponent();
            updateInfoProfile();
            ccontroller = new ContractController();
            this.ucontroller = new UserController();

            if (tbctrlProfile.SelectedTab.Name != "tabProfile")
            {
                foreach (TabPage t in tbctrlProfile.TabPages)
                {
                    tbctrlProfile.TabPages.Remove(t);
                }
                tbctrlProfile.TabPages.Add(tabProfile);
                

            }


        }

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {

            if (PasswordHashingHelper.StringToHash(tbOldPassword.Text) == mainuser.Password)
            {
                if (chkChangePassword.Checked == false)
                {
                    UserController.UpdateProfile(
                        mainuser.ID,
                        Convert.ToInt64(tbPhoneNumber.Text),
                        Convert.ToInt64(tbContactPhone.Text),
                        tbSurname.Text
                        );
                        MessageBox.Show("Your profile details have been updated");
                        
                }
                else
                {
                    UserController.UpdatePassword(
                        mainuser.ID,
                        tbNewPassword.Text
                        );
                    MessageBox.Show("Your password has been updated!");
                }

                tbOldPassword.Text = "";
            }
            else
            {
                MessageBox.Show("Password is incorrect");
            }

            
        }

        private void updateInfoProfile()
        {
            tbFirstName.Text = mainuser.FirstName;
            tbSurname.Text = mainuser.SurName;
            tbUsername.Text = mainuser.UserName;
            tbPhoneNumber.Text = Convert.ToString(mainuser.PhoneNumber);
            tbContactPhone.Text = Convert.ToString(mainuser.ContactPerson);
            tbBSN.Text = Convert.ToString(mainuser.BSN);
            tbJob.Text = mainuser.Job;

            Department dep = DepartmentController.GetDepartmentByID(mainuser.Department);

            tbDepartment.Text = dep.DepartmentName;

        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            if (chkChangePassword.Checked)
            {
                tbNewPassword.Enabled = true;
                tbPhoneNumber.Enabled = false;
                tbSurname.Enabled = false;
                tbContactPhone.Enabled = false;
            }
            else
            {
                tbNewPassword.Enabled = false;
                tbPhoneNumber.Enabled = true;
                tbSurname.Enabled = true;
                tbContactPhone.Enabled = true;
            }

        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            if (tbctrlProfile.SelectedTab.Name != "tabProfile")
            {
                foreach (TabPage t in tbctrlProfile.TabPages)
                {
                    tbctrlProfile.TabPages.Remove(t);
                }
                tbctrlProfile.TabPages.Add(tabProfile);
                updateInfoProfile();
            }
        }

        private void btnContract_Click(object sender, EventArgs e)
        {

            if (tbctrlProfile.SelectedTab.Name != "tabContract")
            {
                foreach (TabPage t in tbctrlProfile.TabPages)
                {
                    tbctrlProfile.TabPages.Remove(t);
                }
                tbctrlProfile.TabPages.Add(tabContract);
                updateInfoContract();

            }

        }




        private void updateInfoContract()
        {

            int id = mainuser.ID;
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

        


    }
}
