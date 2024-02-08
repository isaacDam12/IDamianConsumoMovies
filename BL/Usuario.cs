using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Usuario
    {
        public static Dictionary<string,object>Add(ML.Usuario usuario)
        {
            string msg = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Resultado", false }, { "Mensaje", msg } };

            try
            {
                using (DL.IdamianMoviesContext context = new DL.IdamianMoviesContext())
                {
                    int filas = context.Database.ExecuteSqlRaw($"AddUsuario '{usuario.Nombre}','{usuario.ApellidoPaterno}','{usuario.ApellidoMaterno}','{usuario.Username}','{usuario.Email}',@password",new SqlParameter("@Password", System.Data.SqlDbType.VarBinary) {Value=usuario.Password});

                    if (filas > 0)
                    {
                        diccionario["Resultado"] = true;

                    }
                    else
                    {
                        diccionario["Resultado"] = false;
                    }
                }
            }
            catch (Exception e)
            {

            }
            return diccionario;
        }

        /*public static Dictionary<string, object>GetAll(ML.Usuario usuario)
        {
            string msg = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Resultado", false }, { "Mensaje", msg } };

            try
            {
                using (DL.IdamianMoviesContext context = new DL.IdamianMoviesContext())
                {

                }
            }
            catch (Exception e)
            {

            }
            return diccionario;
        }

        public static Dictionary<string, object>GetById(ML.Usuario usuario)
        {
            string msg = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Resultado", false }, { "Mensaje", msg } };

            try
            {
                using (DL.IdamianMoviesContext context = new DL.IdamianMoviesContext())
                {

                }
            }
            catch (Exception e)
            {

            }
            return diccionario;
        }*/

        public static Dictionary<string, object> GetByEmail(string email)
        {
            ML.Usuario usuario = new ML.Usuario();
            string msg = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Resultado", false }, { "Mensaje", msg },{"Usuario",usuario } };

            try
            {
                using (DL.IdamianMoviesContext context = new DL.IdamianMoviesContext())
                {
                    var query = (from user in context.Usuarios where user.Email == email select new
                    {
                        Email = user.Email,
                        Password = user.Password,

                    }).First();

                    if (query != null)
                    {
                        usuario.Email = query.Email;
                        usuario.Password = query.Password;

                        diccionario["Resultado"] = true;
                        diccionario["Usuario"] = usuario;
                    }
                    else
                    {
                        diccionario["Resultado"] = false;
                    }
                }
            }
            catch (Exception e)
            {
                msg = e.Message;
                diccionario["Mensaje"] = msg;
            }
            return diccionario;
        }

    }
}
