<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditItem.aspx.cs" Inherits="DAbile.EditItem" EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:HiddenField id="idItem" runat="server"/>
    <div class="col-md-4 col-md-offset-4 main">
    <div role="form">
    <div class="form-group">
    <asp:Label Text="Marca:" Font-Size="Large" CssClass="block" ToolTip="Modifica o aggiungi la marca" runat="server"></asp:Label><p>  </p>
        <asp:TextBox ID="marca" CssClass="tbox form-control" runat="server"></asp:TextBox></div>
    
    <div class="form-group">
    <asp:Label Text="Prodotto:" Font-Size="Large" CssClass="block" ToolTip="Modifica o aggiungi il prodotto" runat="server"></asp:Label><p>  </p>
        <asp:TextBox ID="prodotto" CssClass="tbox form-control" runat="server"></asp:TextBox></div>
    
    <div class="form-group">
    <asp:Label Text="Quantità:" Font-Size="Large" CssClass="block" ToolTip="Modifica o aggiungi la quantità" runat="server"></asp:Label><p>  </p>
        <asp:TextBox ID="quanti" CssClass="tbox form-control" runat="server"></asp:TextBox></div>
 
    <div class="form-group">
    <asp:Label Text="Scadenza:" Font-Size="Large" CssClass="block" ToolTip="Modifica o aggiungi la scadenza" runat="server"></asp:Label><p>  </p>
        <asp:TextBox ID="scadenza" CssClass="tbox form-control" runat="server"></asp:TextBox></div>

</div>
    <asp:Button ID="btnSalva" CssClass="btn btn-success btn-block" Text="Salva Modifiche" runat="server"  OnCommand="SaveItem"/> 
        </div>
</asp:Content>


