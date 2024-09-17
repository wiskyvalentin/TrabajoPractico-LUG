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
    public class BLLProveedores : IGestor<BEProveedores>
    {
        MPPProveedores oMPPProvedores;
        public BLLProveedores()
        {
            oMPPProvedores = new MPPProveedores();
        }
        #region METODOS GENERICOS

        public bool Baja(BEProveedores Objeto)
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
