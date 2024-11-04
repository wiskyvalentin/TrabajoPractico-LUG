using Abstraccion;
using BE;

using MPP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public abstract class BLLPersonas
    {
        private MPPPersonas oMPPPersonas;
        protected BLLPersonas()
        {
            oMPPPersonas = new MPPPersonas();
        }
        #region METODOS NO GENERICOS
        public virtual bool GuardarDataSet(DataSet DatosProveedor)
        {
            return oMPPPersonas.GuardarDataSet(DatosProveedor);
        }
        public virtual DataTable ConvertirListaADataTable(List<BEProveedores> listaproveedores)
        {
            return oMPPPersonas.ConvertirListaADataTable(listaproveedores);
        }
        public virtual DataSet ListarTodoDataSet()
        {
            return oMPPPersonas.ListarTodoDataSet();
        }

        #endregion

    }
}
