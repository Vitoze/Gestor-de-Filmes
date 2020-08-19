<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Diretores.aspx.cs" Inherits="gestor_filmesWebSite.Add.Realizadores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h2> <i class="glyphicon glyphicon-plus"></i>  Adicionar Diretor </h2>
    <br />

    <div class="form-group">
        <asp:Label runat="server" CssClass="col-md-2 control-label">Nome: </asp:Label>
        <div class="col-md-4">
            <asp:TextBox watermark="ika" runat="server" ID="TextBox1" CssClass="form-control" />
        </div>
    </div>

    <br /> <br />


    <div class="form-group">
        <asp:Label runat="server"  CssClass="col-md-2 control-label">Foto </asp:Label>
        <div class="col-md-10">

            <asp:TextBox watermark="ika"  placeholder="url" runat="server" ID="TextBox2" CssClass="form-control" />
            <asp:Label runat="server" >ou </asp:Label>

        </div>

    </div>


    <br /> <br />

    <div class="form-group">
        <asp:Label runat="server"  CssClass="col-md-2 control-label"></asp:Label>
        <div class="col-md-10">

            <asp:FileUpload ID="FileUpload1" runat="server"  />


        </div>

    </div>


   

    <br /> <br />

    <div class="form-group">
        <asp:Label runat="server"  CssClass="col-md-2 control-label">Data de Nascimento</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="TextBox4" CssClass="form-control" />
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
                    <h4 class="modal-title"><img style="width: 7%; height: 7%"" src="https://cdn0.iconfinder.com/data/icons/round-ui-icons/512/tick_green.png" alt="Mountain View" style="width:174px;">Diretor adicionado com sucesso!</h4>
                </div>

                <div class="modal-footer">
                    <asp:Button ID="Button5" CssClass="btn btn-default btn-xs" runat="server" OnClick="Button1_Click" Text="Fechar" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
