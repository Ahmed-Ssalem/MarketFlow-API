using System.ComponentModel.DataAnnotations;


namespace MarketFlow.Core.Dtos
{
    public class ProductForCreationDto
    {

        [MaxLength(300)]
        public string Name { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        public double Price { get; set; }
    }
}
