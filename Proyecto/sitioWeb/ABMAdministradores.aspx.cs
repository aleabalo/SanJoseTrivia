using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webService;

public partial class ABMAdministradores : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        string documento;
        Administrador admin = null;
        documento = txtDocumento.Text.Trim();
        try
        {
            WebService servicio = new WebService();
            admin = servicio.BuscarAdministrador(documento);

            if (admin != null)
            {
                Session["Buscado"]=admin;
                txtDocumento.Enabled = false;
                txtContraseña.Enabled = true;
                rbtVisualizaEstadisticas.Enabled = true;
                txtNombreCompleto.Enabled = true;
                txtUsuarioLogueo.Enabled = true;

                txtContraseña.Text = admin.Contraseña;
                txtNombreCompleto.Text = admin.NombreCompleto;
                txtUsuarioLogueo.Text = admin.UsuLogueo;
                rbtVisualizaEstadisticas.Checked = admin.Estadistica;

                btnBuscar.Enabled = false;
                btnModificar.Enabled = true;
                btnAgregar.Enabled = false;
                btnEliminar.Enabled = true;

            }

            else
            {
                txtDocumento.Enabled = false;
                txtContraseña.Enabled = true;
                rbtVisualizaEstadisticas.Enabled = true;
                txtNombreCompleto.Enabled = true;
                txtUsuarioLogueo.Enabled = true;
                btnBuscar.Enabled = false;
                btnModificar.Enabled = false;
                btnAgregar.Enabled = true;
                btnEliminar.Enabled = false;
            }


        }

        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        string documento, usuarioLogueo, contraseña, nombreCompleto;
        bool estadisticas;

        Administrador admin = new Administrador();

        try
        {
            WebService servicio = new WebService();

            documento = txtDocumento.Text.Trim();
            usuarioLogueo = txtUsuarioLogueo.Text.Trim();
            contraseña = txtContraseña.Text.Trim();
            nombreCompleto = txtNombreCompleto.Text.Trim();
            estadisticas = rbtVisualizaEstadisticas.Checked;


            admin.Cedula = documento;
            admin.UsuLogueo = usuarioLogueo;
            admin.Contraseña = contraseña;
            admin.NombreCompleto = nombreCompleto;
            admin.Estadistica = estadisticas;

            servicio.AgregarAdministrador(admin);

            lblError.Text = "Registro con éxito";

            txtContraseña.Enabled = false;
            txtDocumento.Enabled = false;
            txtNombreCompleto.Enabled = false;
            txtUsuarioLogueo.Enabled = false;
            rbtVisualizaEstadisticas.Enabled = false;
            btnAgregar.Enabled = false;
        }

        catch (Exception ex)
        {

            lblError.Text = ex.Message;
        }
    }


    protected void btnModificar_Click(object sender, EventArgs e)
    {
        string documento, usuarioLogueo, contraseña, nombreCompleto;
        bool estadisticas;

        Administrador admin = new Administrador();

        try
        {
            WebService servicio = new WebService();

            documento = txtDocumento.Text.Trim();
            usuarioLogueo = txtUsuarioLogueo.Text.Trim();
            contraseña = txtContraseña.Text.Trim();
            nombreCompleto = txtNombreCompleto.Text.Trim();
            estadisticas = rbtVisualizaEstadisticas.Checked;


            admin.Cedula = documento;
            admin.UsuLogueo = usuarioLogueo;
            admin.Contraseña = contraseña;
            admin.NombreCompleto = nombreCompleto;
            admin.Estadistica = estadisticas;

            servicio.AgregarAdministrador(admin);

            lblError.Text = "Modificación con éxito";

            txtContraseña.Enabled = false;
            txtDocumento.Enabled = false;
            txtNombreCompleto.Enabled = false;
            txtUsuarioLogueo.Enabled = false;
            rbtVisualizaEstadisticas.Enabled = false;
            btnAgregar.Enabled = false;
        }

        catch (Exception ex)
        {

            lblError.Text = ex.Message;
        }
    }


    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        Administrador admin = (Administrador)Session["Buscado"];

        try
        {
            WebService servicio = new WebService();

            if (admin != null)
            {
                servicio.BajaAdministrador(admin);
                lblError.Text = "Baja con éxito";
            }

            else
            {
                lblError.Text = "No se encontro el usuario a eliminar";
            }
        }

        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}