<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="marcadetalle.aspx.cs" Inherits="TPC_QUINTANA.marcadetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="navbar-light bg-light">
        <button type="button" id="sidebarCollapse" class="navbar-toggler buttonmenu alert-primary" aria-controls="navbarToggleExternalContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
    </div>
    <div class="container h-100" style="margin-top: 10%">
        <div class="row h-100 justify-content-center align-items-center">
            <div class="card">
                <asp:Label runat="server" Text="AGREGAR MARCA" ID="title" Style="text-align: center;" CssClass="card-header btn-block"></asp:Label>
                <div class="card-body" style="height: 250px; width: 350px;">
                    <div role="form">
                        <div class="col-md-12">
                            <div>
                                <div class="navbar-header">
                                    <a class="navbar-brand">
                                        <asp:Image CssClass="icon" runat="server" ImageUrl="~/images/ic_logo.png" />
                                    </a>
                                </div>
                                <a class="navbar-brand text-logo" runat="server">EN CASA</a>
                            </div>
                            <div class="form-group">
                                <asp:TextBox runat="server" type="text" class="form-control" ID="marcaLabel" required="" />
                            </div>
                            <div>
                                <asp:Button runat="server" ID="Agregar" Text="Agregar" CssClass="btn btn-success btn-block" OnClick="Agregar_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#sidebarCollapse').on('click', function () {
                $('#sidebar').toggleClass('active');
            });
        });
    </script>
</asp:Content>
