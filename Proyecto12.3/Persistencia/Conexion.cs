using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistencia
{
    public class Conexion
    {

        private static string _cnn = "Data Source=.;Initial Catalog=Pronostico;Integrated Security=True";
      //private static string _cnn = "Data Source=.;Initial Catalog=Pronostico;Integrated Security=True";
        public static string Cnn
        {
            get { return _cnn; }
        }
    }
}
