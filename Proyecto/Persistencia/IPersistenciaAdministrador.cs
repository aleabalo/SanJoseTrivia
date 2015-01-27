using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaAdministrador
    {
        void AgregarAdministrador(Administrador unAdmin);
        void BajaAdministrador(Administrador unAdmin);
        Administrador BuscarAdministrador(string Cedula);
        void ModificarAdministrador(Administrador unAdmin);
    }
}
