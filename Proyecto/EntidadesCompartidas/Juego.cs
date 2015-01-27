using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    [Serializable]

    class Juego
    {
        //atributos
        private int _idJuego;
        private int _tiradas;
        private DateTime _fechaInicio;
        private DateTime _fechaFin;
        private List<Jugador> _lista;
        private Pregunta _preg;


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

        public List<Jugador> Lista
        {
            get { return _lista; }
            set { _lista = value; }
        }

        public Pregunta Preg
        {
            get { return _preg; }
            set { _preg = value; }
        }

        //constructor
        public Juego(int oIdJuego, int oTiradas, DateTime oFechaInicio, DateTime oFechaFin, List<Jugador> oLista, Pregunta oPreg)
        {
            Id = oIdJuego;
            Tiradas = oTiradas;
            FechaInicio = oFechaInicio;
            FechaFin = oFechaFin;
            Lista = oLista;
            Preg = oPreg;
        }

        public Juego()
        {
        }
           

    }
}
