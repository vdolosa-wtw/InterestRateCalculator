using InterestRateCalculator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InterestRateCalculator.DataProvider
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public virtual T Add(T entity)
        {
            return this.dbContext.Add(entity).Entity;
        }

        public int Count()
        {
            return this.dbContext.Set<T>().Count();
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return this.dbContext.Set<T>()
                        .AsQueryable()
                        .Where(predicate)
                        .ToList();
        }

        public virtual T Get(Guid id)
        {
            return this.dbContext.Find<T>(id);
        }

        public virtual IEnumerable<T> Get(int page = 0, int itemCount = 10)
        {
            return this.dbContext.Set<T>()
                        .AsQueryable()
                        .Skip(page * itemCount)
                        .Take(itemCount)
                        .ToList();
        }

        public virtual void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        public virtual T Update(T entity)
        {
            return this.dbContext.Update(entity).Entity;
        }
    }
}
