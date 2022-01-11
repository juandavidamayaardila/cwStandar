using co.com.CeluwebEstandarFV.BussinesObject;
using laCosmetiquera.App_Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Juagar_Jugar : System.Web.UI.Page
{
    string cadenaconexion;
    string respuesta;
    string jugador = "";
    Ronda ronda;
    protected void Page_Load(object sender, EventArgs e)
    {

        cadenaconexion = ConfigurationManager.ConnectionStrings["Conexion"].ToString();
        if (IsPostBack)
        {
            /**
             * Si la pagina se recarga por respuesta de eventos
             * se obtiene la istancia de la variable de session
             * para no perder la referencia
             */
            ronda = (Ronda)Session["ronda"];
        }
        else
        {
            /**
             * 
             * Si el juego se carga por primera vez o se recarga 
             * ingresa a registro de jugador
             */
            pnJugador.Visible = true;
            pnPreguntas.Visible = false;
        }

    }


    /**
     * Metodo que inici el juego
     * almacena la instancia de Ronda en la variable de session para no perder la referencia
     * obtiene la pregutna de la clase Ronda
     * obtiene un numero entre 1 -5 para varias la posicion de las respuestas
     * invoca al metodo publicar para mostrar las preguntas GUI
     */
    public void iniciarJuego()
    {

        ronda = new Ronda(jugador, 1, 0);
        Session["ronda"] = ronda;

        Pregunta pregunta = ronda.obtenerPregunta();
        Random aleatorio = new Random();
        int numero = aleatorio.Next(1, 5);

        publicarPreguntas(numero, pregunta);

    }


    /**
     * Metodo encargado de continuar con el juego
     * seguir con las preguntas del siguiente nivel
     * obtiene un numero entre 1 - 5 para varias la posicion de las respuesta en la GUI
     */
    public void ContinuarJuego()
    {

        Pregunta pregunta = ronda.obtenerPregunta();
        Random aleatorio = new Random();
        int numero = aleatorio.Next(1, 5);

        publicarPreguntas(numero, pregunta);
    }

    /**
     * Metodo encargado de publicar mostrar las preguntas y respuestas 
     * en la GUI 
     * Almacena la respuesta correcta en la variable de session 
     * para posterior comparar y determinar si continua en el juego
     * 
     */
    public void publicarPreguntas(int numero, Pregunta pregunta)
    {
        switch (numero)
        {
            case 1:
                lblPregunta.Text = pregunta._descripcion;
                lblRespuesta1.Text = pregunta._respuetaVerdadera;
                lblRespuesta2.Text = pregunta._respuestaFalsa1;
                lblRespuesta3.Text = pregunta._respuestaFalsa2;
                lblRespuesta4.Text = pregunta._respuestaFalsa3;

                Session["respuestaCorrecta"] = "A";
                break;

            case 2:
                lblPregunta.Text = pregunta._descripcion;
                lblRespuesta1.Text = pregunta._respuestaFalsa1;
                lblRespuesta2.Text = pregunta._respuetaVerdadera;
                lblRespuesta3.Text = pregunta._respuestaFalsa2;
                lblRespuesta4.Text = pregunta._respuestaFalsa3;

                Session["respuestaCorrecta"] = "B";
                break;

            case 3:
                lblPregunta.Text = pregunta._descripcion;
                lblRespuesta1.Text = pregunta._respuestaFalsa1;
                lblRespuesta2.Text = pregunta._respuestaFalsa2;
                lblRespuesta3.Text = pregunta._respuetaVerdadera;
                lblRespuesta4.Text = pregunta._respuestaFalsa3;

                Session["respuestaCorrecta"] = "C";
                break;

            case 4:
                lblPregunta.Text = pregunta._descripcion;
                lblRespuesta1.Text = pregunta._respuestaFalsa1;
                lblRespuesta2.Text = pregunta._respuestaFalsa2;
                lblRespuesta3.Text = pregunta._respuestaFalsa3;
                lblRespuesta4.Text = pregunta._respuetaVerdadera;

                Session["respuestaCorrecta"] = "D";
                break;
        }
    }

    /**
     * Evento del radio button lo selecciona
     * y almance en session la respuesta seleccionada
     * para compararla cuando confirme la respuesta
     */
    protected void rbA_CheckedChanged(object sender, EventArgs e)
    {

        rbB.Checked = false;
        rbC.Checked = false;
        rbD.Checked = false;

        Session["respuesta"] = "A";
    }


    /**
   * Evento del radio button lo selecciona
   * y almance en session la respuesta seleccionada
   * para compararla cuando confirme la respuesta
   */
    protected void rbB_CheckedChanged(object sender, EventArgs e)
    {
        rbA.Checked = false;
        rbC.Checked = false;
        rbD.Checked = false;

        Session["respuesta"] = "B";
    }

    /**
   * Evento del radio button lo selecciona
   * y almance en session la respuesta seleccionada
   * para compararla cuando confirme la respuesta
   */
    protected void rbC_CheckedChanged(object sender, EventArgs e)
    {

        rbA.Checked = false;
        rbB.Checked = false;
        rbD.Checked = false;

        Session["respuesta"] = "C";

    }

    /**
   * Evento del radio button lo selecciona
   * y almance en session la respuesta seleccionada
   * para compararla cuando confirme la respuesta
   */
    protected void rbD_CheckedChanged(object sender, EventArgs e)
    {
        rbA.Checked = false;
        rbB.Checked = false;
        rbC.Checked = false;

        Session["respuesta"] = "D";
    }

    /**
     * Evento del boton confirmar pregunta, determina si la respuesta es correcta
     * e invoca los metodos aumentarPuntaje, aumentarCategoria, limpiar y continuarJuego si la respuesta es correcta
     * invoca registrarGanador si ha finalizado el juego
     * 
     * muestra la informacion al usuario
     */
    protected void btnAceptar_Click(object sender, EventArgs e)
    {

        if (Session["respuesta"].ToString().Equals(Session["respuestaCorrecta"].ToString()))
        {
            if (ronda.validarGanador())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "swal('¡Felicidades!', '¡  " + jugador + " HAS GANADO EL JUEGO!', 'success')", true);
                lblPuntajeActual.Text = "Su puntaje es: 0";
                lblNivel.Text = "Nivel actual: 1";
                registrarGanador(1);

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "swal('¡Felicidades!', '¡ Respuesta Correcta!', 'success')", true);

                lblPuntajeActual.Text = "Su puntaje es: " + ronda.aumentarPuntaje().ToString();
                ronda.aumentarCategoria();
                lblNivel.Text = "Nivel actual: " + ronda.categoria;
                Limpiar();
                ContinuarJuego();
            }

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "swal('¡Error!', '¡Jugador Eliminado !', 'error')", true);
            lblPuntajeActual.Text = "";
            lblNivel.Text = "";
            registrarGanador(0);
            Limpiar();
            ReiniciarJuego();
        }
    }

    /**
     * Metodo encargado de limpiar 
     * la seleccion de las respuestas
     */
    private void Limpiar()
    {

        rbA.Checked = false;
        rbB.Checked = false;
        rbC.Checked = false;
        rbD.Checked = false;

    }

    /**
     * Metodo encargado de reiniciar el juego
     * y limpiar las variables y las etiquetas del GUI
     */
    private void ReiniciarJuego()
    {
        Limpiar();
        Session["categoria"] = "1";
        iniciarJuego();
        lblTitulo.Text = "VAMOS A JUGAR ";

        pnJugador.Visible = true;
        pnPreguntas.Visible = false;
    }

    /**
     * Evento del boton registrar jugador
     * muestra el nombre del jugador en la etiqueta
     * e inicia jugo 
     */
    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        DatosBO datos = new DatosBO(cadenaconexion);
        if (datos.validarPreguntas().Equals("OK"))
        {
            jugador = txtJugador.Text;
            lblTitulo.Text = "VAMOS A JUGAR: " + jugador;
            pnJugador.Visible = false;
            pnPreguntas.Visible = true;
            iniciarJuego();
            txtJugador.Text = "";
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "swal('¡Error!', '¡Por favor complete las preguntas antes de continuar !', 'error')", true);
        }

    }


    /**
     * Metodo encargado de invocar el metodo que registra el 
     * jugador en la BD de la clase Ronda
     * aumenta el puntaje si es ganado
     * y reinicia el juego
     * 
     * si es un jugador que ha perdido o se ha retirado
     * no aumenta el puntaje pero si registra
     *  
     *  @parametro opcion 1 ganador 0 perdedor o retiro Voluntario
     */
    private void registrarGanador(int opcion)
    {
        if (opcion == 1)
        {
            ronda.aumentarPuntaje();
            ronda.RegistrarGanador();
            gvDatos.DataBind();
            ReiniciarJuego();
        }
        else
        {
            ronda.RegistrarGanador();
            gvDatos.DataBind();
            ReiniciarJuego();
        }

    }

    /**
     * Evento del boton retiro voluntario
     * invoca registrar ganador
     * 
     * 1 si es ganador 0 si es retiro voluntario o perdedor
     */
    protected void btnRetiro_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "swal('¡Felicidades!', '¡ Jugador retirado voluntariamente su puntaje es " + ronda.puntaje.ToString() + "', 'success')", true);
        lblPuntajeActual.Text = "";
        lblNivel.Text = "";
        registrarGanador(0);
    }
}