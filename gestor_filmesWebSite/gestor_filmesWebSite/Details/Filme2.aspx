<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Filme2.aspx.cs" Inherits="gestor_filmesWebSite.Details.Filme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <h2> <i class="glyphicon glyphicon-film"></i>  2012 </h2>
    <br />

    <br />

    <div class="panel panel-success">
        <div class="panel-heading">
            <h1 class="panel-title" > Geral </h1> 

        </div>
        <div class="panel-body">
            <div class="col-md-3 center">
                <center>
                    <img src="../image/2012_Poster.jpg" alt="Mountain View" style="width:174px;">
                </center>

            </div>

            <div class="col-md-9">
                <h4>Descrição</h4>
                <h5>filme de catástrofe</h5>                
                <h4>Duração</h4>
                <h5>158 min</h5>
                <h4>Classificação</h4>
                <center>
                    <span class="glyphicon glyphicon-star" aria-hidden="true"></span>
                    <span class="glyphicon glyphicon-star" aria-hidden="true"></span>
                    <span class="glyphicon glyphicon-star" aria-hidden="true"></span>
                    <span class="glyphicon glyphicon-star" aria-hidden="true"></span>
                    <span class="glyphicon glyphicon-star-empty" aria-hidden="true"></span>
                    <span class="glyphicon glyphicon-star-empty" aria-hidden="true"></span>
                </center>

                <br />
                <div class="col-md-4">
                    <h4>Director</h4>
                    <h5><a href="url">Roland Emmerich </a></h5>
                </div>
                <div class="col-md-4">
                    <h4>Companhia</h4>
                    <h5>Centropolis</h5>
                </div>
                <div class="col-md-4">
                    <h4>Escritores</h4>
                    <h5><a href="url">Roland Emmerich</a>, <a href="url">Harald Kloser</a></h5>
                </div>
            </div>
        </div>
    </div>



    <br />

    <div class="panel panel-success">
        <div class="panel-heading">
            <h1 class="panel-title" > Elenco </h1> 

        </div>
        <div class="panel-body">
            <div class="col-md-4 center">
                <center>
                    <a href="../Details/Atores"><img src="https://upload.wikimedia.org/wikipedia/commons/7/76/Chiwetel_Ejiofor_TIFF_2015.jpg" alt="Mountain View" style="width:154px;"></a>
                    <br />  <a href="../Details/Atores">Chiwetel Ejiofor</a> 
                </center>
            </div>
            <div class="col-md-4 center">
                <center>
                    <a href="../Details/Atores"><img src="http://ia.media-imdb.com/images/M/MV5BMTk3Nzk0NjgxN15BMl5BanBnXkFtZTcwMzI3NDE1Mg@@._V1_UX214_CR0,0,214,317_AL_.jpg" alt="Mountain View" style="width:154px;"></a>
                    <br />  <a href="../Details/Atores">Amanda Peet</a> 
                </center>
            </div>
            <div class="col-md-4 center">
                <center>
                    <a href="../Details/Atores"><img src="http://supernovo.net/wp-content/uploads/2015/01/triple-nine-02.jpg" alt="Mountain View" style="width:154px;"></a>
                    <br /> <a href="../Details/Atores">Woody Harrelson</a> 
                </center>
            </div>
        </div>
    </div>


    <br />


    <div class="panel panel-success">
        <div class="panel-heading">
            <h1 class="panel-title" > Trailer </h1> 

        </div>
        <div class="panel-body">
            <center>
                <img src="http://www.birocars.az/assets/media/images/main/notavailable_en.png" alt="Mountain View" style="width:254px;">
            </center>
            <div style="text-align: right;"> 
                <a href="../Add/Trailers" class="btn btn-primary btn-xs right">Adicionar novo trailer</a>
            </div>
        </div>
    </div>



    <br />

    <div class="panel panel-success">
        <div class="panel-heading">
            <h1 class="panel-title" > Datas de lançamento </h1> 

        </div>
        <div class="panel-body">
            <center>
                <img src="http://www.birocars.az/assets/media/images/main/notavailable_en.png" alt="Mountain View" style="width:254px;">
            </center>
            <div style="text-align: right;"> 
                <a href="../Add/Lancamento" class="btn btn-primary btn-xs right">Adicionar nova data de lançamento</a>
            </div>
        </div>
    </div>


    <br />

    <div class="panel panel-success">
        <div class="panel-heading">
            <h1 class="panel-title" > Banda sonora </h1> 

        </div>
        <div class="panel-body">
            <div class="col-md-6 center">
                <center>
                    <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/a/ac/No_image_available.svg/2000px-No_image_available.svg.png" alt="Mountain View" style="width:154px;">
                    <br /> The impact
                </center>
            </div>
            <div class="col-md-6 center">
                <center>
                    <img src="https://i.ytimg.com/vi/fj0-pc91aLw/hqdefault.jpg" alt="Mountain View" style="width:194px;">
                    <br /> Ashes in D.C
                </center>
            </div>

        </div>
    </div>



    
    <br />

    <div class="panel panel-success">
        <div class="panel-heading">
            <h1 class="panel-title" > Prémios </h1> 

        </div>
        <div class="panel-body">

            <center>
                <h4>2010</h4>
                <img width="50px" src="../image/winner_icon_1x.png" />
                <h3>Grammy</h3>
                <h4>Melhor filme de aventura</h4>

            </center>
           
            <div style="text-align: right;"> 
                <a href="../Add/Premios" class="btn btn-primary btn-xs right">Adicionar novo prémio</a>
            </div>
        </div>

    </div>


</asp:Content>
