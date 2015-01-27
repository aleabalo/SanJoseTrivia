using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaUsuario : ILogicaUsuario
    {
        //Singleton
        private static LogicaUsuario _instancia = null;

        private LogicaUsuario() { }


        public static LogicaUsuario GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaUsuario();
            return _instancia;
        }


    }
}
