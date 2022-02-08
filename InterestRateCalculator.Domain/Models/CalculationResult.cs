using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestRateCalculator.Domain.Models
{
    public class CalculationResult
    {
        /// <summary>
        /// Year count
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// The current value/amount
        /// </summary>
        public decimal CurrentValue { get; set; }

        /// <summary>
        /// Interest rate applied
        /// </summary>
        public decimal InterestRate { get; set; }

        /// <summary>
        /// The future value/amount
        /// </summary>
        public decimal FutureValue { get; set; }
    }
}
