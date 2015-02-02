using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaJugador
    {
        void AgregarJugador(Jugador unJugador);
        Jugador LoginJugador(string Usuario, string Contraseña);

    }
}
