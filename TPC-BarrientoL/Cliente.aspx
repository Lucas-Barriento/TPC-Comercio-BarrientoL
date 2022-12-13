<%@ Page Title="Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="TPC_BarrientoL.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%if (TPC_BarrientoL.Functions.Validaciones.SesionIniciada(Page))
        {
            if (TPC_BarrientoL.Functions.Validaciones.EsAdmin(Page))
            {%>
    <h2><%: Title %></h2>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
                        <asp:Label Text="Buscar" runat="server" CssClass="form-label"/>
            <asp:TextBox CssClass="form-control" runat="server" ID="txtBuscar" AutoPostBack="true" OnTextChanged="txtBuscar_TextChanged"/>
                        <br />
            <div>
            <asp:Button Text="Agregar" runat="server" PostBackUrl="~/FormCliente.aspx" CssClass="btn btn-secondary" />
            </div>
            <br />
            <asp:GridView runat="server" ID="dgvClientes" AutoGenerateColumns="false" DataKeyNames="ID" OnRowCommand="dgvClientes_RowCommand" CssClass="table table-dark table-striped">
                <Columns>
                    <asp:BoundField HeaderText="DNI" DataField="Id" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                    <asp:CheckBoxField HeaderText="Activo" DataField="Estado" ControlStyle-CssClass="form-check" />
                    <asp:ButtonField ShowHeader="false" CommandName="Modificar" ButtonType="Button" Text="Modificar" ControlStyle-CssClass="btn btn-secondary"  />
                    <%--<asp:buttonfield ShowHeader="false" CommandName="Eliminar" ButtonType="Button" Text="Eliminar" />--%>
                </Columns>
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
