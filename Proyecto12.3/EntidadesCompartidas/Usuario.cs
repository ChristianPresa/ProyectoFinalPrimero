using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Usuario
    {
        private string _NomLog;
        private string _Password;
        private string _Nombre1;
        private string _Nombre2;
        private string _Apellido1;
        private string _Apellido2;

        public string NomLog
        {
            get { return _NomLog; }
            set
            {
                if (value != "")
                    _NomLog = value;
                else
                    throw new Exception("Debe ingresar un nombre de usuario");
            }
        }
        public string Password
        {
            get { return _Password; }
            set
            {
                if (value != "")
                    _Password = value;
                else
                    throw new Exception("Debe ingresar una Contraseña");
            }
        }
        public string Nombre1
        {
            get { return _Nombre1; }
            set
            {
                if (value != "")
                    _Nombre1 = value;
                else
                    throw new Exception("Debe ingresar un primer Nombre");
            }
        }
        
        public string Apellido1
        {
            get { return _Apellido1; }
            set
            {
                if (value != "")
                    _Apellido1 = value;
                else
                    throw new Exception("Debe ingresar un primer Apellido");
            }
        }

        public string Nombre2
        {
            get { return _Nombre2; }
            set { _Nombre2 = value; }
        }

        public string Apellido2
        {
            get { return _Apellido2; }
            set { _Apellido2 = value; }
        }

        public Usuario(string nNomLog, string pPassword, string nNombre1, string nNombre2, string aApelido1, string aApellido2)
        {
            NomLog = nNomLog;
            Password = pPassword;
            Nombre1 = nNombre1;
            Nombre2 = nNombre2;
            Apellido1 = aApelido1;
            Apellido2 = aApellido2;
        }

        public override string ToString()
        {
            return ("Nombre Logueo: " + NomLog + " Nombre completo: " + Nombre1 + " " + Apellido1);
        }
    }
}
