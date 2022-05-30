using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using EntidadesCompartidas;

namespace Persistencia
{
    public class PresistenciaPais
    {
        public static Pais BuscarPais(string p)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("BuscarPais", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodPais", p);
            string oCodPais;
            string oNomPais;
            Pais pPais = null;
       
            try
            {
                cnn.Open();
                SqlDataReader Lector = cmd.ExecuteReader();
                if (Lector.Read())
                {
                    oCodPais = (string)Lector["CodPais"];
                    oNomPais = (string)Lector["NomPais"];
                    pPais = new Pais (oCodPais, oNomPais);
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
            return pPais;
            
        }

        public static void AgregarPais(string CodPais, string NomPais)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("AgregarPais", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CodPais", CodPais);
            cmd.Parameters.AddWithValue("@NomPais", NomPais);

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
        public static void ModificarPais(string CodPais, string NomPais)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmm = new SqlCommand("ModPais", _cnn);
            cmm.CommandType = CommandType.StoredProcedure;

            cmm.Parameters.AddWithValue("@CodPais", CodPais);
            cmm.Parameters.AddWithValue("@NomPais", NomPais);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            cmm.Parameters.Add(oRetorno);

            try
            {
                _cnn.Open();
                cmm.ExecuteNonQuery();

                int oAfectados = (int)cmm.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("No se pudo modificar el Pais");    
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
                    throw new Exception("No se elimina, tiene pronosticos asociados.");
                 if (oAfectados == -2)
                    throw new Exception("BD ERROR 2.");
                 if (oAfectados == -3)
                    throw new Exception("BD ERROR 3.");
                
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
        public static List<Pais> ListarPais()
        {

            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmm = new SqlCommand("ListarPais", cnn);
            cmm.CommandType = CommandType.StoredProcedure;
           
            List<Pais> oAux = new List<Pais>();

            string  cCodPais ,nNombrePais;
            
            SqlDataReader oReader;
            try
            {
                cnn.Open();
                oReader = cmm.ExecuteReader();

                while (oReader.Read())
                {
                    
                    cCodPais = (string)oReader["CodPais"];
                    nNombrePais = (string)oReader["NomPais"];

                   

                    Pais Pai = new Pais(cCodPais,nNombrePais);
                    oAux.Add(Pai);
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
