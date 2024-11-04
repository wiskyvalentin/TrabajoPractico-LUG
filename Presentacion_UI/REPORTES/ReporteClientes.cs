using System;
using Negocio;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion_UI.REPORTES
{
    public partial class ReporteClientes : Form
    {
        private BLLCliente oBLLCliente;
        public ReporteClientes()
        {
            oBLLCliente = new BLLCliente();

            InitializeComponent();
        }

        private void ReporteClientes_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.DataSources
                [0].Value = oBLLCliente.ListarTodo();
            this.reportViewer1.RefreshReport();
            
        }
    }
}
