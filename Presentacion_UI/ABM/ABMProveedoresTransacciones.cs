using BE;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Presentacion_UI.ABM
{
    public partial class ABMProveedoresTransacciones : Form
    {
        private BEProveedores oBEProveedores;
        private BLLProveedores oBLLProveedores;
        private DataSet Dset;
        public ABMProveedoresTransacciones()
        {
            oBEProveedores = new BEProveedores();
            oBLLProveedores = new BLLProveedores();
            Dset = new DataSet();
            InitializeComponent();
        }






        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ABMProveedores_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            Dset = oBLLProveedores.ListarTodoDataSet();

            if (Dset != null && Dset.Tables.Count > 0)
            {
                // Crear un DataView con filtro
                DataView view = new DataView(Dset.Tables[0]);
                view.RowFilter = "CBU IS NOT NULL AND CBU <> ''";

                // Asignar el DataView filtrado al DataGridView
                this.dataGridView1.DataSource = view;
                // Ocultar columnas no deseadas
                this.dataGridView1.Columns["CUIT_DNI"].Visible = false;
                this.dataGridView1.Columns["CondicionVenta"].Visible = false;
                this.dataGridView1.Columns["Contraseña"].Visible = false;
            }


        }

        private void dataGridView1_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {

        }



        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in Dset.Tables[0].Rows)
            {
                Console.WriteLine($"Row State: {row.RowState} | ID_Persona: {row["ID_Persona"]}");
            }

            oBLLProveedores.GuardarDataSet(Dset);
            cargarGrilla();
        }

    }
}
