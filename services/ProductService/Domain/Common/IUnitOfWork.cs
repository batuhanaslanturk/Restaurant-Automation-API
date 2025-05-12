using Domain.Repositories;
using Restaurant.Shared.Domain;

namespace Domain.Common
{
    public interface IUnitOfWork : IBaseUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
    }
}
