using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketFlow.Core.Entities
{
    public class StoreProduct : BaseEntity
    {
  
        // Foreign Key Properties 
        
        public long StoreId { get; set; }
        public long ProductId { get; set; }


        // Navigation Properties
        
        [ForeignKey("StoreId")]
        public Store Store { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int ProductsQuantity { get; set; }
    }
}
