using System;
using System.Collections.Generic;
using System.Configuration; // para usar el app.config
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Acceso
    {
        private SqlConnection oCnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionString"].ToString());
        ////declaro el objeto transacction
        //private SqlTransaction Tranx;
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

            if (Consulta_SQL == null || Consulta_SQL.Length == 0)
                throw new ArgumentException("El array de consultas SQL está vacío o es nulo.");

            try
            {
                // Abrir la conexión
                oCnn.Open();

                // Iniciar la transacción
                using (SqlTransaction Tranx = oCnn.BeginTransaction())
                {
                    using (SqlCommand cmd = oCnn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = oCnn;
                        cmd.Transaction = Tranx;  // Asociar la transacción al comando

                        try
                        {               
                                cmd.CommandText =Consulta_SQL;
                                int respuesta = cmd.ExecuteNonQuery();
                           

                            // Confirmar la transacción
                            Tranx.Commit();
                            return true;
                        }
                        catch (SqlException)
                        {
                            // Si ocurre un error en SQL, hacer rollback
                            Tranx.Rollback();
                            throw;
                        }
                        catch (Exception)
                        {
                            // Si ocurre otro tipo de error, hacer rollback
                            Tranx.Rollback();
                            throw;
                        }
                    }
                }
            }
            finally
            {
                // Asegurarse de cerrar la conexión siempre
                oCnn.Close();
            }

        }

        public bool Escribir(List<string> Consulta_SQL)
        {
            if (Consulta_SQL == null || Consulta_SQL.Count == 0)
                throw new ArgumentException("La lista de consultas SQL está vacía o es nula.");

            try
            {
                // Abrir la conexión
                oCnn.Open();

                // Iniciar la transacción
                using (SqlTransaction Tranx = oCnn.BeginTransaction())
                {
                    using (SqlCommand cmd = oCnn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = oCnn;
                        cmd.Transaction = Tranx;  // Asociar la transacción al comando

                        try
                        {
                            // Ejecutar todas las consultas en la lista
                            foreach (var consulta in Consulta_SQL)
                            {
                                cmd.CommandText = consulta;  // Asignar la consulta al comando
                                int respuesta = cmd.ExecuteNonQuery();  // Ejecutar la consulta
                            }

                            // Confirmar la transacción
                            Tranx.Commit();
                            return true;
                        }
                        catch (SqlException)
                        {
                            // Si ocurre un error en SQL, hacer rollback
                            Tranx.Rollback();
                            throw;
                        }
                        catch (Exception)
                        {
                            // Si ocurre otro tipo de error, hacer rollback
                            Tranx.Rollback();
                            throw;
                        }
                    }
                }
            }
            finally
            {
                // Asegurarse de cerrar la conexión siempre
                oCnn.Close();
            }
        }

    }

}
       
