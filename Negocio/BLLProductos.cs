using Abstraccion;
using BE;
using MPP;
using System.Collections.Generic;

namespace Negocio
{
    public class BLLProductos : IGestor<BEProductos>

    {
        private MPPProductos oMPPPRODUCTOS;
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

        public BEProductos AsignarValores(int IdObjeto)
        {
            return oMPPPRODUCTOS.AsignarValores(IdObjeto);

        }
        public BEProductos AsignarValores(int IdObjeto, double Cantidad)
        {
            return oMPPPRODUCTOS.AsignarValores(IdObjeto, Cantidad);

        }

        public List<BEProductos> ListarTodo()
        {
            return oMPPPRODUCTOS.ListarTodo();

        }
        public List<BEProductos> ListarTodo(BEFactura Objeto)
        {
            return oMPPPRODUCTOS.ListarTodo(Objeto);

        }
        #endregion
        #region METODOS NO GENERICOS
        #endregion
    }
}
