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
    public partial class StockRequestInfoForm : Form
    {
        private StockRequest stockRequest;
        public StockRequestInfoForm(StockRequest stockRequest)
        {
            this.stockRequest = stockRequest;
            InitializeComponent();
            Initialize();
        }

        private void lblProductId_Click(object sender, EventArgs e)
        {

        }

        private void Initialize()
        {
            SetTabControlPage();
            string stateInfo = "";
            lblProductId.Text = "Product id: " + stockRequest.Product.Id;
            lblProductName.Text = "Product name: " + stockRequest.Product.Name;
            boxStoreStock.Value = stockRequest.StockStoreNeeded;
            boxDepotStock.Value = stockRequest.StockDepotNeeded;
            lblState.Text = "Stockrequest state: " + stockRequest.State.ToString();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            if(stockRequest.State == State.Open)
            {
                progressBar1.Value = 25;
                stateInfo = "The stock request has been opened but nothing has been ordered yet.";
            }
            if (stockRequest.State == State.StockOrdered)
            {
                progressBar1.Value = 50;
                stateInfo = "The stock has been ordered but has not been delivered yet";
            }
            if(stockRequest.State == State.StockDelivered)
            {
                progressBar1.Value = 75;
                stateInfo = "The stock has been delivered but it has not yet been confirmed that the stock request is finished.";
            }
            if(stockRequest.State == State.Handled)
            {
                progressBar1.Value = 100;
                stateInfo = "The stock request has been completely handled!";
            }
            lblStateInfo.Text = stateInfo;
        }

        private void SetTabControlPage()
        {
            foreach (TabPage tp in tabControl1.TabPages)
            {
                tabControl1.TabPages.Remove(tp);
            }

            if (stockRequest.State == State.Open)
            {
                tabControl1.TabPages.Add(tabPageOrder);
                tabControl1.SelectedTab = tabPageOrder;
            }
            if(stockRequest.State == State.StockOrdered)
            {
                tabControl1.SelectedTab = tabPageDelivery;
                tabControl1.TabPages.Add(tabPageDelivery);
            }
            if(stockRequest.State == State.StockDelivered)
            {
                tabControl1.SelectedTab = tabPageHandle;
                tabControl1.TabPages.Add(tabPageHandle);
            }
            if(stockRequest.State == State.Handled)
            {
                tabControl1.SelectedTab = tabPageFinished;
                tabControl1.TabPages.Add(tabPageFinished);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOrderConfirm_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("The state of the stock request will be set to ordered, are you sure?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.No)
            {
                return;
            }
            //DB Update state
            UpdateNewState(State.StockOrdered);

        }

        private void UpdateNewState(State state)
        {
            if(StockRequestDAL.ChangeState(stockRequest, state) <1)
            {
                MessageBox.Show("Something went wrong when changing the state in the database");
            }
            string stateInfo = "";
            if(state == State.Open)
            {
                stockRequest.State = State.Open;
                progressBar1.Value = 25;
                stateInfo = "The stock request has been opened but nothing has been ordered yet.";
            }
            if(state == State.StockOrdered)
            {
                stockRequest.State = State.StockOrdered;
                progressBar1.Value = 50;
                stateInfo = "The stock has been ordered but has not been delivered yet.";
            }
            if(state == State.StockDelivered)
            {
                stockRequest.State = State.StockDelivered;
                progressBar1.Value = 75;
                stateInfo = "The stock has been delivered but it has not yet been confirmed that the stock request is finished.";
            }
            if(state == State.Handled)
            {
                stockRequest.Product.StoreStock += stockRequest.StockStoreNeeded;
                stockRequest.Product.DepotStock += stockRequest.StockDepotNeeded;
                ProductDAL.EditProduct(stockRequest.Product);

                stockRequest.State = State.Handled;
                progressBar1.Value = 100;
                stateInfo = "The stock request has been completely handled!";
            }

            lblStateInfo.Text = stateInfo;
            lblState.Text = "Stockrequest state: " + stockRequest.State.ToString();
            SetTabControlPage();
        }

        private void btnConfirmDelivery_Click(object sender, EventArgs e)
        {
            int stockStoreDelivered = (int)boxStoreStockDelivered.Value;
            int stockDepotDelivered = (int)BoxDepotStockDelivered.Value;

            State newState = State.StockDelivered;

            if (stockStoreDelivered < stockRequest.StockStoreNeeded || stockDepotDelivered < stockRequest.StockDepotNeeded)
            {
                DialogResult dr = MessageBox.Show("Warning: The received stock is less than the requested stock. The state will be set back to open so that the remaining stock can be ordered. Do you want to continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No)
                {
                    return;
                }
                newState = State.Open;
            }
            else
            {
                DialogResult dr2 = MessageBox.Show("The state of the stock request will be set to delivered. Do you want to continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr2 == DialogResult.No)
                {
                    return;
                }
            }
            UpdateNewState(newState);
        }

        private void btnConfirmHandled_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("The state of the stock request will be set to handled. The stock will be added to the product in the database. Do you want to continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.No)
            {
                return;
            }
            UpdateNewState(State.Handled);
        }

        private void TabIndexChangedTabControl(object sender, EventArgs e)
        {
        }
    }
}
