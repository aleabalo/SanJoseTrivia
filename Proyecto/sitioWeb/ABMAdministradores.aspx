<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ABMAdministradores.aspx.cs" Inherits="ABMAdministradores" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
        .style2
        {
            width: 241px;
            height: 23px;
        }
        .style3
        {
            height: 23px;
        }
        .style4
        {
            width: 158px;
        }
        .style5
        {
            height: 23px;
            width: 158px;
        }
        .style6
        {
            height: 22px;
        }
        .style7
        {
            width: 158px;
            height: 22px;
        }
        .style8
        {
            height: 23px;
            text-align: center;
            font-family: tahoma;
            font-size: x-large;
        }
        .style9
        {
            height: 22px;
            width: 222px;
        }
        .style10
        {
            height: 23px;
            width: 222px;
        }
        .style11
        {
            width: 222px;
        }
        .style12
        {
            text-align: center;
            font-family: tahoma;
            font-size: x-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="style6">
                </td>
                <td class="style7">
                </td>
                <td class="style9">
                </td>
                <td class="style6">
                </td>
                <td class="style6">
                </td>
            </tr>
            <tr>
                <td class="style8" colspan="5">
                    <strong>ABM Administradores</strong></td>
            </tr>
            <tr>
                <td class="style12" colspan="5">
                </td>
            </tr>
            <tr>
                <td class="style3">
                </td>
                <td class="style5">
                    <asp:Label ID="lblDocumento" runat="server" Text="Documento"></asp:Label>
                </td>
                <td class="style10">
                    <asp:TextBox ID="txtDocumento" runat="server" Width="206px"></asp:TextBox>
                </td>
                <td class="style3">
                    <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" 
                        Text="Buscar" />
                </td>
                <td class="style3">
                </td>
            </tr>
            <tr>
                <td class="style2">
                </td>
                <td class="style5">
                    <asp:Label ID="lblUsuarioLogueo" runat="server" Text="Usuario Logueo"></asp:Label>
                </td>
                <td class="style10">
                    <asp:TextBox ID="txtUsuarioLogueo" runat="server" Enabled="False" Width="206px"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style3">
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="lblContraseña" runat="server" Text="Contraseña"></asp:Label>
                </td>
                <td class="style11">
                    <asp:TextBox ID="txtContraseña" runat="server" Enabled="False" Width="206px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="lblNombreCompleto" runat="server" Text="Nombre Completo"></asp:Label>
                </td>
                <td class="style11">
                    <asp:TextBox ID="txtNombreCompleto" runat="server" Enabled="False" 
                        Width="206px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style11">
                    <asp:RadioButton ID="rbtVisualizaEstadisticas" runat="server" Enabled="False" 
                        Text="Visualiza Estadisticas" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnAgregar" runat="server" Enabled="False" 
                        onclick="btnAgregar_Click" Text="Agregar" />
                    <asp:Button ID="btnModificar" runat="server" Enabled="False" 
                        onclick="btnModificar_Click" Text="Modificar" />
                    <asp:Button ID="btnEliminar" runat="server" Enabled="False" 
                        onclick="btnEliminar_Click" Text="Eliminar" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" colspan="4">
                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style11">
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
