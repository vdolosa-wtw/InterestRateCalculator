using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ObjectsComparer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace InterestRateCalculator.Domain.Test
{
    [TestClass]
    public class InterestCalculatorTest
    {
        [TestMethod]
        public void CanCalculateCorrectly()
        {
            var interestConfiguration = new Mock<IRepository<InterestConfiguration>>();
            var interestCalculator = new InterestCalculator(interestConfiguration.Object);
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
    }
}
