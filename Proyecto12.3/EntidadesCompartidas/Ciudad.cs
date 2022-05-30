using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Ciudad
    {
       // private string _CodPais;
        private string _NomCiudad;
        private string _CodCiudad;
        Pais _Pais;

        public string NomCiudad
        {
            get { return _NomCiudad; }
            set
            {
                if (value != "")
                    _NomCiudad = value;
                else
                    throw new Exception("Debe ingresar un nombre de ciudad ");
            }
        }
        //public string CodPais
        //{
        //    set
        //    {
        //        if (value.Length == 3)
        //            _CodPais = value;
        //        else
        //            throw new Exception("EL codigo debe contener 3 letras");
        //    }
        //    get { return _CodPais; }
        //}

        public string CodCiudad
        {
            set
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(value, "[A-Z]{3}"))
                    _CodCiudad = value;
                else
                    throw new Exception("EL codigo debe contener 3 letras");
            }
            get { return _CodCiudad; }
        }
        public Pais pPais
        {
            set
            {
                if (value == null)
                    throw new Exception("Debe ingresar un Pais");
                else
                    _Pais = value;
            }
            get { return _Pais; }
        }


        public Ciudad( string cCodCiudad, string nNomCiudad,Pais cPais)
        {
            CodCiudad = cCodCiudad;   
            NomCiudad = nNomCiudad;
            pPais = cPais;
        }


        public override string ToString()
        {
            return ("Codigo de ciudad: " + CodCiudad + "\n" + "Codigo Pais: " + pPais + "\n " + "nombre ciudad: " + NomCiudad);
        }
    }
}
