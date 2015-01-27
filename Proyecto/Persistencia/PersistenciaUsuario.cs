using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;

namespace Persistencia
{
    internal class PersistenciaUsuario : IPersistenciaUsuario
    {
        //Singleton
        private static PersistenciaUsuario _instancia = null; 

        private PersistenciaUsuario() {} 

        public static PersistenciaUsuario GetInstancia()  
        {
            if (_instancia == null) 
                _instancia = new PersistenciaUsuario(); 
            return _instancia; 
        }


    }
}
