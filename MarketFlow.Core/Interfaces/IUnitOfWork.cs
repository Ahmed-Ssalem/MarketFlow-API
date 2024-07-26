using MarketFlow.Core.Entities;
using MarketFlow.Core.Interfaces.Reposetories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketFlow.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IStoreRepository Stores { get; }
        IGenericRepository<Product> Products { get; }

        Task<int> Complete();
    }
}
