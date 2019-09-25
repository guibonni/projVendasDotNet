using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjVendasAula
{
    public partial class CadastroCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }

        protected void BtnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        private void LoadGrid()
        {
            List<Cliente> clientes = new Entities().Cliente.ToList<Cliente>();
            foreach (Cliente cliente in clientes)
            {
                cliente.CPF = GerarCPFCompleto(int.Parse(cliente.CPF));
            }
            GVCliente.DataSource = clientes;
            GVCliente.DataBind();
        }

        private void SendMessage(string msg)
        {
            LblMsg.Text = msg;
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente()
            {
                Nome = TxtNome.Text,
                Telefone = TxtTelefone.Text,
                Cidade = TxtCidade.Text,
                Endereco = TxtEndereco.Text,
                CPF = TxtCPF.Text.Substring(0, 9)
            };

            Entities context = new Entities();

            context.Cliente.Add(cliente);
            context.SaveChanges();

            LoadGrid();
            SendMessage("Ae, foi!");

            TxtNome.Text = "";
            TxtTelefone.Text = "";
            TxtCidade.Text = "";
            TxtEndereco.Text = "";
            TxtCPF.Text = "";
        }

        private string GerarCPFCompleto(int cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;

            string cpfString = cpf.ToString();

            soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(cpfString[i].ToString()) * multiplicador1[i];
            }

            resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = resto.ToString();

            cpfString = cpfString + digito;

            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(cpfString[i].ToString()) * multiplicador2[i];
            }

            resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = resto.ToString();

            cpfString = cpfString + digito;

            return cpfString.Substring(0, 3) + "." + cpfString.Substring(3, 3) + "." + cpfString.Substring(6, 3) + "-" + cpfString.Substring(9, 2);
        }
    }
}