using APIgerir.Dominios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIgerir.Interfaces
{
    interface ITarefaRepositorio
    {
        Tarefa BuscarPorId(Guid Id);
        Tarefa Cadastrar(Tarefa tarefa);
        Tarefa Editar(Tarefa tarefa);
        Tarefa Remover(Guid Id);
    }
}
