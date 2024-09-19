using Abstraccion;
using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace MPP
{
    public class MPPCliente : IGestor<BECliente>
    {
        private Acceso oDatos;
        private string Consulta_SQL;

        public bool Baja(BECliente Objeto)
        {
            if (Objeto.Id != 0)
            {
                Consulta_SQL = "DELETE FROM Personas WHERE ID_Persona = " + Objeto.Id;
                oDatos = new Acceso();
                return oDatos.Escribir(Consulta_SQL);
            }
            else { throw new ArgumentException("EL CLIENTE SELECCIONADO NO SE PUEDE DAR DE BAJA"); };
        }

        public bool Guardar(BECliente Objeto)
        {

            if (Objeto.Id != 0)
            {
                Consulta_SQL = "UPDATE Personas SET Nombre='" + Objeto.Nombre + "',Apellido='" + Objeto.Apellido + "',Correo='" + Objeto.Correo + "',CUIT_DNI=" + Objeto.Cuit + "," +
                    "CondicionVenta= '" + Objeto.CondicionVenta + "' WHERE ID_Persona = " + Objeto.Id;
            }
            else
            {
                Consulta_SQL = "INSERT Personas(Nombre,Apellido,Correo,CUIT_DNI,CondicionVenta) values('" + Objeto.Nombre + "', '" + Objeto.Apellido +
                    "', '" + Objeto.Correo + "', '" + Objeto.Cuit + "', '" + Objeto.CondicionVenta + "')";

            };
            oDatos = new Acceso();
            return oDatos.Escribir(Consulta_SQL);
        }

        public BECliente AsignarValores(int IdObjeto)
        {
            DataSet Ds;
            oDatos = new Acceso();
            string Consulta = "SELECT ID_Persona,Nombre,Apellido,Correo,CUIT_DNI,CondicionVenta FROM PERSONAS WHERE ID_Persona = " + IdObjeto.ToString();
            Ds = oDatos.Leer(Consulta);

            //rcorro la tabla dentro del Dataset y la paso a lista
            if (Ds.Tables[0].Rows.Count == 1)
            {
                DataRow fila = Ds.Tables[0].Rows[0];
                if (fila["CUIT_DNI"] != DBNull.Value)
                {
                    BECliente oBEcliente = new BECliente(
                    Convert.ToInt32(fila["ID_Persona"]), fila["CUIT_DNI"].ToString(), fila["CondicionVenta"].ToString(),
                    fila["Nombre"].ToString(), fila["Apellido"].ToString(), fila["Correo"].ToString());
                    return oBEcliente;
                }
            }
            return null;

        }

        public List<BECliente> ListarTodo()
        {
            DataSet Ds;
            oDatos = new Acceso();
            string Consulta = "SELECT ID_Persona,Nombre,Apellido,Correo,CUIT_DNI,CondicionVenta FROM Personas";
            Ds = oDatos.Leer(Consulta);
            List<BECliente> ListaClientes = new List<BECliente>();
            if (Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in Ds.Tables[0].Rows)
                {
                    if (fila["CUIT_DNI"] != DBNull.Value)
                    {
                        BECliente oBEcliente = new BECliente(
                        Convert.ToInt32(fila["ID_Persona"]), fila["CUIT_DNI"].ToString(), fila["CondicionVenta"].ToString(),
                        fila["Nombre"].ToString(), fila["Apellido"].ToString(), fila["Correo"].ToString());
                        ListaClientes.Add(oBEcliente);
                    }
                }
            }
            else { ListaClientes = null; }
            return ListaClientes;
        }
    }
}
