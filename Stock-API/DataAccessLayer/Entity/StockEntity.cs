using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Utils;
namespace DataAccessLayer.Entity
{
    public class StockEntity
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string ProfileId { get; set; }
        [Required]
        [Range(100000,2100000)]
        public int Price { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name  { get; set; }
        [Required]
        public long Kms { get; set; }
        [Required]
        [ValidMakeYear]
        public int MakeYear { get; set; }
        [Required]
        [MaxLength(50)]
        public string MakeName { get; set; }
        [Required]
        [MaxLength(50)]
        public string MakeModel { get; set; }
        [Required]
        [MaxLength(10)]
        public string FuelType { get; set; }
    }
}