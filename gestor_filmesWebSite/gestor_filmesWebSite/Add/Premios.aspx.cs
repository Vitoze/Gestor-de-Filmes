using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gestor_filmesWebSite.Add
{
    public partial class Premios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var filmes = new List<string> {
                " Deadpool","2012", "Intocáveis", "De Volta para o Futuro", "De Volta Para o Futuro 2" , "O Fabuloso Destino de Amélie Poulain"
            };


            filmes.Sort();


            DropDownList2.DataSource = filmes;
            DropDownList2.DataBind();


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }

    }
}