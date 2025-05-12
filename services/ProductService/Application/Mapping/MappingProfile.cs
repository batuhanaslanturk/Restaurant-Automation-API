using Application.Commands;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryCommand, Category>();
            CreateMap<Category, CategoryDTO>();
        }
    }
}
