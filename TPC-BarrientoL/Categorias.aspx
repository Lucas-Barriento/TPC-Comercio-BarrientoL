<%@ Page Title="Categorias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="TPC_BarrientoL.Categorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <asp:GridView runat="server" ID="dgvCategorias"></asp:GridView>
</asp:Content>
