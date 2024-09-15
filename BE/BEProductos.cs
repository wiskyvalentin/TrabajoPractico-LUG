using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEProductos : Entidades
    {
        public string Codigo { get; set; }
        public string Descripcion{ get; set; }
        public double PrecioInd { get; set; }
        public double Descuento{ get; set; }
        public double Cantidad { get; set; }
        public BEProveedores oBEProveedor{ get; set; }

        public BEProductos()
        {
            oBEProveedor = new BEProveedores();
        }
        public BEProductos(int Id) : this() 
        {
            this.Id = Id;
        }
    }
}
