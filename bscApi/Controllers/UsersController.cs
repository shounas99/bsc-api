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
        [HttpGet("clients")]
        public async Task<ObjectResult> GetClients()
        {
            try
            {
                var clients = await _context.VwGetClients.ToListAsync();
                return Ok(clients);
                
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPut("{idUsuario}")]
        public async Task<ObjectResult> ChangeStatus([FromRoute] int idUsuario)
        {
            try
            {
                var user = await _context.Usuarios.Where(x => x.IdPersona == idUsuario).FirstOrDefaultAsync();
                var activeS = await _context.CatEstatusUsuarios.Where(x => x.EstatusUsuarios == "Activo").Select(x => x.IdEstatusUsuario).FirstOrDefaultAsync();
                var inactiveS = await _context.CatEstatusUsuarios.Where(x => x.EstatusUsuarios == "Inactivo").Select(x => x.IdEstatusUsuario).FirstOrDefaultAsync();

                if (activeS == user.IdEstatusUsuario)
                {
                    user.IdEstatusUsuario = inactiveS;
                } else {
                    user.IdEstatusUsuario = activeS;
                }
                _context.Usuarios.Update(user);
                await _context.SaveChangesAsync();
                return new OkObjectResult(user);
                
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
