using InterestRateCalculator.Domain;
using InterestRateCalculator.WebApp.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace InterestRateCalculator.WebApp.Test
{
    [TestClass]
    public class CalculateInterestControllerTest
    {
        [TestMethod]
        public void CanCallGetFromCalculateInterestController()
        {
            var interestCalculator = new Mock<IInterestCalculatorService>();
            var calculateInterestController = new CalculateInterestController(interestCalculator.Object);
            calculateInterestController.Get(0, 0);

            interestCalculator.Verify(calc => calc.Calculate(It.IsAny<decimal>(), It.IsAny<int>()), Times.AtMostOnce());
        }
    }
}
