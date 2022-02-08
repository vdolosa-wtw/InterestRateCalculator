using InterestRateCalculator.DataProvider.Models;
using InterestRateCalculator.Domain;
using InterestRateCalculator.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InterestRateCalculator.DataProvider
{
    public class CalculationSessionRepository : IRepository<CalculationSession>
    {
        protected readonly ApplicationDbContext dbContext;
        protected readonly IUserService userService;

        public CalculationSessionRepository(ApplicationDbContext dbContext,
                                               IUserService userService)
        {
            this.dbContext = dbContext;
            this.userService = userService;
        }

        public CalculationSession Add(CalculationSession entity)
        {
            var ntt = entity.ToEntity();
            ntt.UserId = this.userService.CurrentUser.Id;
            return this.dbContext.Add(ntt).Entity;
        }

        public int Count()
        {
            return this.dbContext.Set<CalculationSessionDataModel>().Count();
        }

        public IEnumerable<CalculationSession> Find(Expression<Func<CalculationSession, bool>> predicate)
        {
            return this.dbContext.Set<CalculationSessionDataModel>()
                        .AsQueryable()
                        .Include(p => p.Results)
                        .Include(p => p.User)
                        .Where(predicate)
                        .ToList()
                        .ToEntities();
        }

        public CalculationSession Get(Guid id)
        {
            var session = this.dbContext.Set<CalculationSessionDataModel>()
                            .AsQueryable()
                            .Include(p => p.CalculationResults)
                            .Include(p => p.User)
                            .Where(p => p.Id == id)
                            .FirstOrDefault();
            
            return session?.ToEntity();
        }

        public IEnumerable<CalculationSession> Get(int page = 0, int itemCount = 10)
        {
            return this.dbContext.Set<CalculationSessionDataModel>()
                        .AsQueryable()
                        .Include(p => p.CalculationResults)
                        .Include(p => p.User)
                        .Skip(page * itemCount)
                        .Take(itemCount)
                        .ToList()
                        .ToCalculationSessions();
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        public CalculationSession Update(CalculationSession entity)
        {
            var ntt = entity.ToEntity();
            ntt.UserId = this.userService.CurrentUser.Id;

            return this.dbContext.Update(ntt).Entity;
        }
    }
}
