<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPC_BarrientoL._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%if (!(TPC_BarrientoL.Functions.Validaciones.SesionIniciada(Page)))
        { %>
    <h2>Iniciar sesión</h2>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label ID="lblUsuario" Text="Usuario" runat="server" for="txtUsuario" />
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:Label ID="lblPass" Text="Contraseña" runat="server" for="txtPass" />
                <asp:TextBox TextMode="Password" ID="txtPass" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:Button Text="Ingresar" ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" />
                <%--<asp:Button Text="Cancelar" ID="btnCancelar" runat="server" OnClick="btnCancelar_Click"/>--%>
            </div>
        </div>
    </div>
    <%}
        else
        {%>
    <h2>Sesion iniciada</h2>
    <asp:Button Text="Cerrar Sesión" runat="server" ID="btnCerrarSesion" OnClick="btnCerrarSesion_Click" />
    <%}%>
</asp:Content>
