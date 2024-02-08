using IDamianConsumoMovies.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IDamianConsumoMovies.Controllers
{
    public class ConsumoApi : Controller
    {
        public IActionResult Movies()
        {
            using (HttpClient client = new HttpClient())
            {
                /*Version 1, con la creacion de modelos tal cual el json y listas correspondientes*/
                var uri = "https://api.themoviedb.org/3/movie/popular?api_key=4b121ffcd872e6ee01d2de2f26dabbff";
                var resposeTask = client.GetAsync(uri);
                resposeTask.Wait();
                var result = resposeTask.Result;

                if (resposeTask.IsCompleted)
                {
                    string json = result.Content.ReadAsStringAsync().Result;
                    ApiData apiData = JsonConvert.DeserializeObject<ApiData>(json);    
                    
                    return View(apiData);
                }
                else
                {
                    return View(null);
                }
            }
        }

        [HttpPost]
        public IActionResult AgregarMovies(int idMovie)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
                
                var objAnonimo = new
                {
                    media_type = "movie",
                    media_id = idMovie,
                    favorite = true
                };            
                var resposeTask = client.PostAsJsonAsync("account/20961340/favorite?api_key=4b121ffcd872e6ee01d2de2f26dabbff&session_id=e97c0793fdeeba26c200ef3ff2d6be07d58868d4", objAnonimo);
                resposeTask.Wait();
                var result = resposeTask.Result;

                if(result.IsSuccessStatusCode)
                {
                    var json = result.Content.ReadAsStringAsync().Result;
                    dynamic respuesta = JsonConvert.DeserializeObject(json);
                    ViewBag.Mensaje = "pelicula agregada";
                    return PartialView("Modal");
                }

            }
              return View();
        }

        [HttpGet]
        public IActionResult Favoritas()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.themoviedb.org/3/");        
                var responseTask = client.GetAsync("account/20961340/favorite/movies?api_key=4b121ffcd872e6ee01d2de2f26dabbff&session_id=e97c0793fdeeba26c200ef3ff2d6be07d58868d4");
                responseTask.Wait();
                var respuesta = responseTask.Result;

                if(respuesta.IsSuccessStatusCode)
                {
                    var json = respuesta.Content.ReadAsStringAsync().Result;
                    ApiData apiData = JsonConvert.DeserializeObject<ApiData>(json);
                    return View(apiData);
                }
            
            }
            return View();
        }

        [HttpGet]
        public IActionResult Eliminar(int idPeli)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
                //var uri = "https://api.themoviedb.org/3/account/20961340/favorite?api_key=4b121ffcd872e6ee01d2de2f26dabbff&session_id=e97c0793fdeeba26c200ef3ff2d6be07d58868d4";
                var objAnonimo = new
                {
                    media_type = "movie",
                    media_id = idPeli,
                    favorite = false
                };
                var resposeTask = client.PostAsJsonAsync("account/20961340/favorite?api_key=4b121ffcd872e6ee01d2de2f26dabbff&session_id=e97c0793fdeeba26c200ef3ff2d6be07d58868d4", objAnonimo);
                resposeTask.Wait();
                var result = resposeTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var json = result.Content.ReadAsStringAsync().Result;
                    dynamic respuesta = JsonConvert.DeserializeObject(json);
                    ViewBag.Mensaje = "Pelicula Elminada";
                    return PartialView("Modal");
                }

            }
            return View();
        }
    }
}
