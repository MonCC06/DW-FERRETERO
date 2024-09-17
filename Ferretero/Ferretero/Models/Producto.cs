using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ferretero.Models
{
    public class Producto
    {
        [Key] //poner como llave
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre del producto es obligatorio")]
        public string NombreProducto { get; set; }
        [Required(ErrorMessage = "Nombre de la descripción corta es obligatorio")]
        public string DescripcionCorta { get; set; }
        [Required(ErrorMessage = "Nombre de la descripción del producto es obligatorio")]
        public string DescripcionProducto { get; set; }
        [Required(ErrorMessage = "Precio del producto es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage ="El precio debe ser mayor a cero")]
        public double Precio { get; set; }

        public string ImagenURL { get; set; }


        //F.Key
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }

        public int TipoAplicacionId { get; set; }

        [ForeignKey("TipoAplicacionId")]
        public virtual TipoAplicacion TipoAplicacion { get; set; }
    }
}
