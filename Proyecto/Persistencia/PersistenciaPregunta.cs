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

            SqlParameter oTipo = new SqlParameter("@Tipo", unaPregunta.Tipo);
            SqlParameter oTextoPregunta = new SqlParameter("@TextoPregunta", unaPregunta.TextoPregunta);
            SqlParameter oTextoRespuesta1 = new SqlParameter("@TextoRespuesta1", unaPregunta.Respuestas[0].TextoRespuesta);
            SqlParameter oTextoRespuesta2 = new SqlParameter("@TextoRespuesta2", unaPregunta.Respuestas[1].TextoRespuesta);
            SqlParameter oTextoRespuesta3 = new SqlParameter("@TextoRespuesta3", unaPregunta.Respuestas[2].TextoRespuesta);
            SqlParameter oCorrecta1 = new SqlParameter("@Correcta1", unaPregunta.Respuestas[0].Correcta);
            SqlParameter oCorrecta2 = new SqlParameter("@Correcta2", unaPregunta.Respuestas[1].Correcta);
            SqlParameter oCorrecta3 = new SqlParameter("@Correcta3", unaPregunta.Respuestas[2].Correcta);


            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oTipo);
            oComando.Parameters.Add(oTextoPregunta);
            oComando.Parameters.Add(oTextoRespuesta1);
            oComando.Parameters.Add(oTextoRespuesta2);
            oComando.Parameters.Add(oTextoRespuesta3);
            oComando.Parameters.Add(oCorrecta1);
            oComando.Parameters.Add(oCorrecta2);
            oComando.Parameters.Add(oCorrecta3);
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


        public Pregunta BuscarPregunta(int IdPregunta)
        {
            string _textoPregunta, _tipo;
            Pregunta preg = null;
            List<Respuesta> _listaRespuestas =null;

            SqlConnection _cnn = new SqlConnection(Conexion.MiConexion);
            SqlCommand _comando = new SqlCommand("BuscarPregunta", _cnn);
            SqlParameter oIdPregunta = new SqlParameter("@IdPregunta", IdPregunta);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.Add(oIdPregunta);

            SqlDataReader _oRead;

            try
            {
                _cnn.Open();
                _oRead = _comando.ExecuteReader();
                if (_oRead.Read())
                {
                    _textoPregunta = (string)_oRead["Texto"];
                    _tipo = (string)_oRead["Tipo"];

                    _listaRespuestas = ListadoRespuestasPorPregunta(IdPregunta);
                    preg = new Pregunta(IdPregunta, _textoPregunta, _tipo, _listaRespuestas);
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
            return preg;
        }

        public void ModificarPregunta(Pregunta unaPregunta)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.MiConexion);
            SqlCommand oComando = new SqlCommand("ModificarPregunta", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oIdPregunta = new SqlParameter("@IdPregunta", unaPregunta.IdPregunta);
            SqlParameter oTipo = new SqlParameter("@Tipo", unaPregunta.Tipo);
            SqlParameter oTextoPregunta = new SqlParameter("@TextoPregunta", unaPregunta.TextoPregunta);
            SqlParameter oTextoRespuesta1 = new SqlParameter("@TextoRespuesta1", unaPregunta.Respuestas[0].TextoRespuesta);
            SqlParameter oTextoRespuesta2 = new SqlParameter("@TextoRespuesta2", unaPregunta.Respuestas[1].TextoRespuesta);
            SqlParameter oTextoRespuesta3 = new SqlParameter("@TextoRespuesta3", unaPregunta.Respuestas[2].TextoRespuesta);
            SqlParameter oCorrecta1 = new SqlParameter("@Correcta1", unaPregunta.Respuestas[0].Correcta);
            SqlParameter oCorrecta2 = new SqlParameter("@Correcta2", unaPregunta.Respuestas[1].Correcta);
            SqlParameter oCorrecta3 = new SqlParameter("@Correcta3", unaPregunta.Respuestas[2].Correcta);


            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oIdPregunta);
            oComando.Parameters.Add(oTipo);
            oComando.Parameters.Add(oTextoPregunta);
            oComando.Parameters.Add(oTextoRespuesta1);
            oComando.Parameters.Add(oTextoRespuesta2);
            oComando.Parameters.Add(oTextoRespuesta3);
            oComando.Parameters.Add(oCorrecta1);
            oComando.Parameters.Add(oCorrecta2);
            oComando.Parameters.Add(oCorrecta3);
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




        public List<Respuesta> ListadoRespuestasPorPregunta(int idPregunta)
        {
             int _idRespuesta;
         string _textoRespuesta;
         bool _correcta;
         Respuesta resp = null;
            List<Respuesta> _lista = new List<Respuesta>();

            SqlConnection _cnn = new SqlConnection(Conexion.MiConexion);
            SqlCommand _comando = new SqlCommand("ListadoRespuestasPorPregunta", _cnn);
            SqlParameter _idPregunta = new SqlParameter("@IdPregunta", idPregunta);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.Add(_idPregunta);
            SqlDataReader _oRead;


            try
            {
                _cnn.Open();
                _oRead = _comando.ExecuteReader();
                if (_oRead.HasRows)
                {
                    while (_oRead.Read())
                    {

                        _idRespuesta = (int)_oRead["IdRespuesta"];
                        _textoRespuesta =(string)_oRead["Texto"];
                        _correcta = (bool)_oRead["Correcto"];

                        resp = new Respuesta(_idRespuesta, _textoRespuesta, _correcta);
                        _lista.Add(resp);
                    }
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
            return _lista;
        }


    }
}
