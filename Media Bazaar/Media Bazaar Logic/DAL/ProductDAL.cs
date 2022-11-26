using System;
using System.Collections.Generic;
using System.Data;
using Media_Bazaar_Logic.Class;

namespace Media_Bazaar_Logic.DAL
{
    public static class ProductDAL
    {
        private static string sql;

        public static Product GetProductById(int id)
        {
            sql = "SELECT * FROM product WHERE ID = @ID";

            Product p = null;

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("ID", id)
            };

            

            try
            {
                DataSet dataSet = DatabaseController.ExecuteSql(sql, parameters);
                p = Parsers.ProductParser.DataSetToProduct(dataSet, 0);
            }
            catch (Exception)
            {
                return null;
            }
            return p;
        }

        public static List<Product> GetAllProducts()
        {
            sql = "SELECT * FROM product";

            List<Product> products = new List<Product>();

            try
            {
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>> { };
                DataSet dataSet = DatabaseController.ExecuteSql(sql, parameters);

                for (int x = 0; x < dataSet.Tables[0].Rows.Count; x++)
                {
                    Product p = Parsers.ProductParser.DataSetToProduct(dataSet, x);
                    products.Add(p);
                }
            }
            catch (Exception)
            {
            }
            return products;
        }

        public static void AddProduct(Product product)
        {
            //sql = $"INSERT INTO product VALUES({product.Id.ToString()}, {product.Name}, {product.Brand}, {product.Description}, {product.Length.ToString()}, {product.Width.ToString()}, {product.Height.ToString()}, {product.Category.ToString()}, {product.SellingPrice.ToString()}, {product.PriceWithoutVAT.ToString()})";
            sql = $"INSERT INTO product VALUES(@ID, @Name, @Brand, @Length, @Width, @Height, @SellingPrice, @PriceWithoutVAT, @DepotStock, @StoreStock, @DepotLocation, @Category, @Description)";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("ID", product.Id),
                new KeyValuePair<string, dynamic>("Name", product.Name),
                new KeyValuePair<string, dynamic>("Brand", product.Brand),
                new KeyValuePair<string, dynamic>("Length", product.Length),
                new KeyValuePair<string, dynamic>("Width", product.Width),
                new KeyValuePair<string, dynamic>("Height", product.Height),
                new KeyValuePair<string, dynamic>("SellingPrice", product.SellingPrice),
                new KeyValuePair<string, dynamic>("PriceWithoutVAT", product.PriceWithoutVAT),
                new KeyValuePair<string, dynamic>("DepotStock", product.DepotStock),
                new KeyValuePair<string, dynamic>("StoreStock", product.StoreStock),
                new KeyValuePair<string, dynamic>("DepotLocation", product.DepotLocation),
                new KeyValuePair<string, dynamic>("Category", product.Category.ID),
                new KeyValuePair<string, dynamic>("Description", product.Description)
            };

            try
            {
                DatabaseController.ExecuteInsert(sql, parameters);
            }
            catch (Exception e)
            {
            }
        }

        public static void EditProduct(Product product)
        {
            //UPDATE product SET `Name` = 'testproduct2345',`Brand` = 'testbrand',
            //`Description` = 'Descriotion',`Length` = 0,`Width` = 0,`Height` = 0,`Category` = 'No',`SellingPrice` = 0,`PriceWithoutVAT` = 0 WHERE id=4;


            /*sql = $"UPDATE product " +
                    $"SET `Name` = '{product.Name}'," +
                    $"`Brand` = '{product.Brand}'," +
                    $"`Length` = {product.Length}," +
                    $"`Width` = {product.Width}," +
                    $"`Height` = {product.Height}," +
                    $"`SellingPrice` = {product.SellingPrice}," +
                    $"`PriceWithoutVAT` = {product.PriceWithoutVAT}" +
                    $" WHERE id={product.Id}";*/

            sql = $"UPDATE `product` " +
                  $"SET Name = @Name," +
                  $"Brand = @Brand," +
                  $"Length = @Length," +
                  $"Width = @Width," +
                  $"Height = @Height," +
                  $"Category = @Category," +
                  $"SellingPrice = @SellingPrice," +
                  $"PriceWithoutVAT = @PriceWithoutVAT," +
                  $"DepotStock = @DepotStock," +
                  $"StoreStock = @StoreStock," +
                  $"DepotLocation = @DepotLocation," +
                  $"Category = @Category," +
                  $"Description = @Description" +
                  $" WHERE id= @ID;";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("ID", product.Id),
                new KeyValuePair<string, dynamic>("Name", product.Name),
                new KeyValuePair<string, dynamic>("Brand", product.Brand),
                new KeyValuePair<string, dynamic>("Length", product.Length),
                new KeyValuePair<string, dynamic>("Width", product.Width),
                new KeyValuePair<string, dynamic>("Height", product.Height),
                new KeyValuePair<string, dynamic>("SellingPrice", product.SellingPrice),
                new KeyValuePair<string, dynamic>("PriceWithoutVAT", product.PriceWithoutVAT),
                new KeyValuePair<string, dynamic>("DepotStock", product.DepotStock),
                new KeyValuePair<string, dynamic>("StoreStock", product.StoreStock),
                new KeyValuePair<string, dynamic>("DepotLocation", product.DepotLocation),
                new KeyValuePair<string, dynamic>("Category", product.Category.ID),
                new KeyValuePair<string, dynamic>("Description", product.Description)
            };
            try
            {
                DatabaseController.ExecuteInsert(sql, parameters);
            }
            catch (Exception)
            {
            }
        }

        public static void DeleteProduct(Product product)
        {
            sql = $"DELETE FROM product WHERE id= '@ID'";
            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("ID", product.Id)
            };

            try
            {
                DatabaseController.ExecuteInsert(sql, parameters);
            }
            catch (Exception)
            {
            }
        }

        public static string[] GetAllCategories()
        {
            sql = $"SELECT DISTINCT `category` FROM product;";

            List<string> categories = new List<string>();

            try
            {
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>> { };
                DataSet dataSet = DatabaseController.ExecuteSql(sql, parameters);

                for (int x = 0; x < dataSet.Tables[0].Rows.Count; x++)
                {
                    string category = (string)dataSet.Tables[0].Rows[x]["Category"];
                    categories.Add(category);
                }
            }
            catch (Exception)
            {
            }
            return categories.ToArray();
        }

        public static bool AddSoldProduct(Product product, int amountStore, int amountDepot, DateTime soldMoment)
        {
            sql = $"INSERT INTO soldproduct VALUES(@productId, @amountStore, @amountDepot, @soldMoment)";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("productId", product.Id),
                new KeyValuePair<string, dynamic>("amountStore", amountStore),
                new KeyValuePair<string, dynamic>("amountDepot", amountDepot),
                new KeyValuePair<string, dynamic>("soldMoment", soldMoment)
            };

            try
            {
                DatabaseController.ExecuteInsert(sql, parameters);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// This method returns all the products that have been sold as a List containing SoldProduct items
        /// </summary>
        /// <returns></returns>
        public static List<SoldProduct> ReadAllSoldProducts()
        {
            List<SoldProduct> soldProductsList = new List<SoldProduct>();

            sql = $"SELECT * FROM soldproduct JOIN product ON soldproduct.productId = product.ID";
            
            try
            {
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>> { };
                DataSet dataSet = DatabaseController.ExecuteSql(sql, parameters);

                for (int x = 0; x < dataSet.Tables[0].Rows.Count; x++)
                {
                    SoldProduct sp = Parsers.SoldProductParser.DataSetToProduct(dataSet, x);
                    soldProductsList.Add(sp);
                }
            }
            catch (Exception)
            {
            }
            return soldProductsList;
        }

        public static List<SoldProduct> RealAllSoldProductsLast30Days()
        {
            List<SoldProduct> soldProductsList = new List<SoldProduct>();

            sql = $"SELECT * FROM soldproduct JOIN product ON soldproduct.productId = product.ID WHERE soldproduct.soldMoment >= @dateString";
            
            DateTime dateTime30DaysAgo = DateTime.Now - TimeSpan.FromDays(30);
            string dateString = dateTime30DaysAgo.Year + "" + dateTime30DaysAgo.Month + "" + dateTime30DaysAgo.Day;
            
            try
            {
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                    new ("dateString", dateString),
                };
                DataSet dataSet = DatabaseController.ExecuteSql(sql, parameters);

                for (int x = 0; x < dataSet.Tables[0].Rows.Count; x++)
                {
                    SoldProduct sp = Parsers.SoldProductParser.DataSetToProduct(dataSet, x);
                    soldProductsList.Add(sp);
                }
            }
            catch (Exception)
            {
            }
            return soldProductsList;
        }

        public static List<int> GetSoldAmountsForProductAllTime(Product p)
        {
            sql = "SELECT `amountStore`, `amountDepot` FROM `soldproduct` WHERE productId = @prodId;";
            
            List<int> returnList = new List<int>();
            
            try
            {
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                    new ("prodId", p.Id),
                };
                DataSet dataSet = DatabaseController.ExecuteSql(sql, parameters);

                for (int x = 0; x < dataSet.Tables[0].Rows.Count; x++)
                {
                    int amountStore = (int) dataSet.Tables[0].Rows[x]["amountStore"];
                    int amountDepot = (int) dataSet.Tables[0].Rows[x]["amountDepot"];

                    if (returnList.Count == 0)
                    {
                        returnList.Add(amountStore);
                        returnList.Add(amountDepot);
                    }
                    else
                    {
                        returnList[0] += amountStore;
                        returnList[1] += amountDepot;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }

            return returnList;
        }
        
        public static List<int> GetSoldAmountsForProductLastDays(Product p, int days)
        {
            sql = "SELECT `amountStore`, `amountDepot` FROM `soldproduct` WHERE productId = @prodId AND soldMoment > @dateString;";
            
            List<int> returnList = new List<int>();
            DateTime dateTime30DaysAgo = DateTime.Now - TimeSpan.FromDays(days);
            string dateString = dateTime30DaysAgo.Year + "-" + dateTime30DaysAgo.Month + "-" + dateTime30DaysAgo.Day + " 00:00:00";
            
            try
            {
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                    new ("prodId", p.Id),
                    new ("dateString", dateString)
                };
                DataSet dataSet = DatabaseController.ExecuteSql(sql, parameters);

                for (int x = 0; x < dataSet.Tables[0].Rows.Count; x++)
                {
                    int amountStore = (int) dataSet.Tables[0].Rows[x]["amountStore"];
                    int amountDepot = (int) dataSet.Tables[0].Rows[x]["amountDepot"];

                    if (returnList.Count == 0)
                    {
                        returnList.Add(amountStore);
                        returnList.Add(amountDepot);
                    }
                    else
                    {
                        returnList[0] += amountStore;
                        returnList[1] += amountDepot;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }

            return returnList;
        }
        
        public static List<int> GetSoldAmountsForProductForDate(Product p, DateTime date)
        {
            sql = "SELECT `amountStore`, `amountDepot` FROM `soldproduct` WHERE productId = @prodId AND soldMoment > @dateStringBegin AND soldMoment <= @dateStringEnd;";
            
            List<int> returnList = new List<int>();
            string dateStringBegin = date.Year + "-" + date.Month + "-" + date.Day + " 00:00:00";
            string dateStringEnd = date.Year + "-" + date.Month + "-" + date.Day + " 23:59:59";
            
            try
            {
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                    new ("prodId", p.Id),
                    new ("dateStringBegin", dateStringBegin),
                    new ("dateStringEnd", dateStringEnd),
                };
                DataSet dataSet = DatabaseController.ExecuteSql(sql, parameters);

                for (int x = 0; x < dataSet.Tables[0].Rows.Count; x++)
                {
                    int amountStore = (int) dataSet.Tables[0].Rows[x]["amountStore"];
                    int amountDepot = (int) dataSet.Tables[0].Rows[x]["amountDepot"];

                    if (returnList.Count == 0)
                    {
                        returnList.Add(amountStore);
                        returnList.Add(amountDepot);
                    }
                    else
                    {
                        returnList[0] += amountStore;
                        returnList[1] += amountDepot;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }

            return returnList;
        }




        //CategoryDAL

        public static void AddNewCategory(ProductCategory pc)
        {

            string sql = "INSERT INTO `productcategory` (`categoryname`)" +
                                  "VALUES (@categoryname)";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                  new KeyValuePair<string, dynamic>("categoryname", pc.Name),

                };

            DatabaseController.ExecuteInsert(sql, parameters);

        }


        public static void UpdateCategory(ProductCategory pc)
        {
            string sql = "UPDATE `productcategory` SET categoryname = @categoryname WHERE `categoryid` = @categoryid";


            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                  new KeyValuePair<string, dynamic>("categoryid", pc.ID),
                  new KeyValuePair<string, dynamic>("categoryname", pc.Name),



                };


            DatabaseController.ExecuteInsert(sql, parameters);


        }



        public static List<ProductCategory> GetAllCategorys()
        {
            sql = "SELECT * FROM productcategory";

            List<ProductCategory> list = new List<ProductCategory>();

            try
            {
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>> { };
                DataSet dataSet = DatabaseController.ExecuteSql(sql, parameters);

                for (int x = 0; x < dataSet.Tables[0].Rows.Count; x++)
                {
                    ProductCategory p = Parsers.ProductParser.DataSetToCategory(dataSet, x);
                    list.Add(p);
                }
            }
            catch (Exception)
            {
            }
            return list;
        }

       

        public static ProductCategory GetCategoryByID(int id)
        {

            try
            {
                string sql = "SELECT * FROM productcategory WHERE categoryid = @categoryid";
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                  new KeyValuePair<string, dynamic>("categoryid", id),

                };


                DataSet d = DatabaseController.ExecuteSql(sql, parameters);
                ProductCategory pc = Parsers.ProductParser.DataSetToCategory(d, 0);
                return pc;



            }
            catch (Exception)
            {
                throw;
            }
        }



        /*public static void FilterProduct(string sql)
        {
            try
            {
                cmd = new MySqlCommand(sql, connection);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Error, failed to load data");
            }
            finally
            {
                connection.Close();
            }
        }*/
    }
}
