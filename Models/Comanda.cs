using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMorfar_MVC.Models
{
    public class Comanda
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Pedido? Pedido { get; set; }
        public int PedidoActual { get; set; }
        List<ComandasPersonas> ComandasPersonas { get; set; }
    }
}
