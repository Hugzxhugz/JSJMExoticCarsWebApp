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
    public class UserController : ControllerBase
    {
        private readonly CarDbContext _context;

        public UserController(CarDbContext context)
        {
            _context = context;
        }

        // GET: api/user/get
        [HttpGet("get")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            return await _context.Users
                .Select(x => UserToDTO(x))
                .ToListAsync();
        }

        // GET: api/user/get/5
        [HttpGet("get/{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return UserToDTO(user);
        }

        // PUT: api/user/put/5      
        [HttpPut("put/{id}")]
        public async Task<IActionResult> PutUser(int id, UserDTO userDTO)
        {
            if (id != userDTO.Id)
            {
                return BadRequest();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Name = userDTO.Name;
            user.Funds = userDTO.Funds;

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/user/post      
        [HttpPost("post")]
        public async Task<ActionResult<UserDTO>> PostUser(UserDTO userDTO)
        {
            var user = new User
            {
                Name = userDTO.Name,
                Funds = userDTO.Funds,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var resultDto = new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Funds = user.Funds,
            };

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, resultDto);
        }

        // DELETE: api/car/delete/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private static UserDTO UserToDTO(User user) => new UserDTO
        {
            Id = user.Id,
            Name = user.Name,
            Funds = user.Funds,
        };
    }
}