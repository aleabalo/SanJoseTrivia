using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public interface ILogicaAdministrador
    {
        void AgregarAdministrador(Administrador unAdmin);
        void BajaAdministrador(Administrador unAdmin);
        Administrador BuscarAdministrador(string Cedula);
        void ModificarAdministrador(Administrador unAdmin);
    }
}
