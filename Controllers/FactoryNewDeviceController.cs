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
            catch
            {
                return BadRequest("Failed to make new devices.");
            }
        }
    }
}