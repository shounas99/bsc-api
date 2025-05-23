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
    [Route("catalogs")]
    [Authorize]
    public class CatalogsController : ControllerBase
    {
        private readonly bscContext _context;
        public CatalogsController(bscContext context)
        {
            _context = context;
        }

        [HttpGet("status/pedidos")]
        public async Task<IActionResult> GetStatusOrders()
        {
            try
            {
                var catOrders = await _context.CatEstatusPedidos.ToListAsync();
                return Ok(catOrders);
                
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet("status/users")]
        public async Task<IActionResult> GetStatusUsers()
        {
            try
            {
                var catUsers = await _context.CatEstatusUsuarios.ToListAsync();
                return Ok(catUsers);
                
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet("profiles")]
        public async Task<IActionResult> GetProfiles()
        {
            try
            {
                var catProfiles = await _context.Perfiles.ToListAsync();
                return Ok(catProfiles);
                
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet("category/products")]
        public async Task<IActionResult> GetCategoryProd()
        {
            try
            {
                var catProducs = await _context.CategoriaProductos.ToListAsync();
                return Ok(catProducs);
                
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        
    }
}
