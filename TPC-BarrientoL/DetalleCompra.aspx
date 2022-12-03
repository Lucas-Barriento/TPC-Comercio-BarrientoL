<%@ Page Title="Detalle de la compra" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleCompra.aspx.cs" Inherits="TPC_BarrientoL.DetalleCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <%if (TPC_BarrientoL.Functions.Validaciones.SesionIniciada(Page))
        {
            if (TPC_BarrientoL.Functions.Validaciones.EsAdmin(Page))
            {%>
            <h2><%: Title %></h2>
    <br />
    <br /> 
    <asp:GridView runat="server" ID="dgvDetalleCompras" AutoGenerateColumns="false" DataKeyNames="IdTransaccion" CssClass="table table-condensed table-hover">
        <Columns>
            <asp:BoundField HeaderText="Numero de Compra" DataField="IdTransaccion" />
            <asp:BoundField HeaderText="Producto" DataField="producto.Nombre" />
            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
            <asp:BoundField HeaderText="Precio Parcial" DataField="PrecioParcial" DataFormatString="{0:0.00}" />
        </Columns>
    </asp:GridView>
        <asp:Button Text="Volver" runat="server" PostBackUrl="~/Compra.aspx" />

        <% }
        else
        {%>
    <p>Debes tener cuenta de administrador para ingresar a esta pagina</p>
    <br />
    <a class="nav-link active" aria-current="page" href="Default">Ir al Inicio</a>
    <%}
        }
        else
        {%>
    <p>Debes iniciar sesión para ingresar a esta pagina</p>
    <br />
    <a class="nav-link active" aria-current="page" href="Default">Iniciar sesión</a>
    <%--Response.Redirect("Default.aspx", false);--%>
    <%}%>

</asp:Content>
