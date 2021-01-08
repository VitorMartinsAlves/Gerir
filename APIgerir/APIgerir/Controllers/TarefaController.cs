using APIgerir.Dominios;
using APIgerir.Interfaces;
using APIgerir.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace APIgerir.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;

        public TarefaController()
        {
            _tarefaRepositorio = new TarefaRepositorio();
        }

        [HttpPost]
        public IActionResult Cadastrar(Tarefa tarefa)
        {
            try
            {
                _tarefaRepositorio.Cadastrar(tarefa);

                return Ok(tarefa);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Excluir(Guid idTarefa)
        {
            try
            {

                var usuarioId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti);

                var tarefaexiste = _tarefaRepositorio.BuscarPorId(idTarefa);
                if (tarefaexiste == null)
                    return NotFound();

                if (tarefaexiste.IdUsuario != new Guid(usuarioId.Value))
                    return Unauthorized("Usuario não autorizado");

                _tarefaRepositorio.Remover(idTarefa);

                return Ok(idTarefa);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Editar(Guid idTarefa, Tarefa tarefa)
        {
            try
            {
                var usuarioId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti);

                var tarefaexiste = _tarefaRepositorio.BuscarPorId(idTarefa);
                if (tarefaexiste == null)
                    return NotFound();

                if (tarefaexiste.IdUsuario != new Guid(usuarioId.Value))
                    return Unauthorized("Usuario não autorizado");

                tarefa.IdTarefa = idTarefa;
                _tarefaRepositorio.EditarTarefa(tarefa);

                return Ok(tarefa);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPut("status/{IdTarefa}")]
        public IActionResult AlterarStatus(Guid idTarefa)
        {
            try
            {
                var usuarioId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti);

                var tarefa = _tarefaRepositorio.BuscarPorId(idTarefa);
                if (tarefa == null)
                    return NotFound();

                if (tarefa.IdUsuario != new Guid(usuarioId.Value))
                    return Unauthorized("Usuario não autorizado");

                _tarefaRepositorio.AlterarStatus(idTarefa);

                return Ok(idTarefa);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("buscar{id}")]
        public IActionResult BuscarPorId(Guid IdTarefa)
        {
            try
            {

                //Pega o valor do usuario que está logado
                var usuarioId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti);

                var tarefa = _tarefaRepositorio.BuscarPorId(IdTarefa);
                if (tarefa == null)
                    return NotFound();

                if (tarefa.IdUsuario != new Guid(usuarioId.Value))
                    return Unauthorized("Usuario não autorizado");


                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            {
                try
                {
                    //Pega o valor do usuário que esta logado
                    var usuarioid = HttpContext.User.Claims.FirstOrDefault(
                                    c => c.Type == JwtRegisteredClaimNames.Jti
                                );

                    var tarefas = _tarefaRepositorio.ListarTodos(
                                        new System.Guid(usuarioid.Value)
                                  );

                    return Ok(new { data = tarefas });
                }
                catch (System.Exception ex)
                {
                    return BadRequest(ex.Message);
                }


            }

        }
    }
}
