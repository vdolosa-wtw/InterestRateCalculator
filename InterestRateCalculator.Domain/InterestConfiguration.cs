using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestRateCalculator.Domain
{
    public class InterestConfiguration
    {
        public const double DEFAULT_INTEREST_LOWER = 0.1;
        public const double DEFAULT_INTEREST_UPPER = 0.5;
        public const double DEFAULT_INTEREST_INCREMENTAL = 0.2;

        public Guid Id { get; set; }

        public string ConfigName { get; set; }

        public double Value { get; set; }
    }
}
