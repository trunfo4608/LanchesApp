using Microsoft.AspNetCore.Mvc;

namespace ProjetoLanches.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
