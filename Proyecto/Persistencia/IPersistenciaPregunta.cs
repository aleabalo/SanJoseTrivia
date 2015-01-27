using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaPregunta
    {
        void AgregarPregunta(Pregunta unaPregunta);
        void BajaPregunta(Pregunta unaPregunta);
        //Pregunta BuscarPregunta(int IdPregunta);
        void ModificarPregunta(Pregunta unaPregunta);
    }
}
