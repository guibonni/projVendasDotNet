using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjVendasAula
{
    public partial class CadastroTipo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            Tipo tipo = new Tipo()
            {
                Descricao = TxtDescricao.Text
            };

            Entities context = new Entities();

            context.Tipo.Add(tipo);
            context.SaveChanges();

            LoadGrid();
            SendMessage("Deu bom mano");

            TxtDescricao.Text = "";
        }

        private void LoadGrid()
        {
            GVTipo.DataSource = new Entities().Tipo.ToList<Tipo>();
            GVTipo.DataBind();
        }

        private void SendMessage(string msg)
        {
            LblMsg.Text = msg;
        }

        protected void BtnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}