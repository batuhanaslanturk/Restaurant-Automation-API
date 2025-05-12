using Application.Commands;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Restaurant.Shared.API;

namespace API.Controllers
{
    public class CategoryController : MyBaseController<Category, CategoryCommand, CategoryDTO>
    {
        public CategoryController(ICategoryService service) : base(service)
        {

        }
    }
}
