using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Entidades_Compartidas;



namespace Persistencia
{
    public class PresistenciaPais
    {
        public static Pais BuscarPais(string CodigoPais)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("BuscarPais", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodPais", CodigoPais);
            string oCodPais;

            try
            {
                cnn.Open();
                SqlDataReader Lector = cmd.ExecuteReader();
                if (Lector.Read())
                {
                    oCodPais = (string)Lector["CodPais"];

                }
                Lector.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }

        }

        public static void AgregarPais(Pais p)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("AgregarPais", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CodPais", p.CodPais);
            cmd.Parameters.AddWithValue("@NomPais", p.NomPais);


            SqlParameter Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            Retorno.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(Retorno);
            int oRetorno = 0;


            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();

                oRetorno = (int)cmd.Parameters["@Retorno"].Value;
                if (oRetorno == -1)
                    throw new Exception("Ya existe el pais");
                else if (oRetorno == -2)
                    throw new Exception("Error.");
                else if (oRetorno == 1)
                    throw new Exception("Alta con exito.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }

        }
        public static void ModificarPais(Pais p)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmm = new SqlCommand("ModPais", _cnn);
            cmm.CommandType = CommandType.StoredProcedure;

            cmm.Parameters.AddWithValue("@CodPais", p.CodPais);
            cmm.Parameters.AddWithValue("@NomPais", p.NomPais);

            try
            {
                _cnn.Open();
                cmm.ExecuteNonQuery();

                int oAfectados = (int)cmm.Parameters["@Retorno"].Value;
                if (oAfectados == -2)
                    throw new Exception("No se pudo modificar el Pais");
                else if (oAfectados == 1)
                    throw new Exception("Usuario modificado correctamente");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _cnn.Close();
            }
        }
        public static void EliminarPais(Pais p)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmm = new SqlCommand("EliminarPais", _cnn);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.AddWithValue("@CodPais", p.CodPais);
            // cmm.Parameters.AddWithValue("@CodCiudad", );

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            cmm.Parameters.Add(oRetorno);

            try
            {
                _cnn.Open();
                cmm.ExecuteNonQuery();

                int oAfectados = (int)cmm.Parameters["@Retorno"].Value;
                if (oAfectados == -5)
                    throw new Exception("No existe el pais.");
                if (oAfectados == -1)
                    throw new Exception(".");
                else if (oAfectados == -2)
                    throw new Exception("error.");
                else if (oAfectados == -3)
                    throw new Exception(".");
                else if (oAfectados == -4)
                    throw new Exception(".");
                else if (oAfectados == 1)
                    throw new Exception("Pais eliminado correctamente.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _cnn.Close();
            }
        }
    }
}
