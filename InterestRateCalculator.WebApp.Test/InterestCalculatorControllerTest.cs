using InterestRateCalculator.Domain.Models;
using InterestRateCalculator.Domain.Repositories;
using InterestRateCalculator.Domain.Services;
using InterestRateCalculator.WebApp.Controllers;
using InterestRateCalculator.WebApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace InterestRateCalculator.WebApp.Test
{
    [TestClass]
    public class InterestCalculatorControllerTest
    {
        [TestMethod]
        public void CanCalculationSessionsList()
        {
            var interestCalculatorService = new Mock<IInterestCalculatorService>();
            var calculationSessionRepository = new Mock<IRepository<CalculationSession>>();

            var interestCalculatorController = new InterestCalculatorController(interestCalculatorService.Object, 
                                                                                calculationSessionRepository.Object);

            interestCalculatorController.Get(0, 0);

            calculationSessionRepository.Verify(repo => repo.Count(), Times.Once());
            calculationSessionRepository.Verify(repo => repo.Get(It.IsAny<int>(), It.IsAny<int>()), Times.Once());
        }

        [TestMethod]
        public void CanSaveCalculationSession()
        {
            var interestCalculatorService = new Mock<IInterestCalculatorService>();
            var calculationSessionRepository = new Mock<IRepository<CalculationSession>>();

            var interestCalculatorController = new InterestCalculatorController(interestCalculatorService.Object,
                                                                                calculationSessionRepository.Object);

            interestCalculatorController.Post(new SessionSaveViewModel { });

            interestCalculatorService.Verify(service => service.SaveCalculationSession(It.IsAny<decimal>(), It.IsAny<int>(), It.IsAny<ICollection<CalculationResult>>()), Times.Once());
        }
    }    
}
