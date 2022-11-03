<%@ Page Title="Marcas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="TPC_BarrientoL.Marcas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <asp:GridView runat="server" ID="dgvMarcas"></asp:GridView>
</asp:Content>
