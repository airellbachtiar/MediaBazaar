using Media_Bazaar_Logic.Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Media_Bazaar_Tests.Class_tests
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void ProductConstructorTest1()
        {
            ProductCategory category = new ProductCategory(1, "Category");
            Product p = new Product("Product", "brand", 10, 10 ,10, 20, 17, 2, 3, "A12", category, "description");
            Assert.AreEqual("Product", p.Name);
        }

        [TestMethod]
        public void ProductConstructorTest2()
        {
            ProductCategory category = new ProductCategory(1, "Category");
            Product p = new Product(1, "Product", "brand", 10, 10 ,10, 20, 17, 2, 3, "A12", category, "description");
            Assert.AreEqual("Product", p.Name);
        }

        [TestMethod]
        public void ProductToStringTest()
        {
            ProductCategory category = new ProductCategory(1, "Category");
            Product p = new Product(1, "Product", "brand", 10, 10 ,10, 20, 17, 2, 3, "A12", category, "description");
            string expectedString = "Product[1, Product, brand, 10, 10, 10, 20, 17, 2, 3, A12, Category, description]";
            Assert.AreEqual(expectedString, p.ToString());
        }
    }
}