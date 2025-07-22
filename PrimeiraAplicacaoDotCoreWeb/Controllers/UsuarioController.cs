using Microsoft.AspNetCore.Mvc;

namespace PrimeiraAplicacaoDotCoreWeb.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NovoUsuario()
        {
            return View();
        }
    }
}
