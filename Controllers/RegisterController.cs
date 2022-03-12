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

        /// <summary>
        /// Registracija novega uporabnika eGrow storitve
        /// </summary>
        /// <param name="userRegister">Objekt s podatki o uporabniku</param>
        /// <returns>Objekt s podatki registriranega uporabnika</returns>
        /// <response code="200">Uporabniški raèun uspešno ustvarjen.</response>
        /// <response code="409">Uporabnik s tem uporabniškim imenom že obstaja.</response>
        /// <response code="400">Napaka pri ustvarjanju uporabniškega raèuna.</response>
        [HttpPost]
        public async Task<ActionResult<User>> Register(NewUser userRegister)
        {
            if (await _context.Users.AnyAsync(user => user.Username == userRegister.Username))
            {
                return Conflict("Username is taken.");
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