using InterestRateCalculator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestRateCalculator.WebApp.Models
{
    public class SessionSaveViewModel
    {
        public decimal Value { get; set; }

        public int Years { get; set; }

        public ICollection<CalculationResult> Results {get;set;}
    }
}
