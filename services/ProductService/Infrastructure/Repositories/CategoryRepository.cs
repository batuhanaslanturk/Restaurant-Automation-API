using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Common;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
