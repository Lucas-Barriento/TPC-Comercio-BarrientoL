<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormCliente.aspx.cs" Inherits="TPC_BarrientoL.FormCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function validar() {
            var valido = true;
            var nombre = document.getElementById("<%=txtBoxNombre.ClientID %>").value;
                var dni = document.getElementById("<%=txtBoxId.ClientID%>").value;
                var apellido = document.getElementById("<%=txtBoxApellido.ClientID%>").value;
            if (nombre === "") {
                $("#txtBoxNombre").removeClass("is-valid");
                $("#txtBoxNombre").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtBoxNombre").removeClass("is-invalid");
                $("#txtBoxNombre").addClass("is-valid");
            }
            if (dni === "") {
                $("#txtBoxId").removeClass("is-valid");
                $("#txtBoxId").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtBoxId").removeClass("is-invalid");
                $("#txtBoxId").addClass("is-valid");
            }
            if (apellido === "") {
                $("#txtBoxApellido").removeClass("is-valid");
                $("#txtBoxApellido").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtBoxApellido").removeClass("is-invalid");
                $("#txtBoxApellido").addClass("is-valid");
            }
            return valido
        }

    </script>
    <%if (TPC_BarrientoL.Functions.Validaciones.SesionIniciada(Page))
        {
            if (TPC_BarrientoL.Functions.Validaciones.EsAdmin(Page))
            {%>
        <%if (Request.QueryString["Id"] != null)
        {%>
    <h2>Modificar cliente</h2>
    <%}
        else
        {%>
    <h2>Agregar cliente</h2>
      <%}%>

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label ID="lblId" Text="DNI" runat="server" for="txtBoxId" />
                <asp:TextBox ID="txtBoxId" runat="server" CssClass="form-control" ClientIDMode="Static" />
            </div>
            <div class="mb-3">
                <label for="txtBoxNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtBoxNombre" runat="server" CssClass="form-control" ClientIDMode="Static" />
                <br />
                <label for="txtBoxApellido" class="form-label">Apellido</label>
                <asp:TextBox ID="txtBoxApellido" runat="server" CssClass="form-control" ClientIDMode="Static" />
                <br />
                <formview>
                    <asp:RadioButton ID="rbActivo" Text="Activo" runat="server" GroupName="RadioGroup1" Checked="true" />
                    <asp:RadioButton ID="rbInactivo" Text="Inactivo" runat="server" GroupName="RadioGroup1" />
                </formview>
                <%--<asp:CheckBox Text="Activo" runat="server" Checked="true" />--%>
            </div>
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
