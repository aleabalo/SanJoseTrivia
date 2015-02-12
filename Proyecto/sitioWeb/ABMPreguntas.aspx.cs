using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using webService;
using System.Web.UI.WebControls;

public partial class ABMPreguntas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        string tipo, textoPregunta, textoRespuesta1, textoRespuesta2, textoRespuesta3;
        bool correcta1, correcta2, correcta3;

        List<Respuesta> listaResp = new List<Respuesta>();
        Pregunta preg = new Pregunta();


        try
        {
            webService.Service Servicio = new webService.Service();

            tipo = drpTipo.SelectedValue;
            textoPregunta = txtPregunta.Text;
            textoRespuesta1 = txtRespuesta1.Text;
            textoRespuesta2 = txtRespuesta2.Text;
            textoRespuesta3 = txtRespuesta3.Text;
            correcta1 = rbtCorrecta.Items[0].Selected;
            correcta2 = rbtCorrecta.Items[1].Selected;
            correcta3 = rbtCorrecta.Items[2].Selected;

            Respuesta Resp1 = new Respuesta();
            Resp1.Id = 1;
            Resp1.TextoRespuesta = textoRespuesta1;
            Resp1.Correcta = correcta1;
            listaResp.Add(Resp1);

            Respuesta Resp2 = new Respuesta();
            Resp2.Id = 2;
            Resp2.TextoRespuesta = textoRespuesta2;
            Resp2.Correcta = correcta2;
            listaResp.Add(Resp2);

            Respuesta Resp3 = new Respuesta();
            Resp3.Id = 3;
            Resp3.TextoRespuesta = textoRespuesta3;
            Resp3.Correcta = correcta3;
            listaResp.Add(Resp3);

            preg.Tipo = tipo;
            preg.TextoPregunta = textoPregunta;
            //preg.Respuestas = listaResp;

            Servicio.AgregarPregunta(preg);

            lblError.Text = "Pregunta agregada con éxito";

        }

        catch (Exception ex)
        {
            lblError.Text = ex.Message ;
        }


    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        int id;

        Pregunta preg = null;

        try
        {
            id = Convert.ToInt32(txtId.Text);
            webService.Service Servicio = new webService.Service();
            preg = Servicio.BuscarPregunta(id);

            if (preg != null)
            {
                txtId.Enabled = false;
                txtPregunta.Enabled = true;
                txtRespuesta1.Enabled = true;
                txtRespuesta2.Enabled = true;
                txtRespuesta3.Enabled = true;
                rbtCorrecta.Enabled = true;
                btnAgregar.Enabled = false;
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
                btnBuscar.Enabled = false;

                txtPregunta.Text = preg.TextoPregunta;
                txtRespuesta1.Text = preg.Respuestas[0].TextoRespuesta;
                txtRespuesta2.Text = preg.Respuestas[1].TextoRespuesta;
                txtRespuesta3.Text = preg.Respuestas[2].TextoRespuesta;
                drpTipo.SelectedValue = preg.Tipo;

                Session["Pregunta"] = preg;
            }

            else
            {
                txtId.Enabled = false;
                txtPregunta.Enabled = true;
                txtRespuesta1.Enabled = true;
                txtRespuesta2.Enabled = true;
                txtRespuesta3.Enabled = true;
                rbtCorrecta.Enabled = true;

                btnAgregar.Enabled = true;
                btnBuscar.Enabled = false;
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
            }
        }

        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        Pregunta preg;
        try
        {
            if (Session["Pregunta"] != null)
            {
                preg = (Pregunta)Session["Pregunta"];
                webService.Service Servicio = new webService.Service();
                Servicio.BajaPregunta(preg);
                lblError.Text = "Baja exitosa";
            }

            else
            {
                lblError.Text = "No hay pregunta buscada previamente";
            }
        }

        catch (Exception ex)
        {

            lblError.Text = ex.Message;
        }
    }
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        int id;
        string tipo, textoPregunta, textoRespuesta1, textoRespuesta2, textoRespuesta3;
        bool correcta1, correcta2, correcta3;

        List<Respuesta> listaResp = new List<Respuesta>();
        Pregunta preg = new Pregunta();


        try
        {
            if (Session["Pregunta"] != null)
            {
                webService.Service Servicio = new webService.Service();
                id = Convert.ToInt32(txtId.Text);
                tipo = drpTipo.SelectedValue;
                textoPregunta = txtPregunta.Text;
                textoRespuesta1 = txtRespuesta1.Text;
                textoRespuesta2 = txtRespuesta2.Text;
                textoRespuesta3 = txtRespuesta3.Text;
                correcta1 = rbtCorrecta.Items[0].Selected;
                correcta2 = rbtCorrecta.Items[1].Selected;
                correcta3 = rbtCorrecta.Items[2].Selected;

                Respuesta Resp1 = new Respuesta();
                Resp1.Id = 1;
                Resp1.TextoRespuesta = textoRespuesta1;
                Resp1.Correcta = correcta1;
                listaResp.Add(Resp1);

                Respuesta Resp2 = new Respuesta();
                Resp2.Id = 2;
                Resp2.TextoRespuesta = textoRespuesta2;
                Resp2.Correcta = correcta2;
                listaResp.Add(Resp2);

                Respuesta Resp3 = new Respuesta();
                Resp3.Id = 3;
                Resp3.TextoRespuesta = textoRespuesta3;
                Resp3.Correcta = correcta3;
                listaResp.Add(Resp3);
                preg.IdPregunta = id;
                preg.Tipo = tipo;
                preg.TextoPregunta = textoPregunta;
                //preg.Respuestas = listaResp;

                Servicio.ModificarPregunta(preg);

                lblError.Text = "Pregunta modificada con éxito";
            }

            else
            {
                lblError.Text = "No hay una pregunta buscada previamente";
            }
        }

        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}