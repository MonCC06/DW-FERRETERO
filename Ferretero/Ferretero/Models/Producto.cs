using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ferretero.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre de Producto obligatorio")]
        public string NombreProducto { get; set; }


        [Required(ErrorMessage = "Nombre de Descripcion corta es obligatorio")]
        public string DescripcionCorta { get; set; }


        [Required(ErrorMessage = "Nombre de Descripcion del producto es obligatorio")]
        public string DescripcionProducto { get; set; }


        [Required(ErrorMessage = "El dato del precio es obligatorio")]
        //El orden de los datos sea mayor a 0, no puede ser un numero negativo
        [Range(1, double.MaxValue, ErrorMessage = "El precio debe ser mayor a cero")]
        public double Precio { get; set; }

        public string ImagenUrl { get; set; }

        //Foregin key

        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }

        public int TipoAplicacionId { get; set; }
        [ForeignKey("TipoAplicacionId")]
        public virtual TipoAplicacion TipoAplicacion { get; set; }
    }
}
