using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    [Serializable]

    public class Respuesta
    {
        //atributos
        private int _id;
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

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        //constructor
        public Respuesta(int oId, string oTextoRespuesta, bool oCorrecta)
        {
            Id = oId;
            TextoRespuesta = oTextoRespuesta;
            Correcta = oCorrecta;
        }


    }
}
