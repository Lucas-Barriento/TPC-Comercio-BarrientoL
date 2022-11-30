<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormVenta.aspx.cs" Inherits="TPC_BarrientoL.FormVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="mb-3">
        <label for="ddlCliente" class="form-label">Cliente</label>
        <asp:DropDownList ID="ddlCliente" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddlCliente_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
    </div>
        <div id="grillaProductos">
            <asp:GridView runat="server" ID="dgvProductos" AutoGenerateColumns="false" DataKeyNames="ID" CssClass="table table-condensed table-hover" OnRowCommand="dgvProductos_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="Id" DataField="Id" Visible="false" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca.Nombre" />
                    <asp:BoundField HeaderText="Categoria" DataField="Categoria.Nombre" />
                    <asp:BoundField HeaderText="Stock" DataField="Stock" />
                    <%--<asp:TemplateField HeaderText="Cantidad">
                        <ItemTemplate>
                            <asp:TextBox ID="txtboxCantidad" TextMode="Number" runat="server" min="1" max='<%#Eval("Stock") %>' step="1" Width="70px" />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:ButtonField ShowHeader="false" CommandName="Agregar" ButtonType="Button" Text="Agregar" />
                </Columns>
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
        <asp:Button Text="Finalizar Venta" ID="btnFinalizar" runat="server" OnClick="btnFinalizar_Click" />
        <% } %>
    </div>

</asp:Content>
