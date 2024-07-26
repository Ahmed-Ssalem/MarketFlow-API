using MarketFlow.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketFlow.Presistence.Context
{
    public class MarketFlowDbContext : DbContext
    {
        public MarketFlowDbContext(DbContextOptions<MarketFlowDbContext> options) : base(options)
        {

        }

        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<StoreProduct> StoreProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StoreProduct>().HasData(
                new StoreProduct { Id = 1, StoreId = 1, ProductId = 1, ProductsQuantity = 5},
                new StoreProduct { Id = 2, StoreId = 1, ProductId = 2, ProductsQuantity = 60 },
                new StoreProduct { Id = 3, StoreId = 3, ProductId = 4, ProductsQuantity = 7 }
                );
        }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestamps()
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTimeOffset.UtcNow;
                    entry.Entity.UpdatedAt = DateTimeOffset.UtcNow;
                    entry.Entity.IsDeleted = false;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTimeOffset.UtcNow;
                }
                else if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                    entry.Entity.UpdatedAt = DateTimeOffset.UtcNow;
                }
            }
        }


    }
}
