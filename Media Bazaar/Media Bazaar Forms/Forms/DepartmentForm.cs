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

namespace Media_Bazaar.Forms
{
    public partial class DepartmentForm : Form
    {

        

        public DepartmentForm()
        {
            InitializeComponent();
            


            startup();


        }


        public void startup()
        {
            if (tabControl.SelectedTab.Name != "tabAddNewDepartment")
            {
                foreach (TabPage t in tabControl.TabPages)
                {
                    tabControl.TabPages.Remove(t);
                }
                tabControl.TabPages.Add(tabAddNewDepartment);


            }
        }




        private void btnAddNewDepartment_Click(object sender, EventArgs e)
        {


            try
            {
                string depname = tbxName.Text;
                string depdescription = rtbxDescription.Text;
                DepartmentController.AddNewDepartment(depname,depdescription);
                MessageBox.Show("Department Added");
                if (tabControl.SelectedTab.Name != "tabOverview")
                {
                    foreach (TabPage t in tabControl.TabPages)
                    {
                        tabControl.TabPages.Remove(t);
                    }
                    tabControl.TabPages.Add(tabOverview);


                }
                UpdateGUIDepartment();
            }
            catch
            {
                MessageBox.Show("Fill in the fields");
            }

            
        }

        private void btnOverview_Click(object sender, EventArgs e)
        {

            if (tabControl.SelectedTab.Name != "tabOverview")
            {
                foreach (TabPage t in tabControl.TabPages)
                {
                    tabControl.TabPages.Remove(t);
                }
                tabControl.TabPages.Add(tabOverview);


            }

            UpdateGUIDepartment();
        }

        public void UpdateGUIDepartment()
        {
            dgvDepartments.Rows.Clear();
            List<Department> departments;
            departments = DepartmentController.GetAllDepartments();
            foreach (Department department in departments)
            {
                dgvDepartments.Rows.Add(department.DepartmentID, department.DepartmentName, department.Description);
            }
        }

        private void btnEditDepartment_Click(object sender, EventArgs e)
        {
            try
            {

                int id = Convert.ToInt32(lblDepId.Text);
                string name = tbEditDepartmentName.Text;
                string description = tbEditDepartmentDescription.Text;

                DepartmentController.UpdateDepartment(id, name, description);

                MessageBox.Show("Updated Department");

                if (tabControl.SelectedTab.Name != "tabOverview")
                {
                    foreach (TabPage t in tabControl.TabPages)
                    {
                        tabControl.TabPages.Remove(t);
                    }
                    tabControl.TabPages.Add(tabOverview);


                }
                UpdateGUIDepartment();


            }
            catch
            {
                MessageBox.Show("Fill in the fields");
            }
        }

        private void btnEditDepartmentPage_Click(object sender, EventArgs e)
        {

            if (dgvDepartments.SelectedRows.Count > 0)
            {

                int selectedindex = dgvDepartments.SelectedCells[0].RowIndex;
                DataGridViewRow selected = dgvDepartments.Rows[selectedindex];

                int depid = Convert.ToInt32(selected.Cells["departmentid"].Value);
                string depname = Convert.ToString(selected.Cells["departmentname"].Value);
                string description = Convert.ToString(selected.Cells["description"].Value);

                tbEditDepartmentName.Text = depname;
                tbEditDepartmentDescription.Text = description;
                lblDepId.Text = Convert.ToString(depid);

                if (tabControl.SelectedTab.Name != "tabEditDepartment")
                {
                    foreach (TabPage t in tabControl.TabPages)
                    {
                        tabControl.TabPages.Remove(t);
                    }
                    tabControl.TabPages.Add(tabEditDepartment);


                }



            }
            else
            {
                MessageBox.Show("Select a department first!");
            }

            

            


            

        }

        private void btnAddTab_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name != "tabAddNewDepartment")
            {
                foreach (TabPage t in tabControl.TabPages)
                {
                    tabControl.TabPages.Remove(t);
                }
                tabControl.TabPages.Add(tabAddNewDepartment);
                
                
            }
        }
    }
}
