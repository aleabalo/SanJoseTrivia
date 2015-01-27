using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaJugador : ILogicaJugador
    {
        //Singleton
        private static LogicaJugador _instancia = null;

        private LogicaJugador() { }


        public static LogicaJugador GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaJugador();
            return _instancia;
        }

        public void AgregarJugador(Jugador j)
        {
            IPersistenciaJugador FJugador = FabricaPersistencia.getPersistenciaJugador();
            FJugador.AgregarJugador(j);
        }
    }
}
