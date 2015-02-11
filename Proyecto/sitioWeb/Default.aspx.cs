using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webService;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        string _usuario = Login1.UserName;
        string _contraseña = Login1.Password;

        WebService Servicio = new WebService();

        Administrador admn = null;

        Jugador jug = null;

        try
        {
            //llamo al metodo de login pasando un obeto del tipo usuario
            admn = Servicio.LoginAdministrador(_usuario, _contraseña);
            jug = Servicio.LoginJugador(_usuario, _contraseña);
        }
        catch (System.Web.Services.Protocols.SoapException ex)
        {
            lblError.Text = ex.Detail.InnerText;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }

        if (admn != null) // si es disitnto de null lo cargo en la session y doy ok al login
        {
            Session["Administrador"] = admn;
            e.Authenticated = true;
            Response.Redirect("IngresoAdministrador.aspx");
        }
        else if (jug != null)
        {
            Session["Jugador"] = jug;
            e.Authenticated = true;
            Response.Redirect("IngresoJugador.aspx");
        }
        else // si no es administrador ni jugador error
        {
            lblError.Text = "Usuario y/o Contraseña incorrecta";
            e.Authenticated = false;

        }

        


    }
}