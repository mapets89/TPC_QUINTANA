<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="articuloDetalle.aspx.cs" Inherits="TPC_QUINTANA.articuloDetalle" %>
<asp:Content ID="DetalleContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="navbar-light bg-light">
        <button type="button" id="sidebarCollapse" class="navbar-toggler buttonmenu" aria-controls="navbarToggleExternalContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
    </div>
    <div id="formulario" style="height:0px";">
        <div class="form-row">
            <div class="form-group col-md-6">
                <label>Nombre del Articulo</label>
                    <asp:TextBox runat="server" class="form-control" ID="nombreArt"/>
            </div>
            <div class="form-group col-md-6">
                <label>Descripcion</label>
                    <asp:TextBox runat="server" class="form-control" ID="descripArt"/>
            </div>
             <div class="form-group col-md-6">
                <label>Codigo</label>
                    <asp:TextBox runat="server" class="form-control" ID="codigoArt"/>
            </div>
        </div>
        <div class="form-group">
            <label>Marca</label>
                <asp:DropDownList runat="server" ID="ddlMarca" DataTextField="nombre" OnSelectedIndexChanged="ddlMarca_SelectedIndexChanged" DataValueField="id"/>
        </div>
        <div class="form-group">
            <label>Categoria</label>
                <asp:DropDownList runat="server" ID="ddlCategoria" DataTextField="nombre" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" DataValueField="id"/>
        </div>
        <div class="form-group">
            <label>Seccion</label>
                <asp:DropDownList runat="server" ID="ddlSeccion" DataTextField="nombre" OnSelectedIndexChanged="ddlSeccion_SelectedIndexChanged" DataValueField="id"/>
        </div>
        <div class="form-row">
            <div class="form-group col-md-6">
                <label>Precio</label>
                    <asp:TextBox runat="server" class="form-control" ID="precio"/>
        </div>
        <div class="form-group col-md-4">
            <label>Proveedor</label>
                <asp:DropDownList runat="server" ID="ddlProveedor" DataTextField="nombre" OnSelectedIndexChanged="ddlProveedor_SelectedIndexChanged" DataValueField="cod"/>
        </div>
            <div class="form-group col-md-4">
            <label>Origen</label>
                <asp:DropDownList runat="server" ID="ddlOrigen" DataTextField="nombre" OnSelectedIndexChanged="ddlOrigen_SelectedIndexChanged" DataValueField="id"/>
        </div>
        <div class="form-group col-md-2">
            <label>Stock</label>
            <asp:TextBox runat="server" class="form-control" ID="stock"/>
        </div>
            <div class="form-group col-md-2">
            <label>Imagen</label>
            <img src="<%#Eval("imagen")%>" class="card-img-top cardCustom" alt="...">
            <asp:TextBox runat="server" class="form-control" ID="imagen"/>
        </div>
  </div>
         <asp:Button type="submit" runat="server" class="btn btn-primary" ID="botonDetalleArticulo" OnClick="boton_Click" Text="MODIFICAR"></asp:Button>
</div>
</asp:Content>
