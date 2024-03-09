using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace PARCIAL1A.Models
{
    public class librosContext : DbContext
    {
        public librosContext(DbContextOptions <librosContext> options): base(options) { 
        
        }

        public DbSet<libros> libros { get; set; }
        public DbSet<Posts> posts { get; set; }
        public DbSet<autores> autores { get; set; }
        public DbSet<AutorLibro> autorLibros { get; set; }
    }
}
