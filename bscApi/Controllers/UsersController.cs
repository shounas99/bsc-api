using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bscApi.Helpers;
using bscApi.Models;
using bscApi.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace bscApi.Controllers
{
    [Route("users")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly bscContext _context;
        public UsersController(bscContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _context.VwGetUsers.ToListAsync();
                return Ok(users);
                
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUsers()
        {
            try
            {
                var users = await _context.Usuarios.ToListAsync();
                return Ok(users);
                
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
