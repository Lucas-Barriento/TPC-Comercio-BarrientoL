<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormVenta.aspx.cs" Inherits="TPC_BarrientoL.FormVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%if (TPC_BarrientoL.Functions.Validaciones.SesionIniciada(Page))
        { %>
        <asp:UpdatePanel runat="server">
        <ContentTemplate>
    <div class="mb-3">
        <label for="ddlCliente" class="form-label">Cliente</label>
        <asp:DropDownList ID="ddlCliente" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddlCliente_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
    </div>
    <div id="grillaProductos">
            <asp:GridView runat="server" ID="dgvProductos" ClientIDMode="Static" AutoGenerateColumns="false" DataKeyNames="ID" OnSelectedIndexChanged="dgvProductos_SelectedIndexChanged" CssClass="table table-condensed table-hover" AllowPaging="true" PageSize="4" OnPageIndexChanging="dgvProductos_PageIndexChanging">
            <Columns>
                <asp:BoundField HeaderText="Id" DataField="Id" Visible="false" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Marca" DataField="Marca.Nombre" />
                <asp:BoundField HeaderText="Categoria" DataField="Categoria.Nombre" />
                <asp:BoundField HeaderText="Stock" DataField="Stock" />
                <asp:CommandField ShowHeader="false" ButtonType="Button" SelectText="Agregar" ShowSelectButton="true" ControlStyle-CssClass="btn btn-secondary" />
            </Columns>
            <PagerSettings Mode="Numeric" Position="Top" PageButtonCount="10" />
            <PagerStyle BackColor="White" Height="30px" VerticalAlign="Bottom" HorizontalAlign="Center" />
        </asp:GridView>
    </div>
    <div id="listaVenta">
        <%if (VentaSession().Count > 0)
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
        <%foreach (var item in VentaSession())
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
        <br />
        <asp:Button Text="Borrar lista" ID="btnBorrarLista" runat="server" OnClick="btnBorrarLista_Click" CssClass="btn btn-secondary" />
        <asp:Button Text="Finalizar Venta" ID="btnFinalizar" runat="server" OnClick="btnFinalizar_Click" CssClass="btn btn-secondary"/>
        <% } %>
    </div>
        </ContentTemplate>
        </asp:UpdatePanel>
            <% }
        else
        {%>
    <p>Debes iniciar sesión para ingresar a esta pagina</p>
    <br />
    <a class="nav-link active" aria-current="page" href="Default">Iniciar sesión</a>
    <%--Response.Redirect("Default.aspx", false);--%>
    <%}%>
</asp:Content>
