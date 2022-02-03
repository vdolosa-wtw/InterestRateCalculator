using InterestRateCalculator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestRateCalculator.DataProvider
{
    public class InterestConfigurationRepository: BaseRepository<InterestConfiguration>
    {
        public InterestConfigurationRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
