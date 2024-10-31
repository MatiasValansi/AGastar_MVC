using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMorfar_MVC.Models
{
    public class Comanda
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //public List<Producto> productos; ---> Va o no va?
        //En la Comanda se elige un Producto y la cant de ese Producto?
        // La Comanda no debería ir acumulando los Productos de esa Persona en una lista de Productos?        
        public Pedido IdPedido { get; set; }
    }
}
