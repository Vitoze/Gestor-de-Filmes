using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gestor_filmesWebSite.Add
{
    public partial class Filmes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var makes = new List<string> {
                "Ação", "Animação", "Comédia", "Corridas", "Erótico", "Aventura", "Documentário","Drama"
                ,"Fantasia" ,"Ficção" ,"Guerra" ,"Musical" ,"Policial" ,"Religioso" ,"Romance" ,"Terror"
            };


            var ator = new List<string> {
                "Al Pacino ", "Jack Nicholson","Chiwetel Ejiofor", "Amanda Peet", "Woody Harrelson", "Morgan Freeman",
                "Brad Pitt", "Angelina Jolie", "Benedict Cumberbatch" , "Salvador Dalí", "Al Dalí", "Miranda Cosgrove", "Rik Mayall", "Jimmy Fallon"

            };

            var escritor = new List<string> {
                "Roland Emmerich", "Harald Kloser", "Chiwetel Ejiofor", "Amanda Peet", "Arthur C. Clarke ", " Peter Hyams", "Benedict Cumberbatch" , "Salvador Dalí",
            };

            var song = new List<string> {
                "The impact ","Ashes in D.C", "Singin' in the Rain", "Skyfall", "Born to Be Wild"
            };


            var directores = new List<string> {
                "Ingmar Bergman", "Benedict Cumberbatch" ,"Chiwetel Ejiofor", "Amanda Peet", "Salvador Dalí", "Federico Fellini", "Francis Ford Coppola", "Charles Chaplin", "Tim Burton", "Roman Polanski","Roland Emmerich "
            };





            makes.Sort();
            ator.Sort();
            escritor.Sort();
            song.Sort();
            directores.Sort();

            CheckBoxList2.DataSource = escritor;
            CheckBoxList2.DataBind();
            cblEmployees.DataSource = ator;
            cblEmployees.DataBind();
            cblEmployees.DataSource = directores;

            DropDownList1.DataBind();

            for (int i = 1889; i < 2016; i++)
                   DropDownList3.Items.Add(i.ToString());



            CheckBoxList3.DataSource = song;
            CheckBoxList3.DataBind();



            DropDownList2.DataSource = makes;
            DropDownList2.DataBind();

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }

        protected void addNovoAtor(object sender, EventArgs e)
        {
            Response.Redirect("~/Add/Atores");
        }

        protected void addNovoEscritor(object sender, EventArgs e)
        {
            Response.Redirect("~/Add/Escritores");
        }

        protected void addNovoMusica(object sender, EventArgs e)
        {
            Response.Redirect("~/Add/Musicas");
        }
    }
}