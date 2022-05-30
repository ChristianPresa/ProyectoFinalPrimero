using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Logica;
using EntidadesCompartidas;
using Persistencia;


public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DesactivarBotones();
        }
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    { 
        string NomPais, CodPais;
        EntidadesCompartidas.Pais p = null;
        try
        {
            lblError.Text = ""; 
            NomPais = txtNombrePais.Text;
            CodPais = txtCodPais.Text;
            if (NomPais != "" && CodPais != "")
            {
                p = LogicaPais.BuscarPais(CodPais);
                if (p == null)
                {
                    LogicaPais.AgregarPais(CodPais, NomPais);
                    Limpio();
                    lblError.Text = "Alta con Exito.";
                }
                else
                {
                    txtNombrePais.Text = Convert.ToString(p.NomPais);
                    lblError.Text = "El Pais ya existe, puede modificarlo.";
                    ActivarBotones();
                }
            }
            else
                lblError.Text = "Debe ingresar un valor en los campos vacios";
        }
        catch (Exception ex)
        {
            lblError.Text = "No se pudo agregarel pais." + ex.Message;
        }
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        txtCodPais.Text = "";
        txtNombrePais.Text = "";
        DesactivarBotones();
        lblError.Text = "";
    }

    public void DesactivarBotones ()
    {
        btnEliminar.Enabled = false;
        btnModificar.Enabled = false;
        btnAgregar.Enabled = true;
    }

    public void ActivarBotones()
    {
        btnEliminar.Enabled = true;
        btnModificar.Enabled = true;
        btnAgregar.Enabled = false;
    }

    public void Limpio()
    {
        txtCodPais.Text = "";
        txtNombrePais.Text = "";
        DesactivarBotones();
        lblError.Text = "";
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            lblError.Text = "";
            string Cod = txtCodPais.Text;
            EntidadesCompartidas.Pais p = null;

            p = LogicaPais.BuscarPais(Cod);
            LogicaPais.EliminarPais(p);
            Limpio();
            lblError.Text = "El Pais se elimino correctamente.";
        }
        catch (Exception ex)
        {
            lblError.Text = "No se pudo eliminar el Pais" + ex.Message;
        }
    }
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            lblError.Text = "";
            string Nombre = txtNombrePais.Text;
            string Cod = txtCodPais.Text;
            LogicaPais.Modificar(Cod, Nombre);
            Limpio();
            lblError.Text = "Modificado Correctamente.";
        }
        catch (Exception ex)
        {
            lblError.Text = "Error " + ex.Message;
        }
    }
}