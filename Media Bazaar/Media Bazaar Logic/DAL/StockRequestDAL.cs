using System;
using System.Collections.Generic;
using System.Data;
using Media_Bazaar_Logic.Class;

namespace Media_Bazaar_Logic.DAL
{
    public static class StockRequestDAL
    {
        private static string sql;

        public static List<StockRequest> GetAllStockRequests()
        {
            sql = "SELECT * FROM stockrequest";

            List<StockRequest> stockRequests = new List<StockRequest>();

            try
            {
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>> { };
                DataSet dataSet = DatabaseController.ExecuteSql(sql, parameters);

                for (int x = 0; x < dataSet.Tables[0].Rows.Count; x++)
                {
                    StockRequest sr = Parsers.StockRequestParser.DataSetToStockRequest(dataSet, x);
                    stockRequests.Add(sr);
                }
            }
            catch (Exception)
            {
                return null;
            }
            return stockRequests;
        }

        public static int AddStockRequest(StockRequest sr)
        {
            sql = $"INSERT INTO stockrequest VALUES(@ID, @ProductID, @State, @StockDepotNeeded, @StockStoreNeeded)";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("ID", sr.Id),
                new KeyValuePair<string, dynamic>("ProductID", sr.Product.Id),
                new KeyValuePair<string, dynamic>("State", sr.State.ToString()),
                new KeyValuePair<string, dynamic>("StockDepotNeeded", sr.StockDepotNeeded),
                new KeyValuePair<string, dynamic>("StockStoreNeeded", sr.StockStoreNeeded),
            };

            try
            {
                DatabaseController.ExecuteInsert(sql, parameters);
            }
            catch (Exception e)
            {
                return -1;
            }
            return 1;
        }

        public static int ChangeState(StockRequest stockRequest, State state)
        {
            sql = $"UPDATE `stockrequest` SET State = @State WHERE Id = @ID";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("State", state.ToString()),
                new KeyValuePair<string, dynamic>("ID", stockRequest.Id),
            };

            try
            {
                DatabaseController.ExecuteInsert(sql, parameters);
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static List<StockRequest> GetAllStockRequestsForProduct(Product p)
        {
            string productId = p.Id.ToString();
            sql = "SELECT * FROM stockrequest WHERE ProductId = @productId";

            List<StockRequest> stockRequests = new List<StockRequest>();

            try
            {
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                    new("productId", productId)
                };
                DataSet dataSet = DatabaseController.ExecuteSql(sql, parameters);

                for (int x = 0; x < dataSet.Tables[0].Rows.Count; x++)
                {
                    StockRequest sr = Parsers.StockRequestParser.DataSetToStockRequest(dataSet, x);
                    stockRequests.Add(sr);
                }
            }
            catch (Exception)
            {
                return null;
            }
            return stockRequests;
        }
    }
}
