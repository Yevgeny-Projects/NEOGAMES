using Calculator.Core.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class DivOperation_UnitTest
    {
        #region Fields

        private IOperation service;

        public DivOperation_UnitTest()
        {
        }

        #endregion Fields

        #region Test Helpers

        [TestInitialize]
        public void Init()
        {
            service = new DivOperation();
        }

        #endregion Test Helpers

        [TestMethod]
        public void Calculate_Test()
        {
            decimal expected = 0.2M;
            decimal result = service.Calculate(10, 50);
            Assert.AreEqual(result, expected);
        }
    }
}