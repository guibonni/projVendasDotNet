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
            GVCliente.DataSource = new Entities().Cliente.ToList<Cliente>();
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
                CPF = Int32.Parse(TxtCPF.Text)//TODO: Tratar os roles
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
    }
}