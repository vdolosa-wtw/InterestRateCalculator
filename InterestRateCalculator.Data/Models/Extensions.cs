using InterestRateCalculator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestRateCalculator.DataProvider.Models
{
    public static class Extensions
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
            List<CalculationResult> results = null;

            if (collection != null)
            {
                results = new List<CalculationResult>();

                foreach (var item in collection)
                {
                    results.Add(item.ToCalculationResult());
                }
            }

            return results;
        }

        public static ICollection<CalculationResultDataModel> ToEntities(this ICollection<CalculationResult> results)
        {
            List<CalculationResultDataModel> entities = null;

            if (results != null)
            {
                entities = new List<CalculationResultDataModel>();

                foreach (var item in results)
                {
                    entities.Add(item.ToEntity());
                }
            }

            return entities;
        }
    }
}
