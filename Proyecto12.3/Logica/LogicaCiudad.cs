using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaCiudad
    {

        public static List<Ciudad> ListarCiudad()
        {
            List<Ciudad> oAux = new List<Ciudad>();
            oAux.AddRange(PersistenciaCiudad.ListarCiudad());
            return oAux;    
        }
        public static List<Ciudad> ListarCiudadPorPais(string CodPais)
        {
            List<Ciudad> oAux = new List<Ciudad>();
            oAux.AddRange(PersistenciaCiudad.ListarCiudadPorPais(CodPais));
            return oAux;
        }

        public static Ciudad BuscarCiudad(string CodCiudad, string CodPais)
        {
            return PersistenciaCiudad.BuscarCiudad(CodCiudad, CodPais);
        }

        public static void AgregarCiudad(Ciudad Ciudad)
        {
            PersistenciaCiudad.AgregarCiudad(Ciudad);
        }

        public static void EliminarCiudad(Ciudad Ciudad)
        {
            PersistenciaCiudad.EliminarCiudad(Ciudad);
        }
        public static void ModificarCiudad(Ciudad Ciudad)
        {
            PersistenciaCiudad.ModificarCiudad(Ciudad);
        }
    }
}
