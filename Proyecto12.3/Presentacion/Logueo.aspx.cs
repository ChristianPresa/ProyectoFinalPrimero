using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;
using Logica;
using EntidadesCompartidas;


public partial class Logueo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["Usuario"] = null;
            Limpio();
        }
    }
    private void Limpio()
    {
        txtContraseña.Text = "";
        txtUsuario.Text = "";
    }
   
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        Limpio();
        lblError.Text = "";
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string LogUsuario = "";
        string Contraseña = "";
        try
        {
            LogUsuario = txtUsuario.Text;
            Contraseña = txtContraseña.Text;
            EntidadesCompartidas.Usuario unUsu = LogicaUsuario.Logueo(LogUsuario, Contraseña);
            if (unUsu != null)
            {
                Session["Usuario"] = unUsu;
                Response.Redirect("Default2.aspx");
            }
            else
                lblError.Text = "Datos Incorrectos no tiene permiso para acceder al sitio";
        }
        catch
        {
            lblError.Text = "No existe el usuario ingresado";
            return;
        }     
    }
}