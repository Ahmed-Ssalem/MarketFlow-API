using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketFlow.Core.Entities
{
    public class Product : BaseEntity
    {

        [MaxLength(300)]
        public string Name { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        public double Price { get; set; }

        public List<StoreProduct> StoreProducts { get; set; }
    }
}
