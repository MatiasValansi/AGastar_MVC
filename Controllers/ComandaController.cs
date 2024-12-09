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
                    .Join(context.ComandasPersonas, p => p.PersonaId, cp => cp.IdPersona, (p, cp) => new { Persona = p, ComandaPersona = cp })//Crea un Objeto Anónimo (Objeto Nexo) que tiene a las propiedades de las 2 clases: Persona y ComandasPersonas
                    .Join(context.Comandas, cp => cp.ComandaPersona.IdComanda, c => c.ComandaId, (cp, c) => new { PersonaComanda = cp, Comanda = c }) //Crea otro Objeto Anónimo pero con las propiedades de: Comanda y ComandasPersonas
                    .Where(cp => cp.PersonaComanda.Persona.PedidoActual == id) // Busca dentro de cp coincidencias entre los ID
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
            //Se ejecuta 1°
            //GET: Ingresar los gastos de la Comanda desde el teclado
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
            // Se ejecuta 2°
            //POST: Una vez ingresados los datos por teclado, loe envía a la DB, luego, se encarga de mostrarlos por pantalla en el Index que es la View de "Gastos"
            double saldoAActualizar = 0;

            //Verificamos que la cantidad de PersonasSeleccionadas sea mayor a 0.
            if (PersonasSeleccionadas.Length > 0)
            {
                saldoAActualizar = comanda.Total / PersonasSeleccionadas.Length;
                comanda.TotalPorPersona = saldoAActualizar;
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

        public IActionResult Detalle(int comandaId, int pedidoId)
        {
            ViewBag.pedidoId = pedidoId;
            try
            {
                Comanda? comanda = context.Comandas.Find(comandaId);
                ViewBag.comanda = comanda;

                var personas = context.Comandas
                    .Join(context.ComandasPersonas, c => c.ComandaId, cp => cp.IdComanda, (c, cp) => new { Comanda = c, ComandaPersona = cp })
                    .Join(context.Personas, cp => cp.ComandaPersona.IdPersona, p => p.PersonaId, (cp, p) => new { PersonaComanda = cp, Persona = p })
                    .Where(cp => cp.PersonaComanda.Comanda.ComandaId == comandaId)
                    .Select(cp => cp.Persona)
                    .ToList(); //Convertimos a List las Personas que tiene la Comanda en Context

                // Lista de personas incluidas en el producto de la comanda.
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