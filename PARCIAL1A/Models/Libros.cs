using System.ComponentModel.DataAnnotations;

namespace PARCIAL1A.Models
{
    public class Libros
    {
        [Key]
        public int Id { get; set; }
        public String? Titulo { get; set; }

        public string? Nombre2 { get; set; }
    }
}
