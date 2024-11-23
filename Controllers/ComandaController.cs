using AMorfar_MVC.Contexts;
using AMorfar_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMorfar_MVC.Controllers
{
    public class ComandaController : Controller
    {
        //Hago un context para PersonaController
        readonly Context context = new();
        public IActionResult Index(int id)
        {
            
            Pedido? pedido = null;
            try
            {
                pedido = context.Pedidos.Find(id);
                //var comandas = context.Personas
                //    .Join(context.Comandas, c => c.PersonaId, p => p.ComandaId, (c, p) => new { c, p }).ToList();
                //Console.WriteLine(comandas);
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }

            ViewBag.pedido = pedido;
            return View("Gastos");
        }

        public IActionResult Crear(Comanda comanda, List<Persona> personas)
        {

            return RedirectToAction("Index");
        }

    }
}
