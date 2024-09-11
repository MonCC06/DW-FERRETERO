using System.ComponentModel.DataAnnotations;

namespace Ferretero.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre de categoria es obligatorio")]
        public string NombreCategoria { get; set; }

        [Required(ErrorMessage = "Nombre de orden es obligatorio")]
        [Range(1,int.MaxValue, ErrorMessage = "el orden tiene que ser mayor a cero")]
        public int MostrarOrden {  get; set; }

    }
}
