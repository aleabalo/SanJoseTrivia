using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    [Serializable]

    public class Correcta
    {
        //atributos
        private Pregunta _pregunta;
        private Boolean _contestadaCorrecta;

        public Pregunta Pregunta
        {
            get { return _pregunta; }
            set { _pregunta = value; }
        }

        public Boolean ContestadaCorrecta
        {
            get { return _contestadaCorrecta; }
            set { _contestadaCorrecta = value; }
        }

        public Correcta(Pregunta oPreg, Boolean oContestadaCorrecto)
        {
            Pregunta = oPreg;
            ContestadaCorrecta = oContestadaCorrecto;
        }



    }
}
