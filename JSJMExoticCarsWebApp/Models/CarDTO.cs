using System.ComponentModel.DataAnnotations;
using JSJMExoticCarsWebApp.Models.Enums;

namespace JSJMExoticCarsWebApp.Models
{
    public class CarDTO
    {
        public int Id { get; set; }

        [Required]
        public string Model { get; set; } = string.Empty;

        [Required]
        public string Brand { get; set; } = string.Empty;

        [Required]
        public int ModelYear { get; set; }

        [Required]
        public int Mileage { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        public TransmissionType Transmission { get; set; }

        [Required]
        public FuelType Fuel { get; set; }

        [Required]
        public bool Listed { get; set; }

        [Required]
        public int Price { get; set; }
    }
}
