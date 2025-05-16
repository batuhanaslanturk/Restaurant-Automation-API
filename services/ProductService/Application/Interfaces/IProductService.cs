using Application.DTOs;
using Domain.Entities;
using Restaurant.Shared.Domain;

namespace Application.Interfaces
{
    public interface IProductService : IBaseService<Product, ProductDTO>
    {
    }
}
