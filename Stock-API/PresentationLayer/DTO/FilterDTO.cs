using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.DTO
{
    public class FilterDTO
    {
        [RegularExpression("^$|^([1-9]|1[0-9]|20)-([2-9]|1[0-9]|20|21)$")]
        public string? Budget { get; set; }
        [RegularExpression("^$|^[1-6]-[1-6]$|^([1-6](\\+([1-6])){0,5})$")]
        public string? FuelTypes { get; set; }
    }
}