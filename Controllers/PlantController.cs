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
    public class PlantController : ControllerBase
    {
        private readonly MySqlContext _context;

        public PlantController(MySqlContext context)
        {
            _context = context;
        }

        // GET: api/Plant
        /// <summary>
        /// Pridobivanje seznama vseh rastlin v sistemu
        /// </summary>
        /// <returns>Seznam vseh rastlin (Plant)</returns>
        /// <response code="200">Seznam rastlin uspešno vrnjen.</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plant>>> GetPlant()
        {
            return Ok(await _context.Plant.ToListAsync());
        }

        // GET: api/Plant/5
        /// <summary>
        /// Pridobivanje podatkov specifiène rastline po njeni ID številki
        /// </summary>
        /// <param name="id">ID rastline</param>
        /// <returns>Objekt Plant s podatki o rastlini</returns>
        /// <response code="200">Podatki rastline uspešno izpisani.</response>
        /// <response code="404">Rastlina s tem ID ne obstaja.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<Plant>> GetPlant(int id)
        {
            var plant = await _context.Plant.FindAsync(id);

            if (plant == null)
            {
                return NotFound();
            }

            return Ok(plant);
        }

        // PUT: api/Plant/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Posodabljanje podatkov o rastlini
        /// </summary>
        /// <param name="id">ID rastline, kateri želimo posodobiti podatke</param>
        /// <param name="plant">Objekt Plant z novimi podatki o rastlini</param>
        /// <returns></returns>
        /// <response code="204">Podatki rastline uspešno spremenjeni.</response>
        /// <response code="404">Rastlina s tem ID ne obstaja.</response>
        /// <response code="400">"id" in field "PlantId" v ojbektu "plant" se ne ujemata.</response>
        /// <response code="500">Neprièakovana napaka. Kontaktirajte support.</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlant(int id, Plant plant)
        {
            if (id != plant.PlantId)
            {
                return BadRequest();
            }

            _context.Entry(plant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantExists(id))
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

        // POST: api/Plant
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Dodajanje nove rastline
        /// </summary>
        /// <param name="plant">Objekt nove rastline</param>
        /// <returns>Objekt rastline, ki je bila dodana v sistem</returns>
        /// <response code="201">Rastlina uspešno dodana v sistem.</response>
        [HttpPost]
        public async Task<ActionResult<Plant>> PostPlant(Plant plant)
        {
            _context.Plant.Add(plant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlant", new { id = plant.PlantId }, plant);
        }

        // DELETE: api/Plant/5
        /// <summary>
        /// Brisanje rastline iz sistema
        /// </summary>
        /// <param name="id">PlantId rastline, ki jo želimo izbrisati</param>
        /// <returns></returns>
        /// <response code="204">Rastlina uspešno odtsranjena.</response>
        /// <response code="404">Rastlina s tem ID ne obstaja.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlant(int id)
        {
            var plant = await _context.Plant.FindAsync(id);
            if (plant == null)
            {
                return NotFound();
            }

            _context.Plant.Remove(plant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlantExists(int id)
        {
            return _context.Plant.Any(e => e.PlantId == id);
        }
    }
}
