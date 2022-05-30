<%@ Page Title="" Language="C#" MasterPageFile="~/Bienvenida.master" AutoEventWireup="true" CodeFile="UsuarioMP.aspx.cs" Inherits="Default6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: center">
                <asp:Label ID="lblTitulo" runat="server" Text="ABM Usuario"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUsuario" runat="server" Width="199px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="81px" 
                    onclick="btnBuscar_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblContraseña" runat="server" Text="Contraseña:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtContraseña" runat="server" Width="199px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblNombre1" runat="server" Text="Nombre1"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNombre1" runat="server" Width="199px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" Width="81px" 
                    onclick="btnAgregar_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblNombre2" runat="server" Text="Nombre2:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNombre2" runat="server" Width="199px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" Width="81px" 
                    onclick="btnModificar_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblApellido1" runat="server" Text="Apellido1:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtApellido1" runat="server" Width="199px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" 
                    onclick="Button3_Click" Width="81px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblApellido2" runat="server" Text="Apellido2:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtApellido2" runat="server" Width="199px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnLimppiar" runat="server" Text="Limpiar" Width="81px" 
                    onclick="btnLimppiar_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: center">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: center">
                <asp:LinkButton ID="lnkVolver" runat="server" style="text-align: center" 
                    PostBackUrl="~/Default2.aspx">Volver...</asp:LinkButton>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

