using BE;
using Negocio;
using Presentacion_UI.ABM;
using Presentacion_UI.userControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion_UI
{
    public partial class InicioSesion : Form
    {
        public InicioSesion()
        {
            
            InitializeComponent();
        }

        private void InicioSesion_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BLLUsuarios oBLLUsuarios = new BLLUsuarios();
            if (oBLLUsuarios.IniciarSesion(CU_TxtUsuario.Text, cU_TxtContraseña1.Text))
            {
                Form formularioHijo = new Principal(); 
               
                formularioHijo.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("DATOS INCORRECTOS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
        }

        private void cU_TxtContraseña1_Leave(object sender, EventArgs e)
        {
            if (!cU_TxtContraseña1.Validar())
            {
                MessageBox.Show("FORMATO INCORRECTO", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void cU_TxtContraseña1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
