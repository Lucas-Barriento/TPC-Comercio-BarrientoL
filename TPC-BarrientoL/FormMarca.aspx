<%@ Page Title="Modificar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormMarca.aspx.cs" Inherits="TPC_BarrientoL.FormMarca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <script>
        function validar() {
            var nombre = document.getElementById("<%=txtBoxNombre.ClientID %>").value;
            if (nombre === "") {
                $("#txtBoxNombre").removeClass("is-valid");
                $("#txtBoxNombre").addClass("is-invalid");
                return false
            }
            else {
                $("#txtBoxNombre").removeClass("is-invalid");
                $("#txtBoxNombre").addClass("is-valid");
            }
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
                <br />
                <formview>
                    <asp:RadioButton ID="rbActivo" Text="Activo" runat="server" GroupName="RadioGroup1" Checked="true" />
                    <asp:RadioButton ID="rbInactivo" Text="Inactivo" runat="server" GroupName="RadioGroup1" />
                </formview>
                <%--<asp:CheckBox Text="Activo" runat="server" Checked="true" />--%>
            <div class="mb-3">
                <asp:Button Text="Guardar" ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" OnClientClick="return validar()"/>
                <asp:Button Text="Cancelar" ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" />
            </div>
        </div>
    </div>
             <% }
              else{%>
    <p>Debes tener cuenta de administrador para ingresar a esta pagina</p>
    <br />
    <a class="nav-link active" aria-current="page" href="Default">Ir al Inicio</a>
         <%}
             }
             else{%>
                    <p>Debes iniciar sesión para ingresar a esta pagina</p>
                    <br />
                    <a class="nav-link active" aria-current="page" href="Default">Iniciar sesión</a>
                    <%--Response.Redirect("Default.aspx", false);--%>
               <%}%>
</asp:Content>
