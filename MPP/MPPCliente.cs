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

        public bool Baja(BECliente Objeto)
        {
            if (Objeto.Id != 0)
            {
                oDatos = new Acceso();
                return oDatos.Escribir("spEliminar_Cliente", new Dictionary<string, object> { { "@Id", Objeto.Id } });
            }
            else
            {
                throw new ArgumentException("EL CLIENTE SELECCIONADO NO SE PUEDE DAR DE BAJA");
            };
        }


        public bool Guardar(BECliente Objeto)
        {
            oDatos = new Acceso();
            var parametros = new Dictionary<string, object>
            {
                { "@Nombre", Objeto.Nombre },
                { "@Apellido", Objeto.Apellido },
                { "@Correo", Objeto.Correo },
                { "@CUIT_DNI", Objeto.Cuit },
                { "@CondicionVenta", Objeto.CondicionVenta }
            };

            if (Objeto.Id != 0)
            {
                parametros.Add("@Id", Objeto.Id);
                return oDatos.Escribir("spActualizar_Cliente", parametros);
            }
            else
            {
                return oDatos.Escribir("spInsertar_Cliente", parametros);
            }
        }


        public BECliente AsignarValores(int IdObjeto)
        {
            oDatos = new Acceso();
            DataSet Ds = oDatos.Leer("spObtener_Cliente_Por_Id", new Dictionary<string, object>
                            {
                                { "@Id", IdObjeto }
                            });

            if (Ds.Tables[0].Rows.Count == 1)
            {
                DataRow fila = Ds.Tables[0].Rows[0];
                if (fila["CUIT_DNI"] != DBNull.Value)
                {
                    return new BECliente(
                        Convert.ToInt32(fila["ID_Persona"]),
                        fila["CUIT_DNI"].ToString(),
                        fila["CondicionVenta"].ToString(),
                        fila["Nombre"].ToString(),
                        fila["Apellido"].ToString(),
                        fila["Correo"].ToString());
                }
            }

            return null;
        }


        public List<BECliente> ListarTodo()
        {
            oDatos = new Acceso();
            DataSet Ds = oDatos.Leer("spListar_Clientes", new Dictionary<string, object>());
            List<BECliente> ListaClientes = new List<BECliente>();

            if (Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in Ds.Tables[0].Rows)
                {
                    if (fila["CUIT_DNI"] != DBNull.Value)
                    {
                        BECliente oBEcliente = new BECliente(
                            Convert.ToInt32(fila["ID_Persona"]),
                            fila["CUIT_DNI"].ToString(),
                            fila["CondicionVenta"].ToString(),
                            fila["Nombre"].ToString(),
                            fila["Apellido"].ToString(),
                            fila["Correo"].ToString());

                        ListaClientes.Add(oBEcliente);
                    }
                }
            }
            else
            {
                ListaClientes = null;
            }

            return ListaClientes;
        }

    }
}
