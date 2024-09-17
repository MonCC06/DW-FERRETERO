using System.ComponentModel.DataAnnotations;

namespace Ferretero.Models
{
    public class TipoAplicacion
    {
        [Key] //poner como llave
        private int Id { get; set; }
        [Required(ErrorMessage ="El nombre es obligatorio")]
        public string Nombre { get; set; }


    }
}
