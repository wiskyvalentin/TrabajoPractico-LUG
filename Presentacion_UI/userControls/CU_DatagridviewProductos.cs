using BE;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion_UI.userControls
{
    public partial class CU_DatagridviewProductos : UserControl
    {
        private List<BEProductos> Lista = new List<BEProductos>();
        private BLLProductos oBLLProductos;
        public CU_DatagridviewProductos()
        {
            oBLLProductos = new BLLProductos();

            InitializeComponent();
        }

        private void ProductosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CU_DatagridviewProductos_Load(object sender, EventArgs e)
        {
            Lista = oBLLProductos.ListarTodo();
            ProductosDataGridView.DataSource = Lista;
        }
        public void Filtrarxcodigo(string TxtCodigo) 
        {
            ProductosDataGridView.DataSource = null;
            ProductosDataGridView.DataSource = Lista.Where(p => p.Descripcion.IndexOf(TxtCodigo, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }
        public void FiltrarxDescripcion(string TxtCodigo)
        {
            ProductosDataGridView.DataSource = null;
            ProductosDataGridView.DataSource = Lista.Where(p => p.Codigo.IndexOf(TxtCodigo, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }
    }
}
