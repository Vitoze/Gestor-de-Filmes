<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Musicas.aspx.cs" Inherits="gestor_filmesWebSite.Add.Musicas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h2> <i class="glyphicon glyphicon-plus"></i>  Adicionar Músicas </h2>
    <br />
   

    <div class="form-group">
        <asp:Label runat="server" CssClass="col-md-2 control-label">Tituto</asp:Label>
        <div class="col-md-4">
            <asp:TextBox watermark="ika" runat="server" ID="TextBox2" CssClass="form-control" />
        </div>
    </div>

    <br /> <br />

    <div class="form-group">
        <asp:Label runat="server"  CssClass="col-md-2 control-label">Genero</asp:Label>
        <div class="col-md-10">
            <asp:DropDownList ID="DropDownList1" CssClass="form-control" Width="280px" runat="server"></asp:DropDownList>
        </div>
    </div>

    <br /> <br />

    <div class="form-group">
        <asp:Label runat="server"  CssClass="col-md-2 control-label">Interprete/Banda</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="TextBox6" CssClass="form-control" />
        </div>
    </div>

    <br /> <br />

    <div class="form-group">
        <asp:Label runat="server"  CssClass="col-md-2 control-label">URL(YouTube)</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control" />
        </div>
    </div>

    <asp:Button ID="Button4" runat="server" Text="Adicionar" data-target="#myModal" data-toggle="modal" CssClass="btn btn-success" Style="margin-top: 36px; margin-left: 210px" />
    <asp:Button ID="Button6" runat="server" OnClick="Button1_Click" Text="Cancelar" CssClass="btn btn-danger" Style="margin-top: 36px"/>

    <!-- Modal -->
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog">
    
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title"><img style="width: 7%; height: 7%"" src="https://cdn0.iconfinder.com/data/icons/round-ui-icons/512/tick_green.png" alt="Mountain View" style="width:174px;">Musica adicionado com sucesso!</h4>
                </div>

                <div class="modal-footer">
                    <asp:Button ID="Button5" OnClick="Button1_Click" CssClass="btn btn-default btn-xs" runat="server"  Text="Fechar" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
