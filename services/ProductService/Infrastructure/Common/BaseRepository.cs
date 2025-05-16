using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Restaurant.Shared.Domain;
using System.Linq.Expressions;

namespace Infrastructure.Common
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public virtual async Task<T> GetByIdAsync(Guid id) => await BaseGetByIdAsync(id);

        public virtual async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null) => await BaseGetListAsync(predicate);

        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }
        protected async Task<IEnumerable<T>> BaseGetListAsync(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }


        protected async Task<T> BaseGetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes)
        {

            IQueryable<T> query = _dbSet.AsNoTracking();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
