using Julio19.ef;
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
    public partial class Form1 : Form
    {
        public Usuarios usuario { set; get; }
        // 1)
        public Form1()
        {
            InitializeComponent();                       
        }
        // 2)
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'basejorgeDataSet.Usuarios' table. You can move, or remove it, as needed.
            panel1.Enabled=false;

        } // 3) cuando termina esta operacion.

        // 3)
        private async void Form1_Shown(object sender, EventArgs e)
        {
       
            var formLogin = new FormLogin();
            formLogin.ShowDialog();
            panel2.Visible = true;
            usuario =formLogin.usuario;
            toolStripStatusLabel1.Text=usuario.NombreCompleto;

            grillaUsuario.AutoGenerateColumns=false;
       
            // Task.Run()

            // ContinueWith 
            barraProgreso.Value=0;
            grillaUsuario.DataSource=await UsuarioRepo.ListarTodoAsync();
            barraProgreso.Value = 33;
            listBox1.DataSource=  await UsuarioRepo.ListarTodoAsync();
            barraProgreso.Value = 66;
            comboBox1.DataSource= await UsuarioRepo.ListarTodoAsync();
            barraProgreso.Value = 100;
            panel1.Enabled = true;
            panel2.Visible = false;
        }


        // cuando se solicita un cerrado
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        

           // e.Cancel=true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
