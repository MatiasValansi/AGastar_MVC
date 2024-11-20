using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMorfar_MVC.Models
{
    public class Persona
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        [MaxLength(50)]
        public string? Nombre { get; set; }

        public double Saldo { get; set; }

        // Relaciones
        List<ComandasPersonas>? ComandasPersonas { get; set; }

        public int PedidoActual { get; set; }
        
        public Pedido? Pedido { get; set; }

    }

}
