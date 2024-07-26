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
    public class ProductsMapper : Profile
    {
        public ProductsMapper()
        {
            CreateMap<ProductForCreationDto, Product>();

            CreateMap<Product,ProductDto>();
        }
    }
}
