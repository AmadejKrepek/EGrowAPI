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
    public class LookupDevicesController : ControllerBase
    {
        private readonly MySqlContext _context;

        public LookupDevicesController(MySqlContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<User>> LookupDevices(string userGuid)
        {
            try
            {
                var foundUser = await _context.Users.SingleAsync(user => user.UserGuid == userGuid);

                await _context.Entry(foundUser)
                .Collection(user => user.Devices)
                .LoadAsync();
                foundUser.Password = "";
                return Ok(foundUser);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}