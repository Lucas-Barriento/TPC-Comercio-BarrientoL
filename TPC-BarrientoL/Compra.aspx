<%@ Page Title="Compras" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Compra.aspx.cs" Inherits="TPC_BarrientoL.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <asp:Button Text="Agregar" runat="server" PostBackUrl="~/FormCompra.aspx" />
    <br />
    <br />
        <asp:GridView runat="server" ID="dgvCompras" DataKeyNames="Id" AutoGenerateColumns="false" OnRowCommand="dgvCompras_RowCommand">
            <Columns>
                <%-- cargar datos Proveedor FechaCompra PrecioTotal  --%>
                <asp:BoundField HeaderText="Proveedor" DataField="Proveedor.Nombre" />
                <asp:BoundField HeaderText="Fecha" DataField="FechaCompra" DataFormatString = "{0:dd/MM/yyyy}"/>
                <asp:BoundField HeaderText="Total" DataField="PrecioTotal" />
                <asp:CheckBoxField HeaderText="Activo" DataField="Estado" ControlStyle-CssClass="form-check" />
                <asp:buttonfield ShowHeader="false" CommandName="Modificar" ButtonType="Button" Text="Modificar"  />
                <asp:buttonfield ShowHeader="false" CommandName="Eliminar" ButtonType="Button" Text="Eliminar" />
            </Columns>
        </asp:GridView>

</asp:Content>
