using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Logica;
using EntidadesCompartidas;
using Persistencia;

public partial class Default6 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            DesactivarBotones();
    }
 
    protected void btnLimppiar_Click(object sender, EventArgs e)
    {
        Limpiar();
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        string uUsuario, cContraseña, nNombre1, nNombre2, aApellido1, aApellido2;
        Usuario Usuario;

        try
        {
            
            uUsuario = txtUsuario.Text;
            cContraseña = txtContraseña.Text;
            nNombre1 = txtNombre1.Text;
            nNombre2 = txtNombre2.Text;
            aApellido1 = txtApellido1.Text;
            aApellido2 = txtApellido2.Text;
            
            Usuario = LogicaUsuario.BuscarUsuarios(uUsuario);            
        
            if (Usuario == null)
            {
                Usuario = new Usuario(uUsuario, cContraseña, nNombre1, nNombre2, aApellido1, aApellido2);
                LogicaUsuario.AgregarUsuario(Usuario);
                Limpiar();
                lblError.Text = "Se agrego el Usuario de manera correcta.";
                DesactivarBotones();
            }
            else
            {
                txtContraseña.Text = Usuario.Password;
                txtNombre1.Text = Usuario.Nombre1;
                txtNombre2.Text = Usuario.Nombre2;
                txtApellido1.Text = Usuario.Apellido1;
                txtApellido2.Text = Usuario.Apellido2;
                btnAgregar.Enabled = false;
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
                txtUsuario.Enabled = false;
                lblError.Text = "El usuario Ya existe.";
            }

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    
    }
    public void Limpiar()
    {
        txtUsuario.Text = "";
        txtContraseña.Text = "";
        txtNombre1.Text = "";
        txtNombre2.Text = "";
        txtApellido1.Text = "";
        txtApellido2.Text = "";
        lblError.Text = "";
        txtUsuario.Enabled = true;
        btnAgregar.Enabled = false;
    }

    public void ActivarBotones()
    {
        btnEliminar.Enabled = true;
        btnModificar.Enabled = true;
        btnAgregar.Enabled = false;

    }
    public void DesactivarBotones()
    {
        btnEliminar.Enabled = false;
        btnModificar.Enabled = false;
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        string NomLog;
        Usuario Usuario= null;

        try
        {
           NomLog = txtUsuario.Text;
          
            Usuario = LogicaUsuario.BuscarUsuarios(NomLog);
            var unUsu = (EntidadesCompartidas.Usuario)Session["Usuario"];
            if (Usuario != null)
            {


                if (Usuario.NomLog == unUsu.NomLog)
                {
                    btnEliminar.Enabled = false;
                    btnModificar.Enabled = true;
                    txtUsuario.Enabled = false;
                    txtContraseña.Text = Usuario.Password;
                    txtNombre1.Text = Usuario.Nombre1;
                    txtNombre2.Text = Usuario.Nombre2;
                    txtApellido1.Text = Usuario.Apellido1;
                    txtApellido2.Text = Usuario.Apellido2;

                }
                else
                {
                    btnAgregar.Enabled = false;
                    txtUsuario.Enabled = false;
                    btnEliminar.Enabled = true;
                    btnModificar.Enabled = true;
                    txtContraseña.Text = Usuario.Password;
                    txtNombre1.Text = Usuario.Nombre1;
                    txtNombre2.Text = Usuario.Nombre2;
                    txtApellido1.Text = Usuario.Apellido1;
                    txtApellido2.Text = Usuario.Apellido2;

                }
                lblError.Text = "Usuario existente";
                
            }
            else 
                {
                    btnAgregar.Enabled = true;
                    lblError.Text = "No se encontro Usuario";
                }


        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }

    }
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        string  uUsuario,cContraseña, nNombre1, nNombre2, aApellido1, aApellido2;
        

        try
        {
            uUsuario = txtUsuario.Text;
            nNombre1 = txtNombre1.Text;
            nNombre2 = txtNombre2.Text;
            aApellido1 = txtApellido1.Text;
            aApellido2 = txtApellido2.Text;
            cContraseña = txtContraseña.Text;

            Usuario usr = new Usuario(uUsuario, cContraseña, nNombre1, nNombre2, aApellido1, aApellido2);
            LogicaUsuario.Modificar(usr);
            Limpiar();
            lblError.Text = "El Usuario se modifico de manera exitosa";
            DesactivarBotones();
            btnAgregar.Enabled = true;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string NomLog;

        try
        {
            NomLog = txtUsuario.Text;

            LogicaUsuario.Eliminar(NomLog);
            Limpiar();
            DesactivarBotones();
            lblError.Text = "Usuario eliminado";


        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }

    }
}