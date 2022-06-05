using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using EntidadesCompartidas;


namespace Persistencia
{
    public class PersistenciaUsuario
    {
        public static void AgregarUsuario(Usuario Usu)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("AltaUsuario", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NomLog", Usu.NomLog);
            cmd.Parameters.AddWithValue("@Contraseña", Usu.Password);
            cmd.Parameters.AddWithValue("@Nombre1", Usu.Nombre1);
            cmd.Parameters.AddWithValue("@Nombre2", Usu.Nombre2);
            cmd.Parameters.AddWithValue("@Apellido1", Usu.Apellido1);
            cmd.Parameters.AddWithValue("@Apellido2", Usu.Apellido2);

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
                    throw new Exception("El Usuario ya existe");
               
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

        public static void ModificarUsuario(Usuario Usu)
        {

            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("ModificarUsuario", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NomLog", Usu.NomLog);
            cmd.Parameters.AddWithValue("@Contraseña", Usu.Password);
            cmd.Parameters.AddWithValue("@Nombre1", Usu.Nombre1);
            cmd.Parameters.AddWithValue("@Nombre2", Usu.Nombre2);
            cmd.Parameters.AddWithValue("@Apellido1", Usu.Apellido1);
            cmd.Parameters.AddWithValue("@Apellido2", Usu.Apellido2);

            SqlParameter Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            Retorno.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(Retorno);

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();

                int oAfectados = (int)cmd.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("No se pudo modificar el usuario porque no existe");
              
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

        public static void EliminarUsuario(Usuario uUsuario)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmm = new SqlCommand("EliminarUsuario", _cnn);
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.Parameters.AddWithValue("@NomLog", uUsuario.NomLog);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            cmm.Parameters.Add(oRetorno);

            try
            {
                _cnn.Open();
                cmm.ExecuteNonQuery();

                int oAfectados = (int)cmm.Parameters["@Retorno"].Value;
                if (oAfectados == -2)
                    throw new Exception("El Usuario no se puede eiminar porque no Existe");
                else if (oAfectados == -1)
                    throw new Exception("El Usuario no se puede eliminar porque tiene una Noticia asociada");
               
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

        public static Usuario Logueo(string NomLog, string Contraseña)
        {

            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("Logueo", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NomLog", NomLog);
            cmd.Parameters.AddWithValue("@Contraseña", Contraseña);

            string nNomLog, pPassword, nNombre1, nNombre2, aApellido1, aApellido2;
            Usuario Usu = null;
            try
            {
                cnn.Open();
                SqlDataReader _lector = cmd.ExecuteReader();
                if (_lector.Read())
                {         
                     nNomLog = (string)_lector["NomLog"];
                     pPassword = (string)_lector["Contraseña"];
                     nNombre1 = (string)_lector["Nombre1"];
                     nNombre2 = (string)_lector["Nombre2"];
                     aApellido1 = (string)_lector["Apellido1"];
                     aApellido2 = (string)_lector["Apellido2"];
                     Usu = new Usuario(nNomLog, pPassword, nNombre1, nNombre2, aApellido1, aApellido2);
                }
                _lector.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
            return Usu;
        }

         public static Usuario BuscarUsr(string NomLog,string Contraseña )//string Pass)
        {

            SqlConnection cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand cmd = new SqlCommand("BuscarUsuario", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NomLog", NomLog);
            cmd.Parameters.AddWithValue("@Contraseña", Contraseña);

            
           
            string uUsuario, cContraseña, nNombre1, nNombre2, aApellido1, aApellido2;
            Usuario Usuario = null ;

            SqlDataReader oReader;

            try
            {
                cnn.Open();
                oReader = cmd.ExecuteReader();
                while (oReader.Read())
                {
                    uUsuario = (string)oReader["NomLog"];
                    cContraseña = (string)oReader["Contraseña"];
                    nNombre1 = (string)oReader["Nombre1"];
                    nNombre2 = (string)oReader["Nombre2"];
                    aApellido1 = (string)oReader["Apellido1"];
                    aApellido2 = (string)oReader["Apellido2"];

                    Usuario = new Usuario(uUsuario, cContraseña, nNombre1,nNombre2,aApellido1,aApellido2);
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
            return Usuario;
        }

         public static Usuario BuscarUsuarios(string NomLog)
         {

             SqlConnection cnn = new SqlConnection(Conexion.Cnn);
             SqlCommand cmd = new SqlCommand("BuscarUsuarios", cnn);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@NomLog", NomLog);

             string nNomLog, pPassword, nNombre1, nNombre2, aApellido1, aApellido2;
             Usuario Usu = null;

             try
             {
                 cnn.Open();
                 SqlDataReader _lector = cmd.ExecuteReader();
                 if (_lector.Read())
                 {

                     nNomLog = (string)_lector["NomLog"];
                     pPassword = (string)_lector["Contraseña"];
                     nNombre1 = (string)_lector["Nombre1"];
                     nNombre2 = (string)_lector["Nombre2"];
                     aApellido1 = (string)_lector["Apellido1"];
                     aApellido2 = (string)_lector["Apellido2"];
                     
                     Usu = new Usuario(nNomLog, pPassword, nNombre1, nNombre2, aApellido1, aApellido2);
                 }
                 _lector.Close();
             }
             catch (Exception ex)
             {
                 throw ex;
             }
             finally
             {
                 cnn.Close();
             }
             return Usu;
         }

    }
}
