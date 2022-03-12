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
    public class LoginController : ControllerBase
    {
        private readonly MySqlContext _context;

        public LoginController(MySqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Prijava uporabnika v sistem
        /// </summary>
        /// <param name="loginUser">Objekt s podatki uporabnika. UserGuid se ob vsakem klicu metode spremeni.</param>
        /// <returns>Objekt s podatki o uporabniku. Field "Password" je namerno prazen string (seucirty reasons).</returns>
        /// <response code="200">Podatki uporabnika uspešno vrnjeni.</response>
        /// <response code="400">Prišlo je do napake pri prijavi uporabnika.</response>
        /// <response code="401">Neveljavno uporabniško ime ali geslo.</response>
        [HttpPost]
        public async Task<ActionResult<User>> Login(UserLogin loginUser)
        {
            try
            {
                var foundUser = await _context.Users.SingleAsync(user => user.Username == loginUser.Username);

                if (foundUser.Password == loginUser.Password)
                {
                    await _context.Entry(foundUser)
                    .Collection(user => user.Devices)
                    .LoadAsync();
                    
                    foundUser.UserGuid = Utils.SafeRandomNumber();
                    _context.Update(foundUser);
                    await _context.SaveChangesAsync();

                    foundUser.Password = "";

                    this.Response.Cookies.Append("token", foundUser.UserGuid);
                    return Ok(foundUser);
                }
                else
                {
                    return Unauthorized("Password or username is incorrect!");
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}