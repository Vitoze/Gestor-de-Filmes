﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Premios.aspx.cs" Inherits="gestor_filmesWebSite.Add.Premios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h2> <i class="glyphicon glyphicon-plus"></i>  Adicionar Prémios </h2>
    <br />


     <div class="form-group">
        <asp:Label runat="server" CssClass="col-md-2 control-label">Filmes </asp:Label>
        <div class="col-md-4">
            <asp:DropDownList ID="DropDownList2" CssClass="form-control" Width="280px" runat="server"></asp:DropDownList>
        </div>
    </div>

    <br /> <br />

    <div class="form-group">
        <asp:Label runat="server"  CssClass="col-md-2 control-label">Ano </asp:Label>
        <div class="col-md-10">
            <asp:TextBox watermark="ika" runat="server" ID="TextBox9" CssClass="form-control" />

        </div>
    </div>

        <br /> <br />





    <div class="form-group">
        <asp:Label runat="server"  CssClass="col-md-2 control-label">Tipo </asp:Label>
        <div class="col-md-10">
            <asp:TextBox watermark="ika" runat="server" ID="TextBox5" CssClass="form-control" />

        </div>
    </div>

    <br /> <br />  

    <div class="form-group">
        <asp:Label runat="server"  CssClass="col-md-2 control-label">Descrição </asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="TextBox6" TextMode="multiline"  Columns="50" Rows="5" CssClass="form-control" />
        </div>
    </div>

    <br /> <br />  
    <br /> <br />  



    <button type="button" class="btn btn-success" data-toggle="modal" style="margin-top: 36px; margin-left: 210px" data-target="#myModal">Adicionar</button>

    <asp:Button ID="Button3" runat="server" OnClick="Button1_Click"  Text="Cancelar" CssClass="btn btn-danger" Style="margin-top: 36px"/>



          <!-- Modal -->
  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
        <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title"><img style="width: 7%; height: 7%"" src="https://cdn0.iconfinder.com/data/icons/round-ui-icons/512/tick_green.png" alt="Mountain View" style="width:174px;">Prémio adiciona ao filme "2012" com sucesso!</h4>
        </div>

        <div class="modal-footer">
            <asp:Button ID="Button5" CssClass="btn btn-default btn-xs" runat="server" OnClick="Button1_Click" Text="Fechar" />
        </div>
      </div>




    </div>
  </div>


</asp:Content>
