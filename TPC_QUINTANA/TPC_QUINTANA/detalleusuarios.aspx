<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="detalleusuarios.aspx.cs" Inherits="TPC_QUINTANA.detalleusuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="navbar-light bg-light">
        <button type="button" id="sidebarCollapse" class="navbar-toggler buttonmenu" aria-controls="navbarToggleExternalContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
    </div>
    <div id="formulario" style="height:0px";">
        <div class="form-row">
            <div class="form-group col-md-6">
                <label>Nombre</label>
                    <asp:TextBox runat="server" class="form-control" ID="nombre"/>
            </div>
            <div class="form-group col-md-6">
                <label>Apellido</label>
                    <asp:TextBox runat="server" class="form-control" ID="apellido"/>
            </div>
             <div class="form-group col-md-6">
        </div>
        <div class="form-row">
            <div class="form-group col-md-6">
                <label>DNI</label>
                    <asp:TextBox runat="server" class="form-control" ID="dni"/>
        </div>
        <div class="form-group col-md-2">
            <label>User Name</label>
            <asp:TextBox runat="server" class="form-control" ID="username"/>
        </div>
         <div class="form-group col-md-2">
            <label>E-Mail</label>
            <asp:TextBox runat="server" class="form-control" ID="email"/>
        </div>
        <div class="form-group col-md-2">
            <label>Contraseña</label>
            <asp:TextBox runat="server" class="form-control" ID="contraseña"/>
        </div>
            <div class="form-group col-md-2">
            <label>PRIVILEGIO</label>
            <asp:TextBox runat="server" class="form-control" ID="privilegio"/>
        </div>
            <div class="form-group col-md-2">
            <label>Calle</label>
            <asp:TextBox runat="server" class="form-control" ID="calle"/>
        </div>
            <div class="form-group col-md-2">
            <label>Altura</label>
            <asp:TextBox runat="server" class="form-control" ID="altura"/>
        </div>
            <div class="form-group col-md-2">
            <label>Localidad</label>
            <asp:TextBox runat="server" class="form-control" ID="localidad"/>
        </div>
            <div class="form-group col-md-2">
            <label>Provincia</label>
            <asp:TextBox runat="server" class="form-control" ID="provincia"/>
        </div>
            <div class="form-group col-md-2">
            <label>Descripcion</label>
            <asp:TextBox runat="server" class="form-control" ID="descripcion"/>
        </div>
         <asp:Button type="submit" runat="server" class="btn btn-primary" ID="botonDetalleUsuario" OnClick="botonDetalleUsuario_Click" Text="MODIFICAR"></asp:Button>
</div>
            </div>
        </div>
        <script type="text/javascript">
            $(document).ready(function () {
                $('#sidebarCollapse').on('click', function () {
                    $('#sidebar').toggleClass('active');
                });
            });
        </script>
</asp:Content>
