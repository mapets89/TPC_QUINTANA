<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dormitorio.aspx.cs" Inherits="TPC_QUINTANA.Dormitorio" EnableEventValidation="false" %>


<asp:Content ID="DormitorioContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .carousel-custom {
            margin-top: 90px;
            width: 900px;
            height: 400px;
            margin-left: 20%;
        }

        .item-carousel {
            float: left;
            margin-left: 10px;
            width: 35%;
            height: 300px;
        }

        .productos-destacados {
            font-family: Barriecito;
            font-size: 40px;
            float: left;
            margin-left: 25px;
            margin-top: 100px;
        }

        .detalle-producto-destacado {
            font-family: Lakki;
            font-size: 25px;
        }

        .cardCustom {
            max-height: 100px;
            min-height: 100px;
        }
        .boton-add{
            margin-top:0px;
            margin-left:30%;
        }

        @font-face {
            font-family: 'Barriecito';
            src: url(fonts/Barriecito-Regular.ttf);
            font-weight: normal;
            font-style: normal;
        }

        @font-face {
            font-family: 'Lakki';
            src: url(fonts/LakkiReddy-Regular.ttf);
            font-weight: normal;
            font-style: normal;
        }
    </style>

    <div id="carouselDormitorio" class="carousel slide carousel-custom image" data-ride="carousel">
        <ol class="carousel-indicators">
            <li data-target="#carouselDormitorio" data-slide-to="0" class="active"></li>
            <li data-target="#carouselDormitorio" data-slide-to="1"></li>
            <li data-target="#carouselDormitorio" data-slide-to="2"></li>
        </ol>
        <div class="carousel-inner">
            <div class="carousel-item active">
                <asp:Label runat="server" Text="PRODUCTOS <br/> DESTACADOS" CssClass="productos-destacados"></asp:Label>
                <asp:Image ID="imageCarousel1" runat="server" ImageUrl="~/images/carrousel_dormitorio_1.jpg" CssClass="item-carousel d-block" alt="..." />
                <div style="position: absolute; top: 0; right: 15px;">
                    <asp:Label ID="nombreCarousel1" runat="server" Text="Nombre del producto" CssClass="detalle-producto-destacado"></asp:Label>
                </div>

                <div style="position: absolute; margin-top: 40px; right: 15px;">
                    <asp:Label ID="descripCarousel1" runat="server" Text="Descripcion del producto" CssClass="detalle-producto-destacado"></asp:Label>
                </div>
                <div style="position: absolute; bottom: 0; right: 15px;">
                    <asp:Label ID="precioCarousel1" runat="server" Text="Precio del producto" CssClass="detalle-producto-destacado"></asp:Label>
                </div>

            </div>
            <div class="carousel-item">
                <asp:Label runat="server" Text="PRODUCTOS <br/> DESTACADOS" CssClass="productos-destacados"></asp:Label>
                <asp:Image runat="server" ID="imageCarousel2" ImageUrl="~/images/carrousel_dormitorio_2.jpg" CssClass="item-carousel d-block" alt="..." />
                <div style="position: absolute; top: 0; right: 15px;">
                    <asp:Label ID="nombreCarousel2" runat="server" Text="Nombre del producto" CssClass="detalle-producto-destacado"></asp:Label>
                </div>

                <div style="position: absolute; margin-top: 40px; right: 15px;">
                    <asp:Label ID="descripCarousel2" runat="server" Text="Descripcion del producto" CssClass="detalle-producto-destacado"></asp:Label>
                </div>
                <div style="position: absolute; bottom: 0; right: 15px;">
                    <asp:Label ID="precioCarousel2" runat="server" Text="Precio del producto" CssClass="detalle-producto-destacado"></asp:Label>
                </div>
            </div>
            <div class="carousel-item">
                <asp:Label runat="server" Text="PRODUCTOS <br/> DESTACADOS" CssClass="productos-destacados"></asp:Label>
                <asp:Image runat="server" ID="imageCarousel3" ImageUrl="~/images/carrousel_dormitorio_3.jpg" CssClass="item-carousel d-block" />
                <div style="position: absolute; top: 0; right: 15px;">
                    <asp:Label ID="nombreCarousel3" runat="server" Text="Nombre del producto" CssClass="detalle-producto-destacado"></asp:Label>
                </div>

                <div style="position: absolute; margin-top: 40px; right: 15px;">
                    <asp:Label ID="descripCarousel3" runat="server" Text="Descripcion del producto" CssClass="detalle-producto-destacado"></asp:Label>
                </div>
                <div style="position: absolute; bottom: 0; right: 15px;">
                    <asp:Label ID="precioCarousel3" runat="server" Text="Precio del producto" CssClass="detalle-producto-destacado"></asp:Label>
                </div>
            </div>
        </div>
        <a class="carousel-control-prev" href="#carouselDormitorio" role="button" data-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="carousel-control-next" href="#carouselDormitorio" role="button" data-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>

    <div class="card-columns" style="margin-left: 10px; margin-right: 10px; column-count: 3;">

        <asp:Repeater runat="server" ID="Repeater">
            <ItemTemplate>
                <div class="card mb-4" style="max-width: 540px;">
                    <div class="row">
                        <div class="col-md-4">
                            <img src="<%#Eval("imagen")%>" class="card-img cardCustom" alt="...">
                        </div>
                        <div class="col-md-8">
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("nombre")%></h5>
                                <p class="card-text"><%#Eval("descripcion")%></p>
                                <p class="card-text"><small class="text-muted">$ <%#Eval("precio")%></small></p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="mt-0">
                    <asp:Button CssClass="btn btn-toolbar boton-add" ID="addCarrito" Text="Añadir al Carrito" runat="server" CommandArgument='<%#Eval("Id")%>' OnCommand="addCarrito_Command" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
