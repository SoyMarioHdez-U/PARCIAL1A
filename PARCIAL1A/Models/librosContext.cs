using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace PARCIAL1A.Models
{
    public class librosContext : DbContext
    {
        public librosContext(DbContextOptions <librosContext> options): base(options) { 
        
        }

        public DbSet<libros> Libros { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Autores> Autores { get; set; }
        public DbSet<AutorLibro> AutorLibros { get; set; }
    }
}
