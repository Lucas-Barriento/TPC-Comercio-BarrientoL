<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="TPC_BarrientoL.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <asp:Button Text="Agregar" runat="server" PostBackUrl="~/FormProducto.aspx" />
    <br />
    <br />
    <asp:GridView runat="server" ID="dgvProductos" AutoGenerateColumns="false" DataKeyNames="ID" OnRowCommand="dgvProductos_RowCommand" CssClass="table table-condensed table-hover">
        <Columns>
               <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
               <asp:BoundField HeaderText="Marca" DataField="Marca.Nombre" />
               <asp:BoundField HeaderText="Categoria" DataField="Categoria.Nombre" />
               <asp:BoundField HeaderText="Stock" DataField="Stock" />
               <asp:BoundField HeaderText="Stock Minimo" DataField="StockMinimo" />
               <asp:BoundField HeaderText="% Ganancia" DataField="PorcentajeGanancia" />
               <asp:CheckBoxField HeaderText="Activo" DataField="Estado" ControlStyle-CssClass="form-check" />
               <asp:buttonfield ShowHeader="false" CommandName="Modificar" ButtonType="Button" Text="Modificar"  />
               <%--<asp:buttonfield ShowHeader="false" CommandName="Eliminar" ButtonType="Button" Text="Eliminar" />--%>
        </Columns>
    </asp:GridView>

</asp:Content>
