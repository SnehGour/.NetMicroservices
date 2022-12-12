using System.ComponentModel.DataAnnotations;

namespace PlateformService.DTOs
{
    public class PlateformCreateDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public string Cost { get; set; }

    }
}