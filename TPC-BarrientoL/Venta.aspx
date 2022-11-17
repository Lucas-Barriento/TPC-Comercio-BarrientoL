<%@ Page Title="Ventas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Venta.aspx.cs" Inherits="TPC_BarrientoL.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <asp:Button Text="Agregar" runat="server" PostBackUrl="~/FormVenta.aspx" />
    <br />
    <br />
    <asp:GridView runat="server" ID="dgvVentas" AutoGenerateColumns="false" DataKeyNames="IdVenta" OnRowCommand="dgvVentas_RowCommand" CssClass="table table-condensed table-hover">
        <Columns>
            <asp:BoundField HeaderText="Factura" DataField="IdVenta" />
            <asp:BoundField HeaderText="Apellido" DataField="cliente.Apellido" />
            <asp:BoundField HeaderText="Nombre" DataField="cliente.Nombre" />
            <asp:BoundField HeaderText="Precio Total" DataField="PrecioTotal" />
        </Columns>
    </asp:GridView>
</asp:Content>
