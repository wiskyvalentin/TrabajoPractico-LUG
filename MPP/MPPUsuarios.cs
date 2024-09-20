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
        private string Consulta_SQL;


        public bool Baja(BEUsuarios Objeto)
        {
            if (Objeto.Id != 0)
            {
                Consulta_SQL = "DELETE FROM Personas WHERE ID_Persona = " + Objeto.Id;
                oDatos = new Acceso();
                return oDatos.Escribir(Consulta_SQL);
            }
            else { throw new ArgumentException("EL USUARIO SELECCIONADO NO SE PUEDE DAR DE BAJA"); };
        }

        public bool Guardar(BEUsuarios Objeto)
        {
            if (Objeto.Id != 0)
            {
                Consulta_SQL = "UPDATE Personas SET Nombre='" + Objeto.Nombre + "',Apellido='" + Objeto.Apellido + "',Correo=" + Objeto.Correo +
                    ",Contraseña=" + Objeto.Contraseña + "WHERE ID_Persona = " + Objeto.Id;
            }
            else
            {
                Consulta_SQL = "INSERT Personas(Nombre,Apellido,Correo,Contraseña) values('" + Objeto.Nombre + "', '" + Objeto.Apellido +
                    "', '" + Objeto.Correo + "', '" + Encriptar(Objeto.Contraseña) + "')";

            };
            oDatos = new Acceso();
            return oDatos.Escribir(Consulta_SQL);
        }
        public BEUsuarios AsignarValores(int IdObjeto)
        {
            DataSet Ds;
            oDatos = new Acceso();
            string Consulta = "SELECT ID_Persona,Nombre,Apellido,Correo,contraseña FROM PERSONAS WHERE ID_Persona = " + IdObjeto.ToString();
            Ds = oDatos.Leer(Consulta);

            //rcorro la tabla dentro del Dataset y la paso a lista
            if (Ds.Tables[0].Rows.Count == 1)
            {
                DataRow fila = Ds.Tables[0].Rows[0];
                BEUsuarios oBEUsuarios = new BEUsuarios(
                    Convert.ToInt32(fila["IdCliente"]), fila["Nombre"].ToString(), fila["Apellido"].ToString(), fila["Correo"].ToString(),
                    fila["Contraseña"].ToString());
                return oBEUsuarios;
            }
            return null;
        }

        public List<BEUsuarios> ListarTodo()
        {
            DataSet Ds;
            oDatos = new Acceso();
            string Consulta = "SELECT ID_Persona,Nombre,Apellido,Correo,Contraseña FROM Personas";
            Ds = oDatos.Leer(Consulta);
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
            else { }
            return ListaUsuarios;
        }
        public bool IniciarSesion(string usuario, string contraseña)
        {

            DataSet Ds;
            oDatos = new Acceso();
            string Consulta = "SELECT ID_Persona,Nombre,Apellido,Correo,contraseña FROM PERSONAS WHERE Nombre = '" +
                usuario.ToString() + "' AND Contraseña ='" + Encriptar(contraseña) + "'";
            Ds = oDatos.Leer(Consulta);

            //rcorro la tabla dentro del Dataset y la paso a lista
            if (Ds.Tables[0].Rows.Count == 1)
            {
              return true;
            }
            return false;
        }
        private string Encriptar(string Cadena)
        {
            try
            {

                UnicodeEncoding UeCodigo = new UnicodeEncoding();
                //Matriz de bytes enviados
                byte[] ByteSourceText = UeCodigo.GetBytes(Cadena);
                //MD5 Proveedor
                MD5CryptoServiceProvider Md5 = new MD5CryptoServiceProvider();
                //Calcular el valor hash MD5 de la fuente
                byte[] ByteHash = Md5.ComputeHash(ByteSourceText);
                //Y es convertir a formato de cadena para el retorno
                return Convert.ToBase64String(ByteHash);
            }
            catch (CryptographicException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
