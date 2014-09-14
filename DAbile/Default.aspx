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
                <a class="navbar-brand" href="#">DispensAbile 1.1.4[b]</a>
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse navbar-right" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav">
                    <li class=""><a class="btn btn-info btn-xs" href="EditItem.aspx">Aggiungi Item</a></li>
                    <li class=""><a href="slides-deck.html" target="_blank">Tutorial</a></li>
                    <li class=""><a href="javascript:window.print()">Stampa Tabella</a></li>
                    <li class=""><a href="about.html">About</a></li>
                    <li class=""><a href="http://www.webmakeup.com/">WEB MAKEUP</a></li>
                </ul>
            </div><!-- /.navbar-collapse -->
        </div><!-- /.container-fluid -->
    </nav>
</div>


    <asp:GridView ID="ItemGrid" CssClass="table table-condensed" runat="server" OnRowCommand="ItemGrid_RowCommand" OnRowDeleting="ItemGrid_RowDeleting" AutoGenerateColumns="False" ClientIDMode="Static" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
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
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#242121" />
    </asp:GridView>
</asp:Content>
