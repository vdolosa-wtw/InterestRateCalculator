using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestRateCalculator.Domain
{
    public class CalculationSession
    {
        public Guid Id { get; set; }

        public decimal Value { get; set; }

        public int Years { get; set; }

        public DateTime DateTime { get; set; }

        public virtual ICollection<CalculationResult> Results { get; set; }

        public string UserId { get; set; }        
    }
}
