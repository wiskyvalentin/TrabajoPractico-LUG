using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BECliente : BEPersonas
    {
        public string Cuit { get; set; }
        public string CondicionVenta { get; set; }
        public BECliente()
        {

        }
        public BECliente(int ID)
        {
            this.Id = ID;
        }
        public BECliente(int Id, string Cuit, String CondicionVenta, string Nombre, string Apellido, string Correo) : this(Id)
        {
            this.Cuit = Cuit;
            this.CondicionVenta = CondicionVenta;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Correo = Correo;
        }
        public override string ToString()
        {
            return this.Id + "- " + this.Apellido;
        }
    }
}
