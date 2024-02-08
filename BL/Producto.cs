using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Producto
    {
        public static Dictionary<string,object> GetAll()
        {
            ML.Producto producto = new ML.Producto();
            string msg = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { {"Producto",producto},{"Mensaje",msg},{"Resultado",false}};

            try
            {
                using (DL.IdamianMoviesContext context = new DL.IdamianMoviesContext())
                {
                    var query = (from product in context.Productos
                                 join
                                 categoria in context.Categoria on product.IdCategoria equals categoria.IdCategoria
                                 join proveedor in context.Proveedors on product.IdProveedor equals proveedor.IdProveedor
                                 select new
                                 {

                                     IdProducto = product.IdProducto,
                                     Nombre = product.Nombre,
                                     Precio = product.Precio,
                                     provedorIdProveedor = proveedor.IdProveedor,
                                     NombreProveedor = proveedor.Nombre,
                                     CategoriaId = categoria.IdCategoria,
                                     CategoriaNombre = categoria.Nombre

                                 }).ToList();

                    if(query.Count > 0 )
                    {
                        producto.Productos = new List<ML.Producto>();

                        foreach(var item in query)
                        {
                            ML.Producto producto1 = new ML.Producto();
                            producto1.IdProducto = item.IdProducto;
                            producto1.Nombre = item.Nombre;
                            producto1.Precio = (decimal)item.Precio;
                            producto1.Categoria = new ML.Categoria();
                            producto1.Categoria.IdCategoria = item.CategoriaId;
                            producto1.Categoria.Nombre = item.CategoriaNombre;
                            producto1.Proveedor = new ML.Proveedor();
                            producto1.Proveedor.IdProveedor = item.provedorIdProveedor;
                            producto1.Proveedor.Nombre = item.NombreProveedor;
                            
                            producto.Productos.Add(producto1);
                        }

                        diccionario["Resultado"] = true;
                        diccionario["Producto"] = producto;
                    }
                }
            }catch(Exception e)
            {
                msg = e.Message;
                diccionario["Mensaje"] = msg;
            }

            return diccionario;
        }

        //public static Dictionary<string,object> Add()
        //{

        //}
    }
}
