using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PARCIAL1A.Models
{

    public class AutorLibro
    {
        [Key, Column("AutorId", Order = 0)]
        public int AutorId { get; set; }

        [Key, Column("LibroId", Order = 1)]
        public int LibroId { get; set; }
        public int Orden { get; set; }

        
    }
}
