namespace JSJMExoticCarsWebApp.Models;

public class Car
{
    public string carModel { get; set; }
    public string carBrand { get; set; }
    public int yearModel { get; set; }
    public int mileage { get; set; }
    public string description { get; set; }
    public decimal price { get; set; }

    public Car()
    {
     
    }
}