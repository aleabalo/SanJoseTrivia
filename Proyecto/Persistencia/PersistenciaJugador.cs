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

        public Jugador LoginJugador(string Usuario, string Contraseña)
        {
            string cedula, contraseña, nombreCompleto, usuario, nombrePublico;
            Jugador j = null;

            SqlConnection _cnn = new SqlConnection(Conexion.MiConexion);
            SqlCommand _comando = new SqlCommand("LoginJugador", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;

            SqlParameter oUsuario = new SqlParameter("@Usuario", Usuario);
            SqlParameter oContraseña = new SqlParameter("@Contraseña", Contraseña);
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);

            _comando.Parameters.Add(oUsuario);
            _comando.Parameters.Add(oContraseña);


            SqlDataReader _oRead;

            try
            {
                _cnn.Open();
                _oRead = _comando.ExecuteReader();
                if (_oRead.Read())
                {
                    cedula = (string)_oRead["Cedula"];
                    contraseña = (string)_oRead["Contraseña"];
                    usuario = (string)_oRead["UsuLogueo"];
                    nombreCompleto = (string)_oRead["NombreCompleto"];
                    nombrePublico = (string)_oRead["NombrePublico"];
                    j = new Jugador(cedula, contraseña, usuario, nombreCompleto, nombrePublico);
                    _oRead.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _cnn.Close();
            }
            return j;
        }


       
    }
}
