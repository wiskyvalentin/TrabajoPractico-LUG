using BE;
using Negocio;
using System;
using System.Windows.Forms;

namespace Presentacion_UI.ABM
{
    public partial class ABMProveedores : Form
    {
        private BEProveedores oBEProveedores;
        private BLLProveedores oBLLProveedores;
        public ABMProveedores()
        {
            oBEProveedores = new BEProveedores();
            oBLLProveedores = new BLLProveedores();
            InitializeComponent();
        }



        private void LimpiarCampos()
        {
            LabelID.Text = "0";
            TxtCBU.Text = string.Empty;
            TxtNombre.Text = string.Empty;
            TxtCorreo.Text = string.Empty;
            TxtApellido.Text = string.Empty;
            TxtDireccion.Text = string.Empty;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ABMProveedores_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            this.dataGridView1.DataSource = null;
            //llamo al metodo de la BLL de localiadd para cargar las localidades
            this.dataGridView1.DataSource = oBLLProveedores.ListarTodo();
            LimpiarCampos();
        }

        private void dataGridView1_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Acceder al valor de la celda por el nombre de la columna
            if (dataGridView1.SelectedCells.Count > 0)
            {
                LabelID.Text = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                TxtCBU.Text = dataGridView1.CurrentRow.Cells["CBU"].Value.ToString();
                TxtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                TxtCorreo.Text = dataGridView1.CurrentRow.Cells["Correo"].Value.ToString();
                TxtApellido.Text = dataGridView1.CurrentRow.Cells["Apellido"].Value.ToString();
                TxtDireccion.Text = dataGridView1.CurrentRow.Cells["Direccion"].Value.ToString();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(LabelID.Text) != 0)
            {
                DialogResult Respuesta;
                Respuesta = MessageBox.Show("¿Desea modificar el proveedor?", "ALERTA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (Respuesta == DialogResult.Yes)
                {
                    oBEProveedores.Id = Convert.ToInt32(LabelID.Text);
                    oBEProveedores.Nombre = TxtNombre.Text.Trim();
                    oBEProveedores.Apellido = TxtApellido.Text.Trim();
                    oBEProveedores.Correo = TxtCorreo.Text.Trim();
                    oBEProveedores.Direccion = TxtDireccion.Text.Trim();
                    oBEProveedores.CBU = TxtCBU.Text.Trim();
                    oBLLProveedores.Guardar(oBEProveedores);
                    cargarGrilla();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult Respuesta;
            Respuesta = MessageBox.Show("¿Desea agregar el proveedor?", "ALERTA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Respuesta == DialogResult.Yes)
            {
                oBEProveedores.Nombre = TxtNombre.Text.Trim();
                oBEProveedores.Apellido = TxtApellido.Text.Trim();
                oBEProveedores.Correo = TxtCorreo.Text.Trim();
                oBEProveedores.Direccion = TxtDireccion.Text.Trim();
                oBEProveedores.CBU = TxtCBU.Text.Trim();
                oBLLProveedores.Guardar(oBEProveedores);
                cargarGrilla();
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(LabelID.Text) != 0)
            {
                DialogResult Respuesta;
                Respuesta = MessageBox.Show("¿Desea eliminar el proveedor?", "ALERTA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (Respuesta == DialogResult.Yes)
                {
                    oBEProveedores.Id = Convert.ToInt32(LabelID.Text);
                    oBLLProveedores.Baja(oBEProveedores);
                    cargarGrilla();
                }
            }
        }
    }
}
