using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Acceso
    {
        private SqlConnection oCnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionString"].ToString());

        // LeerScalar usando un procedimiento almacenado
        public bool LeerScalar(string nombreSP, Dictionary<string, object> parametros)
        {
            bool resultado = false;

            try
            {
                oCnn.Open();
                SqlCommand cmd = new SqlCommand(nombreSP, oCnn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Agregar parámetros al procedimiento almacenado
                foreach (var param in parametros)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                }

                int respuesta = Convert.ToInt32(cmd.ExecuteScalar());
                resultado = respuesta > 0;
            }
            catch (SqlException sqlEx)
            {
                // Captura de excepciones SQL específicas
                throw new Exception($"Error SQL al ejecutar el procedimiento almacenado '{nombreSP}': {sqlEx.Message}", sqlEx);
            }
            catch (InvalidOperationException opEx)
            {
                // Captura de excepciones por operaciones no válidas (por ejemplo, conexión ya abierta)
                throw new Exception($"Operación inválida al ejecutar '{nombreSP}': {opEx.Message}", opEx);
            }
            catch (Exception ex)
            {
                // Captura de cualquier otra excepción
                throw new Exception($"Error inesperado en '{nombreSP}': {ex.Message}", ex);
            }
            finally
            {
                // Asegurarse de cerrar la conexión incluso si hay una excepción
                if (oCnn.State == ConnectionState.Open)
                {
                    oCnn.Close();
                }
            }

            return resultado;
        }


        // Leer con procedimiento almacenado
        public DataSet Leer(string nombreSP, Dictionary<string, object> parametros)
        {
            DataSet Ds = new DataSet();
            SqlCommand cmd = new SqlCommand(nombreSP, oCnn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Agregar parámetros al procedimiento almacenado
            foreach (var param in parametros)
            {
                cmd.Parameters.AddWithValue(param.Key, param.Value);
            }

            try
            {
                SqlDataAdapter Da = new SqlDataAdapter(cmd);
                Da.Fill(Ds);
            }
            catch (SqlException sqlEx)
            {
                throw new Exception($"Error SQL al ejecutar '{nombreSP}': {sqlEx.Message}", sqlEx);
            }
            catch (InvalidOperationException opEx)
            {
                throw new Exception($"Operación inválida al ejecutar '{nombreSP}': {opEx.Message}", opEx);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado en '{nombreSP}': {ex.Message}", ex);
            }
            finally
            {
                if (oCnn.State == ConnectionState.Open)
                {
                    oCnn.Close();
                }
            }
            return Ds;
        }

        // Escribir con un solo procedimiento almacenado
        public bool Escribir(string nombreSP, Dictionary<string, object> parametros)
        {
            try
            {
                oCnn.Open();
                using (SqlTransaction tranx = oCnn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand(nombreSP, oCnn)
                    {
                        CommandType = CommandType.StoredProcedure,
                        Transaction = tranx
                    };

                    foreach (var param in parametros)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }

                    cmd.ExecuteNonQuery();
                    tranx.Commit();
                    return true;
                }
            }
            catch (SqlException sqlEx)
            {
                throw new Exception($"Error SQL al ejecutar '{nombreSP}': {sqlEx.Message}", sqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado al ejecutar '{nombreSP}': {ex.Message}", ex);
            }
            finally
            {
                if (oCnn.State == ConnectionState.Open)
                {
                    oCnn.Close();
                }
            }
        }


        // Escribir múltiples procedimientos almacenados
        public bool Escribir(List<string> nombresSP, List<Dictionary<string, object>> parametrosList)
        {
            if (nombresSP == null || parametrosList == null || nombresSP.Count != parametrosList.Count)
                throw new ArgumentException("Las listas de nombres de SP y parámetros no coinciden.");

            try
            {
                oCnn.Open();
                using (SqlTransaction tranx = oCnn.BeginTransaction())
                {
                    for (int i = 0; i < nombresSP.Count; i++)
                    {
                        SqlCommand cmd = new SqlCommand(nombresSP[i], oCnn)
                        {
                            CommandType = CommandType.StoredProcedure,
                            Transaction = tranx
                        };

                        foreach (var param in parametrosList[i])
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }

                        cmd.ExecuteNonQuery();
                    }
                    tranx.Commit();
                    return true;
                }
            }
            catch (SqlException sqlEx)
            {
                throw new Exception($"Error SQL al ejecutar uno de los procedimientos almacenados: {sqlEx.Message}", sqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado en la transacción de múltiples procedimientos almacenados.", ex);
            }
            finally
            {
                if (oCnn.State == ConnectionState.Open)
                {
                    oCnn.Close();
                }
            }
        }
        public bool GrabarCambios(string nombreTabla, DataSet dset)
        {
            using (SqlDataAdapter da = new SqlDataAdapter($"SELECT * FROM {nombreTabla}", oCnn))
            {
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.UpdateCommand = cb.GetUpdateCommand();
                da.DeleteCommand = cb.GetDeleteCommand();
                da.InsertCommand = cb.GetInsertCommand();
                da.ContinueUpdateOnError = false;

                try
                {
                    oCnn.Open();
                    // Persistir los cambios en la base de datos
                    da.Update(dset.Tables[0]);
                    return true;
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"Error SQL al guardar cambios en la tabla '{nombreTabla}': {sqlEx.Message}", sqlEx);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error inesperado al guardar cambios en la tabla '{nombreTabla}': {ex.Message}", ex);
                }
                finally
                {
                    if (oCnn.State == ConnectionState.Open)
                    {
                        oCnn.Close();
                    }
                }
            }
        }

    }


}


