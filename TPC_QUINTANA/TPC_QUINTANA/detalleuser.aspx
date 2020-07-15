<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="detalleuser.aspx.cs" Inherits="TPC_QUINTANA.detalleuser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="formulario" style="height:0px;margin-top:25px; ">
        <div class="form">
            <div class="form-group col-md-6">
                <label>Nombre</label>
                    <asp:TextBox runat="server" class="form-control" ID="nombre"/>
            </div>
            <div class="form-group col-md-6">
                <label>Apellido</label>
                    <asp:TextBox runat="server" class="form-control" ID="apellido"/>
            </div>
        <div class="form-group col-md-6">
                <label>DNI</label>
                    <asp:TextBox runat="server" class="form-control" ID="dni"/>
        </div>
        <div class="form-group col-md-6">
            <label>User Name</label>
            <asp:TextBox runat="server" class="form-control" ID="username"/>
        </div>
         <div class="form-group col-md-6">
            <label>E-Mail</label>
            <asp:TextBox runat="server" class="form-control" ID="email"/>
        </div>
        <div class="form-group col-md-6">
            <label>Contraseña</label>
            <asp:TextBox runat="server" class="form-control" ID="contraseña" type="password"/>
        </div>
            <div class="form-group col-md-6">
            <label>Calle</label>
            <asp:TextBox runat="server" class="form-control" ID="calle"/>
        </div>
            <div class="form-group col-md-6">
            <label>Altura</label>
            <asp:TextBox runat="server" class="form-control" ID="altura"/>
        </div>
            <div class="form-group col-md-6">
            <label>Localidad</label>
            <asp:TextBox runat="server" class="form-control" ID="localidad"/>
        </div>
            <div class="form-group col-md-6">
            <label>Provincia</label>
            <asp:TextBox runat="server" class="form-control" ID="provincia"/>
        </div>
            <div class="form-group col-md-6">
            <label>Descripcion</label>
            <asp:TextBox runat="server" class="form-control" ID="descripcion"/>
        </div>
            </div>
        </div>

         <asp:Button style="margin-left:0;margin-top:65px" UseSubmitBehavior="false" runat="server" class="btn btn-primary" ID="botonDetalleUsuario" OnClick="botonDetalleUsuario_Click" Text="MODIFICAR"></asp:Button>
</asp:Content>
