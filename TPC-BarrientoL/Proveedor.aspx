<%@ Page Title="Proveedores" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Proveedor.aspx.cs" Inherits="TPC_BarrientoL.Proveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <asp:Button Text="Agregar" runat="server" PostBackUrl="~/FormProveedor.aspx"/>
    <br />
    <br />
    <asp:GridView runat="server" ID="dgvProveedores" DataKeyNames="ID" OnRowCommand="dgvProveedores_RowCommand" AutoGenerateColumns="false" CssClass="table table-condensed table-hover">
        <Columns>
            <asp:BoundField HeaderText="Proveedor" DataField="Nombre" />
            <asp:BoundField HeaderText="Domicilio" DataField="Domicilio" />
            <asp:BoundField HeaderText="Localidad" DataField="Localidad" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Estado" ControlStyle-CssClass="form-check" />
            <asp:ButtonField ShowHeader="false" CommandName="Modificar" ButtonType="Button" Text="Modificar" />
            <%--<asp:ButtonField ShowHeader="false" CommandName="Eliminar" ButtonType="Button" Text="Eliminar" />--%>
        </Columns>
    </asp:GridView>
</asp:Content>
