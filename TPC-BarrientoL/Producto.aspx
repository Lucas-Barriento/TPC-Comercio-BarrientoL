<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="TPC_BarrientoL.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%if (TPC_BarrientoL.Functions.Validaciones.SesionIniciada(Page))
        {
            if (TPC_BarrientoL.Functions.Validaciones.EsAdmin(Page))
            {%>
    <h2><%: Title %></h2>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Buscar" runat="server" CssClass="form-label" />
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtBuscar" AutoPostBack="true" OnTextChanged="txtBuscar_TextChanged" />
                    </div>
                </div>
                <div class="col-2">
                    <div class="mb-3">
                        <asp:CheckBox CssClass="form-check" Text="Filtro avanzado" runat="server" OnCheckedChanged="checkAvanzado_CheckedChanged" AutoPostBack="true" ID="checkAvanzado" />
                    </div>
                </div>
            </div>
            <br />
            <%if (checkAvanzado.Checked)
                { %>
            <div class="row">
                <div class="col-2">
                    <div class="mb-3">
                        <asp:Label Text="Campo" ID="lblCampo" runat="server" />
                        <asp:DropDownList runat="server" ID="ddlCampo" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                            <asp:ListItem Text="Marca" />
                            <asp:ListItem Text="Categoria" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-2">
                    <div class="mb-3">
                        <asp:Label Text="Criterio" ID="lblCriterio" runat="server" />
                        <asp:DropDownList runat="server" ID="ddlCriterio" AutoPostBack="true" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-2">
                    <div class="mb-3">
                        <asp:Label Text="Filtro" runat="server" />
                        <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <div class="mb-3">
                        <asp:Button Text="Buscar" ID="btnBuscar" CssClass="btn btn-secondary" runat="server" OnClick="btnBuscar_Click" Enabled="false" />
                    </div>
                </div>
                <div class="col-1">
                    <div class="mb-3">
                        <asp:Button Text="Limpiar" ID="btnLimpiar" CssClass="btn btn-secondary" runat="server" OnClick="btnLimpiar_Click" />
                    </div>
                </div>
            </div>
            <% } %>
            <br />
            <div>
                <asp:Button Text="Agregar" runat="server" PostBackUrl="~/FormProducto.aspx" />
            </div>
            <br />

            <asp:GridView runat="server" ID="dgvProductos" ClientIDMode="Static" AutoGenerateColumns="false" DataKeyNames="ID" OnSelectedIndexChanged="dgvProductos_SelectedIndexChanged" CssClass="table table-condensed table-hover" AllowPaging="true" PageSize="5" OnPageIndexChanging="dgvProductos_PageIndexChanging">
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" ItemStyle-Width="390px"/>
                    <asp:BoundField HeaderText="Marca" DataField="Marca.Nombre" />
                    <asp:BoundField HeaderText="Categoria" DataField="Categoria.Nombre" />
                    <asp:BoundField HeaderText="Stock" DataField="Stock" />
                    <asp:BoundField HeaderText="Stock Minimo" DataField="StockMinimo" />
                    <asp:BoundField HeaderText="% Ganancia" DataField="PorcentajeGanancia" />
                    <asp:CheckBoxField HeaderText="Activo" DataField="Estado" ControlStyle-CssClass="form-check" />
                    <asp:CommandField ShowHeader="false" ButtonType="Button" SelectText="Modificar" ShowSelectButton="true" />
                </Columns>
                <PagerSettings Mode="Numeric" Position="Bottom" PageButtonCount="10" />
                <PagerStyle BackColor="White" Height="30px" VerticalAlign="Bottom" HorizontalAlign="Center" />
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
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
