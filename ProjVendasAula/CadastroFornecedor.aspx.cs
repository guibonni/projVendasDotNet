using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjVendasAula
{
    public partial class CadastroFornecedor : System.Web.UI.Page
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
            List<Fornecedor> fornecedores = new Entities().Fornecedor.ToList<Fornecedor>();
            foreach (Fornecedor fornecedor in fornecedores)
            {
                fornecedor.CNPJ = GerarCNPJCompleto(fornecedor.CNPJ);
            }

            GVFornecedor.DataSource = fornecedores;
            GVFornecedor.DataBind();
        }

        private void SendMessage(string msg)
        {
            LblMsg.Text = msg;
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            Fornecedor fornecedor = new Fornecedor()
            {
                Nome = TxtNomeFornecedor.Text,
                Telefone = TxtTelefoneFornecedor.Text,
                Cidade = TxtCidadeFornecedor.Text,
                Endereco = TxtEnderecoFornecedor.Text,
                CNPJ = TxtCNPJ.Text.Substring(0, 12)
            };

            Entities context = new Entities();

            context.Fornecedor.Add(fornecedor);
            context.SaveChanges();

            LoadGrid();
            SendMessage("Deu certo irmão!");

            TxtNomeFornecedor.Text = "";
            TxtTelefoneFornecedor.Text = "";
            TxtCidadeFornecedor.Text = "";
            TxtEnderecoFornecedor.Text = "";
            TxtCNPJ.Text = "";
        }

        private string GerarCNPJCompleto(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            tempCnpj = cnpj.Trim();

            soma = 0;

            for (int i = 0; i < 12; i++)
            {
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            }

            resto = (soma % 11);

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = resto.ToString();

            tempCnpj = tempCnpj + digito;

            soma = 0;

            for (int i = 0; i < 13; i++)
            {
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            }

            resto = (soma % 11);

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = resto.ToString();

            tempCnpj = tempCnpj + digito;

            return tempCnpj.Substring(0, 2) + "." + tempCnpj.Substring(2, 3) + "." + tempCnpj.Substring(5, 3) + "/" + tempCnpj.Substring(8, 4) + "-" + tempCnpj.Substring(12, 2);
        }
    }
}
