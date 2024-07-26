using MarketFlow.Core.Dtos.Shared;
using MarketFlow.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketFlow.Core.Interfaces.Services
{
    public interface IProductServices
    {
        Task<Response<ProductDto>> GetProductById(long id);
        Task<Response<IEnumerable<ProductDto>>> GetAllProducts();

        Task<Response<ProductDto>> CreateProduct(ProductForCreationDto ProductForCreationDto);

        Task<Response<ProductDto>> DeleteProduct(long id);

        Task<Response<ProductDto>> UpdateProduct(long id, ProductForCreationDto ProductForCreationDto);
    }
}
