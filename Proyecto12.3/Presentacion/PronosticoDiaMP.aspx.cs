using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Logica;
using EntidadesCompartidas;
using Persistencia;

public partial class Default5 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {

            gvPronosticoD.DataSource = null;
            gvPronosticoD.DataBind();

            DateTime Fecha = Calendar1.SelectedDate;
            List<Pronostico> P = LogicaPronostico.ListarPronosticoFecha(Fecha);
            if (P.Count > 0)
            {
                gvPronosticoD.DataSource = P;
                gvPronosticoD.DataBind();
                lblError.Text = "";
            }
            else
            {
                lblError.Text = "No hay Pronosticos para el dia seleccionado.";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        } 
    }
    protected void gvPronosticoD_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}