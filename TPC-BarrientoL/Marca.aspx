<%@ Page Title="Marcas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Marca.aspx.cs" Inherits="TPC_BarrientoL.Marcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <button><a href="FormMarca.aspx">Agregar</a></button>
    <asp:GridView runat="server" ID="dgvMarcas" DataKeyNames="Id" OnSelectedIndexChanged="dgvMarcas_SelectedIndexChanged" OnRowCommand="dgvMarcas_RowCommand" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Marca" DataField="Nombre" />
<%--            <asp:CommandField ShowSelectButton="true" SelectText="Modificar" />
            <asp:CommandField  ShowSelectButton="true" SelectText="Eliminar"  />--%>
            <asp:buttonfield ShowHeader="false" CommandName="Modificar" ButtonType="Button" Text="Modificar"  />
            <asp:buttonfield ShowHeader="false" CommandName="Eliminar" ButtonType="Button" Text="Eliminar" /> 
        </Columns>
    </asp:GridView>
</asp:Content>
