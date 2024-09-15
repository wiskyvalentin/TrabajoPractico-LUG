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
    public class BLLPersonas : IGestor<BEPersonas>
    {
        MPPPersonas oMPPPersonas;
        public BLLPersonas()
        {
            oMPPPersonas = new MPPPersonas();
        }
        #region METODOS GENERICOS
        public bool Baja(BEPersonas Objeto)
        {
           return oMPPPersonas.Baja(Objeto);
        }

        public bool Guardar(BEPersonas Objeto)
        {
           return oMPPPersonas.Guardar(Objeto);
       
        }

        public BEPersonas ListarObjeto(BEPersonas Objeto)
        {
            return oMPPPersonas.ListarObjeto(Objeto);

        }

        public List<BEPersonas> ListarTodo()
        {
            return oMPPPersonas.ListarTodo();

        }
        #endregion
        #region METODOS NO GENERICOS
        #endregion

    }
}
