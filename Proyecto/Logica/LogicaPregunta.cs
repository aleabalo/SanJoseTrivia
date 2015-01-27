using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaPregunta : ILogicaPregunta
    {
        //Singleton
        private static LogicaPregunta _instancia = null;

        private LogicaPregunta() { }


        public static LogicaPregunta GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaPregunta();
            return _instancia;
        }


    }
}
