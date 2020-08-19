<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Filmes.aspx.cs" Inherits="gestor_filmesWebSite.Add.Filmes" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h2> <i class="glyphicon glyphicon-plus"></i>  Adicionar Filme </h2>
    <br />

    <script type="text/javascript">
        function SearchEmployees(txtSearch, cblEmployees) {
            if ($(txtSearch).val() != "") {
                var count = 0;
                $(cblEmployees).children('tbody').children('tr').each(function () {
                    var match = false;
                    $(this).children('td').children('label').each(function () {
                        if ($(this).text().toUpperCase().indexOf($(txtSearch).val().toUpperCase()) > -1)
                            match = true;
                    });
                    if (match) {
                        $(this).show();
                        count++;
                    }
                    else { $(this).hide(); }
                });
                $('#spnCount').html((count) + ' resultados');
            }
            else {
                $(cblEmployees).children('tbody').children('tr').each(function () {
                    $(this).show();
                });
                $('#spnCount').html('');
            }
        }


        function SearchEmployees2(txtSearch, cblEmployees) {
            if ($(txtSearch).val() != "") {
                var count = 0;
                $(cblEmployees).children('tbody').children('tr').each(function () {
                    var match = false;
                    $(this).children('td').children('label').each(function () {
                        if ($(this).text().toUpperCase().indexOf($(txtSearch).val().toUpperCase()) > -1)
                            match = true;
                    });
                    if (match) {
                        $(this).show();
                        count++;
                    }
                    else { $(this).hide(); }
                });
                $('#spnCount2').html((count) + ' resultados');
            }
            else {
                $(cblEmployees).children('tbody').children('tr').each(function () {
                    $(this).show();
                });
                $('#spnCount2').html('');
            }
        }

        function SearchEmployees3(txtSearch, cblEmployees) {
            if ($(txtSearch).val() != "") {
                var count = 0;
                $(cblEmployees).children('tbody').children('tr').each(function () {
                    var match = false;
                    $(this).children('td').children('label').each(function () {
                        if ($(this).text().toUpperCase().indexOf($(txtSearch).val().toUpperCase()) > -1)
                            match = true;
                    });
                    if (match) {
                        $(this).show();
                        count++;
                    }
                    else { $(this).hide(); }
                });
                $('#spnCount3').html((count) + ' resultados');
            }
            else {
                $(cblEmployees).children('tbody').children('tr').each(function () {
                    $(this).show();
                });
                $('#spnCount3').html('');
            }
        }






    </script>



        




    <div class="form-group">
        <asp:Label runat="server" CssClass="col-md-2 control-label">Titulo </asp:Label>
        <div class="col-md-4">
            <asp:TextBox watermark="ika" runat="server" ID="TextBox4" CssClass="form-control" />
        </div>
    </div>

    <br /> <br />

    <div class="form-group">
        <asp:Label runat="server"  CssClass="col-md-2 control-label">Descrição </asp:Label>
        <div class="col-md-10">
            <asp:TextBox watermark="ika" runat="server" ID="TextBox9" CssClass="form-control" />

        </div>
    </div>



    <br /> <br />

    <div class="form-group">
        <asp:Label runat="server"  CssClass="col-md-2 control-label">Capa </asp:Label>
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
        <asp:Label runat="server"  CssClass="col-md-2 control-label">Ano</asp:Label>
        <div class="col-md-10">
            <asp:DropDownList ID="DropDownList3" CssClass="form-control" Width="280px" runat="server"> </asp:DropDownList>
        </div>
    </div>

    <br /> <br />

    <div class="form-group">
        <asp:Label runat="server"  CssClass="col-md-2 control-label">Duração (min)</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" Width="100px" ID="TextBox5" CssClass="form-control" />
        </div>
    </div>

    <br /> <br />
       

    <div class="form-group">
        <asp:Label runat="server"  CssClass="col-md-2 control-label">Categoria</asp:Label>
        <div class="col-md-10">
            <asp:DropDownList ID="DropDownList2" CssClass="form-control" Width="280px" runat="server"></asp:DropDownList>
        </div>
    </div>


     <br /> <br />


    <div class="form-group">
        <asp:Label runat="server"  CssClass="col-md-2 control-label">Classificação</asp:Label>
        <div class="col-md-10">

            <asp:RadioButtonList RepeatDirection="Horizontal" ID="RadioButtonList1" CssClass="form-control" runat="server">
                <asp:ListItem Text="0&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"  Value="0" /> 
                <asp:ListItem Text="1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"  Value="1" />
                <asp:ListItem Text="2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"  Value="2" />
                <asp:ListItem Text="3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"  Value="3" />
                <asp:ListItem Text="4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"  Value="4" />
                <asp:ListItem Text="5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"  Value="5" />
                <asp:ListItem Text="6&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"  Value="6" />           
            </asp:RadioButtonList>

        </div>
    </div>




    <br /> <br />

    <div class="form-group">
        <asp:Label runat="server"  CssClass="col-md-2 control-label">Companhia</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control" />
        </div>
    </div>

    <br /> <br />

    <div class="form-group">
        <asp:Label runat="server"  CssClass="col-md-2 control-label">Director</asp:Label>
        <div class="col-md-10">
            <asp:DropDownList ID="DropDownList1" CssClass="form-control" Width="280px" runat="server"></asp:DropDownList>
        </div>
    </div>


    <br /> <br />

    <div class="form-group">
        <asp:Label runat="server"  CssClass="col-md-2 control-label">Elenco</asp:Label>
        <div class="col-md-10">
            <asp:TextBox ID="TextBox3" Width="1000px" runat="server" onkeyup="SearchEmployees(this,'#cblEmployees');" placeholder="Filtrar ator">
            </asp:TextBox> <span id="spnCount"></span>
            <div style="width:280px; height:150px; padding:2px; overflow:auto; border: 1px solid #ccc;">
                <asp:CheckBoxList ID="cblEmployees" ClientIDMode="Static" runat="server"></asp:CheckBoxList>
            </div>
            <asp:Button ID="Button1" runat="server" OnClick="addNovoAtor" Text="Adicionar um novo ator" CssClass="btn btn-primary  btn-xs" Style="margin-top: 36px"/>
            <br /> <br />
        </div>
    </div>
    







    <br /> <br />

    <div class="form-group">
        <asp:Label runat="server"  CssClass="col-md-2 control-label">Escritores</asp:Label>
        <div class="col-md-10">
            <asp:TextBox ID="TextBox6" Width="1000px" runat="server" onkeyup="SearchEmployees2(this,'#CheckBoxList2');" placeholder="Filtrar escritor">
            </asp:TextBox> <span id="spnCount2"></span>
            <div style="width:280px; height:150px; padding:2px; overflow:auto; border: 1px solid #ccc;">
                <asp:CheckBoxList ID="CheckBoxList2" ClientIDMode="Static" runat="server"></asp:CheckBoxList>
            </div>
            <asp:Button ID="Button2" runat="server" OnClick="addNovoEscritor" Text="Adicionar um novo escritor" CssClass="btn btn-primary  btn-xs" Style="margin-top: 36px"/>
            <br /> <br />
        </div>
    </div>
    <br /> <br />




    <div class="form-group">
        <asp:Label runat="server"  CssClass="col-md-2 control-label">Banda sonora</asp:Label>
        <div class="col-md-10">
            <asp:TextBox ID="TextBox7" Width="1000px" runat="server" onkeyup="SearchEmployees3(this,'#CheckBoxList3');" placeholder="Filtrar música">
            </asp:TextBox> <span id="spnCount3"></span>
            <div style="width:280px; height:150px; padding:2px; overflow:auto; border: 1px solid #ccc;">
                <asp:CheckBoxList ID="CheckBoxList3" ClientIDMode="Static" runat="server"></asp:CheckBoxList>
            </div>
            <asp:Button ID="Button3" runat="server" OnClick="addNovoMusica" Text="Adicionar uma nova musica" CssClass="btn btn-primary  btn-xs" Style="margin-top: 36px"/>
        </div>
    </div>
    <br /> <br />




    <asp:Button ID="Button4" runat="server" Text="Adicionar" data-target="#myModal" data-toggle="modal" CssClass="btn btn-success" Style="margin-top: 36px; margin-left: 210px" />
    <asp:Button ID="Button6" runat="server" OnClick="Button1_Click" Text="Cancelar" CssClass="btn btn-danger" Style="margin-top: 36px"/>

    <!-- Modal -->
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog">
    
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title"><img style="width: 7%; height: 7%"" src="https://cdn0.iconfinder.com/data/icons/round-ui-icons/512/tick_green.png" alt="Mountain View" style="width:174px;">Filme "2012" adicionado com sucesso!</h4>
                </div>

                <div class="modal-footer">
                    <asp:Button ID="Button5" CssClass="btn btn-default btn-xs" runat="server" OnClick="Button1_Click" Text="Fechar" />
                </div>
            </div>
        </div>
    </div>



</asp:Content>
