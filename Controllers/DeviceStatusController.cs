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

        /// <summary>
        /// Posodabljanje stanja eGrow naprave. Pod to spadajo: kolièina razpoložljive vode in gnojila, ter podatki o morebitni trenutni napaki na strojni opremi eGrow.
        /// </summary>
        /// <param name="deviceUpdate">Objekt DeviceUpdate</param>
        /// <returns></returns>
        /// <response code="200">Podatki naprave uspešno posodobljeni.</response>
        /// <response code="400">Podatkov naprave, ni bilo možno posodobiti.</response>
        /// <response code="401">Ta naprava ne pripada uporabniku, ki ji posodablja podatke.</response>
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
            catch(Exception ex)
            {
                return BadRequest($"Device status was not updated. Error message: {ex.Message}");
            }
        }

    }
}