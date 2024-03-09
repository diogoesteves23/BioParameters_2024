<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Projecto_ES_12156_12161_12962._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-6 col-md-offset-3">
                <div class="panel panel-login">
                    <div class="panel-heading"style="text-align:center">
                        <div class="row" style="text-align:center" >
                            <div class="col-xs-6" style="text-align:center">
                                <a href="#" style="text-align:center" class="active" id="login-form-link">Login</a>
                            </div>
                        </div>
                        <hr/>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <form id="login-form" action="Login.aspx" method="post" role="form" style="display: block;">
                                    <div class="form-group" id="UserLogin">
                                        <asp:Label ID="LabelUsername" runat="server" Text="Username:"></asp:Label>
                                        <br />
                                        <asp:TextBox ID="TextBoxUsername" runat="server" Width="727px"></asp:TextBox>
                                    </div>
                                    <div class="form-group" id="UserPassword">
                                        <asp:Label ID="LabelPassword" runat="server" Text="Password:"></asp:Label>
                                        <br />
                                        <asp:TextBox ID="TextBoxPassword" runat="server" Width="730px" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <div class="form-group" id="UserFPassWord">
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="text-center">
                                                    <asp:LinkButton ID="LinkButtonRecover" TabIndex="5" class="forgot-password" runat="server" OnClick="LinkButtonRecover_Click">Forgot Password?</asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                     <div class="form-group">
                                        <div class="row">
                                            <div class="col-sm-6 col-sm-offset-3">
                                                <asp:Button ID="Button4" runat="server" TabIndex="4" Text="Log In" name="login-submit" class="form-control btn btn-login" OnClick="Button1_Click" />
                                                <br />
                                                <br />
                                                <asp:Button ID="Button1" runat="server" Text="Registar" class="form-control btn btn-login" OnClick="Button1_Click1"/>
                                            </div>
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

