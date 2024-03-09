using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PARCIAL1A.Models
{
    public class AutorLibro
    {
        
        public int AutorId { get; set; }
        
        public int LibroId { get; set; }
        public int Orden { get; set; }
    }
}
