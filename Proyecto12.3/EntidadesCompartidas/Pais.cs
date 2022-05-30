using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Pais
    {
        private string _CodPais;
        private string _NomPais;  
        
        public string CodPais
        {  
            get { return _CodPais; }
            set
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(value, "[A-Z]{3}"))
                    _CodPais = value;
                else
                    throw new Exception("Debe ingresar un codigo de pais de tres letras ");
            }
        }
        public string NomPais
        {
            get { return _NomPais; }
            set
            {
                if (value != "")
                    _NomPais = value;
                else
                    throw new Exception("Debe ingresar un nombre de pais ");
            }    

        }
        public Pais(string cCodPais, string nNomPais)
        {
            CodPais = cCodPais;
            NomPais = nNomPais;
        }

        public override string ToString()
        {
            return ("Codigo Pais: " + CodPais + "\n" + "Nombre del Pais: " + NomPais);
        }
    }
}
