<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="principalAdmin.aspx.cs" Inherits="TPC_QUINTANA.principalAdmin" %>

<asp:Content ID="PrincialContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .cardCustom {
            max-height: 300px;
            min-height: 300px;
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
        <div class="form-inline" style="right: 0; position: absolute; top: 5px;">
            <input class="form-control mr-sm-2" type="search" placeholder="Busqueda" aria-label="Search">
            <button class="btn btn-outline-light my-2 my-sm-0 text-black-50" type="submit">Buscar</button>
        </div>
    </div>
    <div class="card-columns" style="margin-left: 10px; margin-right: 10px; column-count: 4;">

        <asp:Repeater runat="server" ID="Repeater">
            <ItemTemplate>
                <div class="card body">
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
    </script>
</asp:Content>
