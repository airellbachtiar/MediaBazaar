using System;
using System.Collections.Generic;
using System.Linq;

namespace Media_Bazaar_Logic.Class
{
    public class SoldProduct
    {
        public Product Product { get; set; }
        public int AmountStore { get; set; }
        public int AmountDepot { get; set; }
        public DateTime SoldMoment { get; set; }
        
        /// <summary>
        /// Constructor for the SoldProduct class. This class contains information on a product that has been sold.
        /// </summary>
        /// <param name="product"></param>
        /// <param name="amountStore"></param>
        /// <param name="amountDepot"></param>
        /// /// <param name="soldMoment"></param>
        public SoldProduct(Product product, int amountStore, int amountDepot, DateTime soldMoment)
        {
            this.Product = product;
            this.AmountStore = amountStore;
            this.AmountDepot = amountDepot;
            this.SoldMoment = soldMoment;
        }

        /// <summary>
        /// Returns the most sold Product out of a List containing SoldProduct items
        /// </summary>
        /// <param name="soldProducts"></param>
        /// <returns></returns>
        public static Product GetBestSellingProduct(List<SoldProduct> soldProducts)
        {
            int index = -1;
            int soldAmount = 0;

            for (int i = 0; i < soldProducts.Count; i++)
            {
                SoldProduct currentProduct = soldProducts[i];

                if (currentProduct.AmountDepot + currentProduct.AmountStore > soldAmount)
                {
                    index = i;
                    soldAmount = currentProduct.AmountDepot + currentProduct.AmountStore;
                }
            }

            return soldProducts[index].Product;
        }
        
        public static int GetSoldAmountForProductInList(Product p, List<SoldProduct> soldProducts)
        {
            int soldAmount = 0;
            // Get the SoldProduct out of the list that is the same as p
            List<SoldProduct> filteredSoldProducts = soldProducts.Where(pr => pr.Product.Name.Equals(p.Name)).ToList();
            
            foreach (SoldProduct filteredSoldProduct in filteredSoldProducts)
            {
                soldAmount = soldAmount + filteredSoldProduct.AmountDepot + filteredSoldProduct.AmountStore;
            }

            return soldAmount;
        }

        /// <summary>
        /// Return the most profitable Product in a List containing SoldProduct items
        /// </summary>
        /// <param name="soldProducts"></param>
        /// <returns></returns>
        public static Product GetMostProfitableProduct(List<SoldProduct> soldProducts)
        {
            Product productIndex = null;
            double profitAmount = 0;

            // Dictionary containing all the distinct Products and the profit they made.
            Dictionary<Product, double> distinctProductsProfit = new Dictionary<Product, double>();

            // Add all Products to the dictionary distinctProducts
            foreach (SoldProduct soldProduct in soldProducts)
            {
                var matches = distinctProductsProfit.Where(p => p.Key.Name.Equals(soldProduct.Product.Name)).ToList();
                if (matches.Count == 0)
                {
                    distinctProductsProfit.Add(soldProduct.Product, 0);
                }
            }

            // Calculate the profit for each product in distinctProducts and add it to the dictionary
            foreach (Product product in distinctProductsProfit.Keys.ToList())
            {
                var matches = soldProducts.Where(p => p.Product.Name.Equals(product.Name)).ToList();
                foreach (SoldProduct soldProduct in matches)
                {
                    // Add the profit made
                    distinctProductsProfit[product] = distinctProductsProfit[product] + soldProduct.GetProfit();
                }
            }
            
            // Get the Product that made the most profit
            foreach (KeyValuePair<Product,double> keyValuePair in distinctProductsProfit.ToList())
            {
                if (keyValuePair.Value > profitAmount)
                {
                    productIndex = keyValuePair.Key;
                    profitAmount = keyValuePair.Value;
                }
            }
            
            return productIndex;
        }

        public static double GetProfitFromProductInList(Product p, List<SoldProduct> soldProducts)
        {
            double profit = 0;
            // Get the SoldProduct out of the list that is the same as p
            List<SoldProduct> filteredSoldProducts = soldProducts.Where(pr => pr.Product.Name.Equals(p.Name)).ToList();
            foreach (SoldProduct filteredSoldProduct in filteredSoldProducts)
            {
                profit = profit + filteredSoldProduct.GetProfit();
            }

            return profit;
        }

        /// <summary>
        /// Returns the profit made by this Product as a double
        /// </summary>
        /// <returns></returns>
        public double GetProfit()
        {
            double profit = this.Product.SellingPrice - this.Product.PriceWithoutVAT;
            return profit * (this.AmountStore + this.AmountDepot);
        }
    }
}