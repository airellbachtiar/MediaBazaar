using System;
using System.Data;
using Media_Bazaar_Logic.Class;
using Media_Bazaar_Logic.DAL;

namespace Media_Bazaar_Logic.Parsers
{
    public static class StockRequestParser
    {
        public static StockRequest DataSetToStockRequest(DataSet table, int row)
        {
            int id = (int)table.Tables[0].Rows[row]["Id"];
            int productId = (int)table.Tables[0].Rows[row]["ProductId"];
            string enumString = (string)table.Tables[0].Rows[row]["State"];
            Enum.TryParse(enumString, out State state);
            int stockDepotNeeded = (int)table.Tables[0].Rows[row]["StockNeededDepot"];
            int stockStoreNeeded = (int)table.Tables[0].Rows[row]["StockNeededStore"];

            Product product = ProductDAL.GetProductById(productId);

            return new StockRequest(id, product, state, stockDepotNeeded, stockStoreNeeded);
        }
    }
}
