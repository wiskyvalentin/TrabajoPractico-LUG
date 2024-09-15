using System;
using System.Configuration; // para usar el app.config
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Acceso
    {
        private SqlConnection oCnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionString"].ToString());
        //declaro el objeto transacction
        private SqlTransaction Tranx;
        //leo un escalar-
        public bool LeerScalar(string consulta)
        {
            oCnn.Open();
            //uso el constructor del objeto Command
            SqlCommand cmd = new SqlCommand(consulta, oCnn);
            cmd.CommandType = CommandType.Text;
            try
            {
                int Respuesta = Convert.ToInt32(cmd.ExecuteScalar());
                oCnn.Close();
                if (Respuesta > 0)
                { return true; }
                else
                { return false; }
            }
            catch (SqlException ex)
            { throw ex; }
        }

        public DataSet Leer(string Consulta_SQL)
        {
            DataSet Ds = new DataSet();
            try
            {
                //creo el data adapter
                SqlDataAdapter Da = new SqlDataAdapter(Consulta_SQL, oCnn);
                //lleno el DataSet con el metodo fill
                Da.Fill(Ds);
            }
            catch (SqlException ex)
            { throw ex; }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                oCnn.Close();
            }
            return Ds;
        }

        //realizo un método escribir generico
        public bool Escribir(string Consulta_SQL)
        {

            oCnn.Open();
            //con esto se evita que se utilice la BD
            Tranx = oCnn.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = oCnn;
            cmd.CommandText = Consulta_SQL;
            //le paso el objeto transaccion al command
            cmd.Transaction = Tranx;
            try
            {
                int respuesta = cmd.ExecuteNonQuery();
                //si esta OK confirma la transaccion y libera La BD
                Tranx.Commit();
                return true;
            }
            catch (SqlException ex)
            {    //vuelve para atras
                Tranx.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {    //si pudo realizar la operacion hace un rollback
                Tranx.Rollback();
                throw ex;
            }

            finally
            { oCnn.Close(); }


        }
    }
}
