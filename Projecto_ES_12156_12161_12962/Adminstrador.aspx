<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Adminstrador.aspx.cs" Inherits="Projecto_ES_12156_12161_12962.Adminstrador" %>

<!DOCTYPE html>
<html>
<head>
    <title>Área Administrador</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <style>
        /* Set height of the grid so .sidenav can be 100% (adjust if needed) */
        .row.content {
            height: 800px
        }

        /* Set gray background color and 100% height */
        .sidenav {
            background-color: #f1f1f1;
            height: 100%;
        }

        /* Set black background color, white text and some padding */
        footer {
            background-color: #555;
            color: white;
            padding: 15px;
        }

        /* On small screens, set height to 'auto' for sidenav and grid */
        @media screen and (max-width: 767px) {
            .sidenav {
                height: auto;
                padding: 15px;
            }

            .row.content {
                height: auto;
            }
        }
        .auto-style1 {
            position: relative;
            min-height: 1px;
            float: left;
            width: 72%;
            left: 0px;
            top: 0px;
            height: 644px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
</head>
<body>
    <form runat="server">
        <div class="container-fluid">
            <div class="row content">
                <div class="col-sm-3 sidenav">
                    <br/>
                    <ul class="nav nav-pills nav-stacked">
                        <li class="active"><a href="#section1">Perfis Pendentes</a></li>
                    </ul>
                    <br/>
                </div>

                <div class="col-sm-9" style="text-align: center">
                    <div style="text-align: left">
                        <asp:Label ID="LabeluserADM" runat="server" Text=""></asp:Label>
                    </div>
                    <br />
                    <h4 style="text-align: left;">Perfis:</h4>
                    <hr/>
                    <asp:Button ID="ButtonValidate" runat="server" Text="Validar Pefis" class="form-control btn btn-login" OnClick="Button1_Click" />
                    <asp:Button ID="ButtonEditable" runat="server" Text="Editar Perfis" class="form-control btn btn-login" OnClick="ButtonEditable_Click" />
                    <br />
                    <br />
                    <asp:ListBox ID="ListBoxPerfis" runat="server" Height="173px" Width="285px" Visible="False"></asp:ListBox>
                    <br />
                    <br />
                    <asp:Button ID="ButtonSelect" runat="server" Text="Selecionar Perfil!" class="form-control btn btn-login" BackColor="#0099FF" OnClick="ButtonSelect_Click" Width="180px" Visible="False" />
                    <asp:Button ID="ButtonEdi" runat="server" Text="Editar Perfil!" class="form-control btn btn-login" BackColor="#0099FF" Width="180px" OnClick="ButtonEditar_Click" Visible="False" />
                    <asp:Button ID="ButtonBack2" runat="server" Text="Voltar!" class="form-control btn btn-login" BackColor="#0099FF" Width="180px" OnClick="ButtonBack_Click1"/>
                </div>
                <div class="auto-style1" id="divDados">
                    <div class="form-group">
                        <asp:Label ID="LabelNome" runat="server" Text="Nome:"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBoxNome" runat="server" Width="816px" ReadOnly="True"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelDtNascimento" runat="server" Text="Data de Nascimento:"></asp:Label>
                        <br />
                        <asp:TextBox ID="CalendarDtNascimento" runat="server" Width="728px" ></asp:TextBox>
                        <asp:Label ID="LabelDtNascimento2" runat="server" Text = "(yyyy-mm-dd)"></asp:Label>
                        <br />
                        <asp:Label ID="LabelNrTelemovel" runat="server" Text="NrTelemovel:"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBoxNrTelemovel" runat="server" Width="816px" ReadOnly="True"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelEmail" runat="server" Text="Email:"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBoxEmail" runat="server" Width="816px"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelGenero" runat="server" Text="Genero:"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBoxGenero" runat="server" Width="816px" ReadOnly="True"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelTipSangue" runat="server" Text="Tipo Sanguineo:"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBoxTipoSangue" runat="server" Width="816px" ReadOnly="True"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelMorada" runat="server" Text="Morada:"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBoxMorada" runat="server" Width="816px" ReadOnly="True"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelCp" runat="server" Text="Codigo Postal:"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBoxCP" runat="server" Width="816px"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelLocal" runat="server" Text="Localidade:"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBoxLocalidade" runat="server" Width="816px"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelCedProf" runat="server" Text="Cedula Profissional:"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBoxCedulaPf" runat="server" Width="816px" ReadOnly="True"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelUser" runat="server" Text="Username:"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBoxUsernameR" runat="server" Width="816px" ReadOnly="True"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelPE" runat="server" Text="Password:" Visible="False"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBoxPE" runat="server" Visible="False"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="LabelTipoPerfil" runat="server" Text="Tipo Perfil:"></asp:Label>
                        <br />
                        <asp:CheckBox ID="CheckBoxAdmin" runat="server" Text = "Administrador"/>
                        <asp:CheckBox ID="CheckBoxMed" runat="server" Text = "Medico"/>
                        <asp:CheckBox ID="CheckBoxUtente" runat="server" Text = "Utente" />
                        <asp:Label ID="LabelTP" runat="server" Visible="False"></asp:Label>
                    </div>
                    <div style="text-align: center">
                        <hr/>
                        <asp:Button ID="ButtonVal" runat="server" Text="Validar Perfil!" class="form-control btn btn-login" BackColor="#0099FF" Width="180px" OnClick="ButtonVal_Click" />
                        <asp:Button ID="ButtonDel" runat="server" Text="Eliminar Perfil!" class="form-control btn btn-login" BackColor="#0099FF" Width="180px" Visible="False" OnClick="ButtonDel_Click" />
                        <asp:Button ID="ButtonUpd" runat="server" Text="Guardar Alterações!" class="form-control btn btn-login" BackColor="#0099FF" Width="180px" OnClick="ButtonUpd_Click" Visible="False" />
                        <asp:Button ID="ButtonBack" runat="server" Text="Voltar!" class="form-control btn btn-login" BackColor="#0099FF" Width="180px" OnClick="ButtonBack_Click"/>
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
