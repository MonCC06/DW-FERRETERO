using System.ComponentModel.DataAnnotations;

namespace Ferretero.Models
{
    public class TipoAplicacion
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        public string Nombre { get; set; }
    }
}
