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
    public class BLLFactura : IGestor<BEFactura>
    {
        MPPFactura oMPPFactura;
        public BLLFactura()
        {
            oMPPFactura = new MPPFactura();
        }
        #region METODOS GENERICOS
        public bool Baja(BEFactura Objeto)
        {
            return oMPPFactura.Baja(Objeto);
        }

        public bool Guardar(BEFactura Objeto)
        {
            return oMPPFactura.Guardar(Objeto);

        }

        public BEFactura AsignarValores(int IdObjeto)
        {
            return oMPPFactura.AsignarValores(IdObjeto);

        }

        public List<BEFactura> ListarTodo()
        {
            return oMPPFactura.ListarTodo();

        }
        #endregion
        #region METODOS NO GENERICOS
        #endregion
    }
}
