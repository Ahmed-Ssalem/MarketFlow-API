using AutoMapper;
using MarketFlow.Core.Dtos;
using MarketFlow.Core.Dtos.Shared;
using MarketFlow.Core.Entities;
using MarketFlow.Core.Interfaces;
using MarketFlow.Core.Interfaces.Services;

namespace MarketFlow.Services.Implementation
{
    public class StoreServices : IStoreServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StoreServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<StoreDto>> CreateStore(StoreForCreationDto storeForCreationDto)
        {
            if (storeForCreationDto == null)
                return new Response<StoreDto>("Please Add a store!!");

            var store = _mapper.Map<Store>(storeForCreationDto);

            _unitOfWork.Stores.Add(store);
            await _unitOfWork.Complete();

            var storeToReturn = _mapper.Map<StoreDto>(store);

            return new Response<StoreDto>(storeToReturn);
        }


        public async Task<Response<IEnumerable<StoresWithProductsDto>>> GetAllStores()
        {
            var stores = await _unitOfWork.Stores.GetStores();

            if (stores == null)
                return new Response<IEnumerable<StoresWithProductsDto>>("There are no stores yet!!");

            var storesToReturn = _mapper.Map<IEnumerable<StoresWithProductsDto>>(stores);

            return new Response<IEnumerable<StoresWithProductsDto>>(storesToReturn);
        }

        public async Task<Response<StoresWithProductsDto>> GetStoreById(long id)
        {
            var store = await _unitOfWork.Stores.GetStore(id);

            if (store == null)
                return new Response<StoresWithProductsDto>("Invalid store ID!!");

            var storeToReturn= _mapper.Map<StoresWithProductsDto>(store);

            return new Response<StoresWithProductsDto>(storeToReturn);
        }

        public async Task<Response<StoreDto>> DeleteStore(long id)
        {
            var store = await _unitOfWork.Stores.GetByIdAsync(id);

            if (store == null)
                return new Response<StoreDto>("Invalid store ID!!");

            var storeToReturn = _mapper.Map<StoreDto>(store);

            _unitOfWork.Stores.Delete(store);
            await _unitOfWork.Complete();

            return new Response<StoreDto>(storeToReturn);
        }

        public async Task<Response<StoreDto>> UpdateStore(long id, StoreForCreationDto storeForCreationDto)
        {
            var store = await _unitOfWork.Stores.GetByIdAsync(id);

            if (store == null)
                return new Response<StoreDto>("Invalid store ID!!");

            if (storeForCreationDto == null)
                return new Response<StoreDto>("Please add the store you want to update!!");

            var storeToUpdate = _mapper.Map(storeForCreationDto, store);

            _unitOfWork.Stores.Update(storeToUpdate);

            await _unitOfWork.Complete();

            var storeToReturn = _mapper.Map<StoreDto>(storeToUpdate);

            return new Response<StoreDto>(storeToReturn);

        }
    }
}
