using Presentacion_UI.ABM;
using System;
using System.Windows.Forms;

namespace Presentacion_UI
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formularioHijo = new ABMClientes();  // Crear instancia del formulario hijo
            formularioHijo.MdiParent = this;  // Establecer el contenedor MDI como padre
            formularioHijo.Show();  // Mostrar el formulario hijo
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formularioHijo = new ABMProveedores();  // Crear instancia del formulario hijo
            formularioHijo.MdiParent = this;  // Establecer el contenedor MDI como padre
            formularioHijo.Show();  // Mostrar el formulario hijo

        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formularioHijo = new ABMProductos();  // Crear instancia del formulario hijo
            formularioHijo.MdiParent = this;  // Establecer el contenedor MDI como padre
            formularioHijo.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formularioHijo = new ABMUsuarios();  // Crear instancia del formulario hijo
            formularioHijo.MdiParent = this;  // Establecer el contenedor MDI como padre
            formularioHijo.Show();
        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formularioHijo = new ABMFacturas();  // Crear instancia del formulario hijo
            formularioHijo.MdiParent = this;  // Establecer el contenedor MDI como padre
            formularioHijo.Show();
        }
    }
}
