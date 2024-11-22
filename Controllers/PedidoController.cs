using AMorfar_MVC.Contexts;
using AMorfar_MVC.Helpers;
using AMorfar_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AMorfar_MVC.Controllers
{
    public class PedidoController : Controller 
    {
        readonly Context context = new();
        public IActionResult Index()
        {
            ViewBag.pedidos = context.Pedidos.Where(p=>p.Activo).OrderByDescending(p=>p.PedidoId).ToList();
            return View();
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
                Activo = true,
                Fecha = DateTime.Now
            };

            try
            {
                context.Add(pedidoNuevo);
                context.SaveChanges();

                return RedirectToAction("AgregarPersonas", pedidoNuevo);
            }
            catch (Exception ex)
            {
                ViewData.Add("Error", ex.Message);
                return View();
            }
        }

        public IActionResult AgregarPersonas(Pedido pedido)
        {
            ViewBag.pedido = pedido;
            ViewBag.personas = context.Personas.Where(p => p.PedidoActual == pedido.PedidoId).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AgregarPersonas(Pedido pedido, Persona persona)
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

        public IActionResult Eliminar(int id)
        {
            Pedido pedido = context.Pedidos.Find(id);
            string error = "";
            pedido.Activo = false;
            try
            {
                //context.Remove(pedido);
                context.Pedidos.Update(pedido);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                ViewData.Add("Error", error);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Detalles(int id)
        {
            Pedido? pedido = null;

            try
            {
                pedido = context.Pedidos
                    .Where(p=>p.PedidoId == id)
                    .Include(p => p.Personas) // Incluir las Personas relacionadas
                    .Include(p => p.Comandas) // Incluir las Comandas relacionadas
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }

            ViewBag.pedido = pedido;

            return View("Detalles", pedido);
        }
    }
}
