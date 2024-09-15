using System;
using System.Collections.Generic;

namespace BE
{
    public class BEFactura : Entidades
    {
        #region PROPIEDADES
        
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public string MetodoPago { get; set; }
        public double MontoTotal { get; set; }
        public BECliente BECliente { get; set; }
        public List<BEProductos> BEProductos { get; set; }
        #endregion

        #region Metodos
        public BEFactura()
        {
            BEProductos = new List<BEProductos>();
            BECliente = new BECliente();
            Fecha = DateTime.Now;
        }
        public double CalcularMontoTotal()
        {
            try
            {
                foreach (var Productos in BEProductos)
                {
                    if (Productos.Cantidad != 0)
                    {
                        MontoTotal += (Productos.PrecioInd * Productos.Descuento) * Productos.Cantidad;
                    }   
                }
                return MontoTotal;
            }
            catch (Exception)
            {
                throw new Exception("Error al calcular el Precio Total");
            }
        }
        #endregion
    }
}
