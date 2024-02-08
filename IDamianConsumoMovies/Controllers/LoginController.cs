using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace IDamianConsumoMovies.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Login(string password, string email)
        {
            Dictionary<string, object> result = BL.Usuario.GetByEmail(email);
            bool resultado = (bool)result["Resultado"];

            if (resultado)
            {
                ML.Usuario usuario = (ML.Usuario)result["Usuario"];

                var password1 = ConvertToBytes(password);
                var password2 = usuario.Password;
                bool igual = true;

                if (password1.Length != password2.Length)
                {
                    igual = false;
                }
                for (int i = 0; i < password1.Length; i++)
                {
                    if (password1[i] != password2[i])
                    {
                        igual = false;
                    }
                }

                if (igual)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }


        [HttpPost]
        public IActionResult Registrar(ML.Usuario usuario, string password)
        {
            usuario.Password = ConvertToBytes(password);
            Dictionary<string, object> result = BL.Usuario.Add(usuario);
            bool resultado = (bool)result["Resultado"];

            if (resultado)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {

            }
            return View();
        }


        private byte[] ConvertToBytes(string password)
        {
            byte[] data = Encoding.ASCII.GetBytes(password);
            return data;
        }
    }
}
