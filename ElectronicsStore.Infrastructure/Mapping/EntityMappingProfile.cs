using ElectronicsStore.Entities;
using ElectronicsStore.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ElectronicsStore.Infrastructure.Mapping
{
    public class EntityMappingProfile : Profile
    {
        public EntityMappingProfile()
        {
            CreateMap<Product, ProductDto>()
            .ForMember(m => m.CategoryName, n => n.MapFrom(b => b.Category.Name))
            .ForMember(m => m.BrandName, n => n.MapFrom(b => b.Brand.Name))
            ;

            CreateMap<ProductDto, Product>();
            CreateMap<Category, CategoryDto>();
            CreateMap<RegisterDto, User>();
            CreateMap<PurchaseItemDto, PurchaseItem>();
            CreateMap<PurchaseItem, PurchaseItemDto>()
                .ForMember(m=>m.Name, n=>n.MapFrom(b=>b.Product.Name));
            CreateMap<Order, OrderDto>()
                .ForMember(m=>m.UserName , n=>n.MapFrom(b=>b.User.Email));
        }
    }
}
