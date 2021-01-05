using APIgerir.Dominios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIgerir.Interfaces
{
    interface IUsuarioRepositorio
    {

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="usuario">Contem os dados do usuario</param>
        /// <returns>Retorna o usuario cadastrado</returns>
        Usuario Cadastrar(Usuario usuario);
        /// <summary>
        /// Faz o login de um usuario
        /// </summary>
        /// <param name="email">contem o email do usuario</param>
        /// <param name="senha">contem a senha do usuario</param>
        /// <returns>Usuario logado</returns>
        Usuario Logar(string email, string senha);
        /// <summary>
        /// Edita um usuario
        /// </summary>
        /// <param name="usuario">id do usuario</param>
        /// <returns>Usuario editado</returns>
        Usuario Editar(Usuario usuario);
        /// <summary>
        /// Remove um usuario
        /// </summary>
        /// <param name="Id">Id do usuario</param>
        /// <returns>Usuario removido</returns>
        Usuario Remover(Guid Id);
       
    }
}
