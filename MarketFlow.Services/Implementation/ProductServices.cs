using AutoMapper;
using MarketFlow.Core.Dtos;
using MarketFlow.Core.Dtos.Shared;
using MarketFlow.Core.Entities;
using MarketFlow.Core.Interfaces;
using MarketFlow.Core.Interfaces.Services;

namespace MarketFlow.Services.Implementation
{
    public class ProductServices : IProductServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper  _mapper;

        public ProductServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<ProductDto>> CreateProduct(ProductForCreationDto productForCreationDto)
        {
            if (productForCreationDto == null)
                return new Response<ProductDto>("Please add a product!!");

            var product = _mapper.Map<Product>(productForCreationDto);
           
            _unitOfWork.Products.Add(product);
            
            await _unitOfWork.Complete();

            var productToReturn = _mapper.Map<ProductDto>(product);
            
            return new Response<ProductDto>(productToReturn);
        }

        public async Task<Response<ProductDto>> DeleteProduct(long id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product == null)
                return new Response<ProductDto>("Invalid product ID!!");

            _unitOfWork.Products.Delete(product);
            await _unitOfWork.Complete();

            var productToReturn = _mapper.Map<ProductDto>(product);

            return new Response<ProductDto>(productToReturn);
        }

        public async Task<Response<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var products = await _unitOfWork.Products.GetAllAsync();

            if (products == null)
                return new Response<IEnumerable<ProductDto>>("There are no products yet!!");
            
            var productsToReturn = _mapper.Map<IEnumerable<ProductDto>>(products);

            return new Response<IEnumerable<ProductDto>>(productsToReturn);
        }

        public async Task<Response<ProductDto>> GetProductById(long id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product == null)
                return new Response<ProductDto>("Invalid product ID!!");

            var productToReturn = _mapper.Map<ProductDto>(product);

            return new Response<ProductDto>(productToReturn);
        }

        public async Task<Response<ProductDto>> UpdateProduct(long id, ProductForCreationDto productForCreationDto)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product == null)
                return new Response<ProductDto>("Invalid product ID!!");

            if (productForCreationDto == null)
                return new Response<ProductDto>("Please add the product you want to update!!");

            var productToUpdate = _mapper.Map(productForCreationDto, product);

            _unitOfWork.Products.Update(productToUpdate);
            
            await _unitOfWork.Complete();

            var ProductToReturn = _mapper.Map<ProductDto>(productToUpdate);

            return new Response<ProductDto>(ProductToReturn);
        }
    }
}
