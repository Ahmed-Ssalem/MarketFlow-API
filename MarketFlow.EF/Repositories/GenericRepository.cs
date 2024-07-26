using MarketFlow.Core.Entities;
using MarketFlow.Presistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketFlow.Core.Interfaces.Reposetories;

namespace MarketFlow.Presistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        private readonly  MarketFlowDbContext _context;
        public DbSet<T> _dbSet { get; set; }

        public GenericRepository(MarketFlowDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await _dbSet.Where(a => a.Id == id && !a.IsDeleted).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.Where(a => !a.IsDeleted).ToListAsync();
        }

        public void Add(T t)
        {
            _dbSet.Add(t);
        }

        public void Delete(T t)
        {
            _dbSet.Remove(t);
        }

        public void Update(T t)
        {
            _dbSet.Update(t);
        }
    }
}
