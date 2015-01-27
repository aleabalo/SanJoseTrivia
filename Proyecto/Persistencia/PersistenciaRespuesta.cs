using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;

namespace Persistencia
{
    internal class PersistenciaRespuesta : IPersistenciaRespuesta
    {
        //Singleton
        private static PersistenciaRespuesta _instancia = null; 

        private PersistenciaRespuesta() {} 

        public static PersistenciaRespuesta GetInstancia()  
        {
            if (_instancia == null) 
                _instancia = new PersistenciaRespuesta(); 
            return _instancia; 
        }


    }
}
