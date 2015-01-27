using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public class FabricaPersistencia
    {
        public static IPersistenciaUsuario getPersistenciaUsuario()
        {
            return (PersistenciaUsuario.GetInstancia());
        }

        public static IPersistenciaJugador getPersistenciaJugador()
        {
            return (PersistenciaJugador.GetInstancia());
        }

        public static IPersistenciaAdministrador getPersistenciaAdministrador()
        {
            return (PersistenciaAdministrador.GetInstancia());
        }

        public static IPersistenciaJuego getPersistenciaJuego()
        {
            return (PersistenciaJuego.GetInstancia());
        }

        public static IPersistenciaPregunta getPersistenciaPregunta()
        {
            return (PersistenciaPregunta.GetInstancia());
        }

        public static IPersistenciaRespuesta getPersistenciaRespuesta()
        {
            return (PersistenciaRespuesta.GetInstancia());
        }



    }
}
