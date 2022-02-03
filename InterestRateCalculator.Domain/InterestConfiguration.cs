using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestRateCalculator.Domain
{
    public class InterestConfiguration
    {
        public const string NAME_INTEREST_LOWER = "INTEREST_LOWER_BOUND";
        public const string NAME_INTEREST_UPPER = "INTEREST_UPPER_BOUND";
        public const string NAME_INTEREST_INCREMENTAL = "INTEREST_INCREMENTAL";

        public const decimal DEFAULT_INTEREST_LOWER = 0.1m;
        public const decimal DEFAULT_INTEREST_UPPER = 0.5m;
        public const decimal DEFAULT_INTEREST_INCREMENTAL = 0.2m;        

        public Guid Id { get; set; }

        public string ConfigName { get; set; }

        public decimal Value { get; set; }
    }
}
