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
    public class MPPCliente : IGestor<BECliente>
    {
        Acceso oDatos;

        public bool Baja(BECliente Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BECliente Objeto)
        {
            throw new NotImplementedException();
        }

        public BECliente AsignarValores(BECliente Objeto)
        {
           
        }

        public List<BECliente> ListarTodo()
        {
            throw new NotImplementedException();
        }
    }
}
