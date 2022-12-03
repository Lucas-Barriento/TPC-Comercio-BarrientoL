<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormCompra.aspx.cs" Inherits="TPC_BarrientoL.FormCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%if (TPC_BarrientoL.Functions.Validaciones.SesionIniciada(Page))
        {
            if (TPC_BarrientoL.Functions.Validaciones.EsAdmin(Page))
            {%>
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
                <asp:ButtonField ShowHeader="false" CommandName="Agregar" ButtonType="Button" Text="Agregar" />
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
                    <p><%:productos.Find(x=>x.Id==item.producto.Id).Nombre%></p>
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
