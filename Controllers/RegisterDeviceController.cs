using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database;
using Models;
using System.Text.Json;

namespace EGrowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterDeviceController : ControllerBase
    {
        private readonly MySqlContext _context;

        public RegisterDeviceController(MySqlContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Registracija eGrow naprave k uporabni�kem ra�unu
        /// </summary>
        /// <param name="newDevice">Objekt DeviceRegister</param>
        /// <returns>Objekt Device s podatki</returns>
        /// <response code="200">Naprava uspe�no registrirana k uporabni�kemu ra�unu.</response>
        /// <response code="400">Napaka pri registraciji naprave k uporabni�kemu ra�unu. Kontaktiraj support.</response>
        [HttpPost]
        public async Task<ActionResult<Device>> NewDevice(DeviceRegister newDevice)
        {
            try
            {
                var foundUser = await _context.Users
                .Include(user => user.Devices)
                .SingleAsync(user => user.UserGuid == newDevice.UserGuid);

                var foundDevice = await _context.Devices
                .Include(device => device.SensorMeasurements)
                .SingleAsync(device => device.DeviceGuid == newDevice.DeviceGuid);

                foundDevice.DeviceRegisteredToUser = DateTime.Now;
                foundDevice.User = foundUser;

                _context.Devices.Update(foundDevice);

                await _context.SaveChangesAsync();

                return Ok(foundDevice);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}