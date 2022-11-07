<%@ Page Title="Modificar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormMarca.aspx.cs" Inherits="TPC_BarrientoL.FormMarca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%-- HACER FORMULARIO PARA MODIFICAR --%>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtBoxId" class="form-label">Id</label>
                <asp:TextBox ID="txtBoxId" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtBoxNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtBoxNombre" runat="server" CssClass="form-control"/>
            </div>
            <div class="mb-3" >
                <asp:Button Text="Guardar" ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" />
                <asp:Button Text="Cancelar" ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
