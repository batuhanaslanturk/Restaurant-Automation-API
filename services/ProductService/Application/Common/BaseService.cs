using AutoMapper;
using Domain.Common;
using Restaurant.Shared.Domain;
using System.Linq.Expressions;

namespace Application.Common
{
    public class BaseService<T, TDto> : IBaseService<T, TDto> where T : BaseEntity where TDto : class
    {
        private readonly IMapper _mapper;

        protected IBaseRepository<T> _repo { get; }
        protected IUnitOfWork _unitOfWork { get; }
        public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repo = unitOfWork.GetRepository<T>();
            _unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task AddAsync<TSource>(TSource source)
        {
            var entity = _mapper.Map<T>(source);
            await _repo.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync<TSource>(Guid id, TSource source)
        {
            var entity = _mapper.Map<T>(source);
            entity.Id = id;
            entity.SetUpdated();
            await _repo.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repo.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
        }
        public Task<T> GetByIdAsync(Guid id)
        {
            return _repo.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TDto>> GetListAsync(Expression<Func<T, bool>>? predicate = null)
        {
            var list = await _repo.GetListAsync(predicate);
            var mappedList = _mapper.Map<IEnumerable<TDto>>(list);
            return mappedList;
        }
    }
}
