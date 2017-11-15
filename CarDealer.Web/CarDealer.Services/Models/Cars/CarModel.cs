namespace CarDealer.Services.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using CarDealer.Services.Models.Parts;

    public class CarModel
    {
        [Required]
        [MaxLength(50)]
        public string Make { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        [Display(Name = "Travelled Distance")]
        [Range(0, long.MaxValue, ErrorMessage = "{2} must be positive number.")]
        public long TravelledDistance { get; set; }
    }
}
