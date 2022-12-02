<%@ Page Title="Compras" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Compra.aspx.cs" Inherits="TPC_BarrientoL.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <%if (TPC_BarrientoL.Functions.Validaciones.SesionIniciada(Page))
        {
            if (TPC_BarrientoL.Functions.Validaciones.EsAdmin(Page))
            {%>
    <h2><%: Title %></h2>
    <asp:Button Text="Agregar" runat="server" PostBackUrl="~/FormCompra.aspx" />
    <br />
    <br />
        <asp:GridView runat="server" ID="dgvCompras" DataKeyNames="Id" AutoGenerateColumns="false" OnRowCommand="dgvCompras_RowCommand" CssClass="table table-condensed table-hover">
            <Columns>
                <asp:BoundField HeaderText="Proveedor" DataField="Proveedor.Nombre" />
                <asp:BoundField HeaderText="Fecha" DataField="FechaCompra" DataFormatString = "{0:dd/MM/yyyy}"/>
                <asp:BoundField HeaderText="Total" DataField="PrecioTotal" DataFormatString="{0:0.00}"/>
                <asp:buttonfield ShowHeader="false" CommandName="Detalle" ButtonType="Button" Text="Ver Detalle" />
            </Columns>
        </asp:GridView>
             <% }
              else{%>
    <p>Debes tener cuenta de administrador para ingresar a esta pagina</p>
    <br />
    <a class="nav-link active" aria-current="page" href="Default">Ir al Inicio</a>
         <%}
             }
             else{%>
                    <p>Debes iniciar sesión para ingresar a esta pagina</p>
                    <br />
                    <a class="nav-link active" aria-current="page" href="Default">Iniciar sesión</a>
                    <%--Response.Redirect("Default.aspx", false);--%>
               <%}%>
</asp:Content>
