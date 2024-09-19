using BE;
using Negocio;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;

namespace Presentacion_UI.ABM
{
    public partial class ABMProductos : Form
    {
        private BEProductos oBEProductos;
        private BLLProductos oBLLProductos;
        private BLLProveedores oBLLProveedores;
        public ABMProductos()
        {
            oBLLProveedores = new BLLProveedores();
            oBEProductos = new BEProductos();
            oBLLProductos = new BLLProductos();
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DialogResult Respuesta;
            Respuesta = MessageBox.Show("¿Desea Agregar el producto?", "ALERTA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Respuesta == DialogResult.Yes)
            {
                oBEProductos.Codigo = TxtCodigo.Text.Trim();
                oBEProductos.Descripcion = TxtDescripcion.Text.Trim();
                oBEProductos.Descuento = Convert.ToDouble(TxtDescuento.Text);
                oBEProductos.PrecioInd = Convert.ToDouble(TxtPrecio.Text);
                oBEProductos.BEProveedor = oBLLProveedores.AsignarValores(Convert.ToInt32(ComboProveedor.Text));

                oBLLProductos.Guardar(oBEProductos);
                cargarGrilla();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            DialogResult Respuesta;
            Respuesta = MessageBox.Show("¿Desea modificar el producto?", "ALERTA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Respuesta == DialogResult.Yes)
            {
                oBEProductos.Id = Convert.ToInt32(LabelID.Text);
                oBEProductos.Codigo = TxtCodigo.Text.Trim();
                oBEProductos.Descripcion = TxtDescripcion.Text.Trim();
                oBEProductos.Descuento = Convert.ToDouble(TxtDescuento.Text);
                oBEProductos.PrecioInd = Convert.ToDouble(TxtPrecio.Text);
                oBEProductos.BEProveedor = oBLLProveedores.AsignarValores(Convert.ToInt32(ComboProveedor.Text));

                oBLLProductos.Guardar(oBEProductos);
                cargarGrilla();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(LabelID.Text) != 0)
            {
                DialogResult Respuesta;
                Respuesta = MessageBox.Show("¿Desea eliminar el producto?", "ALERTA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (Respuesta == DialogResult.Yes)
                {
                    oBEProductos.Id = Convert.ToInt32(LabelID.Text);
                    oBLLProductos.Baja(oBEProductos);
                    cargarGrilla();
                }
            }
        }

        private void LimpiarCampos()
        {
            LabelID.Text = "0";
            TxtCodigo.Text = string.Empty;
            TxtDescripcion.Text = string.Empty;
            TxtDescuento.Text = string.Empty;
            TxtPrecio.Text = string.Empty;
            ComboProveedor.Text = string.Empty;
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                // Acceder al valor de la celda por el nombre de la columna
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    LabelID.Text = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();


                }
            }
              catch (Exception ex)
            { MessageBox.Show(ex.Message); }

        }
        

        private void CargarCombo()
        {
            ComboProveedor.DataSource = oBLLProveedores.ListarTodo();
        }
        private void cargarGrilla()
        {
            this.dataGridView1.DataSource = null;
            //llamo al metodo de la BLL de localiadd para cargar las localidades
            this.dataGridView1.DataSource = oBLLProductos.ListarTodo();
            LimpiarCampos();
        }

        private void ABMProductos_Load(object sender, EventArgs e)
        {
            cargarGrilla();
            CargarCombo();
        }
    }
}
