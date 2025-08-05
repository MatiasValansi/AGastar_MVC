using AMorfar_MVC.Contexts;
using AMorfar_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AMorfar_MVC.Controllers
{
    public class ComandaController : Controller
    {
        readonly MockContext context = MockContext.getInstance;


        public IActionResult Index(int id)
        {
            Pedido? pedido = context.GetPedido(id);
            List<Comanda> comandas = new();

            


            if (pedido == null)
            {
                ViewBag.error = $"No se encontró un pedido con ID {id}.";
                return RedirectToAction("Index", "Pedido");
            }

            try
            {
                // Filtra las comandas que están relacionadas con el pedido (vía personas)
                var personasDelPedido = context.Personas
                    .Where(p => p.PedidoActual == id)
                    .Select(p => p.PersonaId)
                    .ToList();

                var comandasIdsRelacionadas = context.ComandasPersonas
                    .Where(cp => personasDelPedido.Contains(cp.IdPersona))
                    .Select(cp => cp.IdComanda)
                    .Distinct()
                    .ToList();

                comandas = context.Comandas
                    .Where(c => comandasIdsRelacionadas.Contains(c.ComandaId))
                    .ToList();
            }
            catch (Exception ex)
            {
                ViewBag.error = "Error al cargar comandas: " + ex.Message;
            }

            ViewBag.pedido = pedido;
            ViewBag.comandas = comandas;

            return View("Gastos");
        }


        public IActionResult Crear(int idPedido)
        {
            try
            {
                List<Persona> personas = context.Personas
                    .Where(p => p.PedidoActual == idPedido)
                    .ToList();

                ViewBag.personas = personas;
                ViewBag.idPedido = idPedido;
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }

            return View();
        }

        [HttpPost]
        public IActionResult Crear(Comanda comanda, int[] PersonasSeleccionadas, int PedidoId)
        {
            double saldoAActualizar = 0;

            if (PersonasSeleccionadas.Length > 0)
            {
                saldoAActualizar = comanda.Total / PersonasSeleccionadas.Length;
                comanda.TotalPorPersona = saldoAActualizar;
            }

            try
            {
                // Agrega la comanda con ID automático
                context.AddComanda(comanda);

                foreach (int personaId in PersonasSeleccionadas)
                {
                    Persona? persona = context.Personas.FirstOrDefault(p => p.PersonaId == personaId);
                    if (persona != null)
                    {
                        persona.Saldo += saldoAActualizar;
                    }

                    context.AddComandasPersonas(new ComandasPersonas
                    {
                        IdComanda = comanda.ComandaId,
                        IdPersona = personaId
                    });
                }

                Pedido? pedido = context.GetPedido(PedidoId);
                if (pedido != null)
                {
                    pedido.Total += comanda.Total;
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }

            return RedirectToAction("Index", new { id = PedidoId });
        }

        public IActionResult Detalle(int comandaId, int pedidoId)
        {
            ViewBag.pedidoId = pedidoId;

            try
            {
                Comanda? comanda = context.Comandas.FirstOrDefault(c => c.ComandaId == comandaId);
                ViewBag.comanda = comanda;

                var personas = context.ComandasPersonas
                    .Where(cp => cp.IdComanda == comandaId)
                    .Select(cp => context.Personas.FirstOrDefault(p => p.PersonaId == cp.IdPersona))
                    .Where(p => p != null)
                    .ToList();

                ViewBag.personas = personas;
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }

            return View();
        }
    }
}
