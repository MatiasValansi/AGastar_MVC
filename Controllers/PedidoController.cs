using AMorfar_MVC.Contexts;
using AMorfar_MVC.Helpers;
using AMorfar_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AMorfar_MVC.Controllers
{
    public class PedidoController : Controller 
    {
        readonly Context context = new();
        public IActionResult Index()
        {
            var pedidos = context.Pedidos.OrderByDescending(p=>p.PedidoId).ToList();
            return View(pedidos);
        }

        [HttpGet]
        public IActionResult Crear() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Pedido pedido)
        {
            Pedido pedidoNuevo = new()
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
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AgregarPersona(Pedido pedido, Persona persona)
        {
            string error = "";
            Persona personaNueva = new()
            {
                Nombre = persona.Nombre,
                PedidoActual = pedido.PedidoId
            };
            try {
                context.Add(personaNueva);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                error = ex.Message;
                ViewData.Add("Error", error);
            }

            return RedirectToAction("AgregarPersonas", pedido);
        }

        [HttpPost]
        public IActionResult EliminarPersona(Persona p, Pedido pedido)
        {
            Persona persona = context.Personas.Find(p.PersonaId);
            string error = "";
            try
            {
                context.Remove(persona);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                ViewData.Add("Error", error);
            }

            return RedirectToAction("AgregarPersonas", pedido);
        }

        public IActionResult Eliminar(Pedido pedido)
        {
            context.Remove(pedido);
            context.SaveChanges();

            return View();
        }
    }
}
