using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JSJMExoticCarsWebApp.Models.Enums;

namespace JSJMExoticCarsWebApp.Models;

[Table("CarTable")]
public class Car
{
    [Key]
    [Column("Car_id")]
    public int Id { get; set; }

    [Required]
    [Column("car_model")]
    public string Model { get; set; }

    [Required]
    [Column("car_brand")]
    public string Brand { get; set; }

    [Required]
    [Column("car_model_year")]
    public int ModelYear { get; set; }

    [Required]
    [Column("car_milage")]
    public int Mileage { get; set; }

    [Column("car_description")]
    public string Description { get; set; }

    [Column("car_image_url")]
    public string ImageUrl { get; set; }
    
    [Required]
    [Column("car_transmission")]
    public TransmissionType Transmission { get; set;}

    [Required]
    [Column("car_fueltype")]
    public FuelType Fuel { get; set; }
}