using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.DTO
{
    public class StockDTO
    {
        [Required]
        [Range(100000, 2100000)]
        public int Price { get; set; }
        [Required]
        public string FormattedPrice { get; set; }
        [Required]
        public string CarName { get; set; }
        [Required]
        public int Kms { get; set; }
        public bool IsValueForMoney { get; set; } 
        [Required]
        public string FuelType { get; set; }
    }
}