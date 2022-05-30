<%@ Page Title="" Language="C#" MasterPageFile="~/Bienvenida.master" AutoEventWireup="true" CodeFile="CiudadesMP.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table style="width:100%;">
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2" style="text-align: center">
                <asp:Label ID="lblTitulo" runat="server" Text="ABM Ciudades"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="lblCodigoPais" runat="server" Text="Codigo Pais:"></asp:Label>
            </td>
            <td class="style6">
                <asp:TextBox ID="txtCodPais" runat="server" Width="184px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
                    runat="server" ControlToValidate="txtCodPais" 
                    ErrorMessage="Codigo de 3 caracteres, solo letras" ForeColor="Red" 
                    ValidationExpression="[A-Z]{3}">*</asp:RegularExpressionValidator>
&nbsp;<asp:Button ID="btnLimpiar" runat="server" onclick="btnLimpiar_Click" 
                    Text="Limpiar" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="lblCodigoCiudad" runat="server" Text="Codigo Ciudad:"></asp:Label>
            </td>
            <td class="style6">
                <asp:TextBox ID="txtCodCiudad" runat="server" Width="184px"></asp:TextBox>
&nbsp;&nbsp;
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="txtCodCiudad" 
                    ErrorMessage="Codigo de 3 caracteres, solo letras" ForeColor="Red" 
                    ValidationExpression="[A-Za-z]{3}">*</asp:RegularExpressionValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre Ciudad:"></asp:Label>
            </td>
            <td class="style6">
                <asp:TextBox ID="txtNomCiudad" runat="server" Width="184px"></asp:TextBox>
            &nbsp;&nbsp;
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                    ControlToValidate="txtNomCiudad" 
                    ErrorMessage="Campo obligatorio, no acepta numeros" ForeColor="Red" 
                    ValidationExpression="[A-Za-z\s]+">*</asp:RegularExpressionValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style6">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" 
                    onclick="btnAgregar_Click" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" 
                    onclick="btnModificar_Click" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnEliminar" runat="server" onclick="btnEliminar_Click" 
                    Text="Eliminar" />
            </td>
            <td class="style7">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
            </td>
            <td class="style4">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
            <td class="style5">
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                <asp:LinkButton ID="lnkVolver" runat="server" PostBackUrl="~/Default2.aspx">Volver...</asp:LinkButton>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </form>
</asp:Content>

