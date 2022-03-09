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
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly MySqlContext _context;

        public SensorController(MySqlContext context)
        {
            _context = context;
        }

        // GET: api/Sensor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorData>>> GetSensorData()
        {
            return await _context.SensorData.ToListAsync();
        }

        // GET: api/Sensor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SensorData>> GetSensorData(Guid id)
        {
            var sensorData = await _context.SensorData.FindAsync(id);

            if (sensorData == null)
            {
                return NotFound();
            }

            return sensorData;
        }

        // PUT: api/Sensor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSensorData(string id, SensorInput sensorData)
        {
            var newSensorData = sensorData.ToSensorData();
            newSensorData.Id = Guid.Parse(id);

            _context.SensorData.Update(
                newSensorData
            );

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensorDataExists(Guid.Parse(id)))
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

        // POST: api/Sensor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SensorData>> PostSensorData(SensorInput sensorData)
        {
            _context.SensorData.Add(sensorData.ToSensorData());
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Sensor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSensorData(Guid id)
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

        private bool SensorDataExists(Guid id)
        {
            return _context.SensorData.Any(e => e.Id == id);
        }
    }
}
