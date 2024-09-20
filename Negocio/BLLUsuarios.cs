using Abstraccion;
using BE;
using MPP;
using System.Collections.Generic;

namespace Negocio
{
    public class BLLUsuarios : IGestor<BEUsuarios>
    {
        MPPUsuarios oMPPUsuarios;
        public BLLUsuarios()
        {
            oMPPUsuarios = new MPPUsuarios();
        }
        public bool Baja(BEUsuarios Objeto)
        {
            return oMPPUsuarios.Baja(Objeto);
        }

        public bool Guardar(BEUsuarios Objeto)
        {
            return oMPPUsuarios.Guardar(Objeto);
        }
        public BEUsuarios AsignarValores(int IdObjeto)
        {
            return oMPPUsuarios.AsignarValores(IdObjeto);
        }

        public List<BEUsuarios> ListarTodo()
        {
            return oMPPUsuarios.ListarTodo();
        }
        public bool IniciarSesion(string usuario, string Contraseña)
        {
            return oMPPUsuarios.IniciarSesion(usuario, Contraseña);
        }
    }
}
