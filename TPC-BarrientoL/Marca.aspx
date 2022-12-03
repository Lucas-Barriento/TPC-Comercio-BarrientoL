﻿<%@ Page Title="Marcas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Marca.aspx.cs" Inherits="TPC_BarrientoL.Marcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%if (TPC_BarrientoL.Functions.Validaciones.SesionIniciada(Page))
        {
            if (TPC_BarrientoL.Functions.Validaciones.EsAdmin(Page))
            {%>
    <h2><%: Title %></h2>
    <asp:Button Text="Agregar" runat="server" PostBackUrl="~/FormMarca.aspx" />
    <br />
    <br />
    <asp:GridView runat="server" ID="dgvMarcas" DataKeyNames="Id" OnRowCommand="dgvMarcas_RowCommand" AutoGenerateColumns="false" CssClass="table table-condensed table-hover">
        <Columns>
            <asp:BoundField HeaderText="Marca" DataField="Nombre" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Estado" ControlStyle-CssClass="form-check" />
            <asp:ButtonField ShowHeader="false" CommandName="Modificar" ButtonType="Button" Text="Modificar" />
            <%--<asp:buttonfield ShowHeader="false" CommandName="Eliminar" ButtonType="Button" Text="Eliminar" />--%>
        </Columns>
    </asp:GridView>
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
