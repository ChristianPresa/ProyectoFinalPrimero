using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Logica;
using EntidadesCompartidas;
using Persistencia; 

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Session["Usuario"] = null;
            if (!IsPostBack)
            {   
                lbList.DataSource = LogicaPronostico.ListarPronostico();
                lbList.DataBind();         
            }

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        } 
    }
}