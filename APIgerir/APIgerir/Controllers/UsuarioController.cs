using APIgerir.Dominios;
using APIgerir.Interfaces;
using APIgerir.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIgerir.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController()
        {
            _usuarioRepositorio = new UsuarioRepositorio();
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            try
            {
                _usuarioRepositorio.Cadastrar(usuario);

                return Ok(usuario);
            }catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Logar(Usuario usuario)
        {
            try
            {
                var usuarioexiste = _usuarioRepositorio.Logar(usuario.Email, usuario.Senha);
                if (usuarioexiste == null)
                    return NotFound();

                return Ok(usuarioexiste);

            }catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
