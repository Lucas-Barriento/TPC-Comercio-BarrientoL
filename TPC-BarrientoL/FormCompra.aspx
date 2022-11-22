<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormCompra.aspx.cs" Inherits="TPC_BarrientoL.FormCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="mb-3">
        <label for="ddlProveedor" class="form-label">Proveedor</label>
        <asp:DropDownList ID="ddlProveedor" runat="server" CssClass="form-select"></asp:DropDownList>
    </div>
    <div id="grillaProductos">
    <asp:GridView runat="server" ID="dgvProductos" AutoGenerateColumns="false" DataKeyNames="ID" OnRowCommand="dgvProductos_RowCommand" CssClass="table table-condensed table-hover">
        <Columns>
            <asp:BoundField HeaderText="Id" DataField="Id" Visible="false" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Nombre" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Nombre" />
            <asp:BoundField HeaderText="Stock" DataField="Stock" />
            <asp:TemplateField HeaderText="Cantidad">
                <ItemTemplate>
                    <asp:TextBox TextMode="Number" runat="server" min="1" step="1" Width="70px" />
                </ItemTemplate>
            </asp:TemplateField>

               <asp:buttonfield ShowHeader="false" CommandName="Agregar" ButtonType="Button" Text="Agregar"  />
        </Columns>
    </asp:GridView>
    </div>
    <div id="listaCompra">
        <p>lista compra</p>
    </div>
</asp:Content>
