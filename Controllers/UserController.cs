using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database;
using Models;

namespace EGrowAPI.Controllers
{
    /// <summary>
    /// !!! ADMIN ONLY !!!
    /// 
    /// Ne uporabljaj te funkcionalnosti na front-end ali pa simulatorju!
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MySqlContext _context;

        public UserController(MySqlContext context)
        {
            _context = context;
        }

        // GET: api/User
        /// <summary>
        /// Seznam vseh uporabnikov v sistemu
        /// </summary>
        /// <returns>List vseh uporabnikov (User)</returns>
        /// <response code="200">Seznam vseh uporabnikov uspešno izpisan.</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return Ok(await _context.Users.Include(user => user.Devices).ToListAsync());
        }

        // GET: api/User/5
        /// <summary>
        /// Izpis podatkov doloèenega uporabnika
        /// </summary>
        /// <param name="id">UserId uporabnika</param>
        /// <returns>Podatki najdenega uporabnika</returns>
        /// <response code="200">Podatki najdenega uporabnika uspešno izpisani.</response>
        /// <response code="404">Uporabnik s tem UserId ne obstaja.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Spreminjanje podatkov nekega uporabnika
        /// </summary>
        /// <param name="id">UserId uporabnika</param>
        /// <param name="user">Objekt User s posodobljenimi podatki</param>
        /// <returns></returns>
        /// <response code="204">Podatki uporabnika uspešno spremenjeni.</response>
        /// <response code="404">Uporabnik s tem UserId ne obstaja.</response>
        /// <response code="400">"id" in field "UserId" v ojbektu "User" se ne ujemata.</response>
        /// <response code="500">Neprièakovana napaka. Kontaktirajte support.</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

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
                    return new ObjectResult("Neprièakovana napaka") { StatusCode = 500 };
                }
            }

            return NoContent();
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Dodajanje novega uporabnika. !!! NI NAMENJENO REGISTRACIJI !!!
        /// </summary>
        /// <param name="user">Objekt User s podatki uporabnika</param>
        /// <returns>Objekt User, ki je bil vnešen v sistem</returns>
        /// <response code="201">Objekt "User" s podatki, ki so bili vnešeni.</response>
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/User/5
        /// <summary>
        /// Odstranjevanje uporabnika iz sistema
        /// </summary>
        /// <param name="id">UserId uporabnika, katerega želimo odstraniti</param>
        /// <returns></returns>
        /// <response code="204">Uporabnik uspešno odstranjen iz sistema.</response>
        /// <response code="404">Uporabnik s tem UserId ne obstaja.</response>
        [HttpDelete("{id}")]
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
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
