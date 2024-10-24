using System.ComponentModel.DataAnnotations;

namespace AMorfar_MVC.Models
{
    public class Producto
    {
        //Hay que declarar el método constructor, EJ:
        /*
         public Producto(int id, string nombre, double precio)
        {
            this.id = id;
            this.nombre = nombre; 
            this.precio = precio;              

        }
         */

        [Key]
        public int ID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public double Precio { get; set; }

        [Required]
        public int Cantidad { get; set; }
    }
}
