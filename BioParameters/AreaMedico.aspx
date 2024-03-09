<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AreaMedico.aspx.cs" Inherits="BioParameters.AreaMedico" %>

<!DOCTYPE html>
<html>
<head>
    <title>Área Medico</title>
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
    </style>
</head>
<body>
    <form runat="server">
        <div class="container-fluid">
            <div class="row content">
                <div class="col-sm-3 sidenav">
                    <br>
                    <ul class="nav nav-pills nav-stacked">
                        <li class="active"><a href="#section1">Area Medico</a></li>
                    </ul>
                    <br>
                </div>

                <div class="col-sm-9">
                    <asp:Label ID="LabelUser" runat="server" Text=""></asp:Label>
                    <br />
                    <asp:Label ID="LabelAlertas" runat="server" Text="Alertas:" Visible="False"></asp:Label>
                    <br />
                    <br />
                    <br />
                    <div style="text-align: center">
                        <asp:ListBox ID="ListBoxUtentes" runat="server" Height="184px" Width="370px"></asp:ListBox>
                        <br />
                        <asp:Button ID="ButtonVerMensagem" runat="server" class="form-control btn btn-login" BackColor="#0099FF" Text="Ver Mensagem" Visible="False" Width="190px" OnClick="ButtonVerMensagem_Click" />
                        <br />
                        <asp:TextBox ID="TextBoxVerMensagem" runat="server" TextMode="MultiLine" Width="321px" Visible="False"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Button ID="ButtonSelecionarUtente" class="form-control btn btn-login" runat="server" BackColor="#0099FF" Text="Selecionar Utente" Width="200px" OnClick="ButtonSelecionarUtente_Click" />
                        <asp:Button ID="ButtonHistorico" runat="server" Text="Historico Medições" BackColor="#0099FF" class="form-control btn btn-login" Width="200px" OnClick="ButtonHistorico_Click" />
                        <asp:Button ID="ButtonMensagens" runat="server" Text="Mensagens" BackColor="#0099FF" class="form-control btn btn-login" Width="200px" OnClick="ButtonMensagens_Click" />
                        <asp:Button ID="ButtonAlertas" runat="server" Text="Alertas" BackColor="#0099FF" class="form-control btn btn-login" Width="200px" OnClick="ButtonAlertas_Click" />
                        <asp:Button ID="ButtonVoltarA" class="form-control btn btn-login" BackColor="#0099FF" runat="server" Text="Voltar" Width="200px" OnClick="ButtonVoltarA_Click" />
                         <asp:Button ID="ButtonVoltarC" class="form-control btn btn-login" BackColor="#0099FF" runat="server" Text="Voltar" Width="200px" OnClick="ButtonVoltarC_Click" Visible="False"/>
                    </div>
                    <br />
                    <asp:Label ID="LabelUteSelecionado" runat="server" Text=""></asp:Label>
                    <br />
                    <asp:Label ID="LabelP1" runat="server" Text="1-Pressão Sistólica" Font-Bold="True" Visible="False"></asp:Label>
                    <br />
                    <asp:Label ID="LabelP2" runat="server" Text="2-Pressão Diastólica" Font-Bold="True" Visible="False"></asp:Label>
                    <br />
                    <asp:Label ID="LabelP3" runat="server" Text="3-Glicemia" Font-Bold="True" Visible="False"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="LabelDados" runat="server" Text="Consulta:" Visible="False" Font-Bold="True"></asp:Label>
                    <br />
                    <br />
                    <div class="form-group">
                        <asp:Label ID="LabelDtConsulta" runat="server" Text="Data:" Visible="False"></asp:Label>
                        <br />
                        <asp:TextBox ID="CalendarDtConsulta" runat="server" Width="639px" Visible="False"></asp:TextBox>
                        <asp:Label ID="LabelDtConsulta2" runat="server" Text="(yyyy-mm-dd)" Visible="False"></asp:Label>
                        <br />
                        <asp:Label ID="LabelMensagem" runat="server" Text="Mensagem:" Visible="False"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBoxMensagem" runat="server" Visible="False" TextMode="MultiLine" Width="564px"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="LabelObs" runat="server" Text="Observações:" Visible="False"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBoxObs" runat="server" Width="729px" TextMode="MultiLine" Visible="False"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="LabelParametro" runat="server" Text="Parametro:" Visible="False"></asp:Label>
                        <br />
                        <asp:DropDownList ID="DropDownParametro" runat="server" Visible="False"></asp:DropDownList>
                        <br />
                        <br />
                        <asp:Label ID="LabelValor" runat="server" Text="Valor:" Visible="False"></asp:Label>
                         &nbsp;&nbsp;
                        <asp:TextBox ID="TextBoxValor" runat="server" Visible="False"></asp:TextBox>
                        &nbsp;&nbsp;
                        <asp:Button ID="ButtonInsMed" runat="server"  class="form-control btn btn-login" BackColor="#0099FF" Text="Inserir Medicão" Width="124px" OnClick="ButtonInsMed_Click" Visible="False" />
                    </div>
                    <div class="form-group">
                        <asp:Label ID="LabelIcd10" runat="server" Text="ICD10:" Visible="False"></asp:Label>
                        <br />
                        <asp:DropDownList ID="DropDownListIDC10" runat="server" Visible="False"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="LabelEstado" runat="server" Text="Estado:" Visible="False"></asp:Label>
                        <br />
                        <asp:DropDownList ID="DropDownListEstado" runat="server" Visible="False"></asp:DropDownList>
                    </div>
                    <div style="text-align: center">
                        <asp:Button ID="ButtonConsulta" class="form-control btn btn-login" BackColor="#0099FF" runat="server" Text="Guardar Dados Consulta" Width="301px" Visible="False" OnClick="ButtonConsulta_Click" />
                        &nbsp;
                        <asp:Button ID="ButtonEnviar" class="form-control btn btn-login" BackColor="#0099FF" runat="server" Text="Enviar Mensagem" Width="301px" Visible="False" OnClick="ButtonEnviar_Click" />
                        &nbsp;
                        <asp:Button ID="ButtonVoltarB" class="form-control btn btn-login" BackColor="#0099FF" runat="server" Text="Voltar" Width="301px" OnClick="ButtonVoltarB_Click" Visible="False" />
                    </div>
                    <hr>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
