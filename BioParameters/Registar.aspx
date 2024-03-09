<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registar.aspx.cs" Inherits="BioParameters.Registar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registo</title>
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
                                <a href="#" class="active" id="register-form-link">Register</a>
                            </div>
                        </div>
                        <hr />
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <form id="register" method="post" runat="server">
                                    <asp:Button ID="ButtonUtente" class="form-control btn btn-login" runat="server" Text="Utente" OnClick="ButtonUtente_Click" Width="154px" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="ButtonMedico" class="form-control btn btn-login" runat="server" Text="Medico" OnClick="ButtonMedico_Click" Width="154px" />
                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                     <asp:Button ID="Button1" runat="server" Text="Voltar" class="form-control btn btn-login" Width="154px" OnClick="Button1_Click" />
                                    <div class="form-group" id="UserName">
                                        <asp:Label ID="LabelNome" runat="server" Text="Nome:"></asp:Label>
                                        <br />
                                        <asp:TextBox ID="TextBoxNome" runat="server" Width="720px"></asp:TextBox>
                                    </div>
                                    <div class="form-group" id="UserDtNascimento">
                                        <asp:Label ID="LabelDtNascimento" runat="server" Text="Data de Nascimento:"></asp:Label>
                                        <br />
                                        <asp:TextBox ID="CalendarDtNascimento" runat="server" ></asp:TextBox>
                                        <asp:Label ID="LabelDtNascimento2" runat="server" Text = "(yyyy-mm-dd)"></asp:Label>
                                     </div>
                                     <div class="form-group" id="UserNrTelemovel">
                                        <asp:Label ID="LabelNrTelemovel" runat="server" Text="NrTelemovel:"></asp:Label>
                                        <br />
                                        <asp:TextBox ID="TextBoxNrTelemovel" runat="server" Width="720px"></asp:TextBox>
                                    </div>
                                    <div class="form-group" id="UserEmail">
                                        <asp:Label ID="LabelEmail" runat="server" Text="Email:"></asp:Label>
                                        <br />
                                        <asp:TextBox ID="TextBoxEmail" runat="server" Width="720px"></asp:TextBox>
                                    </div>
                                    <div class="form-group" id="UserGenero">
                                        <asp:Label ID="LabelGenero" runat="server" Text="Genero:"></asp:Label>
                                        <br />
                                        <asp:CheckBox ID="CheckBoxF" runat="server" Text="Feminino" />
                                        <asp:CheckBox ID="CheckBoxM" runat="server" Text="Masculino" />
                                    </div>
                                    <div class="form-group" id="UserGSang">
                                        <asp:Label ID="LabelTipoSanguineo" runat="server" Text="Tipo Sanguineo:"></asp:Label>
                                        <asp:DropDownList ID="DropDownTS" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="form-group" id="UserMorada">
                                        <asp:Label ID="LabelMorada" runat="server" Text="Morada:"></asp:Label>
                                        <br />
                                        <asp:TextBox ID="TextBoxMorada" runat="server" Width="720px"></asp:TextBox>
                                    </div>
                                     <div class="form-group" id="UserCodigoPostal">
                                        <asp:Label ID="LabelCp" runat="server" Text="Codigo Postal:"></asp:Label>
                                        <br />
                                        <asp:TextBox ID="TextBoxCP" runat="server" Width="720px"></asp:TextBox>
                                    </div>
                                    <div class="form-group" id="UserLocalidade">
                                        <asp:Label ID="LabelLocal" runat="server" Text="Localidade:"></asp:Label>
                                        <br />
                                        <asp:TextBox ID="TextBoxLocalidade" runat="server" Width="720px"></asp:TextBox>
                                    </div>
                                    <div class="form-group" id="UserCedProf">
                                        <asp:Label ID="LabelCedProf" runat="server" Text="Cedula Profissional:"></asp:Label>
                                        <br />
                                        <asp:TextBox ID="TextBoxCedulaPf" runat="server" Width="720px"></asp:TextBox>
                                    </div>
                                    <div class="form-group" id="UserUserName">
                                        <asp:Label ID="LabelUsername" runat="server" Text="Username:"></asp:Label>
                                        <br />
                                        <asp:TextBox ID="TextBoxUsernameR" runat="server" Width="720px"></asp:TextBox>
                                    </div>
                                    <div class="form-group" id="UserPasswordR">
                                        <asp:Label ID="LabelPassword" runat="server" Text="Password:"></asp:Label>
                                        <br />
                                        <asp:TextBox ID="TextBoxPassR" runat="server" Width="720px" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <div class="form-group" id="UserPasswordRC">
                                        <asp:Label ID="LabelPasswordRC" runat="server" Text="Confirme Password:"></asp:Label>
                                        <br />
                                        <asp:TextBox ID="TextBoxPassRC" runat="server" Width="720px" TextMode="Password"></asp:TextBox>
                                        <br />
                                        <asp:Label ID="LabelErrorPassword" runat="server" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                                    </div>
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-sm-6 col-sm-offset-3">
                                                <asp:Button ID="Button3" runat="server" Text="Registar" class="form-control btn btn-login" OnClick="Button3_Click" />
                                                <br />
                                                <br />
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
    <footer style="margin-left: 100px;">
        <p>&copy; <%: DateTime.Now.Year %> - Engenharia Software </p>
    </footer>
</body>
</html>
