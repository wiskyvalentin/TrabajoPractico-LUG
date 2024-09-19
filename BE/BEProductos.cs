using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        public BEProveedores BEProveedor{ get; set; }

        public BEProductos()
        {
            BEProveedor = new BEProveedores();
        }
        public BEProductos(int ID,string Codigo,string Descripcion,double PrecioInd,double Descuento,double Cantidad,BEProveedores Proveedor) :this()
        {
            this.Id = ID;
            this.Codigo = Codigo;
            this.Descripcion = Descripcion;
            this.PrecioInd = PrecioInd;
            this.Descuento = Descuento;
            this.Cantidad = Cantidad;
            this.BEProveedor=Proveedor;
        }
        public override string ToString()
        {
            return this.Codigo + "- " + this.Descripcion + " " + this.Id + " ";
        }
    }
}
