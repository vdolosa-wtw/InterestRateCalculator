using InterestRateCalculator.Domain.Models;
using System.Collections.Generic;

namespace InterestRateCalculator.Domain.Services
{
    public interface IInterestCalculatorService
    {
        public IEnumerable<CalculationResult> Calculate(decimal value, int years);

        public CalculationSession SaveCalculationSession(decimal value, int years, ICollection<CalculationResult> results);
    }
}
