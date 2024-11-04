using Abstraccion;
using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

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
            return oMPPUsuarios.IniciarSesion(usuario,Encriptar( Contraseña));
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
