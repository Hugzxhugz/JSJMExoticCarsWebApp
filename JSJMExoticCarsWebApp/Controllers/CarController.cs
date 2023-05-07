using JSJMExoticCarsWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JSJMExoticCarsWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        DatabaseContext dbc;

        public CarController(DatabaseContext dbc)
        {
            this.dbc = dbc;
        }

        [HttpGet]
        public List<Car> GetCars()
        {
            return dbc.Cars.ToList();
        }

    }
}
