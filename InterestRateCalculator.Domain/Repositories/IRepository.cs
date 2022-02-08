using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InterestRateCalculator.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        T Update(T entity);

        T Get(Guid id);

        IEnumerable<T> Get(int page = 0, int itemCount = 10);

        int Count();

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        void SaveChanges();
    }
}
