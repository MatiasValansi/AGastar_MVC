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

        public override string ToString()
        {
            return $"\n - Nombre: {this.Nombre}\n - Apellido: {this.Apellido}\n - DNI: {this.DNI}";
        }
    }

}
