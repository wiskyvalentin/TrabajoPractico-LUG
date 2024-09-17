using Abstraccion;
using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class BLLCliente : IGestor<BECliente> 
    {

        MPPCliente oMPPCliente;
        public BLLCliente()
        {
            oMPPCliente = new MPPCliente();
        }
        #region METODOS GENERICOS
        public bool Baja(BECliente Objeto)
        {
         return oMPPCliente.Baja(Objeto);
        }

        public bool Guardar(BECliente Objeto)
        {
            return oMPPCliente.Guardar(Objeto); ;
        }

        public BECliente AsignarValores(int IdObjeto)
        {
            return oMPPCliente.AsignarValores(IdObjeto);
        }

        public List<BECliente> ListarTodo()
        {
            return oMPPCliente.ListarTodo();
        }
        #endregion
        #region METODOS NO GENERICOS
        #endregion
    }
}
