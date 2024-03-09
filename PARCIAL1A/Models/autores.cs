using System.ComponentModel.DataAnnotations;
namespace PARCIAL1A.Models
{
    public class autores
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
