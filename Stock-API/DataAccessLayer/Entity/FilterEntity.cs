using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entity
{
    public class FilterEntity
    {
        [Required]
        [Range(1,20)]
        public int MinBudget { get; set; }
        [Required]
        [Range(2,21)]
        public int MaxBudget { get; set; }
        [Required]
        [MaxLength(6)]
        public List<string> FuelTypes { get; set; }       
    }
}