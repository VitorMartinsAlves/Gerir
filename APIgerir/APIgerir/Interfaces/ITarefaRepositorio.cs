using APIgerir.Dominios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIgerir.Interfaces
{
    interface ITarefaRepositorio
    {
        Tarefa BuscarPorId(Guid IdTarefa);
        Tarefa Cadastrar(Tarefa tarefa);
        Tarefa Remover(Guid IdTarefa);
        List<Tarefa> ListarTodos(Guid IdUsuario);
        Tarefa AlterarStatus(Guid IdTarefa);
        Tarefa EditarTarefa(Tarefa tarefa);

    }
}
