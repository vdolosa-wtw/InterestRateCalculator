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

    public static class CalculationResultDataModelExtensions
    {
        public static CalculationResult ToCalculationResult(this CalculationResultDataModel dataModel)
        {
            return new CalculationResult
            {
                Year = dataModel.Year,
                CurrentValue = dataModel.CurrentValue,
                InterestRate = dataModel.InterestRate,
                FutureValue = dataModel.FutureValue
            };
        }

        public static CalculationResultDataModel ToEntity(this CalculationResult result)
        {
            return new CalculationResultDataModel
            {                
                Year = result.Year,
                CurrentValue = result.CurrentValue,
                InterestRate = result.InterestRate,
                FutureValue = result.FutureValue
            };
        }

        public static ICollection<CalculationResult> ToCalculationResults(this ICollection<CalculationResultDataModel> collection)
        {
            var results = new List<CalculationResult>();

            foreach(var item in collection)
            {
                results.Add(item.ToCalculationResult());
            }

            return results;
        }

        public static ICollection<CalculationResultDataModel> ToEntities(this ICollection<CalculationResult> results)
        {
            var entities = new List<CalculationResultDataModel>();

            foreach(var item in results)
            {
                entities.Add(item.ToEntity());
            }

            return entities;
        }
    }
}
