<%@ Page Title="Categorias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categoria.aspx.cs" Inherits="TPC_BarrientoL.Categorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <asp:Button Text="Agregar" runat="server" PostBackUrl="~/FormCategoria.aspx"/>
    <br />
    <br />
    <asp:GridView runat="server" ID="dgvCategorias" DataKeyNames="Id" OnRowCommand="dgvCategorias_RowCommand" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Categoria" DataField="Nombre" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Estado" ControlStyle-CssClass="form-check" />
            <asp:ButtonField ShowHeader="false" CommandName="Modificar" ButtonType="Button" Text="Modificar" />
            <asp:ButtonField ShowHeader="false" CommandName="Eliminar" ButtonType="Button" Text="Eliminar" />
        </Columns>
    </asp:GridView>
</asp:Content>
