using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaRespuesta : ILogicaRespuesta
    {
        //Singleton
        private static LogicaRespuesta _instancia = null;

        private LogicaRespuesta() { }


        public static LogicaRespuesta GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaRespuesta();
            return _instancia;
        }


    }
}
