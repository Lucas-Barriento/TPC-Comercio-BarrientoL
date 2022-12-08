<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormProveedor.aspx.cs" Inherits="TPC_BarrientoL.FormProveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function validar() {
            var nombre = document.getElementById("<%=txtBoxNombre.ClientID %>").value;
            var domicilio = document.getElementById("<%=txtBoxDomicilio.ClientID %>").value;
            var localidad = document.getElementById("<%=txtBoxLocalidad.ClientID %>").value;
            var email = document.getElementById("<%=txtBoxEmail.ClientID %>").value;
            var telefono = document.getElementById("<%=txtBoxTelefono.ClientID %>").value;
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
            if (domicilio === "") {
                $("#txtBoxDomicilio").removeClass("is-valid");
                $("#txtBoxDomicilio").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtBoxDomicilio").removeClass("is-invalid");
                $("#txtBoxDomicilio").addClass("is-valid");
            }
            if (localidad === "") {
                $("#txtBoxLocalidad").removeClass("is-valid");
                $("#txtBoxLocalidad").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtBoxLocalidad").removeClass("is-invalid");
                $("#txtBoxLocalidad").addClass("is-valid");
            }
            if (telefono === "") {
                $("#txtBoxTelefono").removeClass("is-valid");
                $("#txtBoxTelefono").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtBoxTelefono").removeClass("is-invalid");
                $("#txtBoxTelefono").addClass("is-valid");
            }
            if (email === "") {
                $("#txtBoxEmail").removeClass("is-valid");
                $("#txtBoxEmail").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtBoxEmail").removeClass("is-invalid");
                $("#txtBoxEmail").addClass("is-valid");
            }
            return valido;
        }

    </script>
    <%if (TPC_BarrientoL.Functions.Validaciones.SesionIniciada(Page))
        {
            if (TPC_BarrientoL.Functions.Validaciones.EsAdmin(Page))
            {%>
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
                <label for="txtBoxDomicilio" class="form-label">Domicilio</label>
                <asp:TextBox ID="txtBoxDomicilio" runat="server" CssClass="form-control" ClientIDMode="Static" />
            </div>
            <div class="mb-3">
                <label for="txtBoxLocalidad" class="form-label">Localidad</label>
                <asp:TextBox ID="txtBoxLocalidad" runat="server" CssClass="form-control" ClientIDMode="Static" />
            </div>
            <div class="mb-3">
                <label for="txtBoxEmail" class="form-label">Email</label>
                <asp:TextBox ID="txtBoxEmail" runat="server" CssClass="form-control"  ClientIDMode="Static"/>
            </div>
            <div class="mb-3">
                <label for="txtBoxTelefono" class="form-label">Telefono</label>
                <asp:TextBox ID="txtBoxTelefono" runat="server" CssClass="form-control"  ClientIDMode="Static"/>
            </div>
            <formview>
                <asp:RadioButton ID="rbActivo" Text="Activo" runat="server" GroupName="RadioGroup1" Checked="true" />
                <asp:RadioButton ID="rbInactivo" Text="Inactivo" runat="server" GroupName="RadioGroup1" />
            </formview>
            <%--<asp:CheckBox Text="Activo" runat="server" Checked="true" />--%>
            <div class="mb-3">
                <asp:Button Text="Guardar" ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" OnClientClick="return validar()" />
                <asp:Button Text="Cancelar" ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" />
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
