<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="agregardomicilio.aspx.cs" Inherits="TPC_QUINTANA.agregardomicilio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="formulario" style="height:0px; margin-top:50px;">
        <div class="form-row">
            <div class="form-group col-md-6">
                <label>Calle</label>
                    <asp:TextBox runat="server" class="form-control" ID="calleUsuario"/>
            </div>
             <div class="form-group col-md-6">
                <label>Altura</label>
                    <asp:TextBox runat="server" class="form-control" ID="alturaUsuario"/>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-6">
                <label>Localidad</label>
                    <asp:TextBox runat="server" class="form-control" ID="localidadUsuario"/>
        </div>
        <div class="form-group col-md-2">
            <label>Provincia</label>
            <asp:TextBox runat="server" class="form-control" ID="provinciaUsuario"/>
        </div>
            <div class="form-group col-md-2">
            <label>Provincia</label>
            <asp:TextBox runat="server" class="form-control" ID="descripcionUsuario"/>
        </div>
         <asp:Button type="submit" runat="server" class="btn btn-primary" ID="botonAgregar" OnClick="botonAgregar_Click" Text="MODIFICAR"></asp:Button>
</div>
        </div>
</asp:Content>
