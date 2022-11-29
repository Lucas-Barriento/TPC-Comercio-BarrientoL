<%@ Page Title="Compras" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Compra.aspx.cs" Inherits="TPC_BarrientoL.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <asp:Button Text="Agregar" runat="server" PostBackUrl="~/FormCompra.aspx" />
    <br />
    <br />
        <asp:GridView runat="server" ID="dgvCompras" DataKeyNames="Id" AutoGenerateColumns="false" OnRowCommand="dgvCompras_RowCommand" CssClass="table table-condensed table-hover">
            <Columns>
                <%-- cargar datos Proveedor FechaCompra PrecioTotal  --%>
                <asp:BoundField HeaderText="Proveedor" DataField="Proveedor.Nombre" />
                <asp:BoundField HeaderText="Fecha" DataField="FechaCompra" DataFormatString = "{0:dd/MM/yyyy}"/>
                <asp:BoundField HeaderText="Total" DataField="PrecioTotal" DataFormatString="{0:0.00}"/>
                <asp:buttonfield ShowHeader="false" CommandName="Detalle" ButtonType="Button" Text="Ver Detalle" />
<%--<%--            <asp:CheckBoxField HeaderText="Activo" DataField="Estado" ControlStyle-CssClass="form-check" />
                <asp:buttonfield ShowHeader="false" CommandName="Modificar" ButtonType="Button" Text="Modificar"  />--%>
                
            </Columns>
        </asp:GridView>

</asp:Content>
