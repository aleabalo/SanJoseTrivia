using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;

namespace Persistencia
{
    internal class PersistenciaPregunta : IPersistenciaPregunta
    {
        //Singleton
        private static PersistenciaPregunta _instancia = null; 

        private PersistenciaPregunta() {} 

        public static PersistenciaPregunta GetInstancia()  
        {
            if (_instancia == null) 
                _instancia = new PersistenciaPregunta(); 
            return _instancia; 
        }


        public void AgregarPregunta(Pregunta unaPregunta)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.MiConexion);
            SqlCommand oComando = new SqlCommand("AltaPregunta", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oIdPregunta = new SqlParameter("@IdPregunta", unaPregunta.IdPregunta);
            SqlParameter oTipo = new SqlParameter("@Tipo", unaPregunta.Tipo);
            SqlParameter oTexto = new SqlParameter("@Texto", unaPregunta.TextoPregunta);
            //SqlParameter oRespuestas = new SqlParameter("@", unaPregunta.Respuestas);
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oIdPregunta);
            oComando.Parameters.Add(oTipo);
            oComando.Parameters.Add(oTexto);
            //oComando.Parameters.Add(oRespuestas);
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("Error");

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


        public void BajaPregunta(Pregunta unaPregunta)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.MiConexion);
            SqlCommand oComando = new SqlCommand("BajaPregunta", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oIdPregunta = new SqlParameter("@IdPregunta", unaPregunta.IdPregunta);
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oIdPregunta);
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("El IdPregunta no existe");
                if (oAfectados == -2)
                    throw new Exception("Error en la Transaccion");

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


        //public Pregunta BuscarPregunta(int IdPregunta)
        //{
        //    string _textoPregunta, _tipo;
        //    Pregunta preg = null;

        //    SqlConnection _cnn = new SqlConnection(Conexion.MiConexion);
        //    SqlCommand _comando = new SqlCommand("BuscarPregunta", _cnn);
        //    SqlParameter oIdPregunta = new SqlParameter("@IdPregunta", IdPregunta);
        //    _comando.CommandType = CommandType.StoredProcedure;
        //    _comando.Parameters.Add(oIdPregunta);

        //    SqlDataReader _oRead;

        //    try
        //    {
        //        _cnn.Open();
        //        _oRead = _comando.ExecuteReader();
        //        if (_oRead.Read())
        //        {
        //            _textoPregunta = (string)_oRead["TextoPregunta"];
        //            _tipo = (string)_oRead["Tipo"];

        //            preg = new Pregunta(IdPregunta, _textoPregunta, _tipo,
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        _cnn.Close();
        //    }
        //    return preg;
        //}

        public void ModificarPregunta(Pregunta unaPregunta)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.MiConexion);
            SqlCommand oComando = new SqlCommand("ModificarPregunta", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oIdPregunta = new SqlParameter("@IdPregunta", unaPregunta.IdPregunta);
            SqlParameter oTipo = new SqlParameter("@Tipo", unaPregunta.Tipo);
            SqlParameter oTexto = new SqlParameter("@Texto", unaPregunta.TextoPregunta);
            //SqlParameter oRespuestas = new SqlParameter("@", unaPregunta.Respuestas);
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oIdPregunta);
            oComando.Parameters.Add(oTipo);
            oComando.Parameters.Add(oTexto);
            //oComando.Parameters.Add(oRespuestas);
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("Error");

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
