using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjVendasAula
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnTipo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastroTipo.aspx");
        }

        protected void BtnCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastroCliente.aspx");
        }

        protected void BtnFornecedor_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastroFornecedor.aspx");
        }

        protected void BtnMaterial_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastroMaterial.aspx");
        }

        protected void BtnVenda_Click(object sender, EventArgs e)
        {
            Response.Redirect("Venda.aspx");
        }
    }
}