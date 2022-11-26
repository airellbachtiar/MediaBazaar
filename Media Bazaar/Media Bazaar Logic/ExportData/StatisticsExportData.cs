using System.Collections.Generic;
using System.Text;
using Media_Bazaar_Logic.Class;
using Media_Bazaar_Logic.Controllers;
using Media_Bazaar_Logic.DAL;

namespace Media_Bazaar_Logic.ExportData
{
    public class StatisticsExportData : IExportDataFormat
    {
        public string GetCSVString()
        {
            List<SoldProduct> AllSoldProducts = ProductDAL.ReadAllSoldProducts();
            List<SoldProduct> SoldProductsLast30Days = ProductDAL.RealAllSoldProductsLast30Days();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Statistic name, Statistic content");

            // All time statistics:
            Product bestSellingProduct = SoldProduct.GetBestSellingProduct(AllSoldProducts);
            sb.AppendLine("Most bought product all time," + bestSellingProduct.Name);
            sb.AppendLine("Most bought product amount sold all time," + SoldProduct.GetSoldAmountForProductInList(bestSellingProduct, AllSoldProducts));
            Product mostProfitableProduct = SoldProduct.GetMostProfitableProduct(AllSoldProducts);
            sb.AppendLine("Most profitable product all time," + mostProfitableProduct.Name);
            sb.AppendLine("Most profitable product all time profit,€" + SoldProduct.GetProfitFromProductInList(mostProfitableProduct, AllSoldProducts));
            User mostSickUser = SickDayDAL.GetMostSickUserAllTime();
            sb.AppendLine("Most sick employee all time," + mostSickUser.FirstName + " " + mostSickUser.SurName);
            sb.AppendLine("Amount of sick employees all time," + SickDayDAL.GetTotalAmountOfSickEmployees());
            
            // 30 days statistics:
            Product bestSellingProduct30 = SoldProduct.GetBestSellingProduct(SoldProductsLast30Days);
            sb.AppendLine("Most bought product last 30 days," + bestSellingProduct30.Name);
            sb.AppendLine("Most bought product amount sold last 30 days," + SoldProduct.GetSoldAmountForProductInList(bestSellingProduct30, SoldProductsLast30Days));
            Product mostProfitableProduct30 = SoldProduct.GetMostProfitableProduct(SoldProductsLast30Days);
            sb.AppendLine("Most profitable product last 30 days," + mostProfitableProduct30.Name);
            sb.AppendLine("Most profitable product last 30 days profit,€" + SoldProduct.GetProfitFromProductInList(mostProfitableProduct30, SoldProductsLast30Days));
            User mostSickUser30 = SickDayDAL.GetMostSickUserLast30Days();
            sb.AppendLine("Most sick employee last 30 days," + mostSickUser30.FirstName + " " + mostSickUser30.SurName);
            sb.AppendLine("Amount of sick employees last 30 days," + SickDayDAL.GetTotalAmountOfSickEmployeesLast30Days());
            
            // General statistics:
            List<Product> allProductsInTotal = ProductDAL.GetAllProducts();
            int allProductsAmount = allProductsInTotal.Count;
            List<Product> availableProducts = FilterProductsInStock(allProductsInTotal);
            sb.AppendLine("Amount of products being sold," + availableProducts.Count);
            sb.AppendLine("Amount of different products ever being sold," + allProductsAmount);
            
            return sb.ToString();
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
    }
}