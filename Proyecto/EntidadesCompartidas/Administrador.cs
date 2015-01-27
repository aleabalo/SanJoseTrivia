using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    [Serializable]

    public class Administrador : Usuario
    {
        //atributos
        private bool _estadistica;

        //propiedades
        public bool Estadistica
        {
            get { return _estadistica ; }
            set { _estadistica = value; }
        }

        //constructor
        public Administrador(string oCedula, string oContraseña, string oUsuLogueo, string oNombreCompleto, bool oEstadistica)
            :base(oCedula, oContraseña, oUsuLogueo, oNombreCompleto)
        {
            Estadistica = oEstadistica;
        }

        public Administrador()
        {
        }
    }
}
