<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormCompra.aspx.cs" Inherits="TPC_BarrientoL.FormCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="mb-3">
        <label for="ddlProveedor" class="form-label">Proveedor</label>
        <asp:DropDownList ID="ddlProveedor" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddlProveedor_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
    </div>
    <div id="grillaProductos">  
    <asp:GridView runat="server" ID="dgvProductos" AutoGenerateColumns="false" DataKeyNames="ID" OnRowCommand="dgvProductos_RowCommand" CssClass="table table-condensed table-hover">
        <Columns>
            <asp:BoundField HeaderText="Id" DataField="Id" Visible="false" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Nombre" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Nombre" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:BoundField HeaderText="Stock" DataField="Stock" />
            <asp:buttonfield ShowHeader="false" CommandName="Agregar" ButtonType="Button" Text="Agregar"/>
        </Columns>
    </asp:GridView>
    </div>
    
    <div id="listaCompra">
        <%if (CompraSession().Count > 0)
            {%>
        <div class="container text-center">
            <div class="row">
                <div class="col">
                    <p>Producto</p>
                </div>
                <div class="col">
                    <p>Cantidad</p>
                </div>
                <div class="col">
                    <p>Precio Parcial</p>
                </div>
            </div>
        </div>
        <%foreach (var item in CompraSession())
            {%>
        <div class="container text-center">
            <div class="row">
                <div class="col">
                    <p><%:productos.Find(x=>x.Id==item.IdProducto).Nombre%></p>
                </div>
                <div class="col">
                    <p><%:item.Cantidad%></p>
                </div>
                <div class="col">
                    <p>$<%:item.PrecioParcial*item.Cantidad%></p>
                </div>
            </div>
        </div>

        <% } %>
        <asp:Button Text="Borrar lista" ID="btnBorrarLista" runat="server" OnClick="btnBorrarLista_Click" />
        <asp:Button Text="Finalizar Compra" ID="btnFinalizar" runat="server" OnClick="btnFinalizar_Click" />

        <% } %>
    </div>
</asp:Content>
