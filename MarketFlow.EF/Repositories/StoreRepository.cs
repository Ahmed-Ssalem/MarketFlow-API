using MarketFlow.Core.Entities;
using MarketFlow.Core.Interfaces.Reposetories;
using MarketFlow.Presistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketFlow.Presistence.Repositories
{
    public class StoreRepository : GenericRepository<Store>, IStoreRepository
    {
        private readonly MarketFlowDbContext _context;

        public StoreRepository(MarketFlowDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<Store> GetStore(long id)
        {
            return await _context.Stores
                .Where(s => s.Id == id && s.IsDeleted != true)
                .Include(s => s.StoreProducts)
                .ThenInclude(s => s.Product)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Store>> GetStores()
        {
            return await _context.Stores
                .Where(s => s.IsDeleted != true)
                .Include(s => s.StoreProducts)
                .ThenInclude(s => s.Product)
                .ToListAsync();
        }
    }
}
