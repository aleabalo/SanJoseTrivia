using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;

namespace Persistencia
{
    internal class PersistenciaJugador : IPersistenciaJugador
    {
        //Singleton
        private static PersistenciaJugador _instancia = null; 

        private PersistenciaJugador() {} 

        public static PersistenciaJugador GetInstancia()  
        {
            if (_instancia == null) 
                _instancia = new PersistenciaJugador(); 
            return _instancia; 
        }


        public void AgregarJugador(Jugador unJugador)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.MiConexion);
            SqlCommand oComando = new SqlCommand("AltaJugador", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oUsuario = new SqlParameter("@Usuario", unJugador.UsuLogueo);
            SqlParameter oCedula = new SqlParameter("@Cedula", unJugador.Cedula);
            SqlParameter oContraseña = new SqlParameter("@Contraseña", unJugador.Contraseña);
            SqlParameter oNombreCompleto = new SqlParameter("@NombreCompleto", unJugador.NombreCompleto);
            SqlParameter oNombrePublico = new SqlParameter("@NombrePublico", unJugador.NombrePublico);
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oUsuario);
            oComando.Parameters.Add(oCedula);
            oComando.Parameters.Add(oContraseña);
            oComando.Parameters.Add(oNombreCompleto);
            oComando.Parameters.Add(oNombrePublico);
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("La cedula ya existe");

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
          }


       
    }
}
