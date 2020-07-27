using Microsoft.EntityFrameworkCore;

namespace GreatDesafio.Models
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> opt) : base(opt)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}