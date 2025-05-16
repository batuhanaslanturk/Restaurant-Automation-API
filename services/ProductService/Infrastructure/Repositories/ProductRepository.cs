using System.Linq.Expressions;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Common;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
        public override Task<IEnumerable<Product>> GetListAsync(Expression<Func<Product, bool>>? predicate = null)
        {
            return BaseGetListAsync(null, x => x.Category);
        }
    }
}
