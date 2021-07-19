using Julio19.ef;
using Julio19.fachada;
using Julio19.repo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Julio19
{
    public partial class FormLogin : Form
    {
        
        public bool permitirCerrar=false;

        public Usuarios usuario {set; get; }

        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            usuario=UsuarioFachada.Factory(this); // this el formulario actual (FormLogin)
            var validar=UsuarioRepo.Validar(usuario);


            if(validar) {
                permitirCerrar=true;
                usuario=UsuarioRepo.Obtener(usuario.Usuario); // usuario con todos los datos
                this.Close();
            } else
            {
                labelMensaje.Visible=true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            permitirCerrar = true;
            Application.Exit();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(permitirCerrar==false) { 
                e.Cancel=true; 
            }
        }
    }
}
