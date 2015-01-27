using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class FabricaLogica
    {
        public static ILogicaUsuario getLogicaUsuario()
        {
            return (LogicaUsuario.GetInstancia());
        }

        public static ILogicaAdministrador getLogicaAdministrador()
        {
            return (LogicaAdministrador.GetInstancia());
        }

        public static ILogicaJugador getLogicaJugador()
        {
            return (LogicaJugador.GetInstancia());
        }

        public static ILogicaJuego getLogicaJuego()
        {
            return (LogicaJuego.GetInstancia());
        }

        public static ILogicaPregunta getLogicaPregunta()
        {
            return (LogicaPregunta.GetInstancia());
        }

        public static ILogicaRespuesta getLogicaRespuesta()
        {
            return (LogicaRespuesta.GetInstancia());
        }

    }
}
