using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace gestor_filmesWebSite.Add
{
    public partial class Atores : System.Web.UI.Page
    {
        SqlConnection cnn;

        protected void Page_Load(object sender, EventArgs e)
        {

            var mes = new List<string> {
                "Janeiro", "Feveiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", 
                "Outubro", "Novembro", "Dezembro" };

            var dia = new List<int> { 01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31};


            for (int i =1970; i<2015; i++)
                ddlYear.Items.Add(i.ToString()); 

            ddlDay.DataSource = dia;
            ddlMonth.DataSource = mes;

            ddlDay.DataBind();
            ddlMonth.DataBind();
            ddlYear.DataBind(); 





        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }
    }



}
