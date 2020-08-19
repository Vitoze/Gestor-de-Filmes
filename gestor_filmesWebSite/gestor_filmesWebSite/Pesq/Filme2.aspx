<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Filme2.aspx.cs" Inherits="gestor_filmesWebSite.Pesq.Filme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .left
        {
	        float: left;
        }

        .right
        {
	        float: right;
        }
    </style>

    <br />
    <br />
    <h2> <i class="glyphicon glyphicon-search"></i>  Pesquisar filme </h2>
    <br />

    <div class="col-md-10">
        <span class="label label-default">Resultados</span>
        &nbsp; &nbsp; 
        1
    </div>

    <div class="col-md-2">
        <span class="label label-default">Palavras chave</span>
        &nbsp; &nbsp; 
        2012


    </div>



    <br /> 
    <br /> 
    <div class="panel panel-success">
        <div class="panel-heading">
            <h1 class="panel-title" > Capitão América &nbsp; &nbsp; <span class="glyphicon glyphicon-list-alt" aria-hidden="true"></span> 2009 &nbsp; <span class="glyphicon glyphicon-time" aria-hidden="true"></span> 158  &nbsp; &nbsp; <span class="glyphicon glyphicon-tag" aria-hidden="true"></span> aventura </h1> 
        </div>
        <div class="panel-body">
            <div class="col-md-2 center">
                <center>
                    <img src="../image/2012_Poster.jpg" alt="Mountain View" style="width:154px;">
                    <br />
                    <center>
                        <span class="glyphicon glyphicon-star" aria-hidden="true"></span>
                        <span class="glyphicon glyphicon-star" aria-hidden="true"></span>
                        <span class="glyphicon glyphicon-star" aria-hidden="true"></span>
                        <span class="glyphicon glyphicon-star" aria-hidden="true"></span>
                        <span class="glyphicon glyphicon-star-empty" aria-hidden="true"></span>
                        <span class="glyphicon glyphicon-star-empty" aria-hidden="true"></span>
                    </center>
                </center>
            </div>

            <div class="col-md-10">
                <h4>Descrição</h4>
                <h5> filme de catástrofe</h5>
                <h4>Atores</h4>
                <h5><a href="~/Details/Ator.aspx">Chiwetel Ejiofor</a> , <a href="../Details/Atores">Amanda Peet</a> , <a href="~/Details/Ator.aspx">Woody Harrelson</a></h5> 
                <h4>Prémios</h4>
                <h5>Grammy: Melhor filme de aventura</h5>
                <br />
                <a href="../Details/Filme2" class="btn btn-default btn-sm" " style="float: right;">Mais detalhes... </a>
            </div>
        </div>
    </div>


   <br /> 


</asp:Content>
