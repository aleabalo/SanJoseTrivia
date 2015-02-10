using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webService;

public partial class RegistroJugador : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        WebService Servicio = new WebService();
        try
        {
            string usuario = txtUsuario.Text;
            string cedula = txtCedula.Text;
            string contraseña = txtContraseña.Text;
            string nombreCompleto = txtNombreCompleto.Text;
            string nombrePublico = txtNombrePublico.Text;

            Jugador j = new Jugador();
            j.UsuLogueo = usuario;
            j.Cedula = cedula;
            j.Contraseña = contraseña;
            j.NombreCompleto = nombreCompleto;
            j.NombrePublico = nombrePublico;

            Servicio.AgregarJugador(j);
            lblError.Text = "El Jugador se agrego correctamente";
            LimpioControles();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    public void LimpioControles()
    {
        txtCedula.Text = "";
        txtContraseña.Text = "";
        txtNombreCompleto.Text = "";
        txtNombrePublico.Text = "";
        txtUsuario.Text = "";
    }
}
        
