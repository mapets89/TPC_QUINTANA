<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="proveedorDetalle.aspx.cs" Inherits="TPC_QUINTANA.proveedorDetalle" %>
<asp:Content ID="ContentProveedorDetalle" ContentPlaceHolderID="MainContent" runat="server">
        <div class="navbar-light bg-light">
        <button type="button" id="sidebarCollapse" class="navbar-toggler buttonmenu" aria-controls="navbarToggleExternalContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
    </div>
    <div id="formulario" style="height:0px";">
        <div class="form-row">
            <div class="form-group col-md-6">
                <label>Nombre del Proveedor</label>
                    <asp:TextBox runat="server" class="form-control" ID="nombreProv"/>
            </div>
            <div class="form-group col-md-6">
                <label>Descripcion</label>
                    <asp:TextBox runat="server" class="form-control" ID="descripProv"/>
            </div>
             <div class="form-group col-md-6">
        </div>
        <div class="form-row">
            <div class="form-group col-md-6">
                <label>Calle</label>
                    <asp:TextBox runat="server" class="form-control" ID="calleProv"/>
        </div>
        <div class="form-group col-md-2">
            <label>Altura</label>
            <asp:TextBox runat="server" class="form-control" ID="alturaProv"/>
        </div>
         <div class="form-group col-md-2">
            <label>Localidad</label>
            <asp:TextBox runat="server" class="form-control" ID="localidadProv"/>
        </div>
        <div class="form-group col-md-2">
            <label>Provincia</label>
            <asp:TextBox runat="server" class="form-control" ID="provinciaProv"/>
        </div>
         <asp:Button type="submit" runat="server" class="btn btn-primary" ID="botonDetalleProveedor" OnClick="botonDetalleProveedor_Click" Text="MODIFICAR"></asp:Button>
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
