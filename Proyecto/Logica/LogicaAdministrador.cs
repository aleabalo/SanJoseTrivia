using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaAdministrador : ILogicaAdministrador
    {
        //Singleton
        private static LogicaAdministrador _instancia = null;

        private LogicaAdministrador() { }


        public static LogicaAdministrador GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaAdministrador();
            return _instancia;
        }

        public void AgregarAdministrador(Administrador a)
        {
            IPersistenciaAdministrador FAdmin = FabricaPersistencia.getPersistenciaAdministrador();
            FAdmin.AgregarAdministrador(a);
        }

        public void BajaAdministrador(Administrador a)
        {
            IPersistenciaAdministrador FAdmin = FabricaPersistencia.getPersistenciaAdministrador();
            FAdmin.BajaAdministrador(a);
        }

        public Administrador BuscarAdministrador(string Cedula)
        {
            IPersistenciaAdministrador FAdmin = FabricaPersistencia.getPersistenciaAdministrador();
            Administrador a = FAdmin.BuscarAdministrador(Cedula);
            return a;
        }

        public void ModificarAdministrador(Administrador a)
        {
            IPersistenciaAdministrador FAdmin = FabricaPersistencia.getPersistenciaAdministrador();
            FAdmin.ModificarAdministrador(a);
        }
            

    }
}
