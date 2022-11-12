<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormProducto.aspx.cs" Inherits="TPC_BarrientoL.FormProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <%-- ID Nombre Marca Categoria Stock StockMinimo PorcentajeGanancia Estado --%>
        <div class="col-6">
            <div class="mb-3">
                <asp:Label ID="lblId" Text="Id" runat="server" for="txtBoxId" />
                <asp:TextBox ID="txtBoxId" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtBoxNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtBoxNombre" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca</label>
                <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoria</label>
                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtBoxStock" class="form-label">Stock</label>
                <asp:TextBox ID="txtBoxStock" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtBoxStockMinimo" class="form-label">Stock Minimo</label>
                <asp:TextBox ID="txtBoxStockMinimo" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtBoxGanancia" class="form-label">% Ganancia</label>
                <asp:TextBox ID="txtBoxGanancia" runat="server" CssClass="form-control" />
            </div>
                <formview>
                    <asp:RadioButton ID="rbActivo" Text="Activo" runat="server" GroupName="RadioGroup1" />
                    <asp:RadioButton ID="rbInactivo" Text="Inactivo" runat="server" GroupName="RadioGroup1" />
                </formview>
                <%--<asp:CheckBox Text="Activo" runat="server" Checked="true" />--%>
            
            <div class="mb-3">
                <asp:Button Text="Guardar" ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" />
                <asp:Button Text="Cancelar" ID="btnCancelar" runat="server" OnClick="btnCancelar_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
