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
    public class DeviceController : ControllerBase
    {
        private readonly MySqlContext _context;

        public DeviceController(MySqlContext context)
        {
            _context = context;
        }

        // GET: api/Device
        /// <summary>
        /// Seznam vseh naprav skupaj z SensorData (meritvami), ki jim pripadajo.
        /// </summary>
        /// <returns>List vseh naprav (Device)</returns>
        /// <response code="200">Naprave uspešno izpisane.</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevices()
        {
            return await _context.Devices.Include(device => device.SensorMeasurements).ToListAsync();
        }

        // GET: api/Device/5
        /// <summary>
        /// Iskanje naprave po njeni DeviceId
        /// </summary>
        /// <param name="id">ID naprave</param>
        /// <returns>Najden objekt Device</returns>
        /// <response code="200">Naprava najdena in izpisana.</response>
        /// <response code="404">Naprava s tem DeviceId ne obstaja.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<Device>> GetDevice(int id)
        {
            var device = await _context.Devices.FindAsync(id);

            if (device == null)
            {
                return NotFound();
            }

            return device;
        }

        // PUT: api/Device/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Sprememba podatkov eGrow naprave
        /// </summary>
        /// <param name="id">DeviceId naprave</param>
        /// <param name="device">Objekt Device s posodobljenimi podatki. DeviceId mora biti enak parametru "id".</param>
        /// <returns></returns>
        /// <response code="204">Podatki naprave uspešno spremenjeni.</response>
        /// <response code="404">Naprava s tem DeviceId ne obstaja.</response>
        /// <response code="400">"id" in field "DeviceId" v "device" se ne ujemata.</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevice(int id, Device device)
        {
            if (id != device.DeviceId)
            {
                return BadRequest();
            }

            _context.Entry(device).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(id))
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

        // POST: api/Device
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Dodajanje nove eGrow naprave.
        /// </summary>
        /// <param name="device">Objekt naprave</param>
        /// <returns>Objekt naprave, ki je bil shranjen</returns>
        /// <response code="201">Nova naprava uspešno dodana.</response>
        /// <response code="422">Prišlo je do napake pri dodajanju nove naprave. Glej resposne.</response>
        [HttpPost]
        public async Task<ActionResult<Device>> PostDevice(Device device)
        {
            try
            {
                _context.Devices.Add(device);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetDevice", new { id = device.DeviceId }, device);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(new {errorMessage = ex.Message});
            }
            
        }

        // DELETE: api/Device/5
        /// <summary>
        /// Odstranjevanje eGrow naprave. !!! Po izbrisu podatkov ne gre obnoviti !!!
        /// </summary>
        /// <param name="id">DeviceId naprave, katero želimo trajno izbrisati</param>
        /// <returns></returns>
        /// <response code="204">Naprava in pripadajoèi podatki uspešno izbrisani.</response>
        /// <response code="404">Naprava s tem DeviceId ne obstaja.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool DeviceExists(int id)
        {
            return _context.Devices.Any(e => e.DeviceId == id);
        }
    }
}
