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
    public class RegisterDeviceController : ControllerBase
    {
        private readonly MySqlContext _context;

        public RegisterDeviceController(MySqlContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<User>> NewDevice(DeviceRegister newDevice)
        {
            try
            {
                var foundUser = await _context.Users
                .SingleAsync(user => user.UserGuid == newDevice.UserGuid);
                /*
                await _context.Entry(foundUser)
                .Collection(user => user.Devices)
                .LoadAsync();
                */
                foundUser.Devices.Add(
                    _context.Devices.Single(device => device.DeviceGuid == newDevice.DeviceGuid)
                );

                await _context.SaveChangesAsync();

                return Ok(foundUser.Devices);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}