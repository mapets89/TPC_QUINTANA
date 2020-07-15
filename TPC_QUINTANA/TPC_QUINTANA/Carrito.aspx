<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TPC_QUINTANA.Carrito" %>
<asp:Content ID="CarritoContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">

        <style>
            .oculto {
                display: none;
            }

            .precioTotal {
                font-size: 30px;
                text-align: right;
                color:azure;
                font-family: Peralta;
                border-style:none;
                border:none;
            }

            .datosDgv {
                font-family: Cinzel;
                color:black;
                font-size: 15px;
                margin-bottom:0px;
                margin-top:9rem;
            
            }


            .sumaResta{
                width:20px;
                height:20px;
            }

            .eliminar{
                width:30px;
                height:25px;
            }

            .header{
                text-align:center;
                color:white;
            }

            .sinItems{
                margin-top:15rem;
                margin-bottom:15rem;
                font-size:40px;
                color:darkcyan;
                border:none;
                text-align:center;
                font-family:Henny;
            }
            .botonCompra{
                width: auto;
                right:0;
            }
            @font-face {
                font-family: 'Cinzel';
                src: url(fonts/CinzelDecorative-Bold.ttf);
            }

            @font-face {
                font-family: 'Peralta';
                src: url(fonts/Peralta-Regular.ttf);
            }

            @font-face {
                font-family: 'Henny';
                src: url(fonts/HennyPenny-Regular.ttf);
            }

        </style>

        <asp:GridView CssClass="table table-borderless btn-dark text-center datosDgv" ID="dgvCarritoCompras" runat="server" AutoGenerateColumns="false" OnRowCommand="dgvCarritoCompras_RowCommand">
            <Columns>
                <asp:ButtonField HeaderText="Opcion" ItemStyle-CssClass="oculto" HeaderStyle-CssClass="oculto" />
                <asp:BoundField HeaderText="Id" DataField="id" ItemStyle-CssClass="oculto" HeaderStyle-CssClass="oculto" />
                <asp:BoundField HeaderText="Producto" HeaderStyle-CssClass="header" DataField="nombre" ItemStyle-CssClass="alert-info datosDgv" />
                <asp:BoundField HeaderText="Descripcion" HeaderStyle-CssClass="header" DataField="descripcion" ItemStyle-CssClass="alert-info datosDgv" />
                <asp:BoundField HeaderText="Cantidad" HeaderStyle-CssClass="header" DataField="cantidad" ItemStyle-CssClass="alert-info datosDgv" />
                <asp:BoundField HeaderText="Subtotal" HeaderStyle-CssClass="header" DataField="precio" ItemStyle-CssClass="alert-info datosDgv" />
                <asp:ButtonField ButtonType="Image" ControlStyle-BorderStyle="None" ImageUrl="~/images/plus.png"  CommandName="Add" ControlStyle-CssClass="sumaResta" ItemStyle-CssClass="alert-info" />
                <asp:ButtonField ButtonType="Image" ControlStyle-BorderStyle="None" ImageUrl="~/images/substract.png" CommandName="Rest" ControlStyle-CssClass="sumaResta" ItemStyle-CssClass="alert-info" />
                <asp:ButtonField ButtonType="Image" ControlStyle-BorderStyle="None" ImageUrl="~/images/delete.png" CommandName="Eliminar" ControlStyle-CssClass="eliminar" ItemStyle-CssClass="alert-info" />
            </Columns>
        </asp:GridView>
        <asp:Label CssClass="precioTotal btn-info" ID="totalLabel" runat="server"></asp:Label>
        <asp:Button runat="server" ID="comprar" Text="Comprar" Cssclass="btn btn-primary btn-lg btn-block botonCompra" OnClick="comprar_Click"></asp:Button>
        <asp:Label CssClass="" ID="sinItemLabel" runat="server"></asp:Label>
    </div>
</asp:Content>
