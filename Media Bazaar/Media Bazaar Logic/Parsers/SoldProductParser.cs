using System;
using System.Data;
using Media_Bazaar_Logic.Class;
using Media_Bazaar_Logic.Controllers;

namespace Media_Bazaar_Logic.Parsers
{
    public static class SoldProductParser
    {
        public static SoldProduct DataSetToProduct(DataSet table, int row)
        {
            int id = (int)table.Tables[0].Rows[row]["ID"];
            string name = (string)table.Tables[0].Rows[row]["Name"];
            string brand = (string)table.Tables[0].Rows[row]["Brand"];
            double length = (double)table.Tables[0].Rows[row]["Length"];
            double width = (double)table.Tables[0].Rows[row]["Width"];
            double height = (double)table.Tables[0].Rows[row]["Height"];
            double sellingPrice = (double)table.Tables[0].Rows[row]["SellingPrice"];
            double priceWithoutVAT = (double)table.Tables[0].Rows[row]["PriceWithoutVAT"];
            int depotStock = (int)table.Tables[0].Rows[row]["DepotStock"];
            int storeStock = (int)table.Tables[0].Rows[row]["StoreStock"];
            string depotLocation = (string)table.Tables[0].Rows[row]["DepotLocation"];
            int category = (int)table.Tables[0].Rows[row]["Category"];
            ProductCategory pc = ProductController.GetCategoryByID(category);

            string description = (string)table.Tables[0].Rows[row]["Description"];
            

            int amountStore = (int) table.Tables[0].Rows[row]["amountStore"];
            int amountDepot = (int) table.Tables[0].Rows[row]["amountDepot"];
            DateTime soldMoment = (DateTime)table.Tables[0].Rows[row]["soldMoment"];





            Product p = new Product(id, name, brand, length, width, height, sellingPrice, priceWithoutVAT, depotStock,
                storeStock, depotLocation, pc, description);

            return new SoldProduct(p, amountStore, amountDepot, soldMoment);
        }
    }
}