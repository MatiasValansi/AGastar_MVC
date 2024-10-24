using Microsoft.AspNetCore.Mvc;

namespace AMorfar_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //Prueba del COMMIT y PUSH
            return View();
        }
    }
}
