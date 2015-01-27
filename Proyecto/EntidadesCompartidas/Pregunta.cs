using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    [Serializable]

    class Pregunta
    {
        //atributos
        private int _idPregunta;
        private string _textoPregunta;
        private string _tipo;
        private List<Respuesta> _respuestas;



        //atributos
        public int IdPregunta  
        {
            get { return _idPregunta; }
            set { _idPregunta = value; }
        }

        public string TextoPregunta
        {
            get { return _textoPregunta ; }
            set { _textoPregunta = value; }
        }

        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public List<Respuesta> Respuestas
        {
            get { return _respuestas; }
            set { _respuestas = value; }
        }
 

        //constructor
        public Pregunta(int oPregunta, string oTextoPregunta, string oTipo, List<Respuesta> oResp)
        {
            IdPregunta = oPregunta;
            TextoPregunta = oTextoPregunta;
            Tipo = oTipo;
            Respuestas = oResp;
        }

        public Pregunta()
        {
        }

    }
}
