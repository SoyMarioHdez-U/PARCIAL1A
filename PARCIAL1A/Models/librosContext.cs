using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace PARCIAL1A.Models
{
    public class librosContext : DbContext
    {
        public librosContext(DbContextOptions <librosContext> options): base(options) { 
        
        }
    }
}
