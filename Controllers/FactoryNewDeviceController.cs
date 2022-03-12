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
    public class FactoryNewDeviceController : ControllerBase
    {
        private readonly MySqlContext _context;

        public FactoryNewDeviceController(MySqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Ustvarjanje nove eGrow naprave. Namenjeno proizvodnji naprave, da pridobijo GUID.
        /// </summary>
        /// <param name="amountOfNewDevices">�tevilo naprav, kolikor jih �elimo ustvariti</param>
        /// <returns>Seznam naprav, ki so bile novo ustvarjene.</returns>
        /// <response code="200">Naprave uspe�no ustvarjene in izpisane.</response>
        /// <response code="400">Pri�lo je do napake pri ustvarjanju novih naprav. Glej povratno informacijo.</response>
        [HttpPost]
        public async Task<ActionResult<List<Device>>> NewDevice(int amountOfNewDevices)
        {
            List<Device> newDevices = new List<Device>();

            for (int number = 0; number < amountOfNewDevices; number++)
            {
                newDevices.Add(new Device { DeviceGuid = Guid.NewGuid().ToString(), DeviceManufactured = DateTime.Now });
            }
            try
            {
                await _context.AddRangeAsync(newDevices);
                await _context.SaveChangesAsync();

                return Ok(newDevices);
            }
            catch(Exception ex)
            {
                return BadRequest($"Failed to make new devices. Error message: {ex.Message}");
            }
        }
    }
}