namespace JSJMExoticCarsWebApp.Models;

public class Car
{
    public string carModel { get; set; }
    public string carBrand { get; set; }
    public int yearModel { get; set; }
    public string description { get; set; }
    public decimal price { get; set; }

    public Car(string carModel, string carBrand, int yearModel, string description, decimal price)
    {
        this.carModel = carModel;
        this.carBrand = carBrand;
        this.yearModel = yearModel;
        this.description = description;
        this.price = price;
    }
   
}