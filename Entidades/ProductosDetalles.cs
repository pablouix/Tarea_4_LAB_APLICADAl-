
using System.ComponentModel.DataAnnotations;

namespace RegistroProductosDetalles.Entidades
{
    public class ProductosDetalles
    {
        [Key]
        public int ProductosDetallesId { get; set; }
        public int ProductosId { get; set; }    
        public string Presentacion { get; set; }        
        public double Cantidad { get; set; }    
        public double Precio { get; set; }

        public ProductosDetalles()
        {

        }

        public ProductosDetalles(int id, string presentacion, double cantidad, double precio)
        {
            this.ProductosDetallesId = 0;
            this.ProductosId = id;
            this.Presentacion = presentacion;
            this.Cantidad = cantidad;
            this.Precio = precio;
        }
    }
}