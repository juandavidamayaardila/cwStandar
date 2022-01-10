using co.com.CeluwebEstandarFV.BussinesObject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Ronda
/// Clase que permite iniciar el juego, tiene como propiedades
/// el nivel o categoria del juego y el jugador y el puntaje
/// 
/// tiene metodos de aumentarPuntaje, aumnetarCategoria
/// </summary>
namespace laCosmetiquera.App_Code
{

    public class Ronda
    {
        /**
         * Cadena de conexion para pasarla como parametro a 
         * la entidad encargada de registrar en BD
         */
        public string cadenaconexion = ConfigurationManager.ConnectionStrings["Conexion"].ToString();

        /**
         * Propiedad donde se almacena el puntaje del jugador
         */
        public int puntaje { get; set; }

        /**
         * Propiedad donde se almacena el 
         * nivel-categoria donde va el juego
         */
        public int categoria { get; set; }

        /**
         * Propiedad donde se almacena el nombre del jugador
         */
        public string jugador { get; set; }

        public Ronda()
        {

        }

        /**
         * Constructor para crear una ronda
         * 
         * @parametro Jugador - Nombre del jugador
         * @categoria - Categoria 1 para iniciar el juego
         * @puntaje - Puntaje con el que inicia el juego
         */
        public Ronda(string jugador, int categoria, int puntaje)
        {
            this.jugador = jugador;
            this.categoria = categoria;
            this.puntaje = puntaje;
        }


        /**
         * Metodo en cargado de aumentar la categoria o nivel
         * del juego, si y solo si la respuesta fue correcta
         */
        public int aumentarCategoria()
        {
            categoria = categoria + 1;
            return categoria;
        }

        /**
         * Metodo Encargado de calcular el puntaje
         * del jugador segun la categoria - nivel
         * que vaya
         * 
         * @return puntaje
         */
        public int aumentarPuntaje()
        {
            int categoriaTmp = 0;
            switch (categoria)
            {
                case 1:
                    categoriaTmp = 10;
                    break;
                case 2:
                    categoriaTmp = 30;
                    break;
                case 3:
                    categoriaTmp = 60;
                    break;
                case 4:
                    categoriaTmp = 100;
                    break;
                case 5:
                    categoriaTmp = 150;
                    break;

            }
            puntaje = categoriaTmp;
            return categoriaTmp;
        }


        /**
         * Metodo encargado de obtener las 
         * preguntas y respuestas de la base de datos, segun la catogoria o nivel 
         * 
         * @return Pregunta
         */
        public Pregunta obtenerPregunta()
        {
            Pregunta pre = new Pregunta();
            DatosBO datos = new DatosBO(cadenaconexion);
            return pre = datos.obtenerPreguntas(categoria.ToString());

        }


        /**
         * Metodo encargado de registrar el jugador 
         * cuando gane el juego
         * 
         * @return boolean 
         */
        public Boolean RegistrarGanador()
        {
            DatosBO datos = new DatosBO(cadenaconexion);
            datos.registrarResultado(jugador, puntaje);
            return true;
        }


        /**
         * Metodo encargador de validar si el jugador
         * a finalizdo el juego exitosamente 
         * 
         * @return boolean true / false
         */
        public bool validarGanador()
        {
            return categoria == 5 ? true : false;

        }

    }
}