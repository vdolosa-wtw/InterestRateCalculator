using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestRateCalculator.Domain
{
    public interface IInterestCalculatorService
    {
        public IEnumerable<CalculationResult> Calculate(decimal value, int years);

        public CalculationSession SaveCalculationSession(decimal value, int years, ICollection<CalculationResult> results);
    }
}
