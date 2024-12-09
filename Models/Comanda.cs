using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMorfar_MVC.Models
{
    public class Comanda
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Anotación para el ID en EF
        public int ComandaId { get; set; }

        public string? Descripcion { get; set; }

        public double Total { get; set; }

        public double TotalPorPersona { get; set; }
        // Relaciones
        //public Pedido? Pedido { get; set; }
        //public int PedidoActual { get; set; }
        public List<ComandasPersonas>? ComandasPersonas { get; set; }
        public List<Persona>? Personas { get; set; }

    }
}
