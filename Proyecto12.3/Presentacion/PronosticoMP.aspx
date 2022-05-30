<%@ Page Title="" Language="C#" MasterPageFile="~/Bienvenida.master" AutoEventWireup="true" CodeFile="PronosticoMP.aspx.cs" Inherits="Default4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style6
        {
            width: 908px;
            height: 44px;
        }
        .style7
        {
            width: 138px;
            height: 44px;
        }
        .style8
        {
            height: 44px;
        }
        .style9
        {
            width: 138px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style4">
                <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="X-Large" 
                    Text="Pronostico"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="lblCiudad" runat="server">Ciudad:</asp:Label>
            </td>
            <td class="style1" colspan="2">
                <asp:GridView ID="gvCiudad" runat="server" CellPadding="4" ForeColor="#333333" 
                    GridLines="None" Height="83px" Width="466px" 
                    onselectedindexchanged="gvCiudad_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="lblFecha" runat="server">Fecha:</asp:Label>
            </td>
            <td class="style1">
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
                    BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" 
                    ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
                        VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" 
                        Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                </asp:Calendar>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="lblHora" runat="server">Hora:</asp:Label>
            </td>
            <td class="style1">
                <asp:TextBox ID="txtHora" runat="server" Width="137px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtHora" 
                    ErrorMessage="Debe contener el siguiente formato &quot;HH:MM&quot;" 
                    ForeColor="Red" ValidationExpression="^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$">*</asp:RegularExpressionValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="lblVelocidad" runat="server">Velocidad del viento:</asp:Label>
            </td>
            <td class="style1">
                <asp:TextBox ID="txtVelViento" runat="server" Width="137px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="txtVelViento" ErrorMessage="Debe ser un valor positivo" 
                    ForeColor="Red" ValidationExpression="[0-2][0-9][0-9]|[0-9][0-9]|[0/9]">*</asp:RegularExpressionValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="lblProbabilidad" runat="server">Probabilidad:</asp:Label>
            </td>
            <td class="style1">
                <asp:TextBox ID="txtProbabilidad" runat="server" Width="137px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="txtProbabilidad" ErrorMessage="Debe ser un valor positivo" 
                    ForeColor="Red" ValidationExpression="[1][0][0]|[0-9][0-9]|[0-9]">*</asp:RegularExpressionValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="lblTempMax" runat="server">Temp MAX:</asp:Label>
            </td>
            <td class="style1">
                <asp:TextBox ID="txtTempMax" runat="server" Width="137px"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="txtTepMin" ControlToValidate="txtTempMax" 
                    ErrorMessage="Debe ser Mayo que la Temp MIN" ForeColor="Red" 
                    Operator="GreaterThan" ToolTip="[0-9]" Type="Integer">*</asp:CompareValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="lblError5" runat="server">Temp MIN:</asp:Label>
            </td>
            <td class="style7">
                <asp:TextBox ID="txtTepMin" runat="server" Height="22px" Width="137px"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator2" runat="server" 
                    ControlToCompare="txtTempMax" ControlToValidate="txtTepMin" 
                    ErrorMessage="Debe ser Meno que la Temp MAX" ForeColor="Red" 
                    Operator="LessThan" Type="Integer" ValidationGroup="[0-9]">*</asp:CompareValidator>
            </td>
            <td class="style8">
                </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="lblTipoCielo" runat="server">Tipo de Cielo:</asp:Label>
            </td>
            <td class="style1">
                <asp:DropDownList ID="DropDownList1" runat="server" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem>Nuboso</asp:ListItem>
                    <asp:ListItem>Despejado</asp:ListItem>
                    <asp:ListItem>Parcialmente Nuboso</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style1">
                <asp:Button ID="btnAgregar" runat="server" onclick="btnAgregar_Click" 
                    Text="Agregar" Width="91px" />
&nbsp;&nbsp; </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style1">
                <asp:Button ID="btnLimpiar" runat="server" onclick="btnLimpiar_Click" 
                    Text="Limpiar" Width="91px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style4">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style9">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style9">
                <asp:LinkButton ID="lnkVolver" runat="server" PostBackUrl="~/Default2.aspx">Volver...</asp:LinkButton>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

