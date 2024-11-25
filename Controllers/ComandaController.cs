using AMorfar_MVC.Contexts;
using AMorfar_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices.JavaScript;

namespace AMorfar_MVC.Controllers
{
    public class ComandaController : Controller
    {
        //Hago un context para PersonaController
        readonly Context context = new();
        public IActionResult Index(int id)
        {
            
            Pedido? pedido = null;
            List<Comanda>? comandas = null;
            try
            {
                pedido = context.Pedidos.Find(id);
                comandas = context.Personas
                    .Join(context.ComandasPersonas, p => p.PersonaId, cp => cp.IdPersona, (p, cp) => new { Persona = p, ComandaPersona = cp })
                    .Join(context.Comandas, cp => cp.ComandaPersona.IdComanda, c => c.ComandaId, (cp, c) => new { PersonaComanda = cp, Comanda = c })
                    .Where(cp => cp.PersonaComanda.Persona.PedidoActual == id)
                    .GroupBy(cp => cp.Comanda) // Agrupar por comanda
                    .Select(group => group.Key) // Seleccionar la clave de cada grupo (comanda)
                    .ToList();
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }

            ViewBag.pedido = pedido;
            ViewBag.comandas = comandas;
            return View("Gastos");
        }

        public IActionResult Crear(int idPedido)
        {
            List<Persona>? personas = null;

            try
            {
                personas = context.Personas
                    .Where(p => p.PedidoActual == idPedido)
                    .ToList();
                
            }catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }

            ViewBag.personas = personas;
            ViewBag.idPedido = idPedido;

            return View();
        }

        [HttpPost]
        public IActionResult Crear(Comanda comanda, int[] PersonasSeleccionadas, int PedidoId)
        {
            double saldoAActualizar = 0;

            //Verificamos que la cantidad de PersonasSeleccionadas sea mayor a 0.
            if (PersonasSeleccionadas.Length > 0)
            {
                saldoAActualizar = comanda.Total / PersonasSeleccionadas.Length;
            }        

            try
            {
                context.Comandas.Add(comanda);
                context.SaveChanges();

                foreach (int personaId in PersonasSeleccionadas)
                {
                    //Actualizamos el saldo de cada persona a través de su ID.

                    Persona? iteradorPersona = context.Personas.Find(personaId);
                    iteradorPersona.Saldo += saldoAActualizar;
                    context.Personas.Update(iteradorPersona);

                    ComandasPersonas comandaPersona = new ComandasPersonas
                    {
                        IdComanda = comanda.ComandaId,
                        IdPersona = personaId,
                    };
                    context.ComandasPersonas.Add(comandaPersona);

                }
                context.SaveChanges();

                // Actualizar el total del pedido
                Pedido? pedido = context.Pedidos.Find(PedidoId);
                pedido.Total += comanda.Total;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }

            return RedirectToAction("Index", new { id = PedidoId });
        }

        public IActionResult RetornaComandaPorId(int idComanda)
        {
            try
            {
                Comanda? comanda = context.Comandas.Find(idComanda);

                ViewBag.comanda = comanda;
                //Añadimos a la ViewBag una lista de personas. De no ser necesario, lo eliminamos.
                ViewBag.personas = comanda.Personas;
            }
            catch (Exception ex) {
                ViewBag.error = ex.Message;
            }

            
            

            return View();
        }

    }
}
