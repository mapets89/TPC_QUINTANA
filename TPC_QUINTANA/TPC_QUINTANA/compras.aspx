<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="compras.aspx.cs" Inherits="TPC_QUINTANA.compras" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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

        <asp:GridView CssClass="table table-borderless btn-dark text-center datosDgv" ID="dgvCompras" runat="server" AutoGenerateColumns="false" OnRowCommand="dgvCompras_RowCommand">
            <Columns>
                <asp:ButtonField HeaderText="Opcion" ItemStyle-CssClass="oculto" HeaderStyle-CssClass="oculto" />
                <asp:BoundField HeaderText="Numero de Compra" HeaderStyle-CssClass="header" DataField="idVenta" ItemStyle-CssClass="alert-info datosDgv" />          
                <asp:BoundField HeaderText="Total de la Compra" HeaderStyle-CssClass="header" DataField="precioTotal" ItemStyle-CssClass="alert-info datosDgv" />
                <asp:BoundField DataFormatString="{0:d}" HeaderText="Fecha de Compra" HeaderStyle-CssClass="header" DataField="fecha" ItemStyle-CssClass="alert-info datosDgv" />
                <asp:BoundField HeaderText="Estado de la venta" HeaderStyle-CssClass="header" DataField="estado" ItemStyle-CssClass="alert-info datosDgv"/>
                <asp:ButtonField ButtonType="Button" ControlStyle-BorderStyle="None" Text="Ver Detalle" CommandName="detalle" ControlStyle-CssClass="btn-success btn" ItemStyle-CssClass="alert-info" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
