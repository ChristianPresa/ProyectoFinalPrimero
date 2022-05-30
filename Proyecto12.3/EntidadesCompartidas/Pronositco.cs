using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EntidadesCompartidas
{
    public class Pronostico
    {
        private int _Probabilidad;
        private string _TipoCielo;
        private int _VelocidadViento;
        private int _CodPronostico;
        private DateTime _Fecha;
       // private DateTime _Hora;
        //
        private string _Hora;
        //
        private int _TempMax;
        private int _TempMin;
        Ciudad _Ciudad;
        //lo que faltaba
        Usuario _Usuario;

        public int Probabilidad
        {
            get { return _Probabilidad; }
            set
            {
                if (value >= 0)
                    _Probabilidad = value;
                else
                    throw new Exception("No hay probalilidad");
            }
        }
        public string TipoCielo
        {
            get { return _TipoCielo; }
            set
            {
              //  if (value == "nuboso" ||"despejado" ||"parcialmente nuboso")
            _TipoCielo = value;
            }
        }
        public int VelocidadViento
        {
            get { return _VelocidadViento; }
            set
            {
                if (value >= 0)
                    _VelocidadViento = value;
                else
                    throw new Exception("Debe velocidad del viento.");
            }
        }
        public int CodPronostico
        {
            set { _CodPronostico = value; }
            get { return _CodPronostico; }
        }
        public int TempMax
        {
            get { return _TempMax; }
            set {_TempMax = value; }
        }
        public int TempMin
        {
            get { return _TempMin; }
            set{ _TempMin = value;}
        }

        public DateTime Fecha
        {
            set { _Fecha = value; }
            get { return _Fecha; }
        }

        public string Hora
        {
            get { return _Hora; }
            set
            {
                if (!Regex.IsMatch(value, "^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$"))
                {
                    throw new Exception("El formato de la hora no es Valido");
                }
                _Hora = value;
            }

        }
        public Ciudad Ciudad
        {
            set
            {
                if (value == null)
                    throw new Exception("Debe ingresar una ciudad");
                else
                    _Ciudad = value;  
            }
            get { return _Ciudad; }
        }

        public Usuario Usuario
        {
            set
            {
                if (value == null)
                    throw new Exception("Debe contener un Usuario");
                else
                    _Usuario = value;
            }
            get { return _Usuario; }
        }

        
        public Pronostico(int pProbabilidad, string tTipodecielo, int vVelocidadVinento, DateTime fFecha, string hHora, int tTempMin, int tTempMax, int cCodPronostico,Ciudad cCiudad,Usuario uUsuario)
        {
            Probabilidad = pProbabilidad;
            TipoCielo = tTipodecielo;
            VelocidadViento = vVelocidadVinento;
            Fecha = fFecha;
            Hora = hHora;
            TempMax = tTempMax;
            TempMin = tTempMin;
            CodPronostico = cCodPronostico;
            Ciudad = cCiudad;
            Usuario = uUsuario;
        }


        public override string ToString()
        {
            return ("Codigo Pronostico: " + CodPronostico + "\n" + "Probabilidad: " + Probabilidad + "\n " + "Tipo de cielo: " + TipoCielo + "\n" + " Velocidad del Viento: " + VelocidadViento + "\n" + "Fecha: " + Fecha.ToString("d") + "\n" + "Hora: " + Hora + " \n " + "Temperatura Maxima " + TempMax + "\n" + "Temperatura Minima: " + TempMin + "\n" + "Ciudad: " + Ciudad + "\n" + "Usuario: " + Usuario);
        }
    }
}
