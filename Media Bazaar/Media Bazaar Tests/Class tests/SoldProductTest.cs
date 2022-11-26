using System;
using System.Collections.Generic;
using Media_Bazaar_Logic.Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Media_Bazaar_Tests.Class_tests
{
    [TestClass]
    public class SoldProductTest
    {
        [TestMethod]
        public void SoldProductConstructorTest()
        {
            ProductCategory category = new ProductCategory(1, "Category");
            Product p = new Product("Product", "brand", 10, 10 ,10, 20, 17, 2, 3, "A12", category, "description");
            SoldProduct soldProduct = new SoldProduct(p, 10, 20, DateTime.Now);

            Assert.AreEqual(20, soldProduct.AmountDepot);
        }

        [TestMethod]
        public void SoldProductGetBestSellingProductTest()
        {
            ProductCategory category = new ProductCategory(1, "Category");
            Product p = new Product("Product", "brand", 10, 10 ,10, 20, 17, 2, 3, "A12", category, "description");
            SoldProduct soldProduct = new SoldProduct(p, 10, 20, DateTime.Now);
            
            Product p2 = new Product("Product2", "brand", 10, 10 ,10, 20, 17, 2, 3, "A12", category, "description");
            SoldProduct soldProduct2 = new SoldProduct(p2, 12, 20, DateTime.Now);

            Product bestSellingProduct =
                SoldProduct.GetBestSellingProduct(new List<SoldProduct> {soldProduct, soldProduct2});
            
            Assert.AreEqual(p2, bestSellingProduct);
        }

        [TestMethod]
        public void SoldProductGetSoldAmountForProductInListTest()
        {
            ProductCategory category = new ProductCategory(1, "Category");
            Product p = new Product("Product", "brand", 10, 10 ,10, 20, 17, 2, 3, "A12", category, "description");
            SoldProduct soldProduct = new SoldProduct(p, 10, 20, DateTime.Now);
            
            Product p2 = new Product("Product2", "brand", 10, 10 ,10, 20, 17, 2, 3, "A12", category, "description");
            SoldProduct soldProduct2 = new SoldProduct(p2, 12, 20, DateTime.Now);
            SoldProduct soldProduct3 = new SoldProduct(p2, 2, 1, DateTime.Now);

            List<SoldProduct> soldProducts = new List<SoldProduct> {soldProduct, soldProduct2, soldProduct3};
            
            Assert.AreEqual(35, SoldProduct.GetSoldAmountForProductInList(p2, soldProducts));
        }

        [TestMethod]
        public void SoldProductGetMostProfitableProductTest()
        {
            ProductCategory category = new ProductCategory(1, "Category");
            Product p = new Product("Product", "brand", 10, 10 ,10, 20, 5, 2, 3, "A12", category, "description");
            SoldProduct soldProduct = new SoldProduct(p, 10, 20, DateTime.Now);
            
            Product p2 = new Product("Product2", "brand", 10, 10 ,10, 20, 19, 2, 3, "A12", category, "description");
            SoldProduct soldProduct2 = new SoldProduct(p2, 12, 20, DateTime.Now);
            SoldProduct soldProduct3 = new SoldProduct(p2, 2, 1, DateTime.Now);

            List<SoldProduct> soldProducts = new List<SoldProduct> {soldProduct, soldProduct2, soldProduct3};
            
            Assert.AreEqual(p, SoldProduct.GetMostProfitableProduct(soldProducts));
        }

        [TestMethod]
        public void SoldProductGetProfitFromProductInListTest()
        {
            ProductCategory category = new ProductCategory(1, "Category");
            Product p = new Product("Product", "brand", 10, 10 ,10, 20, 17, 2, 3, "A12", category, "description");
            SoldProduct soldProduct = new SoldProduct(p, 10, 20, DateTime.Now);
            
            Product p2 = new Product("Product2", "brand", 10, 10 ,10, 20, 17, 2, 3, "A12", category, "description");
            SoldProduct soldProduct2 = new SoldProduct(p2, 12, 20, DateTime.Now);
            SoldProduct soldProduct3 = new SoldProduct(p2, 2, 1, DateTime.Now);

            List<SoldProduct> soldProducts = new List<SoldProduct> {soldProduct, soldProduct2, soldProduct3};
            
            Assert.AreEqual(105, SoldProduct.GetProfitFromProductInList(p2, soldProducts));
        }
    }
}
