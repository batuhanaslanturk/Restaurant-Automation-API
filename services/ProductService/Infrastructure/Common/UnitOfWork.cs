using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Restaurant.Shared.Domain;

namespace Infrastructure.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private ICategoryRepository _categoryRepository;
        private IProductRepository _productRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(_context);
        public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task RollbackAsync()
        {
            if (_context.Database.CurrentTransaction != null)
            {
                await _context.Database.CurrentTransaction.RollbackAsync();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            if (typeof(TEntity) == typeof(Category))
            {
                return (IBaseRepository<TEntity>)CategoryRepository;
            }
            else if (typeof(TEntity) == typeof(Product))
            {
                return (IBaseRepository<TEntity>)ProductRepository;
            }
            else
            {
                throw new NotImplementedException($"Repository for {typeof(TEntity).Name} not implemented.");
            }
        }
    }
}
