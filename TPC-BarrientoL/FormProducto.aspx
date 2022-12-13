<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormProducto.aspx.cs" Inherits="TPC_BarrientoL.FormProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <script>
        function validar() {
            var nombre = document.getElementById("<%=txtBoxNombre.ClientID %>").value;
            var marca = document.getElementById("<%=ddlMarca.ClientID %>");
            var categoria = document.getElementById("<%=ddlCategoria.ClientID %>").value;
            var stock = document.getElementById("<%=txtBoxStock.ClientID %>").value;
            var stockMinimo = document.getElementById("<%=txtBoxStockMinimo.ClientID %>").value;
            var ganancia = document.getElementById("<%=txtBoxGanancia.ClientID %>").value;
            var precio = document.getElementById("<%=txtPrecio.ClientID %>").value;
            var valido = true;

            if (nombre === "") {
                $("#txtBoxNombre").removeClass("is-valid");
                $("#txtBoxNombre").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtBoxNombre").removeClass("is-invalid");
                $("#txtBoxNombre").addClass("is-valid");
            }
            if (stock === "") {
                $("#txtBoxStock").removeClass("is-valid");
                $("#txtBoxStock").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtBoxStock").removeClass("is-invalid");
                $("#txtBoxStock").addClass("is-valid");
            }
            if (ganancia === "") {
                $("#txtBoxGanancia").removeClass("is-valid");
                $("#txtBoxGanancia").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtBoxGanancia").removeClass("is-invalid");
                $("#txtBoxGanancia").addClass("is-valid");
            }
            if (stockMinimo === "") {
                $("#txtBoxStockMinimo").removeClass("is-valid");
                $("#txtBoxStockMinimo").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtBoxStockMinimo").removeClass("is-invalid");
                $("#txtBoxStockMinimo").addClass("is-valid");
            }
            if (precio === "") {
                $("#txtPrecio").removeClass("is-valid");
                $("#txtPrecio").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtPrecio").removeClass("is-invalid");
                $("#txtPrecio").addClass("is-valid");
            }
            return valido;
        }

        </script>

    <%if (TPC_BarrientoL.Functions.Validaciones.SesionIniciada(Page))
        {
            if (TPC_BarrientoL.Functions.Validaciones.EsAdmin(Page))
            {%>
    <%if (Request.QueryString["Id"] != null)
        {%>
    <h2>Modificar producto</h2>
    <%}
        else
        {%>
    <h2>Agregar producto</h2>
      <%}%>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label ID="lblId" Text="Id" runat="server" for="txtBoxId" />
                <asp:TextBox ID="txtBoxId" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtBoxNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtBoxNombre" runat="server" CssClass="form-control" ClientIDMode="Static" />
            </div>
            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca</label>
                <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select" ClientIDMode="Static"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoria</label>
                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select" ClientIDMode="Static"></asp:DropDownList>
            </div>
            <label for="listacheck" class="form-label">Proveedores</label>
            <div class="mb-3" style="border: 1px solid black; height: 100px; overflow: auto; width: 200px">
                <asp:CheckBoxList runat="server" ID="listacheck" Style="width: 100%;">
                </asp:CheckBoxList>
            </div>
            <div class="mb-3">
                <label for="txtBoxStock" class="form-label">Stock</label>
                <asp:TextBox ID="txtBoxStock" runat="server" CssClass="form-control" ClientIDMode="Static" />
            </div>
            <div class="mb-3">
                <label for="txtBoxStockMinimo" class="form-label">Stock Minimo</label>
                <asp:TextBox ID="txtBoxStockMinimo" runat="server" CssClass="form-control" ClientIDMode="Static" />
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" ClientIDMode="Static" />
            </div>
            <div class="mb-3">
                <label for="txtBoxGanancia" class="form-label">% Ganancia</label>
                <asp:TextBox ID="txtBoxGanancia" runat="server" CssClass="form-control" ClientIDMode="Static" />
            </div>
            <formview>
                <asp:RadioButton ID="rbActivo" Text="Activo" runat="server" GroupName="RadioGroup1" Checked="true" />
                <asp:RadioButton ID="rbInactivo" Text="Inactivo" runat="server" GroupName="RadioGroup1" />
            </formview>
            <%--<asp:CheckBox Text="Activo" runat="server" Checked="true" />--%>
            <div class="mb-3">
                <asp:Button Text="Guardar" ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" OnClientClick="return validar()" CssClass="btn btn-secondary" />
                <asp:Button Text="Cancelar" ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" CssClass="btn btn-secondary"/>
            </div>
        </div>
    </div>
    <% }
        else
        {%>
    <p>Debes tener cuenta de administrador para ingresar a esta pagina</p>
    <br />
    <a class="nav-link active" aria-current="page" href="Default" >Ir al Inicio</a>
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
