using AppCompletoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCompletoApi.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Senha> Senha { get; set; }
    }
}
