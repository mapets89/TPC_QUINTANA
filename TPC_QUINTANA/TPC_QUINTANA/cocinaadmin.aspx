<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="cocinaadmin.aspx.cs" Inherits="TPC_QUINTANA.cocinaadmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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

        .boton-add {
            margin-top: 0px;
            margin-left: 30%;
        }

        @font-face {
            font-family: 'Peralta';
            src: url(fonts/Peralta-Regular.ttf);
        }
    </style>

    <div class="navbar-light bg-light">
        <button type="button" id="sidebarCollapse" class="navbar-toggler buttonmenu" aria-controls="navbarToggleExternalContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <asp:Button runat="server" ButtonType="Button" ControlStyle-BorderStyle="None" Text="Agregar Articulo" ControlStyle-CssClass="btn btn-success" ItemStyle-CssClass="alert-info" Style="font-family: Peralta;" ID="Agregar" OnClick="Agregar_Click" />
        <div class="form-inline" style="right: 0; position: absolute; top: 5px;">
            <input class="form-control mr-sm-2" type="search" placeholder="Busqueda" aria-label="Search">
            <button class="btn btn-outline-light my-2 my-sm-0 text-black-50" type="submit">Buscar</button>
        </div>
    </div>
    <div class="card-columns visible" id="cards" style="margin-left: 10px; margin-right: 10px; column-count: 3;">

        <asp:Repeater runat="server" ID="Repeater">
            <ItemTemplate>
                <div class="card body" style="width=200px; height: 400px;">
                    <h5 class="card-title articuloTit"><%#Eval("nombre")%></h5>
                    <div>
                        <img src="<%#Eval("imagen")%>" class="card-img-top cardCustom" alt="...">
                        <p class="card-text articuloPrec">$ <%#Eval("precio")%></p>
                        <p class="card-text articuloDesc"><%#Eval("descripcion")%></p>
                    </div>
                    <asp:Button CssClass="btn btn-primary boton-add" ID="modificar" Text="Modificar" runat="server" CommandArgument='<%#Eval("Id")%>' OnCommand="modificar_Command" />
                    <asp:Button CssClass="btn btn-primary" ID="eliminar" Text="Eliminar" runat="server" CommandArgument='<%#Eval("Id")%>' OnCommand="eliminar_Command" />
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
    </script>
</asp:Content>
