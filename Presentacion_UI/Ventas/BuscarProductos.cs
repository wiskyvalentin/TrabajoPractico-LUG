using BE;
using Negocio;
using Presentacion_UI.userControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion_UI.Ventas
{
    public partial class BuscarProducto : Form
    {
        private BEProductos oBEProductos;
        private BLLProductos oBLLProductos;
        private List<BEProductos> Lista = new List<BEProductos>();
        
        private NuevaVenta oVenta;
        public BuscarProducto(NuevaVenta form)
        {
            oBEProductos = new BEProductos();
           
            oBLLProductos = new BLLProductos();
            oVenta = form;
            InitializeComponent();
            cU_DatagridviewProductos1.ProductosDataGridView.CellDoubleClick += ProductosDataGridView_CellDoubleClick;

        }

        private void ProductosDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (cU_DatagridviewProductos1.ProductosDataGridView.SelectedRows.Count > 0)
            {
                oBEProductos = oBLLProductos.AsignarValores(Convert.ToInt32(cU_DatagridviewProductos1.ProductosDataGridView.CurrentRow.Cells["Id"].Value.ToString()));
                oBEProductos.Cantidad = Convert.ToDouble(oVenta.CantidadSelect.Value);
                oVenta.oBEFactura.BEProductos.Add(oBEProductos);

            }
            else
            {
                MessageBox.Show("Seleccione un producto", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.Close();
        }

        //DESCRIPCION
        private void BuscarProducto_Load_1(object sender, EventArgs e)
        {

        }
        private void cU_TxtTextocs1_TextChanged(object sender, EventArgs e)
        {
            if (!cU_TxtTextocs1.Validar())
            {
                cU_DatagridviewProductos1.Filtrarxcodigo(cU_TxtTextocs1.Text);
            }
        }
        private void cU_TxtTextocs2_TextChanged_1(object sender, EventArgs e)
        {
            if (!cU_TxtTextocs2.Validar())
            {
                cU_DatagridviewProductos1.FiltrarxDescripcion(cU_TxtTextocs1.Text);
            }
        }

        
    }
}
