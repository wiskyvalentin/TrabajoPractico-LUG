using Abstraccion;
using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace MPP
{
    public class MPPUsuarios : IGestor<BEUsuarios>
    {
        private Acceso oDatos;



        public bool Baja(BEUsuarios Objeto)
        {
            if (Objeto.Id != 0)
            {
                oDatos = new Acceso();
                var parametros = new Dictionary<string, object>
                {
                    { "@Id", Objeto.Id }
                };
                return oDatos.Escribir("spBaja_Usuario", parametros);
            }
            else
            {
                throw new ArgumentException("EL USUARIO SELECCIONADO NO SE PUEDE DAR DE BAJA");
            }
        }

        public bool Guardar(BEUsuarios Objeto)
        {
            oDatos = new Acceso();
            var parametros = new Dictionary<string, object>
            {
                { "@Id", Objeto.Id },
                { "@Nombre", Objeto.Nombre },
                { "@Apellido", Objeto.Apellido },
                { "@Correo", Objeto.Correo },
                { "@Contraseña", Objeto.Contraseña }
            };

            return oDatos.Escribir("spInsertar_Usuario", parametros);
        }

        public BEUsuarios AsignarValores(int IdObjeto)
        {
            DataSet Ds;
            oDatos = new Acceso();
            var parametros = new Dictionary<string, object>
            {
                { "@Id", IdObjeto }
            };
            Ds = oDatos.Leer("spObtener_Usuario_Por_Id", parametros);

            if (Ds.Tables[0].Rows.Count == 1)
            {
                DataRow fila = Ds.Tables[0].Rows[0];
                return new BEUsuarios(
                    Convert.ToInt32(fila["ID_Persona"]), fila["Nombre"].ToString(), fila["Apellido"].ToString(), fila["Correo"].ToString(),
                    fila["Contraseña"].ToString());
            }
            return null;
        }

        public List<BEUsuarios> ListarTodo()
        {
            DataSet Ds;
            oDatos = new Acceso();
            Ds = oDatos.Leer("spListar_Usuarios", new Dictionary<string, object>());

            List<BEUsuarios> ListaUsuarios = new List<BEUsuarios>();
            if (Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in Ds.Tables[0].Rows)
                {
                    if (fila["Contraseña"] != DBNull.Value)
                    {
                        BEUsuarios oBEUsuarios = new BEUsuarios(
                            Convert.ToInt32(fila["ID_Persona"]), fila["Nombre"].ToString(), fila["Apellido"].ToString(), fila["Correo"].ToString(),
                            fila["Contraseña"].ToString());
                        ListaUsuarios.Add(oBEUsuarios);
                    }
                }
            }
            return ListaUsuarios;
        }

        public bool IniciarSesion(string usuario, string contraseña)
        {
            DataSet Ds;
            oDatos = new Acceso();
            var parametros = new Dictionary<string, object>
            {
                { "@Nombre", usuario },
                { "@Contraseña", contraseña }
            };
            Ds = oDatos.Leer("spIniciar_Sesion", parametros);

            return Ds.Tables[0].Rows.Count == 1;
        }

       
    }
}
