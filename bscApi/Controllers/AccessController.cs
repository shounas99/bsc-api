﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bscApi.Helpers;
using bscApi.Models;
using bscApi.DTO;
using Microsoft.AspNetCore.Authorization;
using bscApi.Repository;


namespace bscApi.Controllers
{
    [Route("access")]
    [AllowAnonymous]
    public class AccessController : ControllerBase
    {
        private readonly bscContext _context;
        private readonly Utils _utils;

        private readonly UserRepository _userRepository;
        public AccessController(bscContext context, Utils utils, UserRepository userRepository)
        {
            _context = context;
            _utils = utils;
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO register)
        {
            var user = await _context.Personas.FirstOrDefaultAsync(x => x.Correo == register.Correo);
            if (user != null)
            {
                return BadRequest("Ya existe un usuario con ese correo registrado.");
            }
            var person = new Persona
            {
                Nombre = register.Nombre,
                APaterno = register.APaterno,
                AMaterno = register.AMaterno,
                Domicilio = register.Domicilio,
                Telefono = register.Telefono,
                FNacimiento = DateTime.Now,
                FCreacion = DateTime.Now,
                FModifico = DateTime.Now,
                Correo = register.Correo,
                Contrasenia = _utils.encryptSHA256(register.Contrasenia!)
            };
            await _context.Personas.AddAsync(person);
            await _context.SaveChangesAsync();
            await _userRepository.AddUser(person.IdPersona, register.IdPerfil);

            if (person.IdPersona != 0)
            {
                return Ok(new { isSuccess = true });
            }
            else
            {
                return BadRequest(new { isSuccess = false });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dataLogin)
        {
            var existUser = await _context.Personas
                .Where(x => x.Correo == dataLogin.Correo
                    && x.Contrasenia == _utils.encryptSHA256(dataLogin.Contrasenia)
                 ).FirstOrDefaultAsync();
            if(existUser == null)
            {
                return BadRequest(new { isSuccess = false, token = "" });
            }
            else
            {
                return Ok(new { isSuccess = true, token = _utils.generateJwtToken(existUser) });
            }
        }

    }
}
