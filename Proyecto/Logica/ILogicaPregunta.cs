using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public interface ILogicaPregunta
    {
        Pregunta BuscarPregunta(int IdPregunta);
        void AgregarPregunta(Pregunta p);
        void BajaPregunta(Pregunta p);
        void ModificarPregunta(Pregunta p);
       
    }
}
