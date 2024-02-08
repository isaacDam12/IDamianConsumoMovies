using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpPost]
        public IActionResult Form()
        {

            return View();
        }
    }
}
