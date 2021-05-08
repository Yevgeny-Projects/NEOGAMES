using Calculator.Core.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class MultOperation_UnitTest
    {
        #region Fields

        private IOperation service;

        public MultOperation_UnitTest()
        {
        }

        #endregion Fields

        #region Test Helpers

        [TestInitialize]
        public void Init()
        {
            service = new MultOperation();
        }

        #endregion Test Helpers

        [TestMethod]
        public void Calculate_Test()
        {
            decimal result = service.Calculate(10, 50);
            Assert.AreEqual(result, 500);
        }
    }
}