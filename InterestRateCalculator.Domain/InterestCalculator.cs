using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestRateCalculator.Domain
{
    public class InterestCalculator: IInterestCalculator
    {
        protected IRepository<InterestConfiguration> interestConfiguration;


        public InterestCalculator(IRepository<InterestConfiguration> interestConfiguration)
        {
            this.interestConfiguration = interestConfiguration;
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
    }
}
