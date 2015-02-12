<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ABMPreguntas.aspx.cs" Inherits="ABMPreguntas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-align: center;
            font-family: tahoma;
            font-size: x-large;
        }
        .style2
        {
            width: 125px;
        }
        .style3
        {
            text-align: center;
        }
        .style5
        {
            width: 125px;
            text-align: left;
        }
        .style6
        {
            width: 221px;
            height: 22px;
        }
        .style7
        {
            width: 125px;
            text-align: left;
            height: 22px;
        }
        .style8
        {
            height: 22px;
        }
        .style9
        {
            width: 221px;
            height: 23px;
        }
        .style10
        {
            width: 125px;
            text-align: left;
            height: 23px;
        }
        .style11
        {
            height: 23px;
        }
        .style12
        {
            width: 221px;
            height: 81px;
        }
        .style13
        {
            width: 125px;
            height: 81px;
        }
        .style14
        {
            height: 81px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" colspan="5">
                    <strong>ABM Preguntas</strong></td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style2">
                    Id</td>
                <td>
                    <strong>
                    <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
                    <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" 
                        Text="Buscar" />
                    </strong>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style5">
                    Tipo</td>
                <td>
                    <asp:DropDownList ID="drpTipo" runat="server" AutoPostBack="True" 
                        Enabled="False">
                        <asp:ListItem>Seleccionar</asp:ListItem>
                        <asp:ListItem>Geografia</asp:ListItem>
                        <asp:ListItem>Ciencias</asp:ListItem>
                        <asp:ListItem>Deportes</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style5">
                    Pregunta</td>
                <td rowspan="2">
                    <asp:TextBox ID="txtPregunta" runat="server" Enabled="False" Height="49px" 
                        TextMode="MultiLine" Width="480px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">
                </td>
                <td class="style7">
                </td>
                <td class="style8">
                </td>
                <td class="style8">
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style5">
                    Respuesta 1</td>
                <td rowspan="2">
                    <asp:TextBox ID="txtRespuesta1" runat="server" Enabled="False" Height="49px" 
                        TextMode="MultiLine" Width="480px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                </td>
                <td class="style10">
                </td>
                <td class="style11">
                </td>
                <td class="style11">
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style5">
                    Respuesta 2</td>
                <td rowspan="2">
                    <asp:TextBox ID="txtRespuesta2" runat="server" Enabled="False" Height="49px" 
                        TextMode="MultiLine" Width="480px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style5">
                    Respuesta 3</td>
                <td rowspan="2">
                    <asp:TextBox ID="txtRespuesta3" runat="server" Enabled="False" Height="49px" 
                        TextMode="MultiLine" Width="480px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style12">
                </td>
                <td class="style13">
                    Respuesta Correcta</td>
                <td class="style14">
                    <asp:RadioButtonList ID="rbtCorrecta" runat="server" Enabled="False">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="style14">
                </td>
                <td class="style14">
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnAgregar" runat="server" Enabled="False" 
                        onclick="btnAgregar_Click" Text="Agregar" />
                    <asp:Button ID="btnModificar" runat="server" onclick="btnModificar_Click" 
                        Text="Modificar" />
                    <asp:Button ID="btnEliminar" runat="server" onclick="btnEliminar_Click" 
                        Text="Eliminar" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3" colspan="5">
                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
