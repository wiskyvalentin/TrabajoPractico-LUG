using Abstraccion;
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace MPP
{
    public class MPPProductos : IGestor<BEProductos>
    {
        private const string xmlFilePath = "D:\\UNIVERSIDAD\\CUATRIMESTRE 6\\Lenguajes de ultima generacion\\TrabajoPractico\\Presentacion_UI\\MPP\\Productos.xml"; // Ruta del archivo XML


        public bool Baja(BEProductos Objeto)
        {
            if (Objeto.Id != 0)
            {
                XDocument doc = XDocument.Load(xmlFilePath);
                var producto = doc.Descendants("Producto")
                                  .FirstOrDefault(p => (int)p.Attribute("Id") == Objeto.Id);

                if (producto != null)
                {
                    producto.Remove();
                    doc.Save(xmlFilePath);
                    return true; // Baja exitosa
                }
            }
            else
            {
                throw new ArgumentException("EL PRODUCTO SELECCIONADO NO SE PUEDE DAR DE BAJA");
            }
            return false; // Baja fallida
        }

        public bool Guardar(BEProductos Objeto)
        {
            XDocument doc = XDocument.Load(xmlFilePath);

            if (Objeto.Id != 0)
            {
                var producto = doc.Descendants("Producto")
                                  .FirstOrDefault(p => (int)p.Attribute("Id") == Objeto.Id);
                if (producto != null)
                {
                    // Modificar el producto existente
                    producto.Element("Codigo").Value = Objeto.Codigo;
                    producto.Element("Descripcion").Value = Objeto.Descripcion;
                    producto.Element("PrecioInd").Value = Objeto.PrecioInd.ToString();
                    producto.Element("ProveedorId").Value = Objeto.BEProveedor.Id.ToString();
                    doc.Save(xmlFilePath);
                    return true; // Actualización exitosa
                }
            }
            else
            {
                // Agregar un nuevo producto
                int newId = doc.Descendants("Producto").Count() + 1; // Asignar un nuevo ID
                XElement nuevoElemento = new XElement("Producto",
                    new XAttribute("Id", newId),
                    new XElement("Codigo", Objeto.Codigo),
                    new XElement("Descripcion", Objeto.Descripcion),
                    new XElement("PrecioInd", Objeto.PrecioInd),
                    new XElement("ProveedorId", Objeto.BEProveedor.Id)
                );

                doc.Element("Productos").Add(nuevoElemento);
                doc.Save(xmlFilePath);
                return true; // Guardado exitoso
            }
            return false; // Fallo en el guardado
        }

        public BEProductos AsignarValores(int IdObjeto)
        {
            XDocument doc = XDocument.Load(xmlFilePath);
            var producto = doc.Descendants("Producto")
                              .FirstOrDefault(p => (int)p.Attribute("Id") == IdObjeto);

            if (producto != null)
            {
                return new BEProductos
                {
                    Id = (int)producto.Attribute("Id"),
                    Codigo = (string)producto.Element("Codigo"),
                    Descripcion = (string)producto.Element("Descripcion"),
                    PrecioInd = (double)producto.Element("PrecioInd"),
                    BEProveedor = new MPPProveedores().AsignarValores((int)producto.Element("ProveedorId")) // Asignación correcta del proveedor
                };
            }
            return null;
        }

        public BEProductos AsignarValores(int IdObjeto, double Cantidad)
        {
            XDocument doc = XDocument.Load(xmlFilePath);
            var producto = doc.Descendants("Producto")
                              .FirstOrDefault(p => (int)p.Attribute("Id") == IdObjeto);

            if (producto != null)
            {
                return new BEProductos
                {
                    Id = (int)producto.Attribute("Id"),
                    Codigo = (string)producto.Element("Codigo"),
                    Descripcion = (string)producto.Element("Descripcion"),
                    PrecioInd = (double)producto.Element("PrecioInd"),
                    Cantidad = Cantidad,
                    BEProveedor = new MPPProveedores().AsignarValores((int)producto.Element("ProveedorId")) // Asignación correcta del proveedor
                };
            }
            return null;
        }

        public List<BEProductos> ListarTodo(BEFactura Objeto)
        {
            XDocument doc = XDocument.Load(xmlFilePath);
            var productos = doc.Descendants("Producto")
                .Where(p => (int)p.Element("ProveedorId") == Objeto.Id) // Aquí se debe ajustar según cómo se relacionan productos y facturas
                .Select(p => new BEProductos
                {
                    Id = (int)p.Attribute("Id"),
                    Codigo = (string)p.Element("Codigo"),
                    Descripcion = (string)p.Element("Descripcion"),
                    PrecioInd = (double)p.Element("PrecioInd"),
                    BEProveedor = new MPPProveedores().AsignarValores((int)p.Element("ProveedorId")) // Asignación correcta del proveedor
                }).ToList();

            return productos;
        }

        public List<BEProductos> ListarTodo()
        {
            XDocument doc = XDocument.Load(xmlFilePath);
            var productos = doc.Descendants("Producto")
                .Select(p => new BEProductos
                {
                    Id = (int)p.Attribute("Id"),
                    Codigo = (string)p.Element("Codigo"),
                    Descripcion = (string)p.Element("Descripcion"),
                    PrecioInd = (double)p.Element("PrecioInd"),
                    BEProveedor = new MPPProveedores().AsignarValores((int)p.Element("ProveedorId")) // Asignación correcta del proveedor
                }).ToList();

            return productos;
        }
    }
}






#region ADO DESCONECTADO
#endregion
