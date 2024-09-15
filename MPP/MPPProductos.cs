using Abstraccion;
using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public class MPPProductos : IGestor<BEProductos>
    {
        Acceso oDatos;
        public bool Baja(BEProductos Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BEProductos Objeto)
        {
            throw new NotImplementedException();
        }

        public BEProductos AsignarValores(BEProductos Objeto)
        {
          
        }

        public List<BEProductos> ListarTodo()
        {
            throw new NotImplementedException();
        }
    }
}
