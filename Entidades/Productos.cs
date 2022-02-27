

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroProductosDetalles.Entidades
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "Es obligatorio digitar descripcion.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Es obligatorio digitar el costo.")]
        [Range(1, int.MaxValue, ErrorMessage = "El costo se sale del rango permitido.")]
        public float Costo { get; set; }

        [Required(ErrorMessage = "Es obligatorio la ganancia")]
        [Range(1, 100, ErrorMessage = "La ganancia debe de estar entre 1 y 100")]
        public int Ganancia { get; set; }

        [Required(ErrorMessage = "Es obligatorio el precio")]
        [Range(1, float.MaxValue, ErrorMessage = "El precio se sale del rango permitido.")]
        public float Precio { get; set; }

        [ForeignKey("ProductosId")]
        public virtual List<ProductosDetalles> ProductosDetalles {get; set;}
    }
}