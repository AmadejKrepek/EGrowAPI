using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.EntityFrameworkCore;

namespace EGrowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceStatusController : ControllerBase
    {
        private readonly MySqlContext _context;

        public DeviceStatusController(MySqlContext context)
        {
            _context = context;
        }

        [HttpPut]
        public async Task<ActionResult<List<Device>>> UpdateDeviceStatus(UpdateDevice deviceUpdate)
        {
            try
            {
                var foundDevice = await _context.Devices
                .Include(device => device.User)
                .SingleAsync(device => device.DeviceGuid == deviceUpdate.DeviceGuid);

                if (foundDevice.User.UserGuid != deviceUpdate.UserGuid)
                {
                    return Unauthorized();
                }

                foundDevice.WaterTankLevel = deviceUpdate.WaterTankLevel;
                foundDevice.FertilizerLevel = deviceUpdate.FertilizerLevel;
                foundDevice.HasError = deviceUpdate.HasError;
                foundDevice.ErrorMessage = deviceUpdate.ErrorMessage;

                _context.Devices.Update(foundDevice);
                await _context.SaveChangesAsync();

                return Ok(foundDevice);
            }
            catch
            {
                return BadRequest("Device status was not updated.");
            }
        }

    }
}