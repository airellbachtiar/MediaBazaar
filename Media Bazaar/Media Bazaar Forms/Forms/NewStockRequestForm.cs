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
using Media_Bazaar_Logic.DAL;

namespace Media_Bazaar.Forms
{
    public partial class NewStockRequestForm : Form
    {
        private List<Product> products;

        private Product[] showingList;

        private bool usingPreSelectedProduct;

        private int preSelectedProductId;

        public NewStockRequestForm()
        {
            InitializeComponent();
            Initialize(null);
            usingPreSelectedProduct = false;
        }

        public NewStockRequestForm(Product p)
        {
            InitializeComponent();
            Initialize(p);
            usingPreSelectedProduct = true;
            preSelectedProductId = p.Id;
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            Product selectedProduct;
            int selectedProductIndex = -1;
            if (!usingPreSelectedProduct)
            {
                if (listViewProducts.FocusedItem == null)
                {
                    MessageBox.Show("Please select a product.");
                    return;
                }

                selectedProductIndex = listViewProducts.FocusedItem.Index;
                selectedProduct = showingList[selectedProductIndex];
            }
            else
            {
                selectedProduct = ProductDAL.GetProductById(preSelectedProductId);
            }
            int depotStockAmount = (int)boxDepotStock.Value;
            int storeStockAmount = (int)boxStoreStock.Value;

            if(depotStockAmount <= 0 && storeStockAmount <=0)
            {
                MessageBox.Show("The requested stock should be more than 0.");
                return;
            }

            StockRequest newStockRequest = new StockRequest(selectedProduct, depotStockAmount, storeStockAmount);
            if(StockRequestDAL.AddStockRequest(newStockRequest) != 1)
            {
                MessageBox.Show("Something went wrong when adding the restock request. Please try again later.");
            }
            else
            {
                MessageBox.Show("Succesfully added new restock request.");
                this.Close();
            }
        }

        private void Initialize(Product selectedProduct)
        {
            int selectedProductIndex = -1;
            products = ProductDAL.GetAllProducts();
            showingList = products.ToArray();

            if (selectedProduct != null)
            {
                for(int i = 0; i < products.Count; i++)
                {
                    if (products[i].Id == selectedProduct.Id)
                    {
                        selectedProductIndex = i;
                    }
                }
                lblSelectedProduct.Text = selectedProduct.Name;
                boxSearch.Visible = false;
                listViewProducts.Visible = false;
                lblProduct.Text = "Product: " + selectedProduct.Name;
            }

            foreach (Product p in products)
            {
                string[] itemContent = {p.Id.ToString(), p.Name, p.StoreStock.ToString(), p.DepotStock.ToString()};
                ListViewItem productItem = new ListViewItem(itemContent);
                listViewProducts.Items.Add(productItem);
            }

            if(selectedProductIndex > -1)
            {
                listViewProducts.Items[selectedProductIndex].Focused = true;
                listViewProducts.Items[selectedProductIndex].Selected = true;
                listViewProducts.Items[selectedProductIndex].EnsureVisible();
            }
        }

        private void BoxSearchTextChanged(object sender, EventArgs e)
        {
            LoadListView(boxSearch.Text);
        }

        private void LoadListView(string searchQuery)
        {
            listViewProducts.Items.Clear();
            List<Product> modifiedList = new List<Product>();

            foreach(Product product in products)
            {
                if(product.Name.ToLower().Contains(searchQuery.ToLower()) || product.Id.ToString().ToLower().Contains(searchQuery.ToLower()))
                {
                    modifiedList.Add(product);
                }
            }

            foreach (Product p in modifiedList)
            {
                string[] itemContent = { p.Id.ToString(), p.Name, p.StoreStock.ToString(), p.DepotStock.ToString() };
                ListViewItem productItem = new ListViewItem(itemContent);
                listViewProducts.Items.Add(productItem);
            }
            showingList = modifiedList.ToArray();
        }

        private void ListViewSelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewProducts.FocusedItem != null)
            {
                int selectedProductIndex = listViewProducts.FocusedItem.Index;
                lblSelectedProduct.Text = showingList[selectedProductIndex].Name;
            }
        }
    }
}
