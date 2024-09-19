using Abstraccion;
using BE;
using MPP;
using System.Collections.Generic;

namespace Negocio
{
    public class BLLFactura : IGestor<BEFactura>
    {
        private MPPFactura oMPPFactura;
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
        public void AgregarProducto(BEFactura oFactura, BEProductos oProducto)
        {
            oFactura.BEProductos.Add(oProducto);
        }
        #endregion
    }
}
