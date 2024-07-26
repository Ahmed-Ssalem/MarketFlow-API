using MarketFlow.Core.Dtos;
using MarketFlow.Core.Dtos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketFlow.Core.Interfaces.Services
{
    public interface IStoreServices
    {
        Task<Response<StoresWithProductsDto>> GetStoreById(long id);
        Task<Response<IEnumerable<StoresWithProductsDto>>> GetAllStores();

        Task<Response<StoreDto>> CreateStore(StoreForCreationDto StoreForCreationDto);

        Task<Response<StoreDto>> DeleteStore(long id);

        Task<Response<StoreDto>> UpdateStore(long id, StoreForCreationDto StoreForCreationDto);
    }
}
