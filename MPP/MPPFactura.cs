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
            throw new NotImplementedException();
        }

        public bool Guardar(BEFactura Objeto)
        {
            string Consulta_SQL = string.Empty;

            //PARTE FACTURA
            if (Objeto.Id != 0)
            {
                Consulta_SQL = "Update Facturas SET MontoTotal = " + Objeto.MontoTotal + ", MetodoPago = '" + Objeto.MetodoPago + 
                    "', Fecha = " + Objeto.Fecha.ToString("MM/dd/yyyy") + ", Id_Cliente =" + Objeto.BECliente.Id + " WHERE Id_Factura = " + Objeto.Id ;                
            }

            else
            {
                Consulta_SQL = "Insert into Facturas (MontoTotal, MetodoPago,Fecha, Id_Cliente) values(" + Objeto.MontoTotal + ", '" + Objeto.MetodoPago+
                    "', " + Objeto.Fecha.ToString("MM/dd/yyyy") + "," + Objeto.BECliente + ")";
            }
            oDatos = new Acceso();
            oDatos.Escribir(Consulta_SQL);
            foreach (BEProductos Prod in Objeto.BEProductos)
            {

            }
            return 0;
        }
    

        public BEFactura AsignarValores(BEFactura Objeto)
        {
            DataSet Ds;
            oDatos = new Acceso();
            string Consulta = "SELECT Id_Factura, MontoTotal,MetodoPago,Fecha,Id_Clientes," +
                "Id_Facturas_Productos,Estado FROM Facturas WHERE Id_Factura = " + Objeto.Id;
            Ds = oDatos.Leer(Consulta);

            if (Ds.Tables[0].Rows.Count == 1)
            {
                DataRow fila = Ds.Tables[0].Rows[0];
                BEFactura oFactura = new BEFactura();
                oFactura.Id = Convert.ToInt32(fila["Id_Factura"]);
                oFactura.MetodoPago = fila["MetodoPago"].ToString();
                oFactura.Fecha = Convert.ToDateTime(fila["Fecha"]);
                oFactura.Estado = fila["Estado"].ToString();
                oFactura.BECliente = BuscarCliente(Convert.ToInt32(fila["Id_Clientes"]));
                oFactura.BEProductos = BuscarProductos(oFactura);
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
                    oFactura.BECliente = BuscarCliente(Convert.ToInt32(fila["Id_Clientes"]));
                    oFactura.BEProductos = BuscarProductos(oFactura);
                }

            }
            else
            { ListaFacturas = null; }
            return ListaFacturas;
        }
        #endregion
        #region METODOS NO GENERICOS

        BECliente BuscarCliente(int IdCliente)//consultar si paso el objeto entero!!
        {
            DataSet Ds;
            oDatos = new Acceso();
            string Consulta = "SELECT * FROM PERSONAS WHERE ID_Persona = " + IdCliente;
            Ds = oDatos.Leer(Consulta);

            //rcorro la tabla dentro del Dataset y la paso a lista
            if (Ds.Tables[0].Rows.Count == 1)
            {
                DataRow fila = Ds.Tables[0].Rows[0];
                BECliente oBEcliente = new BECliente(
                    Convert.ToInt32(fila["IdCliente"]), Convert.ToInt32(fila["CUIT_DNI"]), fila["CondicionVenta"].ToString(),
                    fila["Nombre"].ToString(), fila["Apellido"].ToString(), fila["Correo"].ToString());
                return oBEcliente;
            }
            return null;
        }
        List<BEProductos> BuscarProductos(BEFactura Objeto)
        {
            DataSet Ds;
            List<BEProductos> Lista = new List<BEProductos>();
            oDatos = new Acceso();
            string Consulta = "SELECT Id_Factura,Pro.Id_Producto,Pro.Codigo,Pro.Descripcion," +
                "Pro.Precio,Pro.Descuento,Pro.Id_Proveedores FROM DetalleFacturas as DetFac JOIN Productos Pro " +
                "ON DetFac.Id_Producto = Pro.Id_Producto WHERE DetFac.ID_Factura = " + Objeto.Id;
            Ds = oDatos.Leer(Consulta);

            if (Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in Ds.Tables[0].Rows)
                {
                    BEProductos oProductos = new BEProductos(Convert.ToInt32(fila["Id_Producto"]));
                    oProductos.Codigo = fila["Codigo"].ToString();
                    oProductos.Descripcion = fila["Descripcion"].ToString();
                    oProductos.PrecioInd = Convert.ToDouble(fila["Precio"].ToString());
                    oProductos.Descuento = Convert.ToDouble(fila["Descuento"]);
                    oProductos.oBEProveedor = new BEProveedores(Convert.ToInt32(fila["Id_Proveedores"]));

                    Lista.Add(oProductos);
                }

            }
            else
            { Lista = null; }
            return Lista;
        }

        #endregion
    }


}
