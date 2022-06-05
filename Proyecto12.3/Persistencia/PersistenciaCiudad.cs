using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;
using Persistencia;

namespace Persistencia
{
    public class PersistenciaCiudad
    {
        public static Ciudad BuscarCiudad(string CodCiudad, string CodPais)
        {

            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("BuscarCiudad", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodCiudad", CodCiudad);
            cmd.Parameters.AddWithValue("@CodPais", CodPais);

            string oCodCiudad, oCodPais, oNombreCiudad;
            Ciudad cCiudad = null;

            SqlDataReader oReader;

            try
            {
                cnn.Open();
                oReader = cmd.ExecuteReader();
                while (oReader.Read())
                {
                    oCodPais = (string)oReader["CodPais"];
                    oCodCiudad = (string)oReader["CodCiudad"];
                    oNombreCiudad = (string)oReader["NomCiudad"];

                   Pais pPais = PresistenciaPais.BuscarPais(oCodPais);
                    cCiudad = new Ciudad( oCodCiudad, oNombreCiudad,pPais);
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
            return cCiudad;
        }

        public static void AgregarCiudad(Ciudad Ciudad)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("AgregarCiudad", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodCiudad", Ciudad.CodCiudad);
            cmd.Parameters.AddWithValue("@CodPais", Ciudad.pPais);
            cmd.Parameters.AddWithValue("@NomCiudad", Ciudad.NomCiudad);
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);

            oRetorno.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(oRetorno);
            int Retorno = 0;

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                Retorno = (int)cmd.Parameters["@Retorno"].Value;
                if (Retorno == -1)
                    throw new Exception("El pais no existe");
                else if (Retorno == -2)
                    throw new Exception("La ciudad ya existe en este Pais.");
             
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

        public static void ModificarCiudad(Ciudad Ciudad)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("ModCiudad", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodCiudad", Ciudad.CodCiudad);
            cmd.Parameters.AddWithValue("@CodPais", Ciudad.pPais.CodPais);
            cmd.Parameters.AddWithValue("@NomCiudad", Ciudad.NomCiudad);

         //   string oCodCiudad, oCodPais, oNombreCiudad;
          //  Ciudad cCiudad = null;

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(oRetorno);

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
               
                     int oAfectados = (int)cmd.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("No se pudo modificar la Ciudad porque no existe");   
                
                cnn.Close();
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

        public static void EliminarCiudad (Ciudad Ciudad)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("EliminarCiudad", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodCiudad", Ciudad.CodCiudad);
            cmd.Parameters.AddWithValue("@CodPais", Ciudad.pPais.CodPais);
            
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);

            oRetorno.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(oRetorno);
            int Retorno = 0;

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                Retorno = (int)cmd.Parameters["@Retorno"].Value;
                if (Retorno == -1)
                    throw new Exception("El pais no existe");
                if (Retorno == -2)
                    throw new Exception("Error en la tabla escriben");
                else if (Retorno == -3)
                    throw new Exception("La ciudad ya existe en este Pais.");
                
                if (Retorno == -4)
                    throw new Exception("Error en la tabla Ciudad");
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


        public static List<Ciudad> ListarCiudad()
        {    
            List<Ciudad> oAux = new List<Ciudad>();
            string cCodPais, cCodCiudad, nNomCiudad;
            Ciudad cCiudad = null;

            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmm = new SqlCommand("ListarCiudad", cnn);
            cmm.CommandType = CommandType.StoredProcedure;
            SqlDataReader oReader;
            try
            {
                cnn.Open();
                oReader = cmm.ExecuteReader();
                while (oReader.Read())
                {
                    cCodPais = (string)oReader["CodPais"];
                    cCodCiudad = (string)oReader["CodCiudad"];
                    nNomCiudad = (string)oReader["NomCiudad"];

                    Pais pPais = PresistenciaPais.BuscarPais(cCodPais);
                    cCiudad = new Ciudad( cCodCiudad, nNomCiudad,pPais);
                    oAux.Add(cCiudad);
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
            return oAux; 
        }
        public static List<Ciudad> ListarCiudadPorPais(Pais pPais)
        {
            List<Ciudad> oAux = new List<Ciudad>();
            string cCodPais, cCodCiudad, nNomCiudad;   
            Ciudad cCiudad = null;

            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmm = new SqlCommand("ListarCiudadPorPais", cnn);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.AddWithValue("@CodPais", pPais.CodPais);
            SqlDataReader oReader;
            try
            {
                cnn.Open();
                oReader = cmm.ExecuteReader();
                while (oReader.Read())
                {
                    cCodPais = (string)oReader["CodPais"];
               
                    cCodCiudad = (string)oReader["CodCiudad"];
                    nNomCiudad = (string)oReader["NomCiudad"];

                  
                    cCiudad = new Ciudad( cCodCiudad, nNomCiudad,pPais);
                    
                    oAux.Add(cCiudad);
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
            return oAux;
        }
    }
}
