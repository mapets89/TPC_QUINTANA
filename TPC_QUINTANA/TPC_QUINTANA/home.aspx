<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="TPC_QUINTANA.home" %>

<asp:Content ID="HomeContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .image {
            width: 600px;
            height: 500px;
        }

        .carousel-custom {
            margin-top: 90px;
        }
    </style>
    <div id="carouselHome" class="carousel slide carousel-fade active carousel-custom" data-ride="carousel">
        <div class="carousel-inner">
            <div class="carousel-item active">
                <asp:Image runat="server" ImageUrl="~/images/carrousel1.jpg" CssClass="d-block w-100 image" />
            </div>
            <div class="carousel-item">
                <asp:Image runat="server" ImageUrl="~/images/carrousel2.jpg" CssClass="d-block w-100 image" />
            </div>
            <div class="carousel-item">
                <asp:Image runat="server" ImageUrl="~/images/carrousel3.jpg" CssClass="d-block w-100 image" />
            </div>
        </div>
        <a class="carousel-control-prev" href="#carouselHome" role="button" data-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="carousel-control-next" href="#carouselHome" role="button" data-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>
</asp:Content>
