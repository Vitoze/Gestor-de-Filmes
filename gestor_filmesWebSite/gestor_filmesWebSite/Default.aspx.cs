using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace gestor_filmesWebSite
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e){
            //das.PreviewKeyDown += EnterClicked;



        }



        protected void SubmitBtn_Click(object sender, EventArgs e)
        {

            if (dr.Items.FindByValue("filme").Selected && das.Text == "2012")
                Response.Redirect("~/Pesq/Filme2");
            else if (dr.Items.FindByValue("filme").Selected)
                Response.Redirect("~/Pesq/Filme");
            else if (dr.Items.FindByValue("atores").Selected && (das.Text == "cameron" || das.Text == "Cameron"))
                Response.Redirect("~/Pesq/Ator");
            else
                Response.Redirect("~/Pesq/notFound"); 



        }
    }
}