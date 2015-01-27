using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaJuego : ILogicaJuego
    {
        //Singleton
        private static LogicaJuego _instancia = null;

        private LogicaJuego() { }


        public static LogicaJuego GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaJuego();
            return _instancia;
        }


    }
}
