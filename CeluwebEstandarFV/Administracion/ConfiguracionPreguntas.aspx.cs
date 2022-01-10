using co.com.CeluwebEstandarFV.BussinesObject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administracion_ConfiguracionPreguntas : System.Web.UI.Page
{
    string cadenaconexion;
    protected void Page_Load(object sender, EventArgs e)
    {

        cadenaconexion = ConfigurationManager.ConnectionStrings["Conexion"].ToString();

        if (Page.IsPostBack == false)
        {
            try
            {
                ddlCategoria.DataBind();
                cargarUsuarios();
            }
            catch (Exception error)
            {
                string mensaje = error.Message;
            }
            
        }
    }

    public void cargarUsuarios()
    {
        
        gvPregutnas.DataBind();
    }


    protected void btnCrear_Click(object sender, EventArgs e)
    {
        if (ddlCategoria.SelectedValue.ToString().Equals("-1"))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "swal('¡Advertencia!', '¡ Por favor seleccione una categoria !', 'warning')", true);
        }
        else
        {
            DatosBO datos = new DatosBO(cadenaconexion);

            string categoria = ddlCategoria.SelectedValue;
            string pregunta = txtPregunta.Text;
            string respuestaVerdader = txtRespuestaVerdadera.Text;
            string respuestaFalsa1 = txtRespuestaFalsa1.Text;
            string respuestaFalsa2 = txtRespuestaFalsa2.Text;
            string respuestaFalsa3 = txtRespuestaFalsa3.Text;



            Pregunta pre = new Pregunta(categoria, pregunta, respuestaVerdader, respuestaFalsa1, respuestaFalsa2, respuestaFalsa3);

            string respuesta = datos.CrearPreguntas(pre);

            if (respuesta!="error")
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "swal('¡Finalizado!', '¡ Pregunta Creada exitosamente !', 'success')", true);
                limpiar();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "swal('¡Advertencia!', '¡ Por favor intentelo de nuevo !', 'warning')", true);
            }
            cargarUsuarios();

        }
    }

    protected void btnModificar_Click(object sender, System.EventArgs e)
    {
        if (ddlCategoria.SelectedValue.ToString().Equals("-1"))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "swal('¡Advertencia!', '¡ Por favor seleccione una categoria !', 'warning')", true);
        }
        else
        {
            DatosBO datos = new DatosBO(cadenaconexion);

            string idtabla = hfIdTabla.Value;

            string categoria = ddlCategoria.SelectedValue;
            string pregunta = txtPregunta.Text;
            string respuestaVerdader = txtRespuestaVerdadera.Text;
            string respuestaFalsa1 = txtRespuestaFalsa1.Text;
            string respuestaFalsa2 = txtRespuestaFalsa2.Text;
            string respuestaFalsa3 = txtRespuestaFalsa3.Text;

            Pregunta pre = new Pregunta(idtabla, categoria, pregunta, respuestaVerdader, respuestaFalsa1, respuestaFalsa2, respuestaFalsa3);

            string resultado = datos.ActualizarPreguntas(pre);

            if (resultado.Equals("ok"))
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "swal('¡Finalizado!', '¡ Registro actualizado exitosamente!', 'success')", true);
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "swal('¡Error!', '¡Por favor intentelo nuevamente !', 'error')", true);

            limpiar();
            cargarUsuarios();
        }
    }





    protected void limpiar()
    {
        txtPregunta.Text = "";
        txtRespuestaVerdadera.Text = "";
        txtRespuestaFalsa1.Text = "";
        txtRespuestaFalsa2.Text = "";
        txtRespuestaFalsa3.Text = "";       
       

        btnModificar.Visible = false;
        btnCrear.Visible = true;

    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        limpiar();
    }

    protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvPregutnas.DataBind();
    }

    protected void gvPregutnas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DatosBO datos = new DatosBO(cadenaconexion);

        string idTabla = e.CommandArgument.ToString();
        Pregunta pre = new Pregunta(idTabla);

        if (string.IsNullOrEmpty(idTabla) == false)
        {
            Pregunta res = datos.ObtenerInfoPregunta(pre);

            ddlCategoria.SelectedValue = res._categoria;
            txtPregunta.Text = res._descripcion;
            txtRespuestaVerdadera.Text = res._respuetaVerdadera;
            txtRespuestaFalsa1.Text = res._respuestaFalsa1;
            txtRespuestaFalsa2.Text = res._respuestaFalsa2;
            txtRespuestaFalsa3.Text = res._respuestaFalsa3;


            hfIdTabla.Value = idTabla;

            btnModificar.Visible = true;
            btnCrear.Visible = false;

        }
    }



}