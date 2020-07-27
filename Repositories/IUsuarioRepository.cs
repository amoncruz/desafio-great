using System.Collections.Generic;
using GreatDesafio.Models;

namespace GreatDesafio.Repositories
{
    public interface IUsuarioRepository
    {

        bool SaveChanges();
        IEnumerable<Usuario> GetAllUsuarios();
        Usuario GetUsuarioById(int id);

        Usuario GetUserByCpf(string cpf);

        Usuario GetUserByRg(string rg);
        
        void CreateUser(Usuario usuario);

        void DeleteUserByCpf(Usuario usuario);

        void DeleteUserByRg(Usuario usuario);

        IEnumerable<Usuario> GetAllByName(string nome);
    }
}