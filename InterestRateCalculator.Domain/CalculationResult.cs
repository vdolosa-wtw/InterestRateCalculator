using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestRateCalculator.Domain
{
    public class CalculationResult
    {
        public int Year { get; set; }

        public decimal CurrentValue { get; set; }

        public decimal InterestRate { get; set; }

        public decimal FutureValue { get; set; }
    }
}
