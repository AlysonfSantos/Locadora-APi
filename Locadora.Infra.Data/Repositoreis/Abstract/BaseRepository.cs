using Locadora.Domain.Interfaces;
using Locadora.Domain.Interfaces.Repositories;
using Locadora.Infra.Data.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Locadora.Infra.Data.Repositoreis.Abstract
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
     where T : class
    {
        protected readonly LocadoraContext _context;
        public BaseRepository(LocadoraContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }
    }
}
