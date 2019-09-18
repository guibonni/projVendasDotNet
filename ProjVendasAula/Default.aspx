<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProjVendasAula.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="formDefault" runat="server">
        <div>
            <table>
                <tr>
                    <td><asp:Button ID="BtnTipo" runat="server" Text="Tipo" OnClick="BtnTipo_Click" /></td>
                    <td><asp:Button ID="BtnCliente" runat="server" Text="Cliente" OnClick="BtnCliente_Click" /></td>
                    <td><asp:Button ID="BtnFornecedor" runat="server" Text="Fornecedor" OnClick="BtnFornecedor_Click" /></td>
                    <td><asp:Button ID="BtnMaterial" runat="server" Text="Material" OnClick="BtnMaterial_Click" /></td>
                    <td><asp:Button ID="BtnVenda" runat="server" Text="Venda" OnClick="BtnVenda_Click" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
