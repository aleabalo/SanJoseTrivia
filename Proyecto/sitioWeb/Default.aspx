<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td>
                    &nbsp;</td>
                <td align="center">
                    <asp:Image ID="Image1" runat="server" SkinID="Imagenes/sanJoTrivia.png" 
                        style="text-align: center" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                </td>
                <td align="center" class="style1">
                    <asp:HyperLink ID="HyperLink1" runat="server">Registrarse</asp:HyperLink>
                </td>
                <td class="style1">
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td align="center">
                    <asp:Login ID="Login1" runat="server" BackColor="#EFF3FB" BorderColor="#B5C7DE" 
                        BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
                        Font-Size="0.8em" ForeColor="#333333" onauthenticate="Login1_Authenticate">
                        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                        <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" 
                            BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
                        <TextBoxStyle Font-Size="0.8em" />
                        <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.9em" 
                            ForeColor="White" />
                    </asp:Login>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td align="center">
                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
