using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEUsuarios : BEPersonas
    {
        public string Contraseña { get; set; }
        public BEUsuarios()
        {
            
        }
        public BEUsuarios(int ID, string Nombre, string Apellido, string Correo, string Constraseña)        
            {
                this.Id = ID;
                this.Nombre = Nombre;
                this.Apellido = Apellido;
                this.Correo = Correo;
                this.Contraseña = Constraseña;
            }
    }
}
