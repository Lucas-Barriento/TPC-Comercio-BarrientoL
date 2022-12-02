<%@ Page Title="Ventas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Venta.aspx.cs" Inherits="TPC_BarrientoL.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%if (TPC_BarrientoL.Functions.Validaciones.SesionIniciada(Page))
        { %>
    <h2><%: Title %></h2>
    <asp:Button Text="Agregar" runat="server" PostBackUrl="~/FormVenta.aspx" />
    <br />
    <br /> 
    <asp:GridView runat="server" ID="dgvVentas" AutoGenerateColumns="false" DataKeyNames="IdVenta" OnRowCommand="dgvVentas_RowCommand" CssClass="table table-condensed table-hover">
        <Columns>
            <asp:BoundField HeaderText="Factura" DataField="IdVenta" />
            <asp:BoundField HeaderText="Apellido" DataField="cliente.Apellido" />
            <asp:BoundField HeaderText="Nombre" DataField="cliente.Nombre" />
            <asp:BoundField HeaderText="Precio Total" DataField="PrecioTotal" />
            <asp:buttonfield ShowHeader="false" CommandName="Detalle" ButtonType="Button" Text="Ver Detalle"  />
        </Columns>
    </asp:GridView>
       <% }
             else{%>
                    <p>Debes iniciar sesión para ingresar a esta pagina</p>
                    <br />
                    <a class="nav-link active" aria-current="page" href="Default">Iniciar sesión</a>
                    <%--Response.Redirect("Default.aspx", false);--%>
               <%}%>
</asp:Content>
