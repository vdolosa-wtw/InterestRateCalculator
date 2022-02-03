using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestRateCalculator.Domain
{
    public interface IInterestCalculator
    {
        public IEnumerable<CalculationResult> Calculate(decimal value, int years);
    }
}
