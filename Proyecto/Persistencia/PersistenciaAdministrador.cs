using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;

namespace Persistencia
{
    internal class PersistenciaAdministrador : IPersistenciaAdministrador
    {
        //Singleton
        private static PersistenciaAdministrador _instancia = null; 

        private PersistenciaAdministrador() {} 

        public static PersistenciaAdministrador GetInstancia()  
        {
            if (_instancia == null) 
                _instancia = new PersistenciaAdministrador(); 
            return _instancia; 
        }


        public void AgregarAdministrador(Administrador unAdmin)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.MiConexion);
            SqlCommand oComando = new SqlCommand("AltaAdmin", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oUsuario = new SqlParameter("@Usuario", unAdmin.UsuLogueo);
            SqlParameter oCedula = new SqlParameter("@Cedula", unAdmin.Cedula);
            SqlParameter oContraseña = new SqlParameter("@Contraseña", unAdmin.Contraseña);
            SqlParameter oNombreCompleto = new SqlParameter("@NombreCompleto", unAdmin.NombreCompleto);
            SqlParameter oVerEstadisticas = new SqlParameter("@VerEstadisticas", unAdmin.Estadistica);
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


        public void BajaAdministrador(Administrador unAdmin)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.MiConexion);
            SqlCommand oComando = new SqlCommand("BajaAdmin", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oCedula = new SqlParameter("@Cedula", unAdmin.Cedula);
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

        public Administrador BuscarAdministrador(string Cedula)
        {
            string _usuario, _contraseña, _nombreCompleto;
            bool _verEstadisticas;
            Administrador adm = null;

            SqlConnection _cnn = new SqlConnection(Conexion.MiConexion);
            SqlCommand _comando = new SqlCommand("BuscarAdmin", _cnn);
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
                    _usuario = (string)_oRead["UsuLogueo"];
                    _nombreCompleto = (string)_oRead["NombreCompleto"];
                    _verEstadisticas = (bool)_oRead["Estadistica"];

                    adm = new Administrador(Cedula, _contraseña, _usuario, _nombreCompleto, _verEstadisticas);
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
            return adm;
        }


        public void ModificarAdministrador(Administrador unAdmin)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.MiConexion);
            SqlCommand oComando = new SqlCommand("ModificarAdmin", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oUsuario = new SqlParameter("@Usuario", unAdmin.UsuLogueo);
            SqlParameter oCedula = new SqlParameter("@Cedula", unAdmin.Cedula);
            SqlParameter oContraseña = new SqlParameter("@Contraseña", unAdmin.Contraseña);
            SqlParameter oNombreCompleto = new SqlParameter("@NombreCompleto", unAdmin.NombreCompleto);
            SqlParameter oVerEstadisticas = new SqlParameter("@VerEstadisticas", unAdmin.Estadistica);
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

    }
}
