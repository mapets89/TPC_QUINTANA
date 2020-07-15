<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="detalleVenta.aspx.cs" Inherits="TPC_QUINTANA.detalleVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
                    <%--<asp:Button CssClass="button-add btn btn-toolbar" ID="modificar" Text="Modificar" runat="server" CommandArgument='<%#Eval("Id")%>' OnCommand="modificar_Command" />
                    <asp:Button CssClass="button-add btn btn-toolbar" ID="eliminar" Text="Eliminar" runat="server" CommandArgument='<%#Eval("Id")%>' OnCommand="eliminar_Command" />--%>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
