using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;

public partial class Bienvenida : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
        var unUsu = (EntidadesCompartidas.Usuario)Session["Usuario"];
        if (unUsu != null)
        {
            lblNombreLogueo.Text = unUsu.NomLog;
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    
        }   
        catch
        {
            Response.Redirect("Default.aspx");
        }
    }
    protected void btnDeloguear_Click(object sender, EventArgs e)
    {
        try
        {
            Session["Usuario"] = null;
            Response.Redirect("Default.aspx");
        }
        catch
        {
            lblError.Text = "Error."; 
        }
    }
}
