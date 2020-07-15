<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="categorias.aspx.cs" Inherits="TPC_QUINTANA.categorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div>
        <div class="navbar-light bg-light">
            <button type="button" id="sidebarCollapse" class="navbar-toggler buttonmenu alert-primary" aria-controls="navbarToggleExternalContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
        </div>
        <style>
            .oculto {
                display: none;
            }
            .text-title {
                font-family: Peralta;
                color:darkblue;
                font-size: 30px;
                margin-top: 15px;
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

            .sumaResta {
                width: 25px;
                height: 25px;
            }

            .eliminar {
                width: 30px;
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
        <div>
            <div class="navbar-header" style="margin-left:28%;">
                <h1>
                <asp:Label CssClass="navbar-brand text-title" runat="server" Text="NUESTRAS  CATEGORIAS"></asp:Label>

                </h1>
            </div>
        </div>

        <asp:GridView CssClass="table table-borderless btn-dark text-center datosDgv" ID="dgvCategorias" runat="server" AutoGenerateColumns="false" OnRowCommand="dgvCategorias_RowCommand" Style="width: 700px; margin-left: 15%;">
            <Columns>
                <asp:ButtonField HeaderText="Opcion" ItemStyle-CssClass="oculto" HeaderStyle-CssClass="oculto" />
                <asp:BoundField HeaderText="Id" DataField="id" ItemStyle-CssClass="oculto" HeaderStyle-CssClass="oculto" />
                <asp:BoundField HeaderText="Categorias" HeaderStyle-CssClass="header" DataField="nombre" ItemStyle-CssClass="alert-info datosDgv" />
                <asp:ButtonField ButtonType="Image" ControlStyle-BorderStyle="None" ImageUrl="~/images/edit.png" CommandName="Modificar" ControlStyle-CssClass="sumaResta" ItemStyle-CssClass="alert-info" />
                <asp:ButtonField ButtonType="Image" ControlStyle-BorderStyle="None" ImageUrl="~/images/delete.png" CommandName="Eliminar" ControlStyle-CssClass="eliminar" ItemStyle-CssClass="alert-info" />
            </Columns>
        </asp:GridView>
        <asp:Button runat="server" ButtonType="Button" ControlStyle-BorderStyle="None" Text="Agregar Categoria" ControlStyle-CssClass="btn btn-success" ItemStyle-CssClass="alert-info" style="margin-left:15%; margin-top:10px; font-family:Peralta;" ID="Agregar" OnClick="Agregar_Click"/>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#sidebarCollapse').on('click', function () {
                $('#sidebar').toggleClass('active');
            });
        });
    </script>
</asp:Content>
