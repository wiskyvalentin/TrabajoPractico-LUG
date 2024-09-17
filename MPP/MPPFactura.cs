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
        Acceso oDatos;
        public bool Baja(BEFactura Objeto)
        {
            string Consulta_SQL;

            //PARTE FACTURA
            if (Objeto.Id != 0)
            {

                Consulta_SQL = "UPDATE Facturas SET ESTADO = 'BAJA' WHERE Id_Factura = " + Objeto.Id;
                oDatos = new Acceso();
                return oDatos.Escribir(Consulta_SQL);
            }
            else { throw new ArgumentException("LA FACTURA SELECCIONADA NO SE PUEDE DAR DE BAJA"); }
        }

        public bool Guardar(BEFactura Objeto)
        {
            List<string> Consulta_SQL = new List<string>();

            //PARTE FACTURA
            if (Objeto.Id != 0)
            {

                Consulta_SQL.Add("Update Facturas SET MontoTotal = " + Objeto.MontoTotal + ", MetodoPago = '" + Objeto.MetodoPago +
                    "', Fecha = " + Objeto.Fecha.ToString("MM/dd/yyyy") + ", Id_Cliente =" + Objeto.BECliente.Id + " WHERE Id_Factura = " + Objeto.Id);
                foreach (BEProductos Items in Objeto.BEProductos)
                {
                    Consulta_SQL.Add("UPDATE detallefacturas SET CANTIDAD = " + Items.Cantidad + "WHERE Id_Factura =" + Objeto.Id + "AND Id_Producto = " + Items.Id);
                }
            }

            else
            {
                Consulta_SQL.Add("INSERT into Facturas (MontoTotal, MetodoPago,Fecha, Id_Cliente) values(" + Objeto.MontoTotal + ", '" + Objeto.MetodoPago +
                    "', " + Objeto.Fecha.ToString("MM/dd/yyyy") + "," + Objeto.BECliente);
                foreach (BEProductos Items in Objeto.BEProductos)
                {
                    Consulta_SQL.Add("INSERT DetalleFacturas(Id_Producto,Cantidad) values(" + Items.Id + "," + Items.Cantidad + ")");
                }
            }
            oDatos = new Acceso();
            return oDatos.Escribir(Consulta_SQL);

        }



        public BEFactura AsignarValores(int Objeto)
        {
            DataSet Ds;
            oDatos = new Acceso();
            string Consulta = "SELECT Id_Factura, MontoTotal,MetodoPago,Fecha,Id_Clientes," +
                "Id_Facturas_Productos,Estado FROM Facturas WHERE Id_Factura = " + Objeto.ToString();
            Ds = oDatos.Leer(Consulta);

            if (Ds.Tables[0].Rows.Count == 1)
            {
                DataRow fila = Ds.Tables[0].Rows[0];
                BEFactura bEFactura = new BEFactura();
                BEFactura oFactura = bEFactura;
                oFactura.Id = Convert.ToInt32(fila["Id_Factura"]);
                oFactura.MetodoPago = fila["MetodoPago"].ToString();
                oFactura.Fecha = Convert.ToDateTime(fila["Fecha"]);
                oFactura.Estado = fila["Estado"].ToString();
                MPPCliente oMPPCliente = new MPPCliente();
                MPPProductos oMPPProducto = new MPPProductos();
                oFactura.BECliente = oMPPCliente.AsignarValores(Convert.ToInt32(fila["Id_Clientes"]));
                oFactura.BEProductos = oMPPProducto.ListarTodo(oFactura);
                return oFactura;
            }
            else { throw new Exception("Los datos no son correctos"); }

        }

        public List<BEFactura> ListarTodo()
        {
            DataSet Ds;
            oDatos = new Acceso();
            string Consulta = "SELECT Id_Factura, MontoTotal,MetodoPago,Fecha,Id_Clientes,Id_Facturas_Productos FROM Facturas";
            Ds = oDatos.Leer(Consulta);
            List<BEFactura> ListaFacturas = new List<BEFactura>();

            //rcorro la tabla dentro del Dataset y la paso a lista
            if (Ds.Tables[0].Rows.Count > 0)
            {

                foreach (DataRow fila in Ds.Tables[0].Rows)
                {
                    BEFactura oFactura = new BEFactura();
                    oFactura.Id = Convert.ToInt32(fila["Id_Factura"]);
                    oFactura.MetodoPago = fila["MetodoPago"].ToString();
                    oFactura.Fecha = Convert.ToDateTime(fila["Fecha"]);
                    MPPCliente oMPPCliente = new MPPCliente();
                    MPPProductos oMPPProducto = new MPPProductos();
                    oFactura.BECliente = oMPPCliente.AsignarValores(Convert.ToInt32(fila["Id_Clientes"]));
                    oFactura.BEProductos = oMPPProducto.ListarTodo(oFactura);
                }

            }
            else
            { ListaFacturas = null; }
            return ListaFacturas;
        }
        #endregion
        #region METODOS NO GENERICOS

        //BECliente BuscarCliente(int IdCliente)//consultar si paso el objeto entero!!
        //{
        //    DataSet Ds;
        //    oDatos = new Acceso();
        //    string Consulta = "SELECT * FROM PERSONAS WHERE ID_Persona = " + IdCliente;
        //    Ds = oDatos.Leer(Consulta);

        //    //rcorro la tabla dentro del Dataset y la paso a lista
        //    if (Ds.Tables[0].Rows.Count == 1)
        //    {
        //        DataRow fila = Ds.Tables[0].Rows[0];
        //        BECliente oBEcliente = new BECliente(
        //            Convert.ToInt32(fila["IdCliente"]), Convert.ToInt32(fila["CUIT_DNI"]), fila["CondicionVenta"].ToString(),
        //            fila["Nombre"].ToString(), fila["Apellido"].ToString(), fila["Correo"].ToString());
        //        return oBEcliente;
        //    }
        //    return null;
        //}
        //List<BEProductos> BuscarProductos(BEFactura Objeto)
        //{
        //    DataSet Ds;
        //    List<BEProductos> Lista = new List<BEProductos>();
        //    oDatos = new Acceso();
        //    string Consulta = "SELECT Id_Factura,Pro.Id_Producto,Pro.Codigo,Pro.Descripcion," +
        //        "Pro.Precio,Pro.Descuento,Pro.Id_Proveedores FROM DetalleFacturas as DetFac JOIN Productos Pro " +
        //        "ON DetFac.Id_Producto = Pro.Id_Producto WHERE DetFac.ID_Factura = " + Objeto.Id;
        //    Ds = oDatos.Leer(Consulta);

        //    if (Ds.Tables[0].Rows.Count > 0)
        //    {
        //        foreach (DataRow fila in Ds.Tables[0].Rows)
        //        {
        //            BEProductos oProductos = new BEProductos(Convert.ToInt32(fila["Id_Producto"]));
        //            oProductos.Codigo = fila["Codigo"].ToString();
        //            oProductos.Descripcion = fila["Descripcion"].ToString();
        //            oProductos.PrecioInd = Convert.ToDouble(fila["Precio"].ToString());
        //            oProductos.Descuento = Convert.ToDouble(fila["Descuento"]);
        //            oProductos.BEProveedor = new BEProveedores(Convert.ToInt32(fila["Id_Proveedores"]));

        //            Lista.Add(oProductos);
        //        }

        //    }
        //    else
        //    { Lista = null; }
        //    return Lista;
        //}

        #endregion
    }


}
