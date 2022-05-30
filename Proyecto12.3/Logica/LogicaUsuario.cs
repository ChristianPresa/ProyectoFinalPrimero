using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaUsuario
    {
        public static Usuario Logueo(string NomLog, string Contraseña)
        {
            Usuario unUsu = null;
            unUsu = PersistenciaUsuario.Logueo(NomLog, Contraseña);
            return unUsu;
        }
        public static Usuario BuscarUsuarios(string NomLog)
        {
            return PersistenciaUsuario.BuscarUsuarios(NomLog);
        }
        public static void AgregarUsuario(Usuario Usuario)
        {
            PersistenciaUsuario.AgregarUsuario(Usuario);
        }
        public static void Eliminar(string NomLog)
        {
            PersistenciaUsuario.EliminarUsuario(NomLog);
        }
        public static void Modificar(Usuario Usuario)
        {
            PersistenciaUsuario.ModificarUsuario(Usuario);
        }
        
    }
}
