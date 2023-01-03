using ElectronicsStore.Entities;
using ElectronicsStore.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ElectronicsStore.Models;

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
                .ForMember(m=>m.UserName , n=>n.MapFrom(b=>b.User.Email))
                .ForMember(m=>m.PutDate , n=>n.MapFrom((n=> ChangeDateTimeFormat(n.PutDate))));
        }
        public string ChangeDateTimeFormat(DateTime date)
        {
            return date.ToString("yyyy-MM-dd hh:mm:ss");
        }
    }
}
