using InterestRateCalculator.Domain.Models;
using InterestRateCalculator.Domain.Repositories;
using InterestRateCalculator.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace InterestRateCalculator.Domain.Test
{
    [TestClass]
    public class InterestCalculatorTest
    {
        [TestMethod]
        public void CanCalculateCorrectly()
        {
            var interestConfiguration = new Mock<IRepository<InterestConfiguration>>();
            var calculationSession = new Mock<IRepository<CalculationSession>>();
            var userService = new Mock<IUserService>();
            var interestCalculator = new InterestCalculatorService(interestConfiguration.Object, calculationSession.Object, userService.Object);
            var comparer = new ObjectsComparer.Comparer<IEnumerable<CalculationResult>>();

            interestConfiguration.Setup(x => x.Find(p => p.ConfigName == InterestConfiguration.NAME_INTEREST_UPPER))
                .Returns(new InterestConfiguration[] { 
                    new InterestConfiguration { 
                        Id = Guid.NewGuid(),
                        ConfigName = "INTEREST_UPPER_BOUND",
                        Value = 0.5m
                    }
                });

            interestConfiguration.Setup(x => x.Find(p => p.ConfigName == InterestConfiguration.NAME_INTEREST_LOWER))
                .Returns(new InterestConfiguration[] {
                    new InterestConfiguration {
                        Id = Guid.NewGuid(),
                        ConfigName = "INTEREST_LOWER_BOUND",
                        Value = 0.1m
                    }
                });

            interestConfiguration.Setup(x => x.Find(p => p.ConfigName == InterestConfiguration.NAME_INTEREST_INCREMENTAL))
                .Returns(new InterestConfiguration[] {
                    new InterestConfiguration {
                        Id = Guid.NewGuid(),
                        ConfigName = "INTEREST_INCREMENTAL",
                        Value = 0.2m
                    }
                });

            var expectedResult = new CalculationResult[]
            {
                new CalculationResult
                {
                    Year = 1,
                    CurrentValue = 1000m,
                    InterestRate = 0.1m,
                    FutureValue = 1100m
                },
                new CalculationResult
                {
                    Year = 2,
                    CurrentValue = 1100m,
                    InterestRate = 0.3m,
                    FutureValue = 1430m
                },
                new CalculationResult
                {
                    Year = 3,
                    CurrentValue = 1430m,
                    InterestRate = 0.5m,
                    FutureValue = 2145m
                },
                new CalculationResult
                {
                    Year = 4,
                    CurrentValue = 2145m,
                    InterestRate = 0.5m,
                    FutureValue = 3217.5m
                }
            };

            var result = interestCalculator.Calculate(1000, 4);

            bool isEqual = comparer.Compare(expectedResult, result);

            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void CanSaveCalculationSession()
        {
            var interestConfiguration = new Mock<IRepository<InterestConfiguration>>();
            var calculationSession = new Mock<IRepository<CalculationSession>>();
            var userService = new Mock<IUserService>();
            var interestCalculator = new InterestCalculatorService(interestConfiguration.Object, calculationSession.Object, userService.Object);

            userService.Setup(x => x.CurrentUser).Returns(new ApplicationUser { Id = It.IsAny<string>() });

            interestCalculator.SaveCalculationSession(0, 0, new List<CalculationResult>());

            calculationSession.Verify(service => service.Add(It.IsAny<CalculationSession>()), Times.Once());
            calculationSession.Verify(service => service.SaveChanges(), Times.Once());
        }
    }
}
