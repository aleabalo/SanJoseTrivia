using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    [Serializable]

    class Respuesta
    {
        //atributos
        private string _textoRespuesta;
        private bool _correcta;

        //propiedades
        public string TextoRespuesta 
        {
            get { return _textoRespuesta ; }
            set { _textoRespuesta = value; }
        }

        public bool Correcta 
        {
            get { return _correcta; }
            set { _correcta = value; }
        }

        //constructor
        public Respuesta(string oTextoRespuesta, bool oCorrecta)
        {
            TextoRespuesta = oTextoRespuesta;
            Correcta = oCorrecta;
        }


    }
}
