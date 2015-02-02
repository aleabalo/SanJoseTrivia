using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    [Serializable]

    public class Juego
    {
        //atributos
        private int _idJuego;
        private int _tiradas;
        private DateTime _fechaInicio;
        private DateTime _fechaFin;
        private Jugador _jugador;
        private List<Pregunta> _preguntas;




        //propiedades
        public int Id 
        {
            get { return _idJuego ; }
            set { _idJuego = value; }
        }

        public int Tiradas
        {
            get { return _tiradas ; }
            set { _tiradas = value; }
        }

        public DateTime FechaInicio
        {
            get { return _fechaInicio; }
            set { _fechaInicio = value; }
        }

        public DateTime FechaFin
        {
            get { return _fechaFin; }
            set { _fechaFin = value; }
        }

        public Jugador Jugador
        {
            get { return _jugador; }
            set { _jugador = value; }
        }

        public List<Pregunta> Preguntas
        {
            get { return _preguntas; }
            set { _preguntas = value; }
        }



        //constructor
        public Juego(int oIdJuego, int oTiradas, DateTime oFechaInicio, DateTime oFechaFin, Jugador oJugador, List<Pregunta> oPreguntas)
        {
            Id = oIdJuego;
            Tiradas = oTiradas;
            FechaInicio = oFechaInicio;
            FechaFin = oFechaFin;
            Jugador = oJugador;
            Preguntas = oPreguntas;
        }

        public Juego()
        {
        }
           

    }


}
