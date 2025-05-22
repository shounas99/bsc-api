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
    [Route("products")]
    [Authorize]
    public class ProductsController : ControllerBase
    {

        private readonly BscContext _context;
        public ProductsController(BscContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _context.Productos.ToListAsync();
            return Ok(products);
        }

    }
}
