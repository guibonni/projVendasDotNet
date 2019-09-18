<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroFornecedor.aspx.cs" Inherits="ProjVendasAula.CadastroFornecedor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Cadastro de Fornecedores</h1>
            <p><asp:Label ID="LblMsg" runat="server" Text=""></asp:Label></p>
            <table>
                <tr>
                    <td>Nome:</td>
                    <td><asp:TextBox ID="TxtNomeFornecedor" runat="server" Width="400px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Telefone:</td>
                    <td><asp:TextBox ID="TxtTelefoneFornecedor" runat="server" Width="400px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Cidade:</td>
                    <td><asp:TextBox ID="TxtCidadeFornecedor" runat="server" Width="400px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Endereco:</td>
                    <td><asp:TextBox ID="TxtEnderecoFornecedor" runat="server" Width="400px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>CNPJ:</td>
                    <td><asp:TextBox ID="TxtCNPJ" runat="server" Width="400px"></asp:TextBox></td>
                </tr>
            </table>
            <p><asp:GridView ID="GVFornecedor" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
