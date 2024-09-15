using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEProveedores : BEPersonas
    {
       public string Direccion { get; set; }
       public string CBU { get; set; }

        public BEProveedores()
        {
            
        }
        public BEProveedores(int ID)
        {
            this.Id = ID;
        }
    }
}
