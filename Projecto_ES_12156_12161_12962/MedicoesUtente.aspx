<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MedicoesUtente.aspx.cs" Inherits="Projecto_ES_12156_12161_12962.MedicoesUtente" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>
<html>
<head>
    <title>Área Pessoal</title>
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
                        <li class="active"><a href="#section1">Area Utente:</a></li>
                    </ul>
                    <br>
                </div>

                <div class="col-sm-9">
                    <asp:Label ID="LabelUser" runat="server" Text=""></asp:Label>
                    <br />
                    <br />
                    <div style="text-align: center">
                        <div style="text-align: center">
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:ListBox ID="ListBoxHistorico" runat="server" Height="129px" Visible="False" Width="376px"></asp:ListBox></td>
                                    <td>
                                        <asp:Chart ID="Chart1" runat="server" Height="125px" Width="364px">
                                            <ChartAreas>
                                                <asp:ChartArea Name="ChartArea1">
                                                </asp:ChartArea>
                                            </ChartAreas>
                                        </asp:Chart>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <asp:Button ID="ButtonVerMensagem" runat="server" class="form-control btn btn-login" BackColor="#0099FF" Text="Ver Mensagem" Visible="False" Width="190px" />
                            <br />
                        </div>
                        <br />
                        <asp:TextBox ID="TextBoxVerMensagem" runat="server" TextMode="MultiLine" Width="321px" Visible="False"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelP1" runat="server" Text="1-Pressão Sistólica" Font-Bold="True" Visible="False"></asp:Label>
                        <br />
                        <asp:Label ID="LabelP2" runat="server" Text="2-Pressão Diastólica" Font-Bold="True" Visible="False"></asp:Label>
                        <br />
                        <asp:Label ID="LabelP3" runat="server" Text="3-Glicemia" Font-Bold="True" Visible="False"></asp:Label>
                        <br />
                        <br />
                        <asp:Button ID="ButtonMedicao" runat="server" class="form-control btn btn-login" BackColor="#0099FF" Text="Registar Medições" Width="230px" OnClick="ButtonMedicao_Click" />
                        &nbsp;
                        <asp:Button ID="ButtonHistorico" runat="server" Text="Historico Medições" BackColor="#0099FF" class="form-control btn btn-login" Width="230px" OnClick="ButtonHistorico_Click" />
                        &nbsp;
                        <asp:Button ID="ButtonMensagens" runat="server" class="form-control btn btn-login" BackColor="#0099FF" Text="Mensagens" Width="230px" OnClick="ButtonMensagens_Click" />
                        &nbsp;
                        <asp:Button ID="ButtonVoltar" runat="server" class="form-control btn btn-login" BackColor="#0099FF" Text="Voltar" Width="230px" OnClick="ButtonVoltar_Click" />
                        &nbsp;
                        <asp:Button ID="ButtonVoltarC" class="form-control btn btn-login" BackColor="#0099FF" runat="server" Text="Voltar" Width="230px" Visible="False" OnClick="ButtonVoltarC_Click" />
                    </div>
                    <br />
                    <br />
                    <asp:Label ID="LabelMedicoes" runat="server" Text="Medições:" Font-Bold="True" Font-Size="Medium" Visible="False"></asp:Label>
                    <hr>
                    <div class="form-group">
                        <asp:Label ID="LabelDtMedicao" runat="server" Text="Data:" Visible="False"></asp:Label>
                        <br />
                        <asp:TextBox ID="CalendarDtMedicao" runat="server" Width="639px" Visible="False"></asp:TextBox>
                        <asp:Label ID="LabelDtMedicao2" runat="server" Text="(yyyy-mm-dd)" Visible="False"></asp:Label>
                        <br />
                        <asp:Label ID="LabelParametro" runat="server" Text="Parametro:" Visible="False"></asp:Label>
                        <br />
                        <asp:DropDownList ID="DropDownParametro" runat="server" Visible="False"></asp:DropDownList>
                        &nbsp;<br />
                        <br />
                        <asp:Label ID="LabelValor" runat="server" Text="Valor:" Visible="False"></asp:Label>
                        &nbsp;&nbsp;
                        <asp:TextBox ID="TextBoxValor" runat="server" Visible="False" Width="151px"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="LabelGravidez" runat="server" Text="Gravidez (Preencher apenas em caso afirmativo):" Visible="False"></asp:Label>
                        <br />
                        <asp:Label ID="LabelDtI" runat="server" Text="Data Inicio Diabetes:" Visible="False"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBoxGravidezdtI" runat="server" Visible="False"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelDtF" runat="server" Text="Data Fim Diabetes:" Visible="False"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBoxGravidezdtF" runat="server" Visible="False"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="LabelMensagem" runat="server" Text="Mensagem:" Visible="False"></asp:Label>
                        <asp:TextBox ID="TextBoxMensagem" runat="server" Visible="False" TextMode="MultiLine" Width="574px"></asp:TextBox>
                    </div>
                    <br />
                    <br />
                    <div style="text-align: center">
                        <asp:Button ID="ButtonSubmeter" runat="server" class="form-control btn btn-login" Text="Submeter" name="parameter-submit" OnClick="Button1_Click" BackColor="#0099FF" Visible="False" Width="315px" />
                        <asp:Button ID="ButtonEnviar" runat="server" class="form-control btn btn-login" Text="Enviar" name="parameter-submit" BackColor="#0099FF" Visible="False" Width="315px" OnClick="ButtonEnviar_Click" />
                        <asp:Button ID="ButtonVoltarB" runat="server" Text="Voltar" class="form-control btn btn-login" BackColor="#0099FF" Visible="False" Width="314px" OnClick="ButtonVoltarB_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
