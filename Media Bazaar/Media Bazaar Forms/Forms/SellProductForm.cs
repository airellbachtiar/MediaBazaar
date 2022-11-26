using Media_Bazaar_Logic.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Media_Bazaar_Logic.DAL;

namespace Media_Bazaar.Forms
{
    public partial class SellProductForm : Form
    {
        private Product sellProduct;
        
        public SellProductForm(Product p)
        {
            sellProduct = p;
            InitializeComponent();
            lblProductName.Text = p.Name;
        }

        private void SellProductForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            Product checkProduct = ProductDAL.GetProductById(sellProduct.Id);
            int availableStore = checkProduct.StoreStock;
            int availableDepot = checkProduct.DepotStock;
            if (numericUpDownStore.Value > availableStore || numericUpDownDepot.Value > availableDepot)
            {
                MessageBox.Show("This amount of stock is not available, please try again.");
            }
            else
            {
                int newStoreStock = availableStore - (int) numericUpDownStore.Value;
                int newDepotStock = availableDepot - (int) numericUpDownDepot.Value;
                checkProduct.StoreStock = newStoreStock;
                checkProduct.DepotStock = newDepotStock;
                ProductDAL.EditProduct(checkProduct);
                if (!ProductDAL.AddSoldProduct(checkProduct, (int) numericUpDownStore.Value,
                    (int) numericUpDownDepot.Value,
                    DateTime.Now))
                {
                    MessageBox.Show("Something went wrong when trying to sell the product. Please try again later.");
                    return;
                }
                MessageBox.Show("Successfully sold product.");
                this.Close();
            }
        }
    }
}
