using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gestor_filmesWebSite.Add
{
    public partial class Musicas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var makes = new List<string> {
                "Hip hop", "Punk", "Pop", "Rock", "Heavy metal", "Jazz", "Electro"
            };
            makes.Sort();

            DropDownList1.DataSource = makes;
            DropDownList1.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }
    }
}