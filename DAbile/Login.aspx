<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DAbile.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="col-md-4 col-md-offset-4 main">
    <div role="form">
    <div class="form-group">
    <asp:Label Text="Username:" Font-Size="Large" CssClass="block" ToolTip="Username" runat="server"></asp:Label><p>  </p>
        <asp:TextBox ID="UserBox" CssClass="tbox form-control" runat="server"></asp:TextBox></div>
    
    <div class="form-group">
    <asp:Label Text="Password:" Font-Size="Large" CssClass="block" ToolTip="Password" runat="server"></asp:Label><p>  </p>
        <asp:TextBox ID="PassBox" CssClass="tbox form-control" TextMode="Password" runat="server"></asp:TextBox></div>

</div>
    <asp:Button ID="Bottone" CssClass="btn btn-success btn-block" Text="Login" OnClick="FormLogin" style="margin:0 auto" runat="server" />
        </div>
</asp:Content>
