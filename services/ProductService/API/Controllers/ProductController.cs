using Application.Commands;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Restaurant.Shared.API;

namespace API.Controllers
{
    public class ProductController : MyBaseController<Product, ProductCommand, ProductDTO>
    {
        public ProductController(IProductService service) : base(service)
        {
        }
    }
}