using Inventario.api.Models.Administracion;
using Microsoft.EntityFrameworkCore;

namespace Inventario.api
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        
        }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
