using JSJMExoticCarsWebApp.Models.Enums;
using Microsoft.VisualBasic.FileIO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace JSJMExoticCarsWebApp.Models;

[Table("CarTable")]
public class Car
{
    [Key]
    public int Id{ get; set; }
    
    [Required]
    [MaxLength(45)]
    [Column("car_model")]
    public string CarModel { get; set; }

    [Column("car_brand")]
    public string CarBrand { get; set; }

    [Column("car_year_model")]
    public int YearModel { get; set; }

    [Column("car_mileage")]
    public int Mileage { get; set; }

    [MaxLength(255)]
    [Column("car_description")]
    public string Description { get; set; }

    [Column("car_transmission_type")]
    public TransmissionType Transmission { get; set; }

    [Column("car_fuel_type")]
    public FuelType Fuel { get; set; }

    [Column("car_price")]
    public int Price { get; set; }
    

}