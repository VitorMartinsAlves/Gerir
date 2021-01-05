using APIgerir.Contextos;
using APIgerir.Dominios;
using APIgerir.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        
        public Usuario BuscarPorId(Guid IdUsuario)
        {
            try
            {
                var usuario = _context.Usuarios.Find(IdUsuario);
                //sempre retornar a variavel declada, nunca o escopo do metodo
                return (usuario);
            }catch(System.Exception ex)
            {
                throw new(ex.Message);
                
            }
        }

        public Usuario Editar(Usuario usuario)
        {
            try { 
            var usuarioexiste = BuscarPorId(usuario.id);
            if(usuarioexiste == null)
            {
                throw new Exeception("Usuario nao encontrado")

                
            }
                usuarioexiste.Nome = usuario.Nome;
                usuarioexiste.Senha = usuario.Senha;
                if (!string.IsNullOrEmpty(usuario.Senha))
                    usuarioexiste.Senha = usuario.Senha;

                _context.Usuarios.Update(usuarioexiste);

                _context.SaveChanges();

                return usuarioexiste;
            }
            catch
            {

            }
        }

        public Usuario Logar(string email, string senha)
        {
            try
            {
                ///firstOrDefault pega a primeira que bate com os dados
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
