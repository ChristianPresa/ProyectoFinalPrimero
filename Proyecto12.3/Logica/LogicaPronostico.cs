using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;


namespace Logica
{
   public class LogicaPronostico
    {
       public static List<Pronostico> ListarPronostico()
       {
           return PersistenciaPronostico.ListarPronosticoDiario();
       }
       public static List<Pronostico> ListarPronosticoFecha(DateTime Fecha)
       {
           return PersistenciaPronostico.ListarPronosticoFecha(Fecha);
       }

       public static void AgregarPronostico(Pronostico Pro)
       {
           PersistenciaPronostico.AgregarPronostico(Pro);
       }

       public static List<Pronostico> ListarPronosticoPorCiudad(string CodPais, string CodCiudad)
       {
           return PersistenciaPronostico.ListarPronosticoPorCiudad(CodPais, CodCiudad);
       }

       //public static List<Pronostico> EstadoCielo()
       //{
           //return PersistenciaPronostico.EstadoCielo();
       //}
    }
}
