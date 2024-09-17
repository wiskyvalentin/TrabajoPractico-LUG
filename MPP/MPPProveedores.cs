using Abstraccion;
using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace MPP
{
    public class MPPProveedores : IGestor<BEProveedores>
    {
        Acceso oDatos;
        string Consulta_SQL;
        public MPPProveedores()
        {

        }

        public bool Baja(BEProveedores Objeto)
        {
            if (Objeto.Id != 0)
            {
                Consulta_SQL = "DELETE FROM Personas WHERE ID_Persona = " + Objeto.Id;
                oDatos = new Acceso();
                return oDatos.Escribir(Consulta_SQL);
            }
            else { throw new ArgumentException("EL PROVEEDOR SELECCIONADO NO SE PUEDE DAR DE BAJA"); };
        }

        public bool Guardar(BEProveedores Objeto)
        {
            if (Objeto.Id != 0)
            {
                Consulta_SQL = "UPDATE Personas SET Nombre='" + Objeto.Nombre + "',Apellido='" + Objeto.Apellido + "',Correo=" + Objeto.Correo + ",CBU=" + Objeto.CBU + "," +
                    "Direccion= " + Objeto.Direccion + "WHERE ID_Persona = " + Objeto.Id;
            }
            else
            {
                Consulta_SQL = "INSERT Personas(Nombre,Apellido,Correo,CBU,Direccion) values(" + Objeto.Nombre + ", '" + Objeto.Apellido +
                    ", '" + Objeto.Correo + ", '" + Objeto.CBU + ", '" + Objeto.Direccion + ")";

            };
            oDatos = new Acceso();
            return oDatos.Escribir(Consulta_SQL);
        }

        public BEProveedores AsignarValores(int IdObjeto)
        {
            DataSet Ds;
            oDatos = new Acceso();
            string Consulta = "SELECT ID_Persona,Nombre,Apellido,Correo,CBU,Direccion FROM PERSONAS WHERE ID_Persona = " + IdObjeto.ToString();
            Ds = oDatos.Leer(Consulta);

            //rcorro la tabla dentro del Dataset y la paso a lista
            if (Ds.Tables[0].Rows.Count == 1)
            {
                DataRow fila = Ds.Tables[0].Rows[0];
                BEProveedores oBEProveedores = new BEProveedores(
                    Convert.ToInt32(fila["IdCliente"]), fila["Nombre"].ToString(), fila["Apellido"].ToString(), fila["Correo"].ToString(),
                    fila["Direccion"].ToString(), fila["CBU"].ToString());
                return oBEProveedores;
            }
            return null;
        }

        public List<BEProveedores> ListarTodo()
        {
            DataSet Ds;
            oDatos = new Acceso();
            string Consulta = "SELECT ID_Persona,Nombre,Apellido,Correo,CBU,Direccion FROM Personas";
            Ds = oDatos.Leer(Consulta);
            List<BEProveedores> ListaProveedores = new List<BEProveedores>();
            if (Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in Ds.Tables[0].Rows)
                {
                    BEProveedores oBEProveedor = new BEProveedores(
                    Convert.ToInt32(fila["IdCliente"]), fila["Nombre"].ToString(), fila["Apellido"].ToString(), fila["Correo"].ToString(),
                    fila["Direccion"].ToString(), fila["CBU"].ToString());
                    ListaProveedores.Add(oBEProveedor);
                }
            }
            else { ListaProveedores = null; }
            return ListaProveedores;
        }
    }
}
