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
        private Acceso oDatos;

        public bool Baja(BEProveedores Objeto)
        {
            if (Objeto.Id != 0)
            {
                oDatos = new Acceso();
                var parametros = new Dictionary<string, object>
                {
                    { "@Id", Objeto.Id }
                };
                return oDatos.Escribir("sp_BajaProveedor", parametros);
            }
            else
            {
                throw new ArgumentException("EL PROVEEDOR SELECCIONADO NO SE PUEDE DAR DE BAJA");
            }
        }


        public bool Guardar(BEProveedores Objeto)
        {
            oDatos = new Acceso();
            var parametros = new Dictionary<string, object>
            {
                { "@Nombre", Objeto.Nombre },
                { "@Apellido", Objeto.Apellido },
                { "@Correo", Objeto.Correo },
                { "@CBU", Objeto.CBU },
                { "@Direccion", Objeto.Direccion }
            };

            if (Objeto.Id != 0)
            {
                parametros.Add("@Id", Objeto.Id);
                return oDatos.Escribir("spActualizar_Proveedor", parametros);
            }
            else
            {
                return oDatos.Escribir("spInsertar_Proveedor", parametros);
            }
        }


        public BEProveedores AsignarValores(int IdObjeto)
        {
            oDatos = new Acceso();
            var parametros = new Dictionary<string, object>
            {
                { "@Id", IdObjeto }
            };

            DataSet Ds = oDatos.Leer("spObtener_Proveedor_Por_Id", parametros);

            if (Ds.Tables[0].Rows.Count == 1)
            {
                DataRow fila = Ds.Tables[0].Rows[0];
                if (fila["Direccion"] != DBNull.Value)
                {
                    BEProveedores oBEProveedores = new BEProveedores(
                        Convert.ToInt32(fila["ID_Persona"]),
                        fila["Nombre"].ToString(),
                        fila["Apellido"].ToString(),
                        fila["Correo"].ToString(),
                        fila["Direccion"].ToString(),
                        fila["CBU"].ToString());
                    return oBEProveedores;
                }
            }
            return null;
        }


        public List<BEProveedores> ListarTodo()
        {
            oDatos = new Acceso();
            DataSet Ds = oDatos.Leer("spListar_Proveedores", new Dictionary<string, object>());

            List<BEProveedores> ListaProveedores = new List<BEProveedores>();
            if (Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in Ds.Tables[0].Rows)
                {
                    if (fila["Direccion"] != DBNull.Value)
                    {
                        BEProveedores oBEProveedor = new BEProveedores(
                            Convert.ToInt32(fila["ID_Persona"]),
                            fila["Nombre"].ToString(),
                            fila["Apellido"].ToString(),
                            fila["Correo"].ToString(),
                            fila["Direccion"].ToString(),
                            fila["CBU"].ToString());

                        ListaProveedores.Add(oBEProveedor);
                    }
                }
            }
            else
            {
                ListaProveedores = null;
            }

            return ListaProveedores;
        }


        #region transacciones
      
        #endregion
    }
}
