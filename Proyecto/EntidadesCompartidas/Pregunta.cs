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
        private Respuesta _resp;

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

        public Respuesta Resp
        {
            get { return _resp; }
            set { _resp = value; }
        }

        //constructor
        public Pregunta(int oPregunta, string oTextoPregunta, string oTipo, Respuesta oResp)
        {
            IdPregunta = oPregunta;
            TextoPregunta = oTextoPregunta;
            Tipo = oTipo;
            Resp = oResp;
        }

        public Pregunta()
        {
        }

    }
}
