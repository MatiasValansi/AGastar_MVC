using AMorfar_MVC.Contexts;
using AMorfar_MVC.Helpers;
using AMorfar_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AMorfar_MVC.Controllers
{
    public class PedidoController : Controller 
    {
        readonly Context context = new();
        public IActionResult Index()
        {
            var pedidos = context.Pedidos.ToList();
            return View(pedidos);
        }

        [HttpGet]
        // devuelve la vista que se llame Crear dentro de las views de Pedidos (el formulario)
        public IActionResult Crear() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Pedido pedido)
        {
            Pedido newPedido = new()
            {
                Titulo = pedido.Titulo,
                Propina = pedido.Propina,
                Fecha = DateTime.Now
            };

            //Response response = Helper.Guardar(context, newPedido);
            Response response = new Response(true, "asd");
            context.Add(newPedido);
            context.SaveChanges();
            ViewData.Add("Response", response);
            // lo devuelvo a la misma vista, con la diferencia de que en la viewbag le mando la respuesta que me haya devuelto el metodo Guardar
            return View();
        }

        public IActionResult DetalleDePedido()
        {
            //var queryParam = ....{PedidoId}

            return View();
        }

    }
}
