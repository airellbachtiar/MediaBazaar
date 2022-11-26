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
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();


            
                foreach (TabPage t in tbctrlCategory.TabPages)
                {
                    tbctrlCategory.TabPages.Remove(t);
                }
                tbctrlCategory.TabPages.Add(tabAddCategory);
                

            

        }


        



        private void btnAddNewCategory_Click(object sender, EventArgs e)
        {

            if(tbAddCategoryName.Text != "")
            {

                string cname = tbAddCategoryName.Text;

                ProductCategory pc = new ProductCategory(cname);
                ProductController.AddNewCategory (pc);

                tbAddCategoryName.Text = "";

                MessageBox.Show("Category Added");


            }
            else
            {
                MessageBox.Show("Fill in the name field");
            }

            
            

        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (tbctrlCategory.SelectedTab.Name != "tabAddCategory")
            {
                foreach (TabPage t in tbctrlCategory.TabPages)
                {
                    tbctrlCategory.TabPages.Remove(t);
                }
                tbctrlCategory.TabPages.Add(tabAddCategory);


            }
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            if (tbctrlCategory.SelectedTab.Name != "tabEditCategory")
            {
                foreach (TabPage t in tbctrlCategory.TabPages)
                {
                    tbctrlCategory.TabPages.Remove(t);
                }
                tbctrlCategory.TabPages.Add(tabEditCategory);
                UpdateGUICategory();
            }

        }

        public void UpdateGUICategory()
        {

            this.dgvCategory.Rows.Clear();

            List<ProductCategory> list = ProductController.GetAllCategorys();

            foreach (ProductCategory pc in list)
            {
                dgvCategory.Rows.Add(pc.ID,pc.Name);
            }
        }




        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            

            int selectedindex = dgvCategory.SelectedCells[0].RowIndex;
            DataGridViewRow selected = dgvCategory.Rows[selectedindex];

            int CategoryID = Convert.ToInt32(selected.Cells["CategoryID"].Value);
            string CategoryName = Convert.ToString(selected.Cells["CategoryName"].Value);

            lblSelectedID.Text = Convert.ToString(CategoryID);
            tbEditSelectedName.Text = CategoryName;



        }

        private void btnEditOldCategory_Click(object sender, EventArgs e)
        {
            if (lblSelectedID.Text != "")
            {

                if(tbEditSelectedName.Text != "")
                {

                    ProductCategory pc = new ProductCategory(Convert.ToInt32(lblSelectedID.Text),tbEditSelectedName.Text);

                    ProductController.UpdateCategory(pc);


                    MessageBox.Show("Succesfully adjusted category");

                    lblSelectedID.Text = "";
                    tbEditSelectedName.Text = "";


                }
                else
                {
                    MessageBox.Show("Please fill in a new name for the category");
                }

            }
            else
            {
                MessageBox.Show("Please select a category in the list");
            }
        }
    }
}
