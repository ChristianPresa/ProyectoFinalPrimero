<%@ Page Title="" Language="C#" MasterPageFile="~/Bienvenida.master" AutoEventWireup="true" CodeFile="PaisMP.aspx.cs" Inherits="Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style6
        {
            width: 138px;
            height: 34px;
        }
        .style7
        {
            width: 908px;
            height: 34px;
        }
        .style8
        {
            height: 34px;
        }
        .style9
        {
            width: 138px;
            height: 33px;
        }
        .style10
        {
            width: 908px;
            height: 33px;
        }
        .style11
        {
            height: 33px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2" style="text-align: center">
                    <asp:Label ID="lblABMPais" runat="server" Text="ABM Pais"></asp:Label>
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
                <td class="style9">
                    <asp:Label ID="lblPais" runat="server" Text="Pais:"></asp:Label>
                </td>
                <td class="style10">
                    <asp:TextBox ID="txtNombrePais" runat="server" Width="183px"></asp:TextBox>
&nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ControlToValidate="txtNombrePais" ErrorMessage="saddsadas" ForeColor="Red" 
                        ValidationExpression="[A-Za-z]+">*</asp:RegularExpressionValidator>
                    &nbsp;&nbsp;
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" 
                        onclick="btnLimpiar_Click" />
                </td>
                <td class="style11">
                    </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="lblCodigo" runat="server" Text="Codigo Pais:"></asp:Label>
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtCodPais" runat="server" Width="183px"></asp:TextBox>
                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                        runat="server" ControlToValidate="txtCodPais" 
                        ErrorMessage="Debe contener 3 caracateres (Letras)" ForeColor="Red" 
                        ValidationExpression="[A-Z]{3}">*</asp:RegularExpressionValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">
                    </td>
                <td class="style7">
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" 
                        onclick="btnAgregar_Click" />
&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" 
                        onclick="btnModificar_Click" />
&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" 
                        onclick="btnEliminar_Click" />
                </td>
                <td class="style8">
                    </td>
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
                <td class="style1">
                    &nbsp;</td>
                <td class="style2" style="text-align: center">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2" style="text-align: center">
                    <asp:LinkButton ID="lnkVolver" runat="server" PostBackUrl="~/Default2.aspx">Volver...</asp:LinkButton>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
</asp:Content>

