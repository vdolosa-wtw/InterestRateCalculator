using InterestRateCalculator.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterestRateCalculator.DataProvider.Models
{
    [Table("CalculationSession")]
    public class CalculationSessionDataModel: CalculationSession
    {
        public ICollection<CalculationResultDataModel> CalculationResults { get; set; }

        public override ICollection<CalculationResult> Results {
            get
            {
                if (base.Results == null && this.CalculationResults != null)
                    base.Results = this.CalculationResults.ToCalculationResults();

                return base.Results;
            } 
            
            set => base.Results = value; 
        }

        public virtual ApplicationUser User { get; set; }
    }

    public static class CalculationSessionDataModelExtensions
    {
        public static CalculationSession ToCalculationSession(this CalculationSessionDataModel dataModel)
        {
            return new CalculationSession
            {
                Id = dataModel.Id,
                Value = dataModel.Value,
                Years = dataModel.Years,
                DateTime = dataModel.DateTime,
                Results = dataModel.CalculationResults.ToCalculationResults(),
                UserId = dataModel.UserId
            };
        }

        public static CalculationSessionDataModel ToEntity(this CalculationSession session)
        {
            return new CalculationSessionDataModel
            {
                Id = session.Id,
                Value = session.Value,
                Years = session.Years,
                DateTime = session.DateTime,
                CalculationResults = session.Results.ToEntities(),
                Results = session.Results,
                UserId = session.UserId
            };
        }

        public static ICollection<CalculationSession> ToCalculationSessions(this ICollection<CalculationSessionDataModel> dataModels)
        {
            var sessions = new List<CalculationSession>();

            foreach(var item in dataModels)
            {
                sessions.Add(item.ToCalculationSession());
            }

            return sessions;
        }

        public static ICollection<CalculationSessionDataModel> ToEntities(this ICollection<CalculationSession> sessions)
        {
            var entities = new List<CalculationSessionDataModel>();

            foreach(var item in sessions)
            {
                entities.Add(item.ToEntity());
            }

            return entities;
        }
    }

}
