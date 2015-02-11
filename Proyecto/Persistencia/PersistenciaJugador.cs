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
                    usuario = (string)_oRead["Usuario"];
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

        public void ModificarJugador(Jugador unJug)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.MiConexion);
            SqlCommand oComando = new SqlCommand("ModificarJugador", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oUsuario = new SqlParameter("@Usuario", unJug.UsuLogueo);
            SqlParameter oCedula = new SqlParameter("@Cedula", unJug.Cedula);
            SqlParameter oContraseña = new SqlParameter("@Contraseña", unJug.Contraseña);
            SqlParameter oNombreCompleto = new SqlParameter("@NombreCompleto", unJug.NombreCompleto);
            SqlParameter oVerEstadisticas = new SqlParameter("@NombrePublico", unJug.NombrePublico);
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oUsuario);
            oComando.Parameters.Add(oCedula);
            oComando.Parameters.Add(oContraseña);
            oComando.Parameters.Add(oNombreCompleto);
            oComando.Parameters.Add(oVerEstadisticas);
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

        public Jugador BuscarJugador(string Cedula)
        {
            string _usuario, _contraseña, _nombreCompleto;
            String _nombrePublico;
            Jugador jug = null;

            SqlConnection _cnn = new SqlConnection(Conexion.MiConexion);
            SqlCommand _comando = new SqlCommand("BuscarJugador", _cnn);
            SqlParameter oCedula = new SqlParameter("@Cedula", Cedula);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.Add(oCedula);

            SqlDataReader _oRead;

            try
            {
                _cnn.Open();
                _oRead = _comando.ExecuteReader();
                if (_oRead.Read())
                {
                    _contraseña = (string)_oRead["Contraseña"];
                    _usuario = (string)_oRead["Usuario"];
                    _nombreCompleto = (string)_oRead["NombreCompleto"];
                    _nombrePublico = (string)_oRead["NombrePublico"];

                    jug = new Jugador(Cedula, _contraseña, _usuario, _nombreCompleto, _nombrePublico);
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
            return jug;
        }


        public void BajaJugador(Jugador unJug)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.MiConexion);
            SqlCommand oComando = new SqlCommand("BajaJugador", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oCedula = new SqlParameter("@Cedula", unJug.Cedula);
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oCedula);
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
