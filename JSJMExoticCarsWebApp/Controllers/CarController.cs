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
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            if (_context.Cars == null)
            {
                return NotFound();
            }
            return await _context.Cars.ToListAsync();
        }

        // GET: api/car/get/5
        [HttpGet("get/{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            if (_context.Cars == null)
            {
                return NotFound();
            }
            var car = await _context.Cars.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // PUT: api/car/put/5      
        [HttpPut("put/{id}")]
        public async Task<IActionResult> PutCar(int id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

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
            if (_context.Cars == null)
            {
                return NotFound();
            }
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
    }
}
