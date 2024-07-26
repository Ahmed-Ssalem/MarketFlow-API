using MarketFlow.Core.Interfaces;
using MarketFlow.Core.Entities;
using MarketFlow.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketFlow.Core.Interfaces.Reposetories;

namespace MarketFlow.Presistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MarketFlowDbContext _context;           
        public IStoreRepository Stores { get; private set; }
        public IGenericRepository<Product> Products { get;private set; }

        public UnitOfWork(MarketFlowDbContext context, IStoreRepository stores, IGenericRepository<Product> products)
        {
            _context = context;
            Stores = new StoreRepository(_context);
            Products = new GenericRepository<Product>(_context);
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
