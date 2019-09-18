using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjVendasAula
{
    public partial class CadastroMaterial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDDLTipo();
                LoadDDLFornecedor();
                LoadGrid();
            }
        }

        protected void BtnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            Material material = new Material()
            {
                Descricacao = TxtDescricao.Text,
                DataEntrada = DateTime.Now,
                IdTipo = int.Parse(DDLTipo.SelectedValue.ToString()),
                Valor = Decimal.Parse(TxtValor.Text),
                IdFornecedor = int.Parse(DDLFornecedor.SelectedValue.ToString()),
            };

            Entities context = new Entities();

            context.Material.Add(material);
            context.SaveChanges();

            LoadGrid();
            SendMessage("Boa mano, deu bom!");

            TxtDescricao.Text = "";
            TxtValor.Text = "";
        }

        private void LoadGrid()
        {
            Entities context = new Entities();

            var dados = (from m in context.Material
                         from t in context.Tipo.Where(x => x.Id == m.IdTipo)
                         from f in context.Fornecedor.Where(y => y.Id == m.IdFornecedor)
                         select new
                         {
                             Id = m.Id,
                             Descricao = m.Descricacao,
                             DataEntrada = m.DataEntrada,
                             Tipo = t.Descricao,
                             Valor = m.Valor,
                             Fornecedor = f.Nome
                         }).ToList();

            GVMateriais.DataSource = dados;
            GVMateriais.DataBind();
        }

        private void LoadDDLTipo()
        {
            DDLTipo.DataSource = new Entities().Tipo.ToList<Tipo>();
            DDLTipo.DataTextField = "Descricao";
            DDLTipo.DataValueField = "Id";
            DDLTipo.DataBind();
        }

        private void LoadDDLFornecedor()
        {
            DDLFornecedor.DataSource = new Entities().Fornecedor.ToList<Fornecedor>();
            DDLFornecedor.DataTextField = "Nome";
            DDLFornecedor.DataValueField = "Id";
            DDLFornecedor.DataBind();
        }

        private void SendMessage(String msg)
        {
            LblMsg.Text = msg;
        }
    }
}