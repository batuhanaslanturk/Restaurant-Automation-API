using System.Linq.Expressions;

namespace Restaurant.Shared.Domain
{
    public interface IBaseService<T, TDto> where T : BaseEntity where TDto : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<TDto>> GetListAsync(Expression<Func<T, bool>>? predicate = null);
        Task AddAsync<TSource>(TSource source);
        Task UpdateAsync<TSource>(Guid id, TSource source);
        Task DeleteAsync(Guid id);
    }
}