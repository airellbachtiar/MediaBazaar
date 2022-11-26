using System.Collections.Generic;
using Media_Bazaar_Logic.Class;
using Media_Bazaar_Logic.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Media_Bazaar_Tests.Controllers_tests
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void ProductControllerConstructorTest()
        {
            ProductController pc = new ProductController();
            Assert.IsNotNull(pc);
        }
    }
}