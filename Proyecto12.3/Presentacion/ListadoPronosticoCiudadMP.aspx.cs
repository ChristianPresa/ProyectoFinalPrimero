using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Logica;
using EntidadesCompartidas;
using Persistencia;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {    
       
            try
            {
                if (!IsPostBack)
                {
                    ddlPais.DataSource = LogicaPais.ListarPais();
                    Session["Lista"] = LogicaPais.ListarPais().Count();
                    ddlPais.DataTextField = "NomPais";
                    ddlPais.DataValueField= "CodPais";    
                    ddlPais.DataBind();
                }
            }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
  
    protected void gvCiudad_SelectedIndexChanged(object sender, EventArgs e)
    {
        string CodCiudad = gvCiudad.SelectedRow.Cells[3].Text;
        string CodPais = gvCiudad.SelectedRow.Cells[2].Text;
        List <Pronostico> Pronostico = LogicaPronostico.ListarPronosticoPorCiudad(CodPais, CodCiudad);
        if (Pronostico.Count() > 0)
        {
            lbListar.DataSource = Pronostico;
            lbListar.DataBind();
        }
        else
        {
            string Error = "No se encontro resultado";
            List<string> N = new List<string>();
            N.Add(Error);
            lbListar.DataSource = N;
            lbListar.DataBind();
        }

    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbListar.Items.Clear();
        string CodPais = ddlPais.SelectedValue;
        gvCiudad.DataSource = LogicaCiudad.ListarCiudadPorPais(CodPais);
        gvCiudad.DataBind();
    }
}