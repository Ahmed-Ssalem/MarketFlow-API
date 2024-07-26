using AutoMapper;
using MarketFlow.Core.Dtos;
using MarketFlow.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketFlow.Core.Mapping_Profiles
{
    public class StoresMapper : Profile
    {
        public StoresMapper()
        {
            CreateMap<StoreForCreationDto, Store>();

            CreateMap<Store, StoreDto>();

            CreateMap<Store, StoresWithProductsDto>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.StoreProducts));

            CreateMap<StoreProduct, ProductsOfStore>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Product.Description))
                .ForMember(dest => dest.ProductQuantity, opt => opt.MapFrom(src => src.ProductsQuantity));


        }

    }
}
