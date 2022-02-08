using InterestRateCalculator.Domain.Models;

namespace InterestRateCalculator.DataProvider.Repositories
{
    public class InterestConfigurationRepository: BaseRepository<InterestConfiguration>
    {
        public InterestConfigurationRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
