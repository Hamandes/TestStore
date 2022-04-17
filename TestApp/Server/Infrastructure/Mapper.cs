using AutoMapper;
using TestApp.Domain.Dtos;
using TestApp.Infrastructure.Models;

namespace TestApp.Server.Infrastructure
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Product, ProductModel>().ForMember(
                    dest => dest.CategoryName,
                    opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Category, CategoryModel>().ReverseMap();
        }
    }
}
