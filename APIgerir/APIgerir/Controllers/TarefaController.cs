using APIgerir.Dominios;
using APIgerir.Interfaces;
using APIgerir.Repositorios;
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
        [HttpDelete]
        public IActionResult Excluir(Tarefa tarefa)
        {
            try
            {
                
               _tarefaRepositorio.Remover(tarefa.IdTarefa);

                return Ok();

            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Editar(Tarefa tarefa)
        {
            try
            {
               // _tarefaRepositorio.(tarefa) ;
                
                return Ok(tarefa);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("alterarstatus")]
        public IActionResult AlterarStatus(Tarefa tarefa)
        {
            try
            {
                //

                return Ok(tarefa);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("buscar{id}")]
        public IActionResult BuscarPorId(Guid IdTarefa)
        {
            try {

                var tarefa = _tarefaRepositorio.BuscarPorId(IdTarefa); 


            return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
