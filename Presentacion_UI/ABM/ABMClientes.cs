using BE;
using Negocio;
using System;
using System.Windows.Forms;

namespace Presentacion_UI.ABM
{
    public partial class ABMClientes : Form
    {
        private BECliente oBECliente;
        private BLLCliente oBLLCliente;
        public ABMClientes()
        {
            oBECliente = new BECliente();
            oBLLCliente = new BLLCliente();
            InitializeComponent();
        }

        private void ABMClientes_Load(object sender, EventArgs e)
        {

            cargarGrilla();
        }

        private void cargarGrilla()
        {
            this.dataGridView1.DataSource = null;
            //llamo al metodo de la BLL de localiadd para cargar las localidades
            this.dataGridView1.DataSource = oBLLCliente.ListarTodo();
            LimpiarCampos();
        }
        //agregar
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult Respuesta;
            Respuesta = MessageBox.Show("¿Desea Agregar el Cliente?", "ALERTA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Respuesta == DialogResult.Yes)
            {
                oBECliente.Nombre = TxtNombre.Text.Trim();
                oBECliente.Apellido = TxtApellido.Text.Trim();
                oBECliente.Correo = TxtCorreo.Text.Trim();
                oBECliente.CondicionVenta = TxtCondVenta.Text.Trim();
                oBECliente.Cuit = TxtCuit.Text.Trim();
                oBLLCliente.Guardar(oBECliente);
                cargarGrilla();
            }
        }
        //modificar
        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(LabelID.Text) != 0)
            {
                DialogResult Respuesta;
                Respuesta = MessageBox.Show("¿Desea modificar el Cliente?", "ALERTA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (Respuesta == DialogResult.Yes)
                {
                    oBECliente.Id = Convert.ToInt32(LabelID.Text);
                    oBECliente.Nombre = TxtNombre.Text.Trim();
                    oBECliente.Apellido = TxtApellido.Text.Trim();
                    oBECliente.Correo = TxtCorreo.Text.Trim();
                    oBECliente.CondicionVenta = TxtCondVenta.Text.Trim();
                    oBECliente.Cuit = TxtCuit.Text;
                    oBLLCliente.Guardar(oBECliente);
                    cargarGrilla();
                }
            }
        }

        //eliminar
        private void button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(LabelID.Text) != 0)
            {
                DialogResult Respuesta;
                Respuesta = MessageBox.Show("¿Desea eliminar el Cliente?", "ALERTA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (Respuesta == DialogResult.Yes)
                {
                    oBECliente.Id = Convert.ToInt32(LabelID.Text);
                    oBLLCliente.Baja(oBECliente);
                    cargarGrilla();
                }
            }
        }

        private void LimpiarCampos()
        {
            LabelID.Text = "0";
            TxtCuit.Text = string.Empty;
            TxtNombre.Text = string.Empty;
            TxtCorreo.Text = string.Empty;
            TxtApellido.Text = string.Empty;
            TxtCondVenta.Text = string.Empty;
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Acceder al valor de la celda por el nombre de la columna
            if (dataGridView1.SelectedCells.Count > 0)
            {
                LabelID.Text = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                TxtCuit.Text = dataGridView1.CurrentRow.Cells["Cuit"].Value.ToString();
                TxtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                TxtCorreo.Text = dataGridView1.CurrentRow.Cells["Correo"].Value.ToString();
                TxtApellido.Text = dataGridView1.CurrentRow.Cells["Apellido"].Value.ToString();
                TxtCondVenta.Text = dataGridView1.CurrentRow.Cells["CondicionVenta"].Value.ToString();
            }
        }
    }
}
