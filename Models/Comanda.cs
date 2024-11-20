using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMorfar_MVC.Models
{
    public class Comanda
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ComandaId { get; set; }

        public string Descripcion { get; set; }

        public double Total { get; set; }

        public double TotalPorPersona { get; set; }
        // Relaciones
        public Pedido? Pedido { get; set; }
        public int PedidoActual { get; set; }
        List<ComandasPersonas> ComandasPersonas { get; set; }
    }
}
