using BE;
using Negocio;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System;
using System.Collections;


namespace Presentacion_UI.Ventas
{
    public partial class AgregarCliente : Form
    {
        private BECliente oBECliente;
        private BLLCliente oBLLCliente;
        List<BECliente> Lista = new List<BECliente>();
        private NuevaVenta oVenta;


        public AgregarCliente(NuevaVenta form)
        {
            oBECliente = new BECliente();
            oBLLCliente = new BLLCliente();
            InitializeComponent();
            oVenta = form;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            ClientesDataGridView.DataSource = null;
            ClientesDataGridView.DataSource = Lista.Where(p => p.Nombre.IndexOf(TextBox1.Text, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        private void ProductosDataGridView_DoubleClick(object sender, EventArgs e)
        {

        }


        private void ClientesDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (ClientesDataGridView.SelectedRows.Count > 0)
            {
                oBECliente = oBLLCliente.AsignarValores(Convert.ToInt32(ClientesDataGridView.CurrentRow.Cells["Id"].Value.ToString()));
   
                oVenta.oBEFactura.BECliente= oBECliente;
                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione un cliente", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AgregarCliente_Load(object sender, EventArgs e)
        {
            Lista = oBLLCliente.ListarTodo();
            ClientesDataGridView.DataSource = Lista;
            
        }
    
    }
}
