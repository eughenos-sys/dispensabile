<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DAbile.Default" EnableEventValidation="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
<div class="header">
    <nav class="navbar navbar-custom navbar-fixed-top" role="navigation">
        <div class="container-fluid">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#">DispensAbile 1.0.2[b]</a>
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse navbar-right" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav">
                    <li class=""><a class="" href="EditItem.aspx">Aggiungi Item</a></li>
                    <li class=""><a href="slides-deck.html" target="_blank">Tutorial</a></li>
                    <li class=""><a href="javascript:window.print()">Stampa Tabella</a></li>
                    <li class=""><a href="about.html">About</a></li>
                    <li class=""><a href="http://www.webmakeup.com/">WEB MAKEUP</a></li>
                </ul>
            </div><!-- /.navbar-collapse -->
        </div><!-- /.container-fluid -->
    </nav>
</div>


    <asp:GridView ID="ItemGrid" CssClass="table table-condensed" runat="server" OnRowCommand="ItemGrid_RowCommand" OnRowDeleting="ItemGrid_RowDeleting" AutoGenerateColumns="False" ClientIDMode="Static" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" />
            <asp:BoundField DataField="marca" HeaderText="Marca" />
            <asp:BoundField DataField="prodotto" HeaderText="Prodotto" />
            <asp:BoundField DataField="quanti" HeaderText="Quantità" />
            <asp:BoundField DataField="scadenza" HeaderText="Data Di Scadenza" />
            <asp:TemplateField HeaderText="Comandi">
                <ItemTemplate>
                    <a href="EditItem.aspx?idItem=<%# Eval("id") %>" class="btn btn-warning">Modifica</a>
                    <asp:Button ID="delBut" CssClass="btn btn-danger" runat="server" CommandName="Delete" OnClientClick="return confirm('Sei sicuro di voler eliminare questa pagina? L\' Operazione è irreversibile');" Text="Elimina" CommandArgument='<%# Bind("id") %>' />
                </ItemTemplate>
                <ItemStyle Width="300px" />
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#999999"></EditRowStyle>

        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

        <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

        <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

        <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>

        <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>

        <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>

        <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>
    </asp:GridView>
</asp:Content>
