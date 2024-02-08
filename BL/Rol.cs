using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static Dictionary<string, object> GetAll()
        {
            string msg = "";
            ML.Rol rol = new ML.Rol();
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Rol", rol }, { "Mensaje", msg }, { "Resultado", false } };

            try
            {
                using (DL.IdamianMoviesContext context = new DL.IdamianMoviesContext())
                {
                    var query = (from rols in context.Rols select new { 
                    
                        IdRol = rols.IdRol,
                        Tipo = rols.Tipo,

                    }).ToList();

                    if(query != null)
                    {
                        rol.Rols = new List<ML.Rol>();

                        foreach(var item in query)
                        {
                            ML.Rol rol1 = new ML.Rol();
                            rol1.IdRol = item.IdRol;
                            rol1.Tipo = item.Tipo;

                            rol.Rols.Add(rol1);
                        }

                        diccionario["Rol"] = rol;
                        diccionario["Resultado"] = true;
                    }
                    else
                    {
                        diccionario["Resultado"] = false;
                    }
                }

            }catch (Exception e)
            {
                msg = e.Message;
                diccionario["Resultado"] = false;
            }
            return diccionario;
        }
    }
}
