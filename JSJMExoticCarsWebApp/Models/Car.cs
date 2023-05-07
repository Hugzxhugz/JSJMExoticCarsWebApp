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
    public string CarModel { get; set; }
    public string CarBrand { get; set; }
    public int YearModel { get; set; }
    public int Mileage { get; set; }
    [MaxLength(255)]
    public string Description { get; set; }
    public TransmissionType Transmission { get; set; }
    public FuelType Fuel { get; set; }
    public int Price { get; set; }
    

}