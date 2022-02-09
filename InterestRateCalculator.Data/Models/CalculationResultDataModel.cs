using InterestRateCalculator.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterestRateCalculator.DataProvider.Models
{
    [Table("CalculationResult")]
    public class CalculationResultDataModel
    {
        public Guid Id { get; set; }

        public int Year { get; set; }
        
        public decimal CurrentValue { get; set; }
                
        public decimal InterestRate { get; set; }
                
        public decimal FutureValue { get; set; }

        public CalculationSessionDataModel Session { get; set; }
    }    
}
