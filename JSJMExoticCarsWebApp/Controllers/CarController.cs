using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JSJMExoticCarsWebApp.Models;

namespace JSJMExoticCarsWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarDbContext _context;

        public CarController(CarDbContext context)
        {
            _context = context;
        }

        // GET: api/car/get
        [HttpGet("get")]
        public async Task<ActionResult<IEnumerable<CarDTO>>> GetCars()
        {
            return await _context.Cars
                .Select(x => CarToDTO(x))
                .ToListAsync();
        }


        // GET: api/car/get/5
        [HttpGet("get/{id}")]
        public async Task<ActionResult<CarDTO>> GetCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return CarToDTO(car);
        }

        // PUT: api/car/put/5      
        [HttpPut("put/{id}")]
        public async Task<IActionResult> PutCar(int id, CarDTO carDTO)
        {
            if (id != carDTO.Id)
            {
                return BadRequest();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            car.Model = carDTO.Model;
            car.Brand = carDTO.Brand;
            car.ModelYear = carDTO.ModelYear;
            car.Mileage = carDTO.Mileage;
            car.Description = carDTO.Description;
            car.ImageUrl = carDTO.ImageUrl;
            car.Transmission = carDTO.Transmission;
            car.Fuel = carDTO.Fuel;
            car.Listed = carDTO.Listed;
            car.Price = carDTO.Price;

            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/car/post
        [HttpPost("post")]
        public async Task<ActionResult<CarDTO>> PostCar(CarDTO carDto)
        {   
            var car = new Car
            {
                Model = carDto.Model,
                Brand = carDto.Brand,
                ModelYear = carDto.ModelYear,
                Mileage = carDto.Mileage,
                Description = carDto.Description,
                ImageUrl = carDto.ImageUrl,
                Transmission = carDto.Transmission,
                Fuel = carDto.Fuel,
                Listed = carDto.Listed,
                Price = carDto.Price,                
            };

            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            
            var resultDto = new CarDTO
            {
                Id = car.Id,
                Model = car.Model,
                Brand = car.Brand,
                ModelYear = car.ModelYear,
                Mileage = car.Mileage,
                Description = car.Description,
                ImageUrl = car.ImageUrl,
                Transmission = car.Transmission,
                Fuel = car.Fuel,
                Listed = car.Listed,
                Price = car.Price
            };

            return CreatedAtAction(nameof(GetCar), new { id = car.Id }, resultDto);

        }

        // DELETE: api/car/delete/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {  
            
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarExists(int id)
        {
            return (_context.Cars?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private static CarDTO CarToDTO(Car car) => new CarDTO
        {
            Id = car.Id,
            Model = car.Model,
            Brand = car.Brand,
            ModelYear = car.ModelYear,
            Mileage = car.Mileage,
            Description = car.Description,
            ImageUrl = car.ImageUrl,
            Transmission = car.Transmission,
            Fuel = car.Fuel,
            Listed = car.Listed,
            Price = car.Price
        };
    }
}
