using System.ComponentModel.DataAnnotations;

namespace AMorfar_MVC.Models
{
    public class Persona
    {
        //Hay que declarar el método constructor, EJ:
        /*
         public class Persona
    {
        public Persona() { }
        public Persona(string dni, string nombre, string apellido) 
        {
            this.dni = dni;
            this.nombre = nombre;
        }
         */
        [Key]
        public int ID { get; set; } 

        [MaxLength(8), Required] //Declaramos que el DNI puede tomar máximo 8 valores y que es requerido obligatoriamente.
        public string? DNI { get; set; }

        [MaxLength(50)]
        public string? Nombre { get; set; }

        [MaxLength(50)]
        public string? Apellido { get; set; }
        internal MetodoDePago MetodoPago { get; set; }


        //public List<Comanda>? Comandas { get; set; }

        //Lo de a continuación dicen de añadirlo?
        internal List<Producto> Productos { get; set; } // cada Producto y cantProducto
        public double TotalAPagar;
        public double PropinaCorrespondida;

        public override string ToString()
        {
            return $"\n - Nombre: {this.Nombre}\n - Apellido: {this.Apellido}\n - DNI: {this.DNI}";
        }
    }

    // Definición del enum
    enum MetodoDePago
    {
        EFECTIVO,
        TARJETA,
        BILLETERA_VIRTUAL,
        INVITA_AMIGO
    }
}
