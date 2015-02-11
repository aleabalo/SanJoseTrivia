using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    [Serializable]

   public class Usuario
    {
        //atributos
        private string _cedula;
        private string _contraseña;
        private string _usuLogueo;
        private string _nombreCompleto;

        //propiedades
        public string Cedula
        {
            get { return _cedula; }
            set {
                 _cedula = value; 
            }
        }

        public string Contraseña
        {
            get { return _contraseña; }
            set { _contraseña = value; }
        }

        public string UsuLogueo
        {
            get { return _usuLogueo; }
            set { _usuLogueo = value; }
        }

        public string NombreCompleto
        {
            get { return _nombreCompleto; }
            set { _nombreCompleto = value; }
        }

        //constructor
        public Usuario(string oCedula, string oContraseña, string oUsuLogueo, string oNombreCompleto)
        {
            Cedula = oCedula;
            Contraseña = oContraseña;
            UsuLogueo = oUsuLogueo;
            NombreCompleto = oNombreCompleto;
        }

        public Usuario()
        {
        }


        

    }
}
