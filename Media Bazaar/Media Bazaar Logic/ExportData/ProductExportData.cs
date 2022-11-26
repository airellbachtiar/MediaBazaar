using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Media_Bazaar_Logic.Controllers;
using Media_Bazaar_Logic.Class;

namespace Media_Bazaar_Logic.ExportData
{
    public class ProductExportData : IExportDataFormat
    {
        public string GetCSVString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ID,Name,Brand,Length,Width,Height,SellingPrice,PriceWithoutVAT,DepotStock,StoreStock,DepotLocation,Category,Description");
            foreach (Product p in new ProductController().GetProducts())
            {
                sb.AppendLine(string.Format($"{p.Id},{p.Name},{p.Brand},{p.Length.ToString()},{p.Width.ToString()},{p.Height.ToString()},{p.SellingPrice.ToString()},{p.PriceWithoutVAT.ToString()},{p.DepotStock.ToString()},{p.StoreStock.ToString()},{p.DepotLocation},{p.Category.Name},{p.Description}"));
            }
            return sb.ToString();
        }
    }
}
