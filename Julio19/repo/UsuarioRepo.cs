using Julio19.ef;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Julio19.repo
{
    class UsuarioRepo
    {
        public static bool Validar(Usuarios usuarioDigitado)
        {
            var resultado=false;
            using(var contexto=new  BaseJorgeContexto())
            {
                var usuarioBase=contexto
                    .Usuarios
                    .Where( u => u.Usuario==usuarioDigitado.Usuario && u.Clave==usuarioDigitado.Clave)
                    .FirstOrDefault();  // si el usuario no existe, devuelve un null
                if(usuarioBase!=null)
                {
                    resultado=true;
                }
            }

            return resultado;
        }
        public static List<Usuarios> ListarTodo()
        {
            Thread.Sleep(3000); // detener la ejecucion 3 segundos.

            var listado=new List<Usuarios>();
            using (var contexto = new BaseJorgeContexto())
            {
                listado=contexto.Usuarios.ToList();
            }
            return listado;
        }

        public static async Task<List<Usuarios>> ListarTodoAsync()
        {
            //  await Task.Delay(3000); // detener la ejecucion 3 segundos.

            var listado = new List<Usuarios>();
            using (var contexto = new BaseJorgeContexto())
            {
                listado = await contexto.Usuarios.ToListAsync();
            }
            return listado;
        }

        public static Usuarios Obtener(string login)
        {
            var usuario=new Usuarios();
            using (var contexto = new BaseJorgeContexto())
            {
                usuario=contexto
                    .Usuarios
                    .Find(login);

                //usuario=contexto
                //    .Usuarios
                //    .Where( u =>u.Usuario==login)
                //    .FirstOrDefault();

                //usuario = contexto
                //    .Usuarios
                //    .FirstOrDefault(u => u.Usuario == login);

            } 
            return usuario;
        }

    }
}
