using BE;
using Negocio;
using System;
using System.Windows.Forms;

namespace Presentacion_UI.Ventas
{
    public partial class NuevaVenta : Form
    {
        public BEFactura oBEFactura;
        private BLLFactura oBllFactura;
        
        public NuevaVenta()
        {
            oBEFactura = new BEFactura();

            oBllFactura = new BLLFactura();
            //cargo datos por defecto
            oBEFactura.MetodoPago = "EFECTIVO";
            oBEFactura.Estado = "OK";
            oBEFactura.Fecha = DateTime.Now;
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form formularioHijo = new BuscarProducto(this);

            formularioHijo.ShowDialog();
            CargarDatagridview();
        }
        public void CargarDatagridview()
        {
            DatosFacturaForm.DataSource = null;
            DatosFacturaForm.DataSource = oBEFactura.BEProductos;
            DatosFacturaForm.Columns["BEProveedor"].Visible = false;
            DatosFacturaForm.Columns["Descuento"].Visible = false;
            DatosFacturaForm.Columns["id"].Visible = false;
            PrecioTotalLabel.Text = oBEFactura.CalcularMontoTotal().ToString();
            if (oBEFactura.BECliente.Nombre == null)
            {
                txtCliente.Text = "";
            }
            else
            {
                txtCliente.Text = oBEFactura.BECliente.ToString();
            }
        }

        private void NuevaVenta_Load(object sender, EventArgs e)
        {
            CargarDatagridview();

        }

        private void DatosFacturaForm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnTerminarVentas_Click(object sender, EventArgs e)
        {
            if (oBEFactura.BEProductos.Count == 0 || oBEFactura.BECliente.Id == 0)
            {
                MessageBox.Show("AGREGE UN PRODUCTO O UN CLIENTE PARA CONTINUAR", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //futuramente preguntar si desea imprimir la factura cambiar a yesnocancel
            DialogResult Respuesta;
            Respuesta = MessageBox.Show("¿Desea terminar la venta?", "Terminar venta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Respuesta == DialogResult.Yes)
            {
                oBEFactura.MontoTotal = oBEFactura.CalcularMontoTotal();

                oBllFactura.Guardar(oBEFactura);
                this.Close();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form formularioHijo = new AgregarCliente(this);

            formularioHijo.ShowDialog();
            CargarDatagridview();

        }
    }
}
