using InterestRateCalculator.Domain.Models;
using InterestRateCalculator.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InterestRateCalculator.Domain.Services
{
    public class InterestCalculatorService: IInterestCalculatorService
    {
        protected readonly IRepository<InterestConfiguration> interestConfiguration;
        protected readonly IRepository<CalculationSession> calculationSession;
        protected readonly IUserService userService;

        public InterestCalculatorService(IRepository<InterestConfiguration> interestConfiguration,
                                    IRepository<CalculationSession> calculationSession,
                                    IUserService userService)
        {
            this.interestConfiguration = interestConfiguration;
            this.calculationSession = calculationSession;
            this.userService = userService;
        }

        #region Properties

        private decimal? _upperBoundInterestRate;

        protected decimal? UpperBoundInterestRate
        {
            get
            {
                if (!this._upperBoundInterestRate.HasValue)
                {
                    var config = this.interestConfiguration.Find(p => p.ConfigName == InterestConfiguration.NAME_INTEREST_UPPER).FirstOrDefault();

                    this._upperBoundInterestRate = config?.Value;
                }

                return this._upperBoundInterestRate;
            }
        }

        private decimal? _lowerBoundInterestRate;

        protected decimal? LowerBoundInterestRate
        {
            get
            {
                if (!this._lowerBoundInterestRate.HasValue)
                {
                    var config = this.interestConfiguration.Find(p => p.ConfigName == InterestConfiguration.NAME_INTEREST_LOWER).FirstOrDefault();

                    this._lowerBoundInterestRate = config?.Value;
                }

                return this._lowerBoundInterestRate;
            }
        }

        private decimal? _incrementalInterestRate;

        protected decimal? IncrementalInterestRate
        {
            get
            {
                if (!this._incrementalInterestRate.HasValue)
                {
                    var config = this.interestConfiguration.Find(p => p.ConfigName == InterestConfiguration.NAME_INTEREST_INCREMENTAL).FirstOrDefault();

                    this._incrementalInterestRate = config?.Value;
                }

                return this._incrementalInterestRate;
            }
        }

        #endregion

        public IEnumerable<CalculationResult> Calculate(decimal value, int years)
        {
            decimal? upperBoundInterestRate = this.UpperBoundInterestRate,
                    lowerBoundInterestRate = this.LowerBoundInterestRate,
                    incrementalInterestRate = this.IncrementalInterestRate;

            if (upperBoundInterestRate.HasValue
                && lowerBoundInterestRate.HasValue
                && incrementalInterestRate.HasValue)
            {

                decimal currentRate = lowerBoundInterestRate.Value,
                        currentValue = value;

                bool maxIncrementReached = false;

                for (int year = 1; year <= years; year++)
                {
                    decimal futureValue = currentValue * (1m + currentRate);

                    yield return new CalculationResult
                    {
                        Year = year,
                        CurrentValue = currentValue,
                        InterestRate = currentRate,
                        FutureValue = futureValue
                    };

                    currentValue = futureValue;

                    if (!maxIncrementReached)
                    {
                        currentRate += incrementalInterestRate.Value;

                        if (currentRate >= upperBoundInterestRate.Value)
                        {
                            currentRate = upperBoundInterestRate.Value;
                            maxIncrementReached = true;
                        }
                    }
                }
            }
            else
            {
                yield break;
            }

        }

        public CalculationSession SaveCalculationSession(decimal value, int years, ICollection<CalculationResult> results)
        {
            var session = new CalculationSession
            {
                DateTime = DateTime.UtcNow,
                Value = value,
                Years = years,
                Results = results,
                UserId = this.userService.CurrentUser.Id
            };

            var sesh = this.calculationSession.Add(session);

            this.calculationSession.SaveChanges();

            return sesh;
        }
    }
}
