namespace Restaurant.Shared.Domain
{
    public interface IBaseUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();
        Task RollbackAsync();
        IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
    }
}
