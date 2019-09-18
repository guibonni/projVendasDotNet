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
            GVFornecedor.DataSource = new Entities().Fornecedor.ToList<Fornecedor>();
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
                CNPJ = Int32.Parse(TxtCNPJ.Text.Substring(0, 8))
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
    }
}