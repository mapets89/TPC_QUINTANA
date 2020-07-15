<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ventas.aspx.cs" Inherits="TPC_QUINTANA.ventas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>

        <style>
            .oculto {
                display: none;
            }

            .precioTotal {
                font-size: 30px;
                text-align: right;
                color: azure;
                font-family: Peralta;
                border-style: none;
                border: none;
            }

            .datosDgv {
                font-family: Cinzel;
                color: black;
                font-size: 15px;
                margin-bottom: 0px;
                margin-top: 9rem;
            }

            .text-title {
                font-family: Peralta;
                color: darkblue;
                font-size: 30px;
                margin-top: 15px;
            }

            .sumaResta {
                width: 25px;
                height: 25px;
            }

            .eliminar {
                width: 30px;
                height: 25px;
            }

            .sumaResta {
                width: 25px;
                height: 25px;
            }

            .header {
                text-align: center;
                color: white;
            }

            .sinItems {
                margin-top: 15rem;
                margin-bottom: 15rem;
                font-size: 40px;
                color: darkcyan;
                border: none;
                text-align: center;
                font-family: Henny;
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
        <div class="navbar-light bg-light">
            <button type="button" id="sidebarCollapse" class="navbar-toggler buttonmenu" aria-controls="navbarToggleExternalContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
        </div>
        <div>
            <div class="navbar-header" style="margin-left: 35%;">
                <h1>
                    <asp:Label CssClass="navbar-brand text-title" runat="server" Text="Nuestras Ventas"></asp:Label>

                </h1>
                <asp:DropDownList style="position:absolute;right:12%;top:16%;font-family:Peralta;font-size:15px;" CssClass="btn btn-info dropdown-toggle dropright" runat="server" ID="ddlUsuario" AutoPostBack="true" OnSelectedIndexChanged="ddlUsuario_SelectedIndexChanged" ></asp:DropDownList>
                <asp:DropDownList style="position:absolute;right:33%;top:16%;font-family:Peralta;font-size:15px;" CssClass="btn btn-info dropdown-toggle dropright" runat="server" ID="ddlEstado" AutoPostBack="true" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" ></asp:DropDownList>
            </div>
        </div>
        <asp:GridView CssClass="table table-borderless btn-dark text-center datosDgv" ID="dgvVentas" runat="server" AutoGenerateColumns="false" OnRowCommand="dgvVentas_RowCommand" Style="width: 900px; margin-left: 15%; margin-top:10%;">
            <Columns>
                <asp:ButtonField HeaderText="Opcion" ItemStyle-CssClass="oculto" HeaderStyle-CssClass="oculto" />
                <asp:BoundField HeaderText="Numero de Venta" DataField="idVenta" HeaderStyle-CssClass="header" ItemStyle-CssClass="alert-info datosDgv" />
                <asp:BoundField HeaderText="Nombre Usuario" HeaderStyle-CssClass="header" DataField="nombreUsuario" ItemStyle-CssClass="alert-info datosDgv" />
                <asp:BoundField DataFormatString="{0:d}" HeaderText="Fecha de Venta" HeaderStyle-CssClass="header" DataField="fecha" ItemStyle-CssClass="alert-info datosDgv" />
                <asp:BoundField HeaderText="Importe de la Venta" HeaderStyle-CssClass="header" DataField="precioTotal" ItemStyle-CssClass="alert-info datosDgv" />
                <asp:BoundField HeaderText="Estado de la Venta" HeaderStyle-CssClass="header" DataField="estado" ItemStyle-CssClass="alert-info datosDgv" />
                <asp:ButtonField ButtonType="Image" ControlStyle-BorderStyle="None" ImageUrl="~/images/edit.png" CommandName="Modificar" ControlStyle-CssClass="sumaResta" ItemStyle-CssClass="alert-info" />
            </Columns>
        </asp:GridView>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#sidebarCollapse').on('click', function () {
                $('#sidebar').toggleClass('active');
            });
        });
    </script>
</asp:Content>
