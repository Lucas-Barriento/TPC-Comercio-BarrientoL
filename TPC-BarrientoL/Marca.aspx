<%@ Page Title="Marcas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Marca.aspx.cs" Inherits="TPC_BarrientoL.Marcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <asp:Button Text="Agregar" runat="server" PostBackUrl="~/FormMarca.aspx" />
    <br />
    <br />
    <asp:GridView runat="server" ID="dgvMarcas" DataKeyNames="Id" OnRowCommand="dgvMarcas_RowCommand" AutoGenerateColumns="false" CssClass="table table-condensed table-hover">
        <Columns>
            <asp:BoundField HeaderText="Marca" DataField="Nombre" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Estado" ControlStyle-CssClass="form-check" />
            <asp:buttonfield ShowHeader="false" CommandName="Modificar" ButtonType="Button" Text="Modificar"  />
            <%--<asp:buttonfield ShowHeader="false" CommandName="Eliminar" ButtonType="Button" Text="Eliminar" />--%>
            
        </Columns>
    </asp:GridView>
</asp:Content>
