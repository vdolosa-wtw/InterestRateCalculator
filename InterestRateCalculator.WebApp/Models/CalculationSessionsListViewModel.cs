using InterestRateCalculator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestRateCalculator.WebApp.Models
{
    public class CalculationSessionsListViewModel
    {
        public int Count { get; set; }

        public IEnumerable<CalculationSession> Sessions { get; set; }
    }
}
