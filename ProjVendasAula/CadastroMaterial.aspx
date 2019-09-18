<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroMaterial.aspx.cs" Inherits="ProjVendasAula.CadastroMaterial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Cadastro de Materiais</h1>
            <p><asp:Label ID="LblMsg" runat="server" Text=""></asp:Label></p>
            <table>
                <tr>
                    <td>Descrição:</td>
                    <td><asp:TextBox ID="TxtDescricao" runat="server" Width="400px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Tipo:</td>
                    <td>
                        <asp:DropDownList ID="DDLTipo" Width="400px" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Valor:</td>
                    <td><asp:TextBox ID="TxtValor" runat="server" Width="400px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Fornecedor:</td>
                    <td>
                        <asp:DropDownList ID="DDLFornecedor" Width="400px" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <p><asp:GridView ID="GVMateriais" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
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
                </asp:GridView></p>
            <p>
                <asp:Button ID="BtnVoltar" runat="server" Text="Voltar" OnClick="BtnVoltar_Click" />
                &nbsp;
                <asp:Button ID="BtnSalvar" runat="server" Text="Salvar" OnClick="BtnSalvar_Click" />
            </p>
        </div>
    </form>
</body>
</html>
