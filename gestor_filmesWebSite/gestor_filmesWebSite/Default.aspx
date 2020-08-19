<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="gestor_filmesWebSite._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

    <script src="Scripts/responsiveslides.min.js"></script>
    <link href="Content/responsiveslides.css" rel="stylesheet" />

    <script src="js/jquery.slides.min.js"></script>

  <script>
    $(function() {
      $('#slides').slidesjs({
        width: 1640,
        height: 528,
        navigation: false,
          play:{
              auto: true
          }
      });
    });
  </script>


<!-- SlidesJS Optional: If you'd like to use this design -->
  <style>
    body {
      -webkit-font-smoothing: antialiased;
      font: normal 15px/1.5 "Helvetica Neue", Helvetica, Arial, sans-serif;
      color: #232525;
      padding-top:70px;
    }

    #slides {
      display: none
    }

    #slides .slidesjs-navigation {
      margin-top:3px;
    }

    #slides .slidesjs-previous {
      margin-right: 5px;
      float: left;
    }

    #slides .slidesjs-next {
      margin-right: 5px;
      float: left;
    }

    .slidesjs-pagination {
      margin: 6px 0 0;
      float: right;
      list-style: none;
    }

    .slidesjs-pagination li {
      float: left;
      margin: 0 1px;
    }

    .slidesjs-pagination li a {
      display: block;
      width: 13px;
      height: 0;
      padding-top: 13px;
      background-image: url(img/pagination.png);
      background-position: 0 0;
      float: left;
      overflow: hidden;
    }

    .slidesjs-pagination li a.active,
    .slidesjs-pagination li a:hover.active {
      background-position: 0 -13px
    }

    .slidesjs-pagination li a:hover {
      background-position: 0 -26px
    }

    #slides a:link,
    #slides a:visited {
      color: #333
    }

    #slides a:hover,
    #slides a:active {
      color: #9e2020
    }

  </style>
  <!-- End SlidesJS Optional-->

  <!-- SlidesJS Required: These styles are required if you'd like a responsive slideshow -->
  <style>
    #slides {
      display: none
    }

    .container {
      margin: 0 auto
    }


    /* For tablets & smart phones */
    @media (max-width: 767px) {
      body {
        padding-left: 20px;
        padding-right: 20px;
      }
      .container {
        width: auto
      }
    }

    /* For smartphones */
    @media (max-width: 480px) {
      .container {
        width: auto
      }
    }

    /* For smaller displays like laptops */
    @media (min-width: 768px) and (max-width: 979px) {
      .container {
        width: 724px
      }
    }

    /* For larger displays */
    @media (min-width: 1200px) {
      .container {
        width: 1170px
      }
    }
  </style>

    
    <div class="jumbotron container">
    <div id="slides">
      <img src="img/example-slide-1.jpg" alt="">
      <img src="img/example-slide-2.jpg" alt="">
      <img src="img/example-slide-3.jpg" alt="">
      <img src="img/example-slide-4.jpg" alt="">
      <a href="#" class="slidesjs-previous slidesjs-navigation"><i class="icon-chevron-left icon-large"></i></a>
      <a href="#" class="slidesjs-next slidesjs-navigation"><i class="icon-chevron-right icon-large"></i></a>
    </div>
  </div>




    <div class="container">
    <div class="row">    
        <div class="jumbotron col-xs-8 col-xs-offset-2"  >
            
            <div class="col-md-3">
                Filtrar por 
                
                <asp:DropDownList CssClass="form-control" ID="dr" runat="server">
                    <asp:ListItem Value="all" Selected="True">Todos</asp:ListItem>
                    <asp:ListItem Value="filme">Filme</asp:ListItem>
                    <asp:ListItem Value="atores">Atores</asp:ListItem>
                    <asp:ListItem Value="director">Director</asp:ListItem>
                    <asp:ListItem Value="escritor">Escritor</asp:ListItem>
                    <asp:ListItem Value="musica">Música</asp:ListItem>
                </asp:DropDownList>


            </div>
            
            
                <div class="col-md-6">
                    <br />
                    
                    
                    <asp:Panel runat="server" DefaultButton="Button1">
                        <asp:TextBox runat="server" PreviewKeyDown="EnterClicked" placeholder="Pesquisar termo..." ID="das" CssClass="form-control"></asp:TextBox>
                        <asp:Button ID="Button1" runat="server" OnClick="SubmitBtn_Click" Style="display: none" />
                    </asp:Panel>
                
                </div>
            

                <div class="col-md-3" >
                    <br />
                    <asp:LinkButton ID="SubmitBtn" runat="server"  CssClass="btn btn-default" OnClick="SubmitBtn_Click"><i class=" glyphicon glyphicon-search"></i></asp:LinkButton>
                </div>


        </div>
    </div>
</div>






</asp:Content>
