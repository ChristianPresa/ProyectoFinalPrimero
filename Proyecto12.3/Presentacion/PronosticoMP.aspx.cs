using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Logica;
using EntidadesCompartidas;
using Persistencia;


public partial class Default4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            gvCiudad.DataSource = LogicaCiudad.ListarCiudad();
            gvCiudad.DataBind();
            Calendar1.SelectedDate = DateTime.Now;
            
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        } 
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        Limpiar();
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        string Hora,TipoCielo;
        Ciudad cCiudad;
        int TempMax, TempMin, Prob, vViento, cCodPronsotico = 0;
        try
        {
            DateTime fecha = Calendar1.SelectedDate;
            Hora = txtHora.Text;
            TempMax = Convert.ToInt32(txtTempMax.Text);
            TempMin = Convert.ToInt32(txtTepMin.Text);
            Prob = Convert.ToInt32(txtProbabilidad.Text);
            vViento = Convert.ToInt32(txtVelViento.Text);
            //Tipo Cielo
            TipoCielo = DropDownList1.SelectedValue;
            //Ciudad
            string CodCiudad = Convert.ToString(Session["CodCiudad"]);
            //Usuario completo
            var unUsu = (EntidadesCompartidas.Usuario)Session["Usuario"];
            //Ciudad
            cCiudad = LogicaCiudad.BuscarCiudad(Convert.ToString(Session["CodCiudad"]), Convert.ToString(Session["CodPais"]));
            EntidadesCompartidas.Pronostico Pro = new EntidadesCompartidas.Pronostico(Prob, TipoCielo, vViento, fecha, Hora, TempMin, TempMax, cCodPronsotico, cCiudad, unUsu);
            if (Pro != null)
            {
                LogicaPronostico.AgregarPronostico(Pro);
                Limpiar();
                lblError.Text = "Alta Con Exito.";
            }
            else
            {
                lblError.Text = "No se pudo agregar el pronostico.";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void gvCiudad_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["CodCiudad"] = gvCiudad.SelectedRow.Cells[3].Text;
        Session["CodPais"] = gvCiudad.SelectedRow.Cells[2].Text;
    }

    public void Limpiar()
    {
        txtHora.Text = "";
        txtProbabilidad.Text = "";
        txtTempMax.Text = "";
        txtTepMin.Text = "";
        txtVelViento.Text = "";
        lblError.Text = "";
        Calendar1.SelectedDate = DateTime.Now;
    }
    
}