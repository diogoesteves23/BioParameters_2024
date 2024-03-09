<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecupPassword.aspx.cs" Inherits="BioParameters.RecupPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Recuperar Password</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <a class="navbar-brand" runat="server" href="~/">Aplicação Bio-Paramêtros</a>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-6 col-md-offset-3">
                <div class="panel panel-login">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-xs-6">
                                <a href="#" class="active" id="register-form-link">Recuperar Password</a>
                            </div>
                        </div>
                        <hr />
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <form id="register" method="post" runat="server">
                                    <asp:Button ID="Button3" runat="server" Text="Recuperar Password" class="form-control btn btn-login" OnClick="Button3_Click" Width="202px" />
                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                     <asp:Button ID="Button1" runat="server" Text="Voltar" class="form-control btn btn-login" Width="202px" OnClick="Button1_Click" />
                                    <div class="form-group" id="UserUserName">
                                        <br />
                                        <asp:Label ID="LabelUsername" runat="server" Text="Username:"></asp:Label>
                                        <br />
                                        <asp:TextBox ID="TextBoxUsernameR" runat="server" Width="720px"></asp:TextBox>
                                    </div> 
                                    <div class="form-group" id="UserPasswordR">
                                        <asp:Label ID="LabelP" runat="server" Text=" A sua Password é:" Visible="False"></asp:Label>
                                        &nbsp;<asp:Label ID="LabelPassword" runat="server" Text=""></asp:Label>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <footer style="margin-left: 100px;">
        <p>&copy; <%: DateTime.Now.Year %> - Engenharia Software </p>
    </footer>
</body>
</html>
