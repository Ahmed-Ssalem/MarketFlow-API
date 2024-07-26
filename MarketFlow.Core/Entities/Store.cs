using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketFlow.Core.Entities
{
    public class Store : BaseEntity
    {

        [MaxLength(300)]
        public string Name { get; set; }


        [MaxLength(600)]
        public string Address { get; set; }

        [MaxLength(20)]
        public string PhoneNum { get; set; }
     
        public List<StoreProduct> StoreProducts { get; set; }
    }
}
