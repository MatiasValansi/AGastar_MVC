using AMorfar_MVC.Contexts;
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
            List<Pedido>? pedidos = null;
            try
            {
                pedidos = context.Pedidos.OrderByDescending(p => p.PedidoId).ToList();
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }

            ViewBag.pedidos = pedidos;
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
        [HttpPost]
        public IActionResult EliminarPersona(int personaId)
        {
            Persona? personaAEliminar = context.Personas
                .Where(p => p.PersonaId == personaId)
                .Include(p => p.Pedido) // Incluir las Personas relacionadas
                .FirstOrDefault();

            string error = "";
            try
            {
                context.Personas.Remove(personaAEliminar);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                ViewData.Add("Error", error);
            }

            return RedirectToAction("AgregarPersonas", personaAEliminar.Pedido);
        }

        public IActionResult Eliminar(int id)
        {
            Pedido? pedido = context.Pedidos.Find(id);
            string error = "";
            try
            {
                context.Remove<Pedido>(pedido);
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
                    .Where(p => p.PedidoId == id)
                    .Include(p => p.Personas) // Incluir las Personas relacionadas
                    .FirstOrDefault();
            }

            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }


            ViewBag.pedido = pedido;

            return View("Detalles");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            Pedido? pedido = null;
            try
            {
                pedido = context.Pedidos.Find(id);
            }

            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            ViewBag.pedido = pedido;
            return View(pedido);

        }

        [HttpPost]
        public IActionResult Editar(Pedido pedido)
        {
            try
            {
                context.Pedidos.Update(pedido);
                context.SaveChanges();
            }

            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }

            return RedirectToAction("Index");
        }
    }
}
