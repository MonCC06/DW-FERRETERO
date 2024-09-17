using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ferretero.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre de categoria es obligatorio")]
        public string NombreProducto { get; set; }

        [Required(ErrorMessage = "desc de categoria es obligatorio")]
        public string DescripcionCorta { get; set; }

        [Required(ErrorMessage = "desc de producto es obligatorio")]
        public string DescripcionProducto { get; set; }


        public string ImagenUrl { get; set; }





        [Required(ErrorMessage = "precion es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "el precio tiene que ser mayor a cero")]
        public double Precio { get; set; }





        //foreging key


        public int CategoriaId(get; set;)
            [ForeignKey("CategoriaId")]
            public virtual Categoria Categoria { get; set; }

        public int TipoAplicacionId(get; set;)
            [ForeignKey("TipoAplicacionId")]
        public virtual TipoAplicacion TipoAplicacion { get; set; }





    }
}





