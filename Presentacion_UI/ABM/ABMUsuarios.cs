using BE;
using Negocio;
using System;
using System.Windows.Forms;

namespace Presentacion_UI.ABM
{
    public partial class ABMUsuarios : Form
    {
        private BEUsuarios oBEUsuarios;
        private BLLUsuarios oBLLUsuarios;
        public ABMUsuarios()
        {
            oBEUsuarios = new BEUsuarios();
            oBLLUsuarios = new BLLUsuarios();
            InitializeComponent();
        }

        private void ABMUsuarios_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            this.dataGridView1.DataSource = null;
            //llamo al metodo de la BLL de localiadd para cargar las localidades
            this.dataGridView1.DataSource = oBLLUsuarios.ListarTodo();
            LimpiarCampos();
        }
        private void LimpiarCampos()
        {
            LabelID.Text = "0";

            TxtNombre.Text = string.Empty;
            TxtCorreo.Text = string.Empty;
            TxtApellido.Text = string.Empty;
            TxtContraseña.Text = string.Empty;
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Acceder al valor de la celda por el nombre de la columna
            if (dataGridView1.SelectedCells.Count > 0)
            {
                LabelID.Text = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                TxtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                TxtCorreo.Text = dataGridView1.CurrentRow.Cells["Correo"].Value.ToString();
                TxtApellido.Text = dataGridView1.CurrentRow.Cells["Apellido"].Value.ToString();
                TxtContraseña.Text = dataGridView1.CurrentRow.Cells["Contraseña"].Value.ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DialogResult Respuesta;
            Respuesta = MessageBox.Show("¿Desea Agregar el Cliente?", "ALERTA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Respuesta == DialogResult.Yes)
            {
                oBEUsuarios.Nombre = TxtNombre.Text.Trim();
                oBEUsuarios.Apellido = TxtApellido.Text.Trim();
                oBEUsuarios.Correo = TxtCorreo.Text.Trim();
                oBEUsuarios.Contraseña = TxtContraseña.Text.Trim();
                oBLLUsuarios.Guardar(oBEUsuarios);
                cargarGrilla();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(LabelID.Text) != 0)
            {
                DialogResult Respuesta;
                Respuesta = MessageBox.Show("¿Desea modificar el Cliente?", "ALERTA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (Respuesta == DialogResult.Yes)
                {
                    oBEUsuarios.Id = Convert.ToInt32(LabelID.Text);
                    oBEUsuarios.Nombre = TxtNombre.Text.Trim();
                    oBEUsuarios.Apellido = TxtApellido.Text.Trim();
                    oBEUsuarios.Correo = TxtCorreo.Text.Trim();
                    oBEUsuarios.Contraseña = TxtContraseña.Text.Trim();
                    oBLLUsuarios.Guardar(oBEUsuarios);
                    cargarGrilla();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(LabelID.Text) != 0)
            {
                DialogResult Respuesta;
                Respuesta = MessageBox.Show("¿Desea eliminar el Cliente?", "ALERTA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (Respuesta == DialogResult.Yes)
                {
                    oBEUsuarios.Id = Convert.ToInt32(LabelID.Text);
                    oBLLUsuarios.Baja(oBEUsuarios);
                    cargarGrilla();
                }
            }
        }
    }
}
