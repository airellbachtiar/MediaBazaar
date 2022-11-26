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

namespace Media_Bazaar.Forms
{
    public partial class ProductForm : Form
    {
        private ProductController productController;
        private Product workingProduct;

        //This method is called when you create a new Product
        public ProductForm(ProductController productController)
        {
            this.productController = productController;
            InitializeComponent();
            btnOutOfStock.Enabled = false;
            btnEdit.Enabled = false;

            UpdateCBCategory();
        }

        private void UpdateCBCategory()
        {
            cbCategory.Items.Clear();
            List<ProductCategory> list = ProductController.GetAllCategorys();

            foreach (ProductCategory pc in list)
            {
                cbCategory.Items.Add(pc.Name);
            }
            cbCategory.SelectedIndex = 0;
        }



        //This method is called when you view an existing Product
        public ProductForm(ProductController productController, Product product)
        {
            this.productController = productController;
            this.workingProduct = product;
            InitializeComponent();
            UpdateCBCategory();
            tbxProductName.Text = product.Name;
            tbxBrand.Text = product.Brand;
            tbxLength.Text = product.Length.ToString();
            tbxWidth.Text = product.Width.ToString();
            tbxHeight.Text = product.Height.ToString();
            tbxSellingPrice.Text = product.SellingPrice.ToString();
            tbxPriceWithoutVAT.Text = product.PriceWithoutVAT.ToString();
            tbxDepotStock.Text = product.DepotStock.ToString();
            tbxStoreStock.Text = product.StoreStock.ToString();
            tbxDepotLocation.Text = product.DepotLocation;
            cbCategory.SelectedIndex = product.Category.ID-1;
            rtbxDescription.Text = product.Description;
            labelProductID.Visible = true;
            labelProductID.Text = "Product ID: " + product.Id;

            btnAdd.Visible = false;
            btnOutOfStock.Enabled = true;
            btnEdit.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = tbxProductName.Text;
            string brand = tbxBrand.Text;
            double length;
            double width;
            double height;
            double sellingPrice;
            double priceWithoutVAT;
            int depotStock;
            int storeStock;
            try
            {
                length = Convert.ToDouble(tbxLength.Text);
                width = Convert.ToDouble(tbxWidth.Text);
                height = Convert.ToDouble(tbxHeight.Text);
                sellingPrice = Convert.ToDouble(tbxSellingPrice.Text);
                priceWithoutVAT = Convert.ToDouble(tbxPriceWithoutVAT.Text);
                depotStock = Convert.ToInt32(tbxDepotStock.Text);
                storeStock = Convert.ToInt32(tbxStoreStock.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("One or more boxes contain letters or are empy while they must contain numbers. Please check and try again.");
                return;
            }
            string depotLocation = tbxDepotLocation.Text;

            ProductCategory category = ProductController.GetCategoryByID(cbCategory.SelectedIndex+1);
            string description = rtbxDescription.Text;
            Product p = new Product(name, brand, length, width, height, sellingPrice, priceWithoutVAT, depotStock, storeStock, depotLocation, category, description);

            try
            {
                if (ContainsEmptyFields(p))
                {
                    throw new EmptyFieldException("Please fill in all the fields, no field are allowed to be empty.");
                }
            }
            catch(EmptyFieldException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            productController.AddProduct(p);
            this.Close();
            MessageBox.Show("Successfully added: " + name + ".");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            workingProduct.DepotStock = 0;
            workingProduct.StoreStock = 0;
            ProductDAL.EditProduct(workingProduct);
            MessageBox.Show("Successfully made product with name: " + workingProduct.Name + " out of stock.");
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            workingProduct.Name = tbxProductName.Text;
            workingProduct.Brand = tbxBrand.Text;
            try
            {
                workingProduct.Length = Convert.ToDouble(tbxLength.Text);
                workingProduct.Width = Convert.ToDouble(tbxWidth.Text);
                workingProduct.Height = Convert.ToDouble(tbxHeight.Text);
                workingProduct.SellingPrice = Convert.ToDouble(tbxSellingPrice.Text);
                workingProduct.PriceWithoutVAT = Convert.ToDouble(tbxPriceWithoutVAT.Text);
                workingProduct.DepotStock = Convert.ToInt32(tbxDepotStock.Text);
                workingProduct.StoreStock = Convert.ToInt32(tbxStoreStock.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("One or more boxes contain letters while they can only contain numbers. Please check and try again.");
                return;
            }

            try
            {
                if (ContainsEmptyFields(workingProduct))
                {
                    throw new EmptyFieldException("Please fill in all the fields, no field are allowed to be empty.");
                }
            }
            catch (EmptyFieldException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            workingProduct.DepotLocation = tbxDepotLocation.Text;
            ProductCategory category = ProductController.GetCategoryByID(cbCategory.SelectedIndex+1);
            workingProduct.Category = category;
            workingProduct.Description = rtbxDescription.Text;

            ProductDAL.EditProduct(workingProduct);//Database edit product
            this.Close();
            MessageBox.Show("Successfully edited: " + workingProduct.Name + ".");
        }

        private bool ContainsEmptyFields(Product p)
        {
            //name, brand, length, width, height, sellingPrice, priceWithoutVAT, depotStock, storeStock, depotLocation, category, description
            bool containsEmptyField = false;
            if (p.Name == "" || p.Brand == "" || p.DepotLocation == "" || p.Category.Name == "" || p.Description == "")
            {
                containsEmptyField = true;
            }
            return containsEmptyField;
        }
    }
}
