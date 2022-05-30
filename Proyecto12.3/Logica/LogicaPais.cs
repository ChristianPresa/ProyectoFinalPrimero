using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaPais
    {
        public static Pais BuscarPais(string CodPais)
        {
           return PresistenciaPais.BuscarPais(CodPais);
        }

        public static void AgregarPais(string CodPais, string NomPais)
        {
            PresistenciaPais.AgregarPais(CodPais,NomPais);
        }

        public static void EliminarPais(Pais pPais)
        {
            PresistenciaPais.EliminarPais(pPais);
        }

        public static void Modificar(string CodPais, string NomPais)
        {
            PresistenciaPais.ModificarPais(CodPais, NomPais);
        }
        public static List<Pais> ListarPais()
        {
            List<Pais> oAux = new List<Pais>();
            oAux.AddRange(PresistenciaPais.ListarPais());
            return oAux;
        }
    }
}
