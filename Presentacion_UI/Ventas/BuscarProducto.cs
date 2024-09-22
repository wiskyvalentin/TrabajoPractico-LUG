using BE;
using Negocio;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System;
using Presentacion_UI.ABM;

namespace Presentacion_UI.Ventas
{
    public partial class BuscarProducto : Form
    {
        private BEProductos oBEProductos;
        private BLLProductos oBLLProductos;
        List<BEProductos> Lista = new List<BEProductos>();
        private NuevaVenta oVenta;
        public BuscarProducto(NuevaVenta form)
        {
            oBEProductos = new BEProductos();
            oBLLProductos = new BLLProductos();
            oVenta = form;
            InitializeComponent();
        }

        private void BuscarProducto_Load(object sender, System.EventArgs e)
        {
            Lista = oBLLProductos.ListarTodo();
            ProductosDataGridView.DataSource = Lista;
        }
        //DESCRIPCION
        private void TextBox1_TextChanged(object sender, System.EventArgs e)
        {
            ProductosDataGridView.DataSource = null;
            ProductosDataGridView.DataSource = Lista.Where(p => p.Descripcion.IndexOf(TextBox1.Text, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }
        //CODIGO
        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            ProductosDataGridView.DataSource = null;
            ProductosDataGridView.DataSource = Lista.Where(p => p.Codigo.IndexOf(TextBox2.Text, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        private void ProductosDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (ProductosDataGridView.SelectedRows.Count > 0)
            {
                oBEProductos = oBLLProductos.AsignarValores(Convert.ToInt32(ProductosDataGridView.CurrentRow.Cells["Id"].Value.ToString()));
                oBEProductos.Cantidad = Convert.ToDouble(oVenta.CantidadSelect.Value);
                oVenta.oBEFactura.BEProductos.Add(oBEProductos);
                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione un producto", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
