<%@ Page Title="Ventas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Venta.aspx.cs" Inherits="TPC_BarrientoL.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%if (TPC_BarrientoL.Functions.Validaciones.SesionIniciada(Page))
        { %>
    <h2><%: Title %></h2>
    <asp:Button Text="Agregar" runat="server" PostBackUrl="~/FormVenta.aspx" CssClass="btn btn-secondary" />
    <br />
    <br /> 
    <asp:GridView runat="server" ID="dgvVentas" AutoGenerateColumns="false" DataKeyNames="IdVenta" OnRowCommand="dgvVentas_RowCommand" CssClass="table table-dark table-striped">
        <Columns>
            <asp:BoundField HeaderText="Factura" DataField="IdVenta" />
            <asp:BoundField HeaderText="Fecha" DataField="FechaVenta" DataFormatString = "{0:dd/MM/yyyy}"/>
            <asp:BoundField HeaderText="Apellido" DataField="cliente.Apellido" />
            <asp:BoundField HeaderText="Nombre" DataField="cliente.Nombre" />
            <asp:BoundField HeaderText="Precio Total" DataField="PrecioTotal" DataFormatString="{0:0.00}"/>
            <asp:buttonfield ShowHeader="false" CommandName="Detalle" ButtonType="Button" Text="Ver Detalle" ControlStyle-CssClass="btn btn-secondary" />
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
