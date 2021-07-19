using Julio19.ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Julio19.fachada
{
    class UsuarioFachada
    {

        // funcion factory sirve para crear objetos
        // , en este caso un usuario usando el formulario de login
        public static Usuarios Factory(FormLogin formLogin)
        {
            var usuario=new Usuarios();
            // no olvide que el modifier del cuadro de texto tiene que ser publico
            usuario.Usuario=formLogin.textBoxUsuario.Text;
            usuario.Clave=formLogin.textBoxClave.Text;
            // nombre completo
            return usuario;
        }
    }
}
