using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;

namespace Persistencia
{
    internal class PersistenciaJuego : IPersistenciaJuego
    {
        //Singleton
        private static PersistenciaJuego _instancia = null; 

        private PersistenciaJuego() {} 

        public static PersistenciaJuego GetInstancia()  
        {
            if (_instancia == null) 
                _instancia = new PersistenciaJuego(); 
            return _instancia; 
        }


    }
}
