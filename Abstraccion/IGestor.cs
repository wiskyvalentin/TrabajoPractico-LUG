using System.Collections.Generic;
using System.Data;

namespace Abstraccion
{
    public interface IGestor<T> where T : IEntidad
    {
        bool Guardar(T Objeto);
        bool Baja(T Objeto);
        List<T> ListarTodo();
        T AsignarValores (T Objeto);
    }
}

