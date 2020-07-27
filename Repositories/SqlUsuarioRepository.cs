using System;
using System.Collections.Generic;
using System.Linq;
using GreatDesafio.Models;
using NinjaNye.SearchExtensions;

namespace GreatDesafio.Repositories
{
    public class SqlUsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioContext _context;

        public SqlUsuarioRepository(UsuarioContext context)
        {
            _context = context;
        }

        public void CreateUser(Usuario usuario)
        {
            if(usuario==null){
                throw new ArgumentNullException(nameof(usuario));
            }

            _context.Usuarios.Add(usuario);
        }

        public IEnumerable<Usuario> GetAllUsuarios()
        {
           return  _context.Usuarios.ToList();
        }

        public IEnumerable<Usuario> GetAllByName(string nome)
        {
           return _context.Usuarios.Search(data=>data.Nome).Containing(nome);
        }

        public Usuario GetUsuarioById(int id)
        {
            return _context.Usuarios.FirstOrDefault(p => p.Id == id); 
        }

        public bool SaveChanges()
        {
           return (_context.SaveChanges() >= 0);
        }

        public Usuario GetUserByCpf(string cpf)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Cpf == cpf);
        }

        public Usuario GetUserByRg(string rg)
        {
             return _context.Usuarios.FirstOrDefault(u => u.Rg == rg);
        }

        public void DeleteUserByCpf(Usuario user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Usuarios.Remove(user);
        }

        public void DeleteUserByRg(Usuario user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Usuarios.Remove(user);
        }
    }
}