using APIgerir.Contextos;
using APIgerir.Dominios;
using APIgerir.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIgerir.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly ControleContext _context = new ControleContext();
    
        public Tarefa Cadastrar(Tarefa tarefa)
        {
            try
            {
                _context.Tarefas.Add(tarefa);
                _context.SaveChanges();
                return tarefa;
            }
            catch (System.Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public List<Tarefa> ListarTodos(Guid IdUsuario)
            {
            try
            {
                return _context.Tarefas.Where(
                            c => c.IdUsuario == IdUsuario
                            ).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Tarefa Remover(Guid IdTarefa)
        {
            try
            {
                var tarefa = BuscarPorId(IdTarefa);

                _context.Tarefas.Remove(tarefa);
                _context.SaveChanges();

                return tarefa;

            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Tarefa BuscarPorId(Guid IdTarefa)
        {
            try
            {
                var tarefa = _context.Tarefas.Find(IdTarefa);
                return (tarefa);
            }
            catch (System.Exception ex)
            {
                throw new(ex.Message);

            }
        }

        public Tarefa AlterarStatus(Guid IdTarefa)
        {
            try
            {
                var tarefa = BuscarPorId(IdTarefa);
                //Altera o valor do status conforme estiver no banco
                //Se estiver true o inverso é false e vice e versa
                tarefa.Status = !tarefa.Status;
                _context.Tarefas.Update(tarefa);
                _context.SaveChanges();
                return tarefa;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Tarefa EditarTarefa(Tarefa tarefa)
        {
            try
            {
                var tarefaExiste = BuscarPorId(tarefa.IdTarefa);
                if (tarefaExiste == null)
                {
                    throw new Exception("Tarefa nao encontrada");


                }
                tarefaExiste.Titulo = tarefa.Titulo;
                tarefaExiste.Descricao = tarefa.Descricao;
                tarefaExiste.Categoria = tarefa.Categoria;
                tarefaExiste.DataEntrega = tarefa.DataEntrega;
                _context.Tarefas.Update(tarefa);

                _context.SaveChanges();

                return tarefa;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
