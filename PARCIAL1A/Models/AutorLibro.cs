using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PARCIAL1A.Models
{
    [Keyless]
    public class AutorLibro
    {
        
        public int AutorId { get; set; }
        public int LibroId { get; set; }
        public int Orden { get; set; }

        public string? Nombre2 { get; set; }
    }
}
