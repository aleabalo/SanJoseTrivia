using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    [Serializable]

    public class Jugador : Usuario
    {
        //atributos
        private string _nombrePublico;

        //propiedades
        public string NombrePublico
        {
            get { return _nombrePublico; }
            set { _nombrePublico = value; }
        }

        //constructor
        public Jugador(string oCedula, string oContraseña, string oUsuLogueo, string oNombreCompleto, string oNombrePublico)
            :base(oCedula, oContraseña, oUsuLogueo, oNombreCompleto)
        {
            NombrePublico = oNombrePublico;
        }

        public Jugador()
        {
        }


    }
}
       