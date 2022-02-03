using IdentityServer4.EntityFramework.Options;
using InterestRateCalculator.Domain;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestRateCalculator.DataProvider
{
    public class ApplicationDbContext: ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<InterestConfiguration>()
                    .Property(x => x.Id)
                    .ValueGeneratedOnAdd();

            builder.Entity<InterestConfiguration>()
                    .HasData(new InterestConfiguration
                    {
                        Id = Guid.NewGuid(),
                        ConfigName = InterestConfiguration.NAME_INTEREST_LOWER,
                        Value = InterestConfiguration.DEFAULT_INTEREST_LOWER
                    },
                    new InterestConfiguration
                    {
                        Id = Guid.NewGuid(),
                        ConfigName = InterestConfiguration.NAME_INTEREST_UPPER,
                        Value = InterestConfiguration.DEFAULT_INTEREST_UPPER
                    },
                    new InterestConfiguration
                    {
                        Id = Guid.NewGuid(),
                        ConfigName = InterestConfiguration.NAME_INTEREST_INCREMENTAL,
                        Value = InterestConfiguration.DEFAULT_INTEREST_INCREMENTAL
                    });

            base.OnModelCreating(builder);
        }
    }
}
