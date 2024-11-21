using AMorfar_MVC.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace AMorfar_MVC.Controllers
{
    public class PersonaController : Controller
    {
        //Hago un context para PersonaController
        readonly Context context = new();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MostrarDetalles() 
        {
            return View();  
        }
        
    }
}
