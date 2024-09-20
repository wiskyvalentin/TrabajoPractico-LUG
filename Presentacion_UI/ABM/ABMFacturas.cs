using BE;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Presentacion_UI.ABM
{
    public partial class ABMFacturas : Form
    {
        private BEFactura oBEFactura;
        private BLLFactura OBLLFactura;
        private BECliente oBEcliente;
        private BLLCliente oBLLCliente;
        private BEProductos oBEProductos;
        private BLLProductos oBLLProductos;
        private BEProveedores oBEProveedores;
        private BLLProveedores oBLLProveedores;
        public ABMFacturas()
        {
            OBLLFactura = new BLLFactura();
            oBEFactura = new BEFactura();

            oBLLCliente = new BLLCliente();
            oBEcliente = new BECliente();

            oBEProductos = new BEProductos();
            oBLLProductos = new BLLProductos();

            oBEProveedores = new BEProveedores();
            oBLLProveedores = new BLLProveedores();

            InitializeComponent();
        }

        private void ABMFacturas_Load(object sender, EventArgs e)
        {
            cargarGrilla();
            CargarCombo();
        }
        private void cargarGrilla()
        {
            this.dataGridView1.DataSource = null;
            //llamo al metodo de la BLL de localiadd para cargar las localidades
            this.dataGridView1.DataSource = OBLLFactura.ListarTodo();

            this.dataGridView2.DataSource = null;
            List<BEProductos> list = new List<BEProductos>();

            //llamo al metodo de la BLL de localiadd para cargar las localidades
            this.dataGridView2.DataSource = list;

         
            LimpiarCampos();
        }
        private void LimpiarCampos()
        {
            LabelID.Text = "0";

            TxtCantidad.Value = 0;
            TxtEstado.Text = string.Empty;
            TxtMetodoPago.Text = string.Empty;
            ComboCliente.Text = string.Empty;
            ComboProducto.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Today;
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Acceder al valor de la celda por el nombre de la columna
            if (dataGridView1.SelectedCells.Count > 0)
            {
                LabelID.Text = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                
                TxtEstado.Text = dataGridView1.CurrentRow.Cells["Estado"].Value.ToString();
                TxtMetodoPago.Text = dataGridView1.CurrentRow.Cells["MetodoPago"].Value.ToString();
                if (dataGridView1.CurrentRow.Cells["BECliente"].Value == null)
                {
                    ComboCliente.Text = "";
                }
                else
                {
                    ComboCliente.Text = dataGridView1.CurrentRow.Cells["BECliente"].Value.ToString();
                }

                this.dataGridView2.DataSource = oBLLProductos.ListarTodo(OBLLFactura.AsignarValores(Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value.ToString())));
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DialogResult Respuesta;
            if (oBEFactura.BEProductos.Count ==0)
            {
                MessageBox.Show("AGREGE UN PRODUCTO PARA CONTINUAR", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Respuesta = MessageBox.Show("¿Desea Agregar la Factura?", "ALERTA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Respuesta == DialogResult.Yes)
            {
                oBEFactura.Estado = TxtEstado.Text.Trim();
                oBEFactura.Fecha = dateTimePicker1.Value;
                oBEFactura.MetodoPago = TxtMetodoPago.Text.Trim();
                ComboCliente.ValueMember = "ID";
                oBEFactura.BECliente = oBLLCliente.AsignarValores(Convert.ToInt32(ComboCliente.Text));
                //PRODUCTOS CARGADOS ANTES!
                
              
                
                oBEFactura.MontoTotal = oBEFactura.CalcularMontoTotal();

                OBLLFactura.Guardar(oBEFactura);
                cargarGrilla();
            }
        }



        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(LabelID.Text) != 0)
            {
                DialogResult Respuesta;
                Respuesta = MessageBox.Show("¿Desea eliminar la Factura?", "ALERTA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (Respuesta == DialogResult.Yes)
                {
                    oBEFactura.Id = Convert.ToInt32(LabelID.Text);
                    OBLLFactura.Baja(oBEFactura);
                    cargarGrilla();
                }
            }

        }
        private void CargarCombo()
        {
            ComboCliente.DataSource = oBLLCliente.ListarTodo();
           
            ComboProducto.DataSource = oBLLProductos.ListarTodo();
            
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            oBEProductos.Cantidad = Convert.ToDouble(TxtCantidad.Value);
            ComboProducto.ValueMember = "ID";
            oBEFactura.BEProductos.Add(oBLLProductos.AsignarValores(Convert.ToInt32(ComboProducto.SelectedValue), oBEProductos.Cantidad));
            dataGridView2.DataSource = oBEFactura.BEProductos;
            CargarCombo();

        }
    }
}
