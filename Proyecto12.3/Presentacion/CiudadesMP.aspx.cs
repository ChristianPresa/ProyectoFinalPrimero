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
        DesactivarBotones();
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        string CodPais, CodCiudad, NomCiudad;
        Ciudad cCiudad = null;
        try
        {
            CodCiudad = txtCodCiudad.Text;
            CodPais = txtCodPais.Text;
            NomCiudad = txtNomCiudad.Text;
            lblError.Text = "";
            cCiudad = LogicaCiudad.BuscarCiudad(CodCiudad, CodPais);
            if (cCiudad != null)
            {
                ActivarBotones();
                txtCodCiudad.Text = cCiudad.CodCiudad;
                txtCodPais.Text = cCiudad.pPais.CodPais;
                txtNomCiudad.Text = cCiudad.NomCiudad;
                lblError.Text = "La ciudad ya existe, Puede Modificarla.";
            }
            else
            {
                Pais pPais = LogicaPais.BuscarPais(CodPais);
                cCiudad = new Ciudad(CodCiudad,NomCiudad,pPais);
                LogicaCiudad.AgregarCiudad(cCiudad);
                Limpiar();
                lblError.Text = "Se agrego la ciudad correctamente.";
            }

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    public void  ActivarBotones()
    {
        btnEliminar.Enabled = true;
        btnModificar.Enabled = true;
        btnAgregar.Enabled = false;

    }

    public void Limpiar()
    {
        txtCodPais.Text = "";
        txtNomCiudad.Text = "";
        txtCodCiudad.Text = "";
        DesactivarBotones();
        lblError.Text = "";
    }

    public void  DesactivarBotones()
    {
        btnEliminar.Enabled = false;
        btnModificar.Enabled = false;
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        string CodPais, CodCiudad, NomCiudad;
        Ciudad cCiudad = null;
        try
        {
            lblError.Text = "";
            CodCiudad = txtCodCiudad.Text;
            CodPais = txtCodPais.Text;
            NomCiudad = txtNomCiudad.Text;
            Pais pPais = LogicaPais.BuscarPais(CodPais);
            cCiudad = new Ciudad(CodCiudad,NomCiudad,pPais);
            LogicaCiudad.EliminarCiudad(cCiudad);
            Limpiar();
            btnAgregar.Enabled = true;
            lblError.Text = "Se elimino correctamente la ciudad";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        string CodPais, CodCiudad, NomCiudad;
        Ciudad cCiudad = null;
        try
        {
            lblError.Text = "";
            CodCiudad = txtCodCiudad.Text;
            CodPais = txtCodPais.Text;
            NomCiudad = txtNomCiudad.Text;
            Pais pPais = LogicaPais.BuscarPais(CodPais);
            cCiudad = new Ciudad(CodCiudad,NomCiudad,pPais);
            LogicaCiudad.ModificarCiudad(cCiudad);
            Limpiar();
            btnAgregar.Enabled = true;
            lblError.Text = "Se modifico correctamente la ciudad";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        Limpiar();
    }
}