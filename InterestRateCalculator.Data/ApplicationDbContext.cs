using IdentityServer4.EntityFramework.Options;
using InterestRateCalculator.DataProvider.Models;
using InterestRateCalculator.Domain.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

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
            builder.Entity<CalculationResultDataModel>()
                    .HasKey(cr => cr.Id);

            builder.Entity<CalculationSessionDataModel>()
                    .Ignore(cs => cs.Results);

            builder.Entity<CalculationSessionDataModel>()
                    .HasMany(cs => cs.CalculationResults)
                    .WithOne(cr => cr.Session)
                    .OnDelete(DeleteBehavior.Cascade);            

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
