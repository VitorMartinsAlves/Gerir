using APIgerir.Contextos;
using APIgerir.Dominios;
using APIgerir.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;

namespace APIgerir.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ControleContext _context = new ControleContext();
        public Usuario Cadastrar(Usuario usuario)
        {
            try { 
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
            }
            catch (System.Exception ex)
            {
                throw new (ex.Message);
            }

        }

        public Usuario Editar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario Logar(string email, string senha)
        {
            try
            {
                var usuario = _context.Usuarios.FirstOrDefault(c => c.Email == email && c.Senha == senha);
                return usuario;

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Usuario Remover(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
