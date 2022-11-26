using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Media_Bazaar_Logic.Class;
using Media_Bazaar_Logic.Controllers;
using Media_Bazaar_Logic.DAL;
using Media_Bazaar_Logic.Enums;
using Media_Bazaar_Logic.ExportData;

namespace Media_Bazaar.Forms
{
    public partial class Form1 : Form
    {
        private string selected;
        private ProductController productController;
        private User user;
        private List<StockRequest> localStockRequests;
        private List<Product> localAllProducts;
        private List<Product> showingProducts;


        public Form1(User user)
        {
            this.user = user;
            this.selected = "";
            this.productController = new ProductController();

            List<Product> products = ProductDAL.GetAllProducts();
            InitializeComponent();
            listViewProducts.Visible = false;

            btnOverviewMore.Enabled = false;
            btnNewRestockRequest.Enabled = false;

            lblName.Text = "Username: " + user.UserName;
            lblRole.Text = "Role: " + Convert.ToString(user.Role);

            foreach (TabPage t in tbctMain.TabPages)
            {
                tbctMain.TabPages.Remove(t);
            }
            tbctMain.TabPages.Add(tabMain);


            InitializeMainPage(user);

            if (user.Role == RoleType.Employee)
            {

                btnEmployee.Enabled = false;
                this.btnTabCategory.Visible = false;
            }
            else
            {
                btnEmployee.Enabled = true;
            }
            if(user.Role == RoleType.Admin)
            {
                btnDepartment.Visible = true;
                btnStatistics.Visible = true;
                // We can also make it invisibl, instead of enabling it
                this.btnSchedule.Enabled = true;
                this.btnTabCategory.Visible = true;
            }

            if(user.Role == RoleType.Manager)
            {
                // We can also make it invisibl, instead of enabling it
                this.btnSchedule.Enabled = true;
                btnStatistics.Visible = true;
                this.btnTabCategory.Visible = false;
            }


            List<ProductCategory> list = ProductController.GetAllCategorys();
            foreach (ProductCategory pc in list)
            {
                cbSearchCategory.Items.Add(pc.Name);
            }
            cbSearchCategory.SelectedIndex = 0;
            cbSearchCategory.Visible = false;
            lblCategory.Visible = false;

        }

        private void InitializeMainPage(User user)
        {
            int hour = DateTime.Now.Hour;
            if(hour >= 6 && hour < 12)
            {
                lblGreeting.Text = "Good morning " + user.FirstName;
            }
            if(hour >=12 && hour < 18)
            {
                lblGreeting.Text = "Good afternoon " + user.FirstName;
            }
            if(hour >= 18 || hour <6)
            {
                lblGreeting.Text = "Good evening " + user.FirstName;
            }
        }

        /// <summary>
        /// This method will load the statistics displayed on the main screen
        /// </summary>
        private void LoadStatistics()
        {
            // TODO:
            // Top 5 stock requests
            List<Product> allProductsInTotal = ProductDAL.GetAllProducts();
            int allProductsAmount = allProductsInTotal.Count;
            List<Product> availableProducts = FilterProductsInStock(allProductsInTotal);
            lblStatsTotalAmountOfProducts.Text =
                "Media Bazaar is now selling a total amount of " + availableProducts.Count + " products.";
            lblAmountTotalSold.Text = "Media Bazaar has been selling " + allProductsAmount + " different products in total.";

            List<SoldProduct> AllSoldProducts = ProductDAL.ReadAllSoldProducts();
            List<SoldProduct> SoldProductsLast30Days = ProductDAL.RealAllSoldProductsLast30Days();

            // Best selling product all time:
            Product bestSellingProduct = SoldProduct.GetBestSellingProduct(AllSoldProducts);
            lblMostSoldProductAll.Text = bestSellingProduct.Name;
            // The amount it has been sold:
            lblMostSoldProdAmountAll.Text = "The " + bestSellingProduct.Name + " has been sold " + SoldProduct.GetSoldAmountForProductInList(bestSellingProduct, AllSoldProducts) + " times.";

            // Most profitable product all time:
            Product mostProfitableProduct = SoldProduct.GetMostProfitableProduct(AllSoldProducts);
            lblMostProfitableAll.Text = mostProfitableProduct.Name;

            // Profit made from above product:
            double profit = SoldProduct.GetProfitFromProductInList(mostProfitableProduct, AllSoldProducts);
            lblProfitAll.Text = "€" + profit;


            // Best selling product in last 30 days:
            Product bestSellingProduct30 = SoldProduct.GetBestSellingProduct(SoldProductsLast30Days);
            lblMostSoldProd30.Text = bestSellingProduct30.Name;
            // The amount it has been sold:
            lblMostSoldProdAmount30.Text = "The " + bestSellingProduct30.Name + " has been sold " + SoldProduct.GetSoldAmountForProductInList(bestSellingProduct30, SoldProductsLast30Days) + " times.";

            // Most profitable product in last 30 days:
            Product mostProfitableProduct30 = SoldProduct.GetMostProfitableProduct(SoldProductsLast30Days);
            lblMostProfitableProd30.Text = mostProfitableProduct30.Name;

            // Profit made from above product in last 30 days:
            double profit30 = SoldProduct.GetProfitFromProductInList(mostProfitableProduct30, SoldProductsLast30Days);
            lblProfit30.Text = "€" + profit30;
            
            
            // Sick employees:
            // Most sick employee all time:
            User mostSickUser = SickDayDAL.GetMostSickUserAllTime();
            lblMostSickEmployee.Text = mostSickUser.FirstName + " " + mostSickUser.SurName;
            // Amount of sick employees all time:
            lblAmountSick.Text = SickDayDAL.GetTotalAmountOfSickEmployees().ToString();
            
            // Most sick employee in the last 30 days:
            User mostSickUser30 = SickDayDAL.GetMostSickUserLast30Days();
            lblMostSickEmployee30.Text = mostSickUser30.FirstName + " " + mostSickUser30.SurName;
            // Amount of sick employees in the last 30 days:
            lblAmountSick30.Text = SickDayDAL.GetTotalAmountOfSickEmployeesLast30Days().ToString();
            
            // Load products into Product selector:
            localAllProducts = new List<Product>();
            showingProducts = new List<Product>();
            listViewProductSelector.Items.Clear();
            List<Product> allProducts = ProductDAL.GetAllProducts();
            foreach (Product p in allProducts)
            {
                localAllProducts.Add(p);
                showingProducts.Add(p);
            }
            ProductSelectorShowProducts();
            RadioSelectorsShowCorrect();
            listViewProductSelector.Items[0].Selected = true;
        }


        private List<Product> FilterProductsInStock(List<Product> productsList)
        {
            List<Product> removeList = new List<Product>();
            foreach (Product p in productsList)
            {
                if (p.DepotStock == 0 && p.StoreStock == 0)
                {
                    removeList.Add(p);
                }
            }

            foreach (Product p in removeList)
            {
                productsList.Remove(p);
            }

            return productsList;
        }

        private void btnOverviewAdd_Click(object sender, EventArgs e)
        {
            if (selected.Equals("Product"))
            {
                ProductForm productForm = new ProductForm(productController);
                productForm.ShowDialog();
                ShowProducts();
            }
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {

            if (tbctMain.SelectedTab.Name != "tabRest")
            {
                foreach (TabPage t in tbctMain.TabPages)
                {
                    tbctMain.TabPages.Remove(t);
                }
                tbctMain.TabPages.Add(tabRest);


            }

            selected = "Product";
            cboxSort.SelectedIndex = 0;
            cboxFilter.SelectedIndex = 0;
            ShowProducts();
        }

        //Loads the products into the listview
        public void ShowProducts()
        {
            //Clearing the current items in the field
            listViewProducts.Items.Clear();
            listViewProducts.Visible = true;
            List<Product> productsList = FilterProducts();
            SortProducts(productsList);
            //Add the sorted products to the listview
            foreach (Product p in productsList)
            {
                string[] itemContent = { p.Name, p.Brand, "€"+p.SellingPrice, "€"+p.PriceWithoutVAT, p.DepotStock.ToString(), p.StoreStock.ToString(), p.Category.Name };
                ListViewItem productItem = new ListViewItem(itemContent);
                listViewProducts.Items.Add(productItem);
            }
        }

        private void btnOverviewMore_Click(object sender, EventArgs e)
        {
            if (selected.Equals("Product"))
            {
                MoreProduct();
            }
        }

        //Shows the prompt for more information of a product
        private void MoreProduct()
        {
            if (listViewProducts.FocusedItem == null)
            {
                MessageBox.Show("Please select a product.");
                return;
            }

            int selectedProductIndex = listViewProducts.FocusedItem.Index;
            Product productMore = productController.GetProductByIndex(selectedProductIndex);
            ProductForm moreProductForm = new ProductForm(productController, productMore);
            moreProductForm.ShowDialog();
            ShowProducts();
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            if (tbctMain.SelectedTab.Name != "tabDepartments")
            {
                foreach (TabPage t in tbctMain.TabPages)
                {
                    tbctMain.TabPages.Remove(t);
                }
                tbctMain.TabPages.Add(tabDepartments);
                showFormDepartments();

            }
        }

        private void showFormDepartments()
        {
            Forms.DepartmentForm st = new Forms.DepartmentForm { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            st.FormBorderStyle = FormBorderStyle.None;
            this.pnlDepartments.Controls.Add(st);
            st.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            if (tbctMain.SelectedTab.Name != "tabEmployee")
            {
                foreach (TabPage t in tbctMain.TabPages)
                {
                    tbctMain.TabPages.Remove(t);
                }
                tbctMain.TabPages.Add(tabEmployee);
                showFormEmployee();

            }
        }

        private void showFormEmployee()
        {
            Forms.Employee.EmployeeOverlay st = new Forms.Employee.EmployeeOverlay(user) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            st.FormBorderStyle = FormBorderStyle.None;
            this.pnlEmployee.Controls.Add(st);
            st.Show();
        }

        private List<Product> SortProducts(List<Product> productsList)
        {
            int sortType = cboxSort.SelectedIndex;
            List<Product> sortedProducts = new List<Product>();

            //Sort products
            if (sortType == 1)
            {
                productsList.Sort((p1, p2) => p1.Name.CompareTo(p2.Name));
            }
            if (sortType == 2)
            {
                productsList.Sort((p1, p2) => p1.Name.CompareTo(p2.Name) * -1);
            }
            if (sortType == 3)
            {
                productsList.Sort((p1, p2) => p1.Brand.CompareTo(p2.Brand));
            }
            if (sortType == 4)
            {
                productsList.Sort((p1, p2) => p1.Brand.CompareTo(p2.Brand) * -1);
            }
            if (sortType == 5)
            {
                productsList.Sort((p1, p2) => p1.SellingPrice.CompareTo(p2.SellingPrice));
            }
            if (sortType == 6)
            {
                productsList.Sort((p1, p2) => p1.SellingPrice.CompareTo(p2.SellingPrice) * -1);
            }
            if (sortType == 7)
            {
                productsList.Sort((p1, p2) => p1.Category.Name.CompareTo(p2.Category.Name));
            }
            if (sortType == 8)
            {
                productsList.Sort((p1, p2) => p1.Category.Name.CompareTo(p2.Category.Name) * -1);
            }
            productController.SetProducts(productsList);
            return productsList;
        }

        private List<Product> FilterProducts()
        {
            List<Product> products;

            if (chckCategory.Checked)
            {
                products = productController.GetProductByDepartment(cbSearchCategory.Text);
            }
            else
            {
                products = productController.GetProducts();
            }

            bool sortInStock;
            if (cboxFilter.SelectedIndex == 0)
            {
                sortInStock = true;
            }
            else
            {
                sortInStock = false;
            }

            
            List<Product> productsList = new List<Product>();
            foreach (Product product in products)
            {
                productsList.Add(product);
            }

            List<Product> removeList = new List<Product>();

            if(sortInStock)
            {
                foreach(Product p in productsList)
                {
                    if(p.DepotStock == 0 && p.StoreStock == 0)
                    {
                        removeList.Add(p);
                    }
                }
            }
            else
            {
                foreach(Product p in productsList)
                {
                    if(p.DepotStock > 0 || p.StoreStock > 0)
                    {
                        removeList.Add(p);
                    }
                }
            }

            foreach(Product p in removeList)
            {
                productsList.Remove(p);
            }

            return productsList;
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            if(tbctMain.SelectedTab.Name != "tabSchedule")
            {
                foreach(TabPage t in tbctMain.TabPages)
                {
                    tbctMain.TabPages.Remove(t);
                }
                tbctMain.TabPages.Add(tabSchedule);
                ShowFormSchedule();

            }
        }

        private void ShowFormSchedule()
        {
            ScheduleForm scheduleForm = new ScheduleForm(this.user) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            scheduleForm.FormBorderStyle = FormBorderStyle.None;
            this.pnlSchedule.Controls.Add(scheduleForm);
            scheduleForm.Show();
        }

        private void DoubleClickProductView(object sender, EventArgs e)
        {
            MoreProduct();
        }

        private void cboxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowProducts();
            SetButtonsEnabled();
        }

        private void cboxFilterSelectedIndexChanged(object sender, EventArgs e)
        {
            ShowProducts();
        }

        private void btnNewRestockRequest_Click(object sender, EventArgs e)
        {
            int selectedProductIndex = -1;

            if (listViewProducts.FocusedItem == null)
            {
                MessageBox.Show("Please select a product.");
                return;
            }
            selectedProductIndex = listViewProducts.FocusedItem.Index;
            Product product = productController.GetProductByIndex(selectedProductIndex);

            NewStockRequestForm newStockRequestForm = new NewStockRequestForm(product);
            newStockRequestForm.ShowDialog();
        }

        private void listViewProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonsEnabled();
        }

        private void ListViewClicked(object sender, EventArgs e)
        {
            SetButtonsEnabled();
        }

        private void SetButtonsEnabled()
        {
            if (listViewProducts.FocusedItem == null)
            {
                btnOverviewMore.Enabled = false;
                btnNewRestockRequest.Enabled = false;
            }
            else
            {
                btnOverviewMore.Enabled = true;
                btnNewRestockRequest.Enabled = true;
            }
        }

        private void ListViewMouseClick(object sender, MouseEventArgs e)
        {
        }

        private void btnAllStockRequests_Click(object sender, EventArgs e)
        {
            foreach (TabPage t in tbctMain.TabPages)
            {
                tbctMain.TabPages.Remove(t);
            }
            tbctMain.TabPages.Add(tabPageStockRequestOverview);
            comboBoxFilterStockRequests.SelectedIndex = 0;
            LoadStockRequests();
        }

        private void LoadStockRequests()
        {
            List<StockRequest> stockRequests = StockRequestDAL.GetAllStockRequests();
            FilterStockRequests(stockRequests);

            listViewStockRequests.Items.Clear();

            foreach (StockRequest sr in localStockRequests)
            {
                string[] itemContent = { sr.Id.ToString(), sr.Product.Name, sr.State.ToString(), sr.StockDepotNeeded.ToString(), sr.StockStoreNeeded.ToString()};
                ListViewItem stockRequestItem = new ListViewItem(itemContent);
                listViewStockRequests.Items.Add(stockRequestItem);
            }
        }

        private void FilterStockRequests(List<StockRequest> stockRequests)
        {
            localStockRequests = new List<StockRequest>();
            bool filterOnFinished;
            if(comboBoxFilterStockRequests.SelectedIndex == 0)
            {
                filterOnFinished = false;
            }
            else
            {
                filterOnFinished = true;
            }
            StockRequest[] stockRequestsArray = stockRequests.ToArray();

            foreach(StockRequest sr in stockRequestsArray)
            {
                if(filterOnFinished)
                {
                    if(sr.State == State.Handled)
                    {
                        localStockRequests.Add(sr);
                    }
                }
                if(!filterOnFinished)
                {
                    if(sr.State != State.Handled)
                    {
                        localStockRequests.Add(sr);
                    }
                }
            }
        }

        private void btnNewBaseRestockRequest_Click(object sender, EventArgs e)
        {
            NewStockRequestForm stockRequestForm = new NewStockRequestForm();
            stockRequestForm.ShowDialog();
            LoadStockRequests();
        }

        private void btnBackProducts_Click(object sender, EventArgs e)
        {
            if (tbctMain.SelectedTab.Name != "tabRest")
            {
                foreach (TabPage t in tbctMain.TabPages)
                {
                    tbctMain.TabPages.Remove(t);
                }
                tbctMain.TabPages.Add(tabRest);


            }

            selected = "Product";
            ShowProducts();
        }

        private void DoubleClickStockRequestsOverview(object sender, EventArgs e)
        {
            if (user.Department == 2 || user.Role == RoleType.Admin || user.Role == RoleType.Manager)
            {
                int selectedStockRequestIndex = -1;
                try
                {
                    selectedStockRequestIndex = listViewStockRequests.FocusedItem.Index;
                }
                catch (Exception)
                {
                    MessageBox.Show("Please select a stock request.");
                    return;
                }

                StockRequest selectedStockRequest = localStockRequests[selectedStockRequestIndex];
                StockRequestInfoForm infoForm = new StockRequestInfoForm(selectedStockRequest);
                infoForm.ShowDialog();
                LoadStockRequests();
                return;
            }

            MessageBox.Show("You need to be a depot worker, manager or admin to handle this restock request.");
        }

        private void listViewStockRequests_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxFilterStockRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStockRequests();
        }

        private void btnHomePage_Click(object sender, EventArgs e)
        {
            foreach (TabPage t in tbctMain.TabPages)
            {
                tbctMain.TabPages.Remove(t);
            }
            tbctMain.TabPages.Add(tabMain);


            InitializeMainPage(user);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void btnProfile_Click(object sender, EventArgs e)
        {
            if (tbctMain.SelectedTab.Name != "tabProfile")
            {
                foreach (TabPage t in tbctMain.TabPages)
                {
                    tbctMain.TabPages.Remove(t);
                }
                tbctMain.TabPages.Add(tabProfile);
                showProfileForm();

            }
        }

        private void showProfileForm()
        {
            Profile pf = new Profile(user) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            pf.FormBorderStyle = FormBorderStyle.None;
            this.pnlProfile.Controls.Add(pf);
            pf.Show();
        }

        private void btnSellProduct_Click(object sender, EventArgs e)
        {
            if (listViewProducts.FocusedItem == null)
            {
                MessageBox.Show("Please select a product.");
                return;
            }

            int selectedProductIndex = listViewProducts.FocusedItem.Index;
            Product selectedProduct = productController.GetProductByIndex(selectedProductIndex);
            SellProductForm sellProductForm = new SellProductForm(selectedProduct);
            sellProductForm.ShowDialog();
            ShowProducts();
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            foreach (TabPage t in tbctMain.TabPages)
            {
                tbctMain.TabPages.Remove(t);
            }
            tbctMain.TabPages.Add(tabPageStatistics);
            LoadStatistics();
        }

        private void btnExportData_Click(object sender, EventArgs e)
        {
            ExportData.Export(new ProductExportData());
        }

        private void listViewProductSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSpecificProductStatistics();
            StatsGetStockRequestForProduct();
        }

        private void textBoxSearchProduct_TextChanged(object sender, EventArgs e)
        {
            SearchProductSelector();
        }

        private void radioPeriodAllTime_CheckedChanged(object sender, EventArgs e)
        {
            RadioSelectorsShowCorrect();
            ShowSpecificProductStatistics();
        }

        private void radioLastDays_CheckedChanged(object sender, EventArgs e)
        {
            RadioSelectorsShowCorrect();
            ShowSpecificProductStatistics();
        }

        private void radioSpecificDate_CheckedChanged(object sender, EventArgs e)
        {
            RadioSelectorsShowCorrect();
            ShowSpecificProductStatistics();
        }

        private void numericUpDownDays_ValueChanged(object sender, EventArgs e)
        {
            ShowSpecificProductStatistics();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ShowSpecificProductStatistics();
        }

        private void SearchProductSelector()
        {
            string query = textBoxSearchProduct.Text.ToLower();
            showingProducts.Clear();

            foreach (Product product in localAllProducts)
            {
                if (product.Id.ToString().Contains(query) || product.Name.ToLower().Contains(query))
                {
                    showingProducts.Add(product);
                }
                else
                {
                    string[] partQueries = query.Split(" ");
                    bool containsAll = true;
                    foreach (string partQuery in partQueries)
                    {
                        if (!product.Name.ToLower().Contains(partQuery))
                        {
                            if (!product.Id.ToString().Contains(partQuery))
                            {
                                containsAll = false;
                            }
                        }
                    }
                    if(containsAll) {showingProducts.Add(product);}
                }
            }

            ProductSelectorShowProducts();
        }

        private void ProductSelectorShowProducts()
        {
            listViewProductSelector.Items.Clear();
            
            foreach (Product p in showingProducts)
            {
                    string[] itemContent = {p.Id.ToString(), p.Name};
                    ListViewItem newItem = new ListViewItem(itemContent);
                    listViewProductSelector.Items.Add(newItem);
            }
        }

        private Product ProductSelectorGetSelectedProduct()
        {
            if (listViewProductSelector.SelectedIndices.Count == 0)
            {
                return null;
            }
            int selectedIndex = listViewProductSelector.SelectedIndices[0];
            
            return showingProducts[selectedIndex];
        }

        private void ShowSpecificProductStatistics()
        {
            List<int> soldAmounts = null;
            Product selectedProduct = ProductSelectorGetSelectedProduct();
            if (selectedProduct == null)
            {
                return;
            }

            if (radioPeriodAllTime.Checked)
            {
                soldAmounts = ProductDAL.GetSoldAmountsForProductAllTime(selectedProduct);
            }

            if (radioLastDays.Checked)
            {
                if (numericUpDownDays.Value < 0)
                {
                    MessageBox.Show("The amount of days ago cannot be smaller than zero. Please try again.");
                    return;
                }
                soldAmounts = ProductDAL.GetSoldAmountsForProductLastDays(selectedProduct, (int)numericUpDownDays.Value);
            }

            if (radioSpecificDate.Checked)
            {
                soldAmounts = ProductDAL.GetSoldAmountsForProductForDate(selectedProduct, dateTimePicker1.Value);
            }

            if (soldAmounts == null)
            {
                MessageBox.Show(
                    "Something went wrong when trying to load the statistics for this product. Please try again later.");
                return;
            }

            string[] soldContent = null;
            soldContent = soldAmounts.Count > 0 ? new[] {soldAmounts[0].ToString(), soldAmounts[1].ToString()} : new[] {"0", "0"};
            ListViewItem itemSold = new ListViewItem(soldContent);
            listViewStatsSold.Items.Clear();
            listViewStatsSold.Items.Add(itemSold);
        }

        private void RadioSelectorsShowCorrect()
        {
            if (radioPeriodAllTime.Checked)
            {
                lblLastDays1.Visible = false;
                lblLastDays2.Visible = false;
                numericUpDownDays.Visible = false;
                lblDatePicker.Visible = false;
                dateTimePicker1.Visible = false;
            }

            if (radioLastDays.Checked)
            {
                lblLastDays1.Visible = true;
                lblLastDays2.Visible = true;
                numericUpDownDays.Visible = true;
                lblDatePicker.Visible = false;
                dateTimePicker1.Visible = false;
            }

            if (radioSpecificDate.Checked)
            {
                lblLastDays1.Visible = false;
                lblLastDays2.Visible = false;
                numericUpDownDays.Visible = false;
                lblDatePicker.Visible = true;
                dateTimePicker1.Visible = true;
            }
            
            Product selectedProduct = ProductSelectorGetSelectedProduct();
            if (selectedProduct != null)
            {
                ShowSpecificProductStatistics();
            }
        }

        private void StatsGetStockRequestForProduct()
        {
            Product selectedProduct = ProductSelectorGetSelectedProduct();
            if (selectedProduct == null)
            {
                return;
            }

            List<StockRequest> stockRequests = StockRequestDAL.GetAllStockRequestsForProduct(selectedProduct);
            if (stockRequests == null)
            {
                MessageBox.Show(
                    "Something went wrong when trying to load information about the stock requests for the statistics. PLease try again later.");
                return;
            }
            List<int> requestAmounts = new List<int>();

            foreach (StockRequest stockRequest in stockRequests)
            {
                if (requestAmounts.Count < 2)
                {
                    requestAmounts.Add(stockRequest.StockStoreNeeded);
                    requestAmounts.Add(stockRequest.StockDepotNeeded);
                }
                else
                {
                    requestAmounts[0] += stockRequest.StockStoreNeeded;
                    requestAmounts[1] += stockRequest.StockDepotNeeded;
                }
            }

            string[] stockRequestsContent = new[] {"0", "0" };
            if (stockRequests.Count > 0)
            {
                stockRequestsContent = new[] {requestAmounts[0].ToString(), requestAmounts[1].ToString()};
            }

            ListViewItem listViewItem = new ListViewItem(stockRequestsContent);
            listViewStatsRequested.Items.Clear();
            listViewStatsRequested.Items.Add(listViewItem);
        }

        private void btnTabCategory_Click(object sender, EventArgs e)
        {
            if (tbctMain.SelectedTab.Name != "tabCategory")
            {
                foreach (TabPage t in tbctMain.TabPages)
                {
                    tbctMain.TabPages.Remove(t);
                }
                tbctMain.TabPages.Add(tabCategory);
                showFormCategory();

            }
        }

        

        private void showFormCategory()
        {
            Forms.CategoryForm st = new Forms.CategoryForm { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            st.FormBorderStyle = FormBorderStyle.None;
            this.pnlShowCategory.Controls.Add(st);
            st.Show();
        }




        private void btnExportStatistics_Click(object sender, EventArgs e)
        {
            ExportData.Export(new StatisticsExportData());
        }

        private void chckCategory_CheckedChanged(object sender, EventArgs e)
        {
            ShowProducts();
            if (chckCategory.Checked)
            {
                lblCategory.Visible = true;
                cbSearchCategory.Visible = true;
            }
            else
            {
                lblCategory.Visible = false;
                cbSearchCategory.Visible = false;
            }
        }

        private void cbSearchCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowProducts();
        }
    }

}
