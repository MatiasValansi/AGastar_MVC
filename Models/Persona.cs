using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMorfar_MVC.Models
{
    public class Persona
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        [MaxLength(8), Required] 
        public string? DNI { get; set; }

        [MaxLength(50)]
        public string? Nombre { get; set; }

        [MaxLength(50)]
        public string? Apellido { get; set; }

        List<ComandasPersonas> ComandasPersonas { get; set; }


        public override string ToString()
        {
            //TODO: hacer que este metodo devuelva el nombre de la persona y el monto a pagar. Replicar la info que devuelve la pantalla DETALLE SALDOS en figma
            return $"\n - Nombre: {this.Nombre}\n - Apellido: {this.Apellido}\n - DNI: {this.DNI}";
        }
    }

}
