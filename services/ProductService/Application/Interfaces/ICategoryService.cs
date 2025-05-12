using Application.DTOs;
using Domain.Entities;
using Restaurant.Shared.Domain;

namespace Application.Interfaces
{
    public interface ICategoryService : IBaseService<Category, CategoryDTO>
    {
    }
}
