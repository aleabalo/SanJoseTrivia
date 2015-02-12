using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaPregunta : ILogicaPregunta
    {
        //Singleton
        private static LogicaPregunta _instancia = null;

        private LogicaPregunta() { }


        public static LogicaPregunta GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaPregunta();
            return _instancia;
        }

        public Pregunta BuscarPregunta(int IdPregunta)
        {
            IPersistenciaPregunta FPregunta = FabricaPersistencia.getPersistenciaPregunta();
            Pregunta p = FPregunta.BuscarPregunta(IdPregunta);
            return p;
        }

        public void AgregarPregunta(Pregunta p)
        {
            IPersistenciaPregunta FPregunta = FabricaPersistencia.getPersistenciaPregunta();
            FPregunta.AgregarPregunta(p);
           
        }

        public void BajaPregunta(Pregunta p)
        {
            IPersistenciaPregunta FPreg = FabricaPersistencia.getPersistenciaPregunta();
            FPreg.BajaPregunta(p);
        }

        public void ModificarPregunta(Pregunta p)
        {
            IPersistenciaPregunta FPregunta = FabricaPersistencia.getPersistenciaPregunta();
            FPregunta.ModificarPregunta(p);

        }
    }
}
