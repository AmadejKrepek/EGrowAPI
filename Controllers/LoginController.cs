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
    public class LoginController : ControllerBase
    {
        private readonly MySqlContext _context;

        public LoginController(MySqlContext context)
        {
            _context = context;
        }
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
                    foundUser.Password = "";

                    this.Response.Cookies.Append("token",foundUser.UserGuid);
                    return Ok(foundUser);
                }
                else
                {
                    return Unauthorized("Password is incorrect!");
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}