using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Web.Services.Protocols;
using EntidadesCompartidas;
using Logica;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que este servicio Web se llame desde un script, mediante ASP.NET AJAX, quite el comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{
    public Service () {

        //Eliminar la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

   [WebMethod]
    private void GenerarSoapException(Exception ex)
    {
        XmlDocument _undoc = new System.Xml.XmlDocument();
        XmlNode _NodoError = _undoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);
        XmlNode _NodoDetalle = _undoc.CreateNode(XmlNodeType.Element, "Error", "");
        _NodoDetalle.InnerText = ex.Message;
        _NodoError.AppendChild(_NodoDetalle);
        Console.WriteLine(ex.Message);
        Console.WriteLine(_NodoDetalle);
        SoapException _MiEx = new SoapException("Error WS", SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, _NodoError);
        throw _MiEx;
        
    }


    //LOGIN

    [WebMethod]
    public Administrador LoginAdministrador(string Usuario, string Contraseña)
    {
        Administrador admin = null;
        try
        {
            ILogicaAdministrador LArticulo = FabricaLogica.getLogicaAdministrador();
            admin = LArticulo.LoginAdministrador(Usuario, Contraseña);
        }
        catch (Exception ex)
        {

            this.GenerarSoapException(ex);
            
        }
        return admin;
    }

    [WebMethod]
    public Jugador LoginJugador(string Usuario, string Contraseña)
    {
        Jugador j = null;
        try
        {
            ILogicaJugador LArticulo = FabricaLogica.getLogicaJugador();
            j = LArticulo.LoginJugador(Usuario, Contraseña);
        }
        catch (Exception ex)
        {
            this.GenerarSoapException(ex);
        }
        return j;
    }

    //ADMINISTRADORES

    [WebMethod]
    public void AgregarAdministrador(Administrador admin)
    {
        try
        {
            ILogicaAdministrador LArticulo = FabricaLogica.getLogicaAdministrador();
            LArticulo.AgregarAdministrador(admin);
        }
        catch (Exception ex)
        {
            this.GenerarSoapException(ex);
        }
    }

    [WebMethod]
    public void BajaAdministrador(Administrador admin)
    {
        try
        {
            ILogicaAdministrador LArticulo = FabricaLogica.getLogicaAdministrador();
            LArticulo.BajaAdministrador(admin);
        }
        catch (Exception ex)
        {
            this.GenerarSoapException(ex);
        }
    }

    [WebMethod]
    public Administrador BuscarAdministrador(string Cedula)
    {
        Administrador admin = null;
        try
        {
            ILogicaAdministrador LArticulo = FabricaLogica.getLogicaAdministrador();
            admin = LArticulo.BuscarAdministrador(Cedula);
        }
        catch (Exception ex)
        {
            this.GenerarSoapException(ex);
        }
        return admin;
    }

    [WebMethod]
    public void ModificarAdministrador(Administrador admin)
    {
        try
        {
            ILogicaAdministrador LArticulo = FabricaLogica.getLogicaAdministrador();
            LArticulo.ModificarAdministrador(admin);
        }
        catch (Exception ex)
        {
            this.GenerarSoapException(ex);
        }
    }

    //JUGADOR
    [WebMethod]
    public void AgregarJugador(Jugador j)
    {
        try
        {
            ILogicaJugador LArticulo = FabricaLogica.getLogicaJugador();
            LArticulo.AgregarJugador(j);
        }
        catch (Exception ex)
        {
            this.GenerarSoapException(ex);
        }
    }


    //PREGUNTA

    [WebMethod]
    public Pregunta BuscarPregunta(int IdPregunta)
    {
        Pregunta preg = null;
        try
        {
            ILogicaPregunta LPregunta = FabricaLogica.getLogicaPregunta();
            preg = LPregunta.BuscarPregunta(IdPregunta);
        }
        catch (Exception ex)
        {
            this.GenerarSoapException(ex);
        }
        return preg;
    }

    [WebMethod]
    public void AgregarPregunta(Pregunta P)
    {
        try
        {
            ILogicaPregunta LPregunta = FabricaLogica.getLogicaPregunta();
            LPregunta.AgregarPregunta(P);
        }
        catch (Exception ex)
        {
            this.GenerarSoapException(ex);
        }
    }

    [WebMethod]
    public void ModificarPregunta(Pregunta P)
    {
        try
        {
            ILogicaPregunta LPregunta = FabricaLogica.getLogicaPregunta();
            LPregunta.ModificarPregunta(P);
        }
        catch (Exception ex)
        {
            this.GenerarSoapException(ex);
        }
    }


    [WebMethod]
    public void BajaPregunta(Pregunta preg)
    {
        try
        {
            ILogicaPregunta LPregunta = FabricaLogica.getLogicaPregunta();
            LPregunta.BajaPregunta(preg);
        }
        catch (Exception ex)
        {
            this.GenerarSoapException(ex);
        }
    }



    //RESPUESTAS

    [WebMethod]
    public void AgregarRespuesta(Respuesta res)
    { }

    [WebMethod]

    public Respuesta BuscarRespuesta(int id)
    {
        Respuesta resp=null;
        return resp;
        
    }
}