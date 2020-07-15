<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TPC_QUINTANA.login" %>

<asp:Content ID="ContentLogin" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .checkbox {
            padding-left: 20px;
        }

            .checkbox label {
                display: inline-block;
                position: relative;
                padding-left: 5px;
            }

                .checkbox label::before {
                    content: "";
                    display: inline-block;
                    position: absolute;
                    width: 17px;
                    height: 17px;
                    left: 0;
                    margin-left: -20px;
                    border: 1px solid #cccccc;
                    border-radius: 3px;
                    background-color: #fff;
                    -webkit-transition: border 0.15s ease-in-out, color 0.15s ease-in-out;
                    -o-transition: border 0.15s ease-in-out, color 0.15s ease-in-out;
                    transition: border 0.15s ease-in-out, color 0.15s ease-in-out;
                }

                .checkbox label::after {
                    display: inline-block;
                    position: absolute;
                    width: 16px;
                    height: 16px;
                    left: 0;
                    top: 0;
                    margin-left: -20px;
                    padding-left: 3px;
                    padding-top: 1px;
                    font-size: 11px;
                    color: #555555;
                }

            .checkbox input[type="checkbox"] {
                opacity: 0;
            }

                .checkbox input[type="checkbox"]:focus + label::before {
                    outline: thin dotted;
                    outline: 5px auto -webkit-focus-ring-color;
                    outline-offset: -2px;
                }

                .checkbox input[type="checkbox"]:checked + label::after {
                    font-family: 'FontAwesome';
                    content: "\f00c";
                }

                .checkbox input[type="checkbox"]:disabled + label {
                    opacity: 0.65;
                }

                    .checkbox input[type="checkbox"]:disabled + label::before {
                        background-color: #eeeeee;
                        cursor: not-allowed;
                    }

            .checkbox.checkbox-circle label::before {
                border-radius: 50%;
            }

            .checkbox.checkbox-inline {
                margin-top: 0;
            }

        .checkbox-primary input[type="checkbox"]:checked + label::before {
            background-color: #428bca;
            border-color: #428bca;
        }

        .checkbox-primary input[type="checkbox"]:checked + label::after {
            color: #fff;
        }

        .checkbox-danger input[type="checkbox"]:checked + label::before {
            background-color: #d9534f;
            border-color: #d9534f;
        }

        .checkbox-danger input[type="checkbox"]:checked + label::after {
            color: #fff;
        }

        .checkbox-info input[type="checkbox"]:checked + label::before {
            background-color: #428BCA;
            border-color: #428BCA;
        }

        .checkbox-info input[type="checkbox"]:checked + label::after {
            color: #fff;
        }

        .checkbox-warning input[type="checkbox"]:checked + label::before {
            background-color: #f0ad4e;
            border-color: #f0ad4e;
        }

        .checkbox-warning input[type="checkbox"]:checked + label::after {
            color: #fff;
        }

        .checkbox-success input[type="checkbox"]:checked + label::before {
            background-color: #5cb85c;
            border-color: #5cb85c;
        }

        .checkbox-success input[type="checkbox"]:checked + label::after {
            color: #fff;
        }
    </style>

    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">EN CASA - Sing Up</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body" style ="margin-left:20%;">
                    <div>
                        <div class="form-group">
                            <asp:TextBox runat="server" ID="mail" type="text" class="form-control" />
                        </div>
                        <div class="form-group">
                            <asp:TextBox runat="server" ID="userTxt" type="text" class="form-control" />
                        </div>
                        <div class="form-group">
                            <asp:TextBox runat="server" ID="pass" type="password" class="form-control" />
                        </div>
                        <div class="form-group">
                            <asp:TextBox runat="server" ID="confirmPass" type="password" class="form-control" />
                        </div>
                    </div>
                </div>
                <div style="margin-left:35%;">
                    <asp:Button runat="server" ID="RegistrarButton" Cssclass="btn btn-primary" Text="Registrar" OnClick="RegistrarButton_Click" UseSubmitBehavior="false" data-dismiss="modal" />
                    <asp:Button runat="server" type="button" class="btn btn-secondary" data-dismiss="modal" Text="Cancelar"></asp:Button>
                </div>
            </div>
        </div>
    </div>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <div class="container h-100" style="margin-top: 10%">
        <div class="row h-100 justify-content-center align-items-center">
            <div class="card">
                <h4 class="card-header">EN CASA</h4>
                <div class="card-body">
                    <div class="invisible" runat="server" id="validation" role="alert">
                        Usuario y/o Contraseña incorrecta.
                    </div>
                    <div data-toggle="validator" role="form">
                        <input type="hidden" class="hide" id="csrf_token" name="csrf_token" value="C8nPqbqTxzcML7Hw0jLRu41ry5b9a10a0e2bc2">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>Email / Usuario</label>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><i class="fa fa-envelope-open-o" aria-hidden="true"></i></span>
                                        </div>
                                        <asp:TextBox runat="server" type="text" class="form-control" name="login_email" ID="usuario" pattern=".{4,}" title="Cuatro(4) o mas caracteres" required="" />
                                    </div>
                                    <div class="help-block with-errors text-danger"></div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>Contraseña</label>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><i class="fa fa-unlock" aria-hidden="true"></i></span>
                                        </div>
                                        <asp:TextBox runat="server" ID="password" type="password" name="login_password" class="form-control" pattern=".{4,}" title="Cuatro(4) o mas caracteres" required="" />
                                    </div>
                                    <div class="help-block with-errors text-danger"></div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <input type="hidden" name="redirect" value="">
                                <asp:Button runat="server" type="submit" ID="Login" OnClick="Login_Click" Cssclass="btn btn-primary btn-lg btn-block" Text="Login"></asp:Button>
                            </div>
                        </div>
                    </div>
                    <div class="clear"></div>
                    <i class="fa fa-user fa-fw"></i>¿No tienes cuenta aún? <a data-toggle="modal" data-target="#exampleModal" data-whatever="@mdo" href="#">Regístrate</a><br>
                    <i class="fa fa-undo fa-fw"></i>¿Se te olvidó tu contraseña? <a href="#">Recupérala</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
