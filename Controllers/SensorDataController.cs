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
    public class SensorDataController : ControllerBase
    {
        private readonly MySqlContext _context;

        public SensorDataController(MySqlContext context)
        {
            _context = context;
        }

        // GET: api/SensorData
        /// <summary>
        /// Pridobi popolnoma vse meritve eGrow naprav v sistemu
        /// </summary>
        /// <returns>Seznam vseh meritev v sistemu (SensorData)</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorData>>> GetSensorData()
        {
            return await _context.SensorData.ToListAsync();
        }

        // GET: api/SensorData/5
        /// <summary>
        /// Pridobi doloèeno meritev po njeni ID številki
        /// </summary>
        /// <param name="id">SensorDataId številka</param>
        /// <returns>Najdena meritev (SensorData)</returns>
        /// <response code="204">Podatki meritve uspešno izpisani.</response>
        /// <response code="404">Meritev s tem SensorDataId ne obstaja.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<SensorData>> GetSensorData(int id)
        {
            var sensorData = await _context.SensorData.FindAsync(id);

            if (sensorData == null)
            {
                return NotFound();
            }

            return Ok(sensorData);
        }

        // PUT: api/SensorData/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Spreminjanje podatkov meritve
        /// </summary>
        /// <param name="id">SensorDataId meritve</param>
        /// <param name="sensorData">Posodovljen objekt SensorData</param>
        /// <returns></returns>
        /// <response code="204">Podatki meritve uspešno spremenjeni.</response>
        /// <response code="404">Meritev s tem SensorDataId ne obstaja.</response>
        /// <response code="400">"id" in field "SensorDataId" v ojbektu "SensorData" se ne ujemata.</response>
        /// <response code="500">Neprièakovana napaka. Kontaktirajte support.</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSensorData(int id, SensorData sensorData)
        {
            if (id != sensorData.SensorDataId)
            {
                return BadRequest();
            }

            _context.Entry(sensorData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensorDataExists(id))
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

        // POST: api/SensorData
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Dodajanje nove meritve
        /// </summary>
        /// <param name="sensorData">SensorData s podatki o meritvi</param>
        /// <returns>Vnesen objekt SensorData s podatki</returns>
        /// <response code="201">Meritev uspešno dodana in izpisana.</response>
        [HttpPost]
        public async Task<ActionResult<SensorData>> PostSensorData(SensorData sensorData)
        {
            _context.SensorData.Add(sensorData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSensorData", new { id = sensorData.SensorDataId }, sensorData);
        }

        // DELETE: api/SensorData/5
        /// <summary>
        /// Brisanje meritve iz sistema
        /// </summary>
        /// <param name="id">SensorDataId meritve</param>
        /// <returns></returns>
        /// <response code="204">Meritev uspešno izbrisana iz sistema.</response>
        /// <response code="404">Meritev s tem SensorDataId ne obstaja.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSensorData(int id)
        {
            var sensorData = await _context.SensorData.FindAsync(id);
            if (sensorData == null)
            {
                return NotFound();
            }

            _context.SensorData.Remove(sensorData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SensorDataExists(int id)
        {
            return _context.SensorData.Any(e => e.SensorDataId == id);
        }
    }
}
