<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="DormitorioAdmin.aspx.cs" Inherits="TPC_QUINTANA.DormitorioAdmin" %>

<asp:Content ID="DormitorioContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .cardCustom {
            max-height: 200px;
            min-height: 200px;
        }

        .articuloTit {
            font-size: 25px;
            text-align: center;
            font-family: Bungee;
        }

        .articuloDesc {
            margin-top: 2rem;
            font-size: 15px;
            text-align: center;
            font-family: Cinzel;
        }

        .articuloPrec {
            margin-top: 2rem;
            font-size: 23px;
            text-align: center;
            font-family: Peralta;
        }

        .buttonmenu {
            left: 0px;
            margin-bottom: 25px;
            width: 40px;
            height: 30px;
            align-content: center;
            background-color: crimson;
        }
    </style>

    <div class="navbar-light bg-light">
        <button type="button" id="sidebarCollapse" class="navbar-toggler buttonmenu" aria-controls="navbarToggleExternalContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <button onclick="agregar()" type="button" class="alert-dark">
            <span>Agregar Articulo</span>
        </button>
        <div class="form-inline" style="right: 0; position: absolute; top: 5px;">
            <input class="form-control mr-sm-2" type="search" placeholder="Busqueda" aria-label="Search">
            <button class="btn btn-outline-light my-2 my-sm-0 text-black-50" type="submit">Buscar</button>
        </div>
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
                <asp:DropDownList runat="server" ID="ddlMarca" DataTextField="nombre" AutoPostBack="true" OnSelectedIndexChanged="ddlMarca_SelectedIndexChanged" DataValueField="id"/>
        </div>
        <div class="form-group">
            <label>Categoria</label>
                <asp:DropDownList runat="server" ID="ddlCategoria" DataTextField="nombre" AutoPostBack="true" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" DataValueField="id"/>
        </div>
        <div class="form-row">
            <div class="form-group col-md-6">
                <label>Precio</label>
                    <asp:TextBox runat="server" class="form-control" ID="precio"/>
        </div>
        <div class="form-group col-md-4">
            <label>Proveedor</label>
                <asp:DropDownList runat="server" ID="ddlProveedor" DataTextField="nombre" AutoPostBack="true" OnSelectedIndexChanged="ddlProveedor_SelectedIndexChanged" DataValueField="cod"/>
        </div>
            <div class="form-group col-md-4">
            <label>Origen</label>
                <asp:DropDownList runat="server" ID="ddlOrigen" DataTextField="nombre" AutoPostBack="true" OnSelectedIndexChanged="ddlOrigen_SelectedIndexChanged" DataValueField="id"/>
        </div>
        <div class="form-group col-md-2">
            <label>Cantidad</label>
            <asp:TextBox runat="server" class="form-control" ID="cantidad"/>
        </div>
            <div class="form-group col-md-2">
            <label>Imagen</label>
            <asp:TextBox runat="server" class="form-control" ID="imagen"/>
        </div>
  </div>
 <asp:Button type="submit" runat="server" class="btn btn-primary" ID="cargar" OnClick="cargar_Click" Text="CARGAR"></asp:Button>
</div>
    <div class="card-columns visible" id="cards" style="margin-left: 10px; margin-right: 10px; column-count: 3;">

        <asp:Repeater runat="server" ID="Repeater">
            <ItemTemplate>
                <div class="card body" style="width=200px; height:400px;">
                    <h5 class="card-title articuloTit"><%#Eval("nombre")%></h5>
                    <div>
                        <img src="<%#Eval("imagen")%>" class="card-img-top cardCustom" alt="...">
                        <p class="card-text articuloPrec">$ <%#Eval("precio")%></p>
                        <p class="card-text articuloDesc"><%#Eval("descripcion")%></p>
                    </div>
                    <asp:Button CssClass="button-add btn btn-toolbar" ID="modificar" Text="Modificar" runat="server" CommandArgument='<%#Eval("Id")%>' OnCommand="modificar_Command" />
                    <asp:Button CssClass="button-add btn btn-toolbar" ID="eliminar" Text="Eliminar" runat="server" CommandArgument='<%#Eval("Id")%>' OnCommand="eliminar_Command" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#sidebarCollapse').on('click', function () {
                $('#sidebar').toggleClass('active');
            });
        });
        function agregar() {
            document.getElementById("cards").className = "invisible";
            document.getElementById("formulario").className = "visible";
            document.getElementById("formulario").className = "mt-0";
        }

    </script>
</asp:Content>
