using MarketFlow.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketFlow.Core.Interfaces.Reposetories
{
    public interface IStoreRepository : IGenericRepository<Store>
    {
        Task<IEnumerable<Store>> GetStores();
        Task<Store> GetStore(long id);
    }
}
