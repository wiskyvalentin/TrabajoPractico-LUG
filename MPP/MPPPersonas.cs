using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace MPP
{
    public class MPPPersonas
    {
        private Acceso oDatos;
        public virtual bool GuardarDataSet(DataSet DatosProveedor)
        {
            oDatos = new Acceso();

            // Llamar al método GrabarCambios
            return oDatos.GrabarCambios("Personas", DatosProveedor);

        }
        public virtual DataTable ConvertirListaADataTable(IEnumerable<BEPersonas> listaPersonas)
        {
            DataTable dt = new DataTable();

            DataColumn Clave = new DataColumn();
            Clave.ColumnName = "ID_Persona";
            Clave.DataType = typeof(Int32);
            Clave.AutoIncrement = true;
            Clave.AutoIncrementSeed = 1;
            Clave.AutoIncrementStep = 1;
            Clave.AllowDBNull = false;
            Clave.Unique = true;

            // Definir las columnas comunes de BEPersona
            dt.Columns.Add(Clave);
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Apellido", typeof(string));
            dt.Columns.Add("Correo", typeof(string));
            dt.Columns.Add("CUIT_DNI", typeof(string));
            dt.Columns.Add("Direccion", typeof(string));
            dt.Columns.Add("CBU", typeof(string));
            dt.Columns.Add("CondicionVenta", typeof(string));
            dt.Columns.Add("Contraseña", typeof(string));

            // Agregar las filas a partir de la lista, detectando el tipo específico
            foreach (var persona in listaPersonas)
            {
                DataRow row = dt.NewRow();

                // Asignar valores comunes
                row["ID_Persona"] = persona.Id;
                row["Nombre"] = persona.Nombre;
                row["Apellido"] = persona.Apellido;
                row["Correo"] = persona.Correo;

                // Detectar si es un proveedor o cliente y añadir valores adicionales si los hay
                if (persona is BEProveedores proveedor)
                {
                    row["CBU"] = proveedor.CBU;
                    row["Direccion"] = proveedor.Direccion;

                }
                else if (persona is BECliente cliente)
                {
                    row["CondicionVenta"] = cliente.CondicionVenta;
                    row["CUIT_DNI"] = cliente.Cuit;
                }
                else if (persona is BEUsuarios usuario)
                {
                    row["Contraseña"] = usuario.Contraseña;

                }
                dt.Rows.Add(row);
            }

            return dt;
        }

        public virtual DataSet ListarTodoDataSet()
        {
            oDatos = new Acceso();
            DataSet Ds = oDatos.Leer("spListar_Personas", new Dictionary<string, object>());

            // Verificamos que la consulta retorne datos
            if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
            {
                DataTable dtPersonas = Ds.Tables[0];

                // Habilitar el seguimiento de cambios
                dtPersonas.AcceptChanges(); // Configura el estado de las filas a "Unchanged" inicialmente

                return Ds; // Retorna el DataSet completo con el DataTable rastreable
            }

            return null; // Devuelve null si no hay datos
        }


    }
}
