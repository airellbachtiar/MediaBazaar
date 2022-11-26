using Media_Bazaar_Logic.Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Media_Bazaar_Tests.Class_tests
{
    [TestClass]
    public class PasswordHashingTest
    {
        [TestMethod]
        public void StringToHash()
        {
            string input = "1";
            string hash = PasswordHashingHelper.StringToHash(input);

            Assert.IsNotNull(hash);
        }
    }
}
