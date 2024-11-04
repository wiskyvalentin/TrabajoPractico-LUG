using Abstraccion;
using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace MPP
{
    public class MPPFactura : IGestor<BEFactura>
    {

        #region METODOS GENERICOS
        private Acceso oDatos;

        public bool Baja(BEFactura Objeto)
        {
            if (Objeto.Id != 0)
            {
                oDatos = new Acceso();
                var parametros = new Dictionary<string, object>
            {
                { "@Id_Factura", Objeto.Id }
            };
                return oDatos.Escribir("spBaja_Factura", parametros);
            }
            else
            {
                throw new ArgumentException("LA FACTURA SELECCIONADA NO SE PUEDE DAR DE BAJA");
            }
        }

        public bool Guardar(BEFactura Objeto)
        {
            if (Objeto.Id != 0)
            {
                throw new Exception("Las facturas no se pueden actualizar");
            }
            else
            {
                oDatos = new Acceso();
                var parametros = new Dictionary<string, object>
                    {
                        { "@MontoTotal", Objeto.MontoTotal },
                        { "@MetodoPago", Objeto.MetodoPago },
                        { "@Fecha", Objeto.Fecha },
                        { "@Id_Clientes", Objeto.BECliente.Id },
                        { "@Estado", Objeto.Estado }
                    };
                // se utiliza leer porque devuelve la ultima factura 
                DataSet ds = oDatos.Leer("spInsertar_Factura", parametros);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    Objeto.Id = Convert.ToInt32(ds .Tables[0].Rows[0]["Id_Factura"]);
                    return GuardarProductos(Objeto);
                }
                else
                {
                    throw new Exception("No se pudo insertar la factura");
                }
            }
        }

        public BEFactura AsignarValores(int Objeto)
        {
            oDatos = new Acceso();
            var parametros = new Dictionary<string, object>
            {
                { "@Id_Factura", Objeto }
            };

            DataSet ds = oDatos.Leer("spObtener_Factura_Por_Id", parametros);
            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow fila = ds.Tables[0].Rows[0];
                BEFactura oFactura = new BEFactura
                {
                    Id = Convert.ToInt32(fila["Id_Factura"]),
                    MetodoPago = fila["MetodoPago"].ToString(),
                    Fecha = Convert.ToDateTime(fila["Fecha"]),
                    Estado = fila["Estado"].ToString()
                };

                MPPCliente oMPPCliente = new MPPCliente();
                MPPProductos oMPPProducto = new MPPProductos();
                oFactura.BECliente = oMPPCliente.AsignarValores(Convert.ToInt32(fila["Id_Clientes"]));
                oFactura.BEProductos = oMPPProducto.ListarTodo(oFactura);

                return oFactura;
            }
            else
            {
                throw new Exception("Los datos no son correctos");
            }
        }

        public List<BEFactura> ListarTodo()
        {
            oDatos = new Acceso();
            DataSet ds = oDatos.Leer("spListar_Facturas", new Dictionary<string, object>());
            List<BEFactura> listaFacturas = new List<BEFactura>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    BEFactura oFactura = new BEFactura
                    {
                        Id = Convert.ToInt32(fila["Id_Factura"]),
                        MetodoPago = fila["MetodoPago"].ToString(),
                        MontoTotal = Convert.ToDouble(fila["MontoTotal"]),
                        Fecha = Convert.ToDateTime(fila["Fecha"]),
                        Estado = fila["Estado"].ToString()
                    };

                    MPPCliente oMPPCliente = new MPPCliente();
                    oFactura.BECliente = fila["Id_Clientes"] == DBNull.Value
                        ? new BECliente { Nombre = "Consumidor Final" }
                        : oMPPCliente.AsignarValores(Convert.ToInt32(fila["Id_Clientes"]));

                    MPPProductos oMPPProducto = new MPPProductos();
                    oFactura.BEProductos = oMPPProducto.ListarTodo(oFactura);
                    listaFacturas.Add(oFactura);
                }
            }
            return listaFacturas;
        }

        #endregion

        #region METODOS NO GENERICOS

        public bool GuardarProductos(BEFactura Objeto)
        {
            foreach (BEProductos item in Objeto.BEProductos)
            {
                var parametros = new Dictionary<string, object>
                    {
                        { "@Id_Producto", item.Id },
                        { "@Id_Factura", Objeto.Id },
                        { "@Cantidad", item.Cantidad },
                        { "@Descuento", item.Descuento }
                    };

                oDatos = new Acceso();
                if (!oDatos.Escribir("spInsertar_Detalle_Factura", parametros))
                {
                    return false;
                }
            }
            return true;
        }
        
        private BEFactura ObtenerUltima()
        {//no se deberia de usar al poner la opcion leer =
            //SELECT SCOPE_IDENTITY() AS Id_Factura; que devuelve la ultima factura en "agregar factura"
            oDatos = new Acceso();
            DataSet ds = oDatos.Leer("spObtener_Ultima_Factura", new Dictionary<string, object>());

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow fila = ds.Tables[0].Rows[0];
                BEFactura oFactura = new BEFactura
                {
                    Id = Convert.ToInt32(fila["Id_Factura"]),
                    MetodoPago = fila["MetodoPago"].ToString(),
                    Fecha = Convert.ToDateTime(fila["Fecha"]),
                    Estado = fila["Estado"].ToString()
                };

                MPPCliente oMPPCliente = new MPPCliente();
                oFactura.BECliente = oMPPCliente.AsignarValores(Convert.ToInt32(fila["Id_Clientes"]));

                MPPProductos oMPPProducto = new MPPProductos();
                oFactura.BEProductos = oMPPProducto.ListarTodo(oFactura);

                return oFactura;
            }
            return null;
        }

        #endregion





    }
}
