using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjVendasAula
{
    public partial class CadastroVenda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDDLMaterial();
                LoadDDLFornecedor();
                LoadDDLCliente();
                LoadGrid();
            }
        }

        protected void BtnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            Venda venda = new Venda()
            {
                IdFornecedor = int.Parse(DDLFornecedor.SelectedValue.ToString()),
                IdCliente = int.Parse(DDLClientes.SelectedValue.ToString()),
                IdMaterial = int.Parse(DDLMateriais.SelectedValue.ToString()),
                DataVenda = DateTime.Now
            };

            Entities context = new Entities();

            context.Venda.Add(venda);
            context.SaveChanges();

            LoadGrid();
            SendMessage("Aí sim, a venda foi salva com sucesso!");
        }

        private void LoadGrid()
        {
            Entities context = new Entities();

            var dados = (from v in context.Venda
                         from f in context.Fornecedor.Where(x => x.Id == v.IdFornecedor)
                         from c in context.Cliente.Where(y => y.Id == v.IdCliente)
                         from m in context.Material.Where(z => z.Id == v.IdMaterial)
                         select new
                         {
                             Id = v.Id,
                             Fornecedor = f.Nome,
                             Cliente = c.Nome,
                             Material = m.Descricacao,
                             Data = v.DataVenda
                         }).ToList();

            GVVenda.DataSource = dados;
            GVVenda.DataBind();
        }

        private void LoadDDLMaterial()
        {
            DDLMateriais.DataSource = new Entities().Material.ToList<Material>();
            DDLMateriais.DataTextField = "Descricacao";
            DDLMateriais.DataValueField = "Id";
            DDLMateriais.DataBind();
        }

        private void LoadDDLFornecedor()
        {
            DDLFornecedor.DataSource = new Entities().Fornecedor.ToList<Fornecedor>();
            DDLFornecedor.DataTextField = "Nome";
            DDLFornecedor.DataValueField = "Id";
            DDLFornecedor.DataBind();
        }

        private void LoadDDLCliente()
        {
            DDLClientes.DataSource = new Entities().Cliente.ToList<Cliente>();
            DDLClientes.DataTextField = "Nome";
            DDLClientes.DataValueField = "Id";
            DDLClientes.DataBind();
        }

        private void SendMessage(String msg)
        {
            LblMsg.Text = msg;
        }
    }
}