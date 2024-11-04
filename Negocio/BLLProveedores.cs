using Abstraccion;
using BE;
using MPP;
using System.Collections.Generic;
using System.Data;

namespace Negocio
{
    public class BLLProveedores : BLLPersonas,IGestor<BEProveedores>
    {
        private MPPProveedores oMPPProvedores;
        public BLLProveedores()
        {
            oMPPProvedores = new MPPProveedores();
        }
        #region METODOS GENERICOS

        public  bool Baja(BEProveedores Objeto)
        {
            return oMPPProvedores.Baja(Objeto);
        }

        public bool Guardar(BEProveedores Objeto)
        {
            return oMPPProvedores.Guardar(Objeto);

        }

        public BEProveedores AsignarValores(int IdObjeto)
        {
            return oMPPProvedores.AsignarValores(IdObjeto);

        }

        public List<BEProveedores> ListarTodo()
        {
            return oMPPProvedores.ListarTodo();

        }
            
        #endregion
        #region METODOS NO GENERICOS
        #endregion
    }
}
