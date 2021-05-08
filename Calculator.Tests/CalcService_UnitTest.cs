using Calculator.BL;
using Calculator.Core.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class CalcService_UnitTest
    {
        #region Fields

        private ICalcService service;

        public CalcService_UnitTest()
        {
        }

        #endregion Fields

        #region Test Helpers

        [TestInitialize]
        public void Init()
        {
            service = new CalcService();
        }

        #endregion Test Helpers

        [TestMethod]
        public void Calculate_Test()
        {
            decimal result = service.EvaluateExpression("10 + 20 * 30 / 10  - 5");
            Assert.AreEqual(result, 65);
        }
    }
}