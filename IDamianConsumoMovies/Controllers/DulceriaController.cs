using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class DulceriaController : Controller
    {
        public IActionResult GetAll()
        {
            Dictionary<string,object> result = BL.Producto.GetAll();
            bool resultado = (bool)result["Resultado"];

            if (resultado)
            {
                ML.Producto producto = (ML.Producto)result["Producto"];
                return View(producto);
            }
            else
            {
                ViewBag.Mensaje = "No se ha podido recuperar los datos";
                return PartialView("Modal");
            }
        }
    }
}
