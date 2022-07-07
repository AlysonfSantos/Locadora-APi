using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Locadora.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        IUnitOfWork UnitOfWork { get; }
        Task<T> Get(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate);
    }
}
