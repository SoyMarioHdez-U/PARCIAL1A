using System.ComponentModel.DataAnnotations;

namespace PARCIAL1A.Models
{
    public class libros
    {
        [Key]
        public int Id { get; set; }
        public String Titulo { get; set; }
    }
}
