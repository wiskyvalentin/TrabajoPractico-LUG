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
    public class BLLProductos : IGestor<BEProductos>

    {
        MPPProductos oMPPPRODUCTOS;
        public BLLProductos()
        {
            oMPPPRODUCTOS = new MPPProductos();
        }
        #region METODOS GENERICOS
        public bool Baja(BEProductos Objeto)
        {
            return oMPPPRODUCTOS.Baja(Objeto);
        }

        public bool Guardar(BEProductos Objeto)
        {
            return oMPPPRODUCTOS.Guardar(Objeto);

        }

        public BEProductos ListarObjeto(BEProductos Objeto)
        {
            return oMPPPRODUCTOS.ListarObjeto(Objeto);

        }

        public List<BEProductos> ListarTodo()
        {
            return oMPPPRODUCTOS.ListarTodo();

        }
        #endregion
        #region METODOS NO GENERICOS
        #endregion
    }
}
