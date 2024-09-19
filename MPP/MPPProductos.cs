using Abstraccion;
using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace MPP
{
    public class MPPProductos : IGestor<BEProductos>
    {
        Acceso oDatos;
        string Consulta_SQL;

        public bool Baja(BEProductos Objeto)
        {
            if (Objeto.Id != 0)
            {
                Consulta_SQL = "DELETE FROM Productos WHERE Id_Producto = " + Objeto.Id;
                oDatos = new Acceso();
                return oDatos.Escribir(Consulta_SQL);
            }
            else { throw new ArgumentException("EL PRODUCTO SELECCIONADA NO SE PUEDE DAR DE BAJA"); };
        }

        public bool Guardar(BEProductos Objeto)
        {

            if (Objeto.Id != 0)
            {
                Consulta_SQL = "UPDATE Productos SET Codigo='" + Objeto.Codigo + "',Descripcion='" + Objeto.Descripcion + "',Precio=" + Objeto.PrecioInd + ",Descuento=" + 1 + "," +
                    "Id_Proveedores= " + Objeto.BEProveedor.Id + "WHERE Id_Producto = " + Objeto.Id;
            }
            else
            {
                Consulta_SQL = "INSERT Productos(Codigo,Descripcion,Precio,Descuento,Id_Proveedores) values(" + Objeto.Codigo + ", '" + Objeto.Descripcion +
                    ", '" + Objeto.PrecioInd + ", '" + Objeto.Descuento + ", '" + Objeto.BEProveedor.Id + ")";

            };
            oDatos = new Acceso();
            return oDatos.Escribir(Consulta_SQL);
        }

        public BEProductos AsignarValores(int IdObjeto)
        {
            DataSet Ds;
            oDatos = new Acceso();
            string Consulta = "SELECT Id_Producto,Codigo,Descripcion,Precio,Descuento,Id_Proveedores FROM PRODUCTOS WHERE Id_Producto = " + IdObjeto.ToString();
            Ds = oDatos.Leer(Consulta);

            //rcorro la tabla dentro del Dataset y la paso a lista
            if (Ds.Tables[0].Rows.Count == 1)
            {
                DataRow fila = Ds.Tables[0].Rows[0];

                BEProductos oProductos = new BEProductos();
                oProductos.Id = Convert.ToInt32(fila["Id_Producto"]);
                oProductos.Codigo = fila["Codigo"].ToString();
                oProductos.Descripcion = fila["Descripcion"].ToString();
                oProductos.PrecioInd = Convert.ToDouble(fila["Precio"].ToString());
                oProductos.Descuento = Convert.ToDouble(fila["Descuento"]);
                MPPProveedores oMPPProveedores = new MPPProveedores();

                oProductos.BEProveedor = oMPPProveedores.AsignarValores(Convert.ToInt32(fila["Id_Proveedores"]));

                return oProductos;
            }
            return null;

        }
        public List<BEProductos> ListarTodo(BEFactura Objeto)
        {
            DataSet Ds;
            List<BEProductos> Lista = new List<BEProductos>();
            oDatos = new Acceso();
            string Consulta = "SELECT Pro.Id_Producto,Pro.Codigo,Pro.Descripcion," +
                "Pro.Precio,Pro.Descuento,Pro.Id_Proveedores FROM DetalleFacturas as DetFac JOIN Productos Pro " +
                "ON DetFac.Id_Producto = Pro.Id_Producto WHERE DetFac.ID_Factura = " + Objeto.Id;
            Ds = oDatos.Leer(Consulta);

            if (Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in Ds.Tables[0].Rows)
                {
                    BEProductos oProductos = new BEProductos();
                    oProductos.Id = Convert.ToInt32(fila["Id_Producto"]);
                    oProductos.Codigo = fila["Codigo"].ToString();
                    oProductos.Descripcion = fila["Descripcion"].ToString();
                    oProductos.PrecioInd = Convert.ToDouble(fila["Precio"].ToString());
                    oProductos.Descuento = Convert.ToDouble(fila["Descuento"]);
                    MPPProveedores oMPPProveedores = new MPPProveedores();

                    oProductos.BEProveedor = oMPPProveedores.AsignarValores(Convert.ToInt32(fila["Id_Clientes"]));
                    Lista.Add(oProductos);
                }

            }
            else
            { Lista = null; }
            return Lista;
        }
        public List<BEProductos> ListarTodo()
        {
            DataSet Ds;
            oDatos = new Acceso();
            string Consulta = "SELECT Id_Producto,Codigo,Descripcion,Precio,Descuento,Id_Proveedores FROM Productos";
            Ds = oDatos.Leer(Consulta);
            List<BEProductos> ListaProductos = new List<BEProductos>();
            if (Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in Ds.Tables[0].Rows)
                {
                    BEProductos oProducto = new BEProductos();
                    oProducto.Id = Convert.ToInt32(fila["Id_Producto"]);
                    oProducto.Codigo = fila["Codigo"].ToString();
                    oProducto.Descripcion = fila["Descripcion"].ToString();
                    oProducto.PrecioInd = Convert.ToDouble(fila["Precio"]);
                    oProducto.Descuento = Convert.ToDouble(fila["Descuento"]);
                    MPPProveedores oMPPPROVEEDOR = new MPPProveedores();
                    oProducto.BEProveedor = oMPPPROVEEDOR.AsignarValores(oProducto.Id);
                    ListaProductos.Add(oProducto);
                }
            }
            else { ListaProductos = null; }
            return ListaProductos;
        }

    }
}
