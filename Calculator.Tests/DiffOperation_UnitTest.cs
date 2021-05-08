using Calculator.Core.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class DiffOperation_UnitTest
    {
        #region Fields

        private IOperation service;

        public DiffOperation_UnitTest()
        {
        }

        #endregion Fields

        #region Test Helpers

        [TestInitialize]
        public void Init()
        {
            service = new DiffOperation();
        }

        #endregion Test Helpers

        [TestMethod]
        public void Calculate_Test()
        {
            decimal result = service.Calculate(10, 50);
            Assert.AreEqual(result, -40);
        }
    }
}