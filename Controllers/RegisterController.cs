using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database;
using Models;
using Utility;

namespace EGrowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly MySqlContext _context;

        public RegisterController(MySqlContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Register(NewUser userRegister)
        {
            if (await _context.Users.AnyAsync(user => user.Username == userRegister.Username))
            {
                return BadRequest("Username is taken.");
            }


            var newUser = new User
            {
                UserRegistration = DateTime.Now,
                Username = userRegister.Username,
                Password = userRegister.Password,
                Email = userRegister.Email,
                UserGuid = Utils.SafeRandomNumber()
            };

            var newEntity = _context.Users.Add(newUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return BadRequest();
            }

            return Ok(newEntity.Entity);
        }
    }
}