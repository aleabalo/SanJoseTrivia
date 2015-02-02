﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public interface ILogicaJugador
    {
        void AgregarJugador(Jugador j);
        Jugador LoginJugador(string Usuario, string Contraseña);
    }
}
