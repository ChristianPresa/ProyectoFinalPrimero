using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaPronostico
    {
        public static List<Pronostico> ListarPronosticoDiario()
        {
            DateTime FechaHoy = DateTime.Now;
            string fFechaHoy;
            fFechaHoy = FechaHoy.ToString("MM/dd/yyyy");
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmm = new SqlCommand("ListarPronosticoDiario", cnn);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.AddWithValue("@Fecha", fFechaHoy);

            List<Pronostico> oAux = new List<Pronostico>();

            string tTipoCielo, cCodPais, cCiudad, uUsuario;
            int vVelocidadViento, pProbabilidad, tTempMax, tTempMin;
            int cCodPronostico;
            DateTime fFecha;
            string hHora;

            SqlDataReader oReader;
            try
            {
                cnn.Open();
                oReader = cmm.ExecuteReader();

                while (oReader.Read())
                {
                    tTipoCielo = (string)oReader["TipoCielo"];
                    cCodPais = (string)oReader["CodPais"];
                    cCiudad = (string)oReader["CodCiudad"];
                    fFecha = (DateTime)oReader["Fecha"];
                    hHora = (string)oReader["Hora"].ToString().Substring(0, 5);
                    cCodPronostico = (int)oReader["CodPronostico"];
                    vVelocidadViento = (int)oReader["VelocidadViento"];
                    pProbabilidad = (int)oReader["Probabilidad"];
                    tTempMax = (int)oReader["TempMax"];
                    tTempMin = (int)oReader["TempMin"];
                    uUsuario = (string)oReader["NomLog"];

                    Usuario usuario = PersistenciaUsuario.BuscarUsuarios(uUsuario);
                    Ciudad ciudad = PersistenciaCiudad.BuscarCiudad(cCiudad, cCodPais);

                    Pronostico pro = new Pronostico(pProbabilidad, tTipoCielo, vVelocidadViento, fFecha.Date, hHora, tTempMin, tTempMax, cCodPronostico, ciudad, usuario);
                    oAux.Add(pro);
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
        public static List<Pronostico> ListarPronosticoFecha(DateTime Fecha)
        {

            string fFechaHoy;
            fFechaHoy = Fecha.ToString("MM/dd/yyyy");
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmm = new SqlCommand("ListarPronosticoDiario", cnn);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.AddWithValue("@Fecha", fFechaHoy);

            List<Pronostico> oAux = new List<Pronostico>();

            string tTipoCielo, cCodPais, cCiudad, uUsuario;
            int vVelocidadViento, pProbabilidad, tTempMax, tTempMin;
            int cCodPronostico;
            DateTime fFecha;
            string hHora;

            SqlDataReader oReader;
            try
            {
                cnn.Open();
                oReader = cmm.ExecuteReader();

                while (oReader.Read())
                {
                    tTipoCielo = (string)oReader["TipoCielo"];
                    cCodPais = (string)oReader["CodPais"];
                    cCiudad = (string)oReader["CodCiudad"];
                    fFecha = (DateTime)oReader["Fecha"];
                    hHora = (string)oReader["Hora"].ToString().Substring(0, 5);
                    cCodPronostico = (int)oReader["CodPronostico"];
                    vVelocidadViento = (int)oReader["VelocidadViento"];
                    pProbabilidad = (int)oReader["Probabilidad"];
                    tTempMax = (int)oReader["TempMax"];
                    tTempMin = (int)oReader["TempMin"];
                    uUsuario = (string)oReader["NomLog"];

                    Usuario usuario = PersistenciaUsuario.BuscarUsuarios(uUsuario);
                    Ciudad ciudad = PersistenciaCiudad.BuscarCiudad(cCiudad, cCodPais);

                    Pronostico pro = new Pronostico(pProbabilidad, tTipoCielo, vVelocidadViento, fFecha, hHora, tTempMin, tTempMax, cCodPronostico, ciudad, usuario);
                    oAux.Add(pro);
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

        public static List<Pronostico> ListarPronosticoPorCiudad(string CodPais, string CodCiudad)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmm = new SqlCommand("ListarPronosticoPorCiudad", cnn);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.AddWithValue("@CodPais", CodPais);
            cmm.Parameters.AddWithValue("@CodCiudad", CodCiudad);

            List<Pronostico> oAux = new List<Pronostico>();

            string tTipoCielo, cCodPais, cCiudad, uUsuario;
            int vVelocidadViento, pProbabilidad, tTempMax, tTempMin;
            int cCodPronostico;
            DateTime fFecha;
            string hHora;

            SqlDataReader oReader;
            try
            {
                cnn.Open();
                oReader = cmm.ExecuteReader();

                while (oReader.Read())
                {
                    tTipoCielo = (string)oReader["TipoCielo"];
                    cCodPais = (string)oReader["CodPais"];
                    cCiudad = (string)oReader["CodCiudad"];
                    fFecha = (DateTime)oReader["Fecha"];
                    hHora = (string)oReader["Hora"].ToString().Substring(0, 5);
                    cCodPronostico = (int)oReader["CodPronostico"];
                    vVelocidadViento = (int)oReader["VelocidadViento"];
                    pProbabilidad = (int)oReader["Probabilidad"];
                    tTempMax = (int)oReader["TempMax"];
                    tTempMin = (int)oReader["TempMin"];
                    uUsuario = (string)oReader["NomLog"];

                    Usuario usuario = PersistenciaUsuario.BuscarUsuarios(uUsuario);
                    Ciudad ciudad = PersistenciaCiudad.BuscarCiudad(cCiudad, cCodPais);

                    Pronostico pro = new Pronostico(pProbabilidad, tTipoCielo, vVelocidadViento, fFecha.Date, hHora, tTempMin, tTempMax, cCodPronostico, ciudad, usuario);
                    oAux.Add(pro);
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


        public static int AgregarPronostico(Pronostico Pro)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmm = new SqlCommand("AgregarPronostico", cnn);
            cmm.CommandType = CommandType.StoredProcedure;

            cmm.Parameters.AddWithValue("@Probabilidad", Pro.Probabilidad);
            cmm.Parameters.AddWithValue("@TipoCielo", Pro.TipoCielo);
            cmm.Parameters.AddWithValue("@VelocidadViento", Pro.VelocidadViento);
            cmm.Parameters.AddWithValue("@TempMax", Pro.TempMax);
            cmm.Parameters.AddWithValue("@TempMin", Pro.TempMin);
            cmm.Parameters.AddWithValue("@CodCiudad", Pro.Ciudad.CodCiudad);
            cmm.Parameters.AddWithValue("@CodPais", Pro.Ciudad.pPais.CodPais);
            cmm.Parameters.AddWithValue("@NomLog", Pro.Usuario.NomLog);
            cmm.Parameters.AddWithValue("@Fecha", Pro.Fecha);
            cmm.Parameters.AddWithValue("@Hora", Pro.Hora);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            cmm.Parameters.Add(oRetorno);

            int retorno = 0;

            try
            {
                cnn.Open();
                cmm.ExecuteNonQuery();
                retorno = (int)cmm.Parameters["@Retorno"].Value;
                if (retorno == -3)
                    throw new Exception("Error BD - Tabla Pronostico");
                if (retorno == -5)
                    throw new Exception("Error BD- Tabla Escriben.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
            return retorno;
        }
    }
}
