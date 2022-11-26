using Media_Bazaar_Logic.Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Media_Bazaar_Tests.Class_tests
{
    [TestClass]
    public class StockRequestTest
    {
        [TestMethod]
        public void StockRequestConstructorTest1()
        {
            ProductCategory category = new ProductCategory(1, "Category");
            Product p = new Product(1, "Product", "brand", 10, 10 ,10, 20, 17, 2, 3, "A12", category, "description");
            StockRequest sr = new StockRequest(p, 20, 10);
            Assert.AreEqual(20, sr.StockDepotNeeded);
        }

        [TestMethod]
        public void StockRequestConstructorTest2()
        {
            ProductCategory category = new ProductCategory(1, "Category");
            Product p = new Product(1, "Product", "brand", 10, 10 ,10, 20, 17, 2, 3, "A12", category, "description");
            StockRequest sr = new StockRequest(1, p, State.Open, 20, 10);
            Assert.AreEqual(State.Open, sr.State);
        }
    }
}