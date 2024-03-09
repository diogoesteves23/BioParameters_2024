using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace BioParameters
{
    public partial class MedicoesUtente : System.Web.UI.Page
    {
        string id;
        string username;
        string Mensagens;
        string parametro;
        string parametroID;
        string numMedico;
        string medicoID;
        int numMedicoA;
        string Nome;
        string numMensagens;
        int numMensagensA;
        string mensagemA;
        int numMedicoes;
        string numMedicoesA;
        string numMedicoesB;
        string medID;
        string Data;
        string Valor;
        string Parametro;
        string numParametros;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"];
            username = Request.QueryString["username"];
            LabelUser.Text = "Bem vindo " + username; 
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string parametro = DropDownParametro.SelectedItem.ToString();
            string[] p = parametro.Split('-');
            int pID = int.Parse(p[0]);

            string strcon = "Data Source=localhost;Initial Catalog=TP_ES;Integrated Security=True";
            SqlConnection conexao = new SqlConnection(strcon);

            try
            {
                conexao.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Medições(Data, Valor, UtenteUtenteID, ParametrosParametroID)" + " VALUES('" + CalendarDtMedicao.Text + "','" + TextBoxValor.Text + "','" + id + "', '" + pID + "')", conexao);
                cmd.ExecuteNonQuery();
                
                if (!string.IsNullOrEmpty(TextBoxGravidezdtI.Text))
                {
                    SqlCommand cmdA = new SqlCommand("INSERT INTO Gravidez(InicioDiabetes, FimDiabetes, UtenteUtenteID)" + " VALUES('" + TextBoxGravidezdtI.Text + "','" + TextBoxGravidezdtF.Text + "','" + id + "')", conexao);
                    cmdA.ExecuteNonQuery();
                    TextBoxGravidezdtF.Text = "";
                    TextBoxGravidezdtI.Text = "";
                }
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi possível registar medição!')", true);
            }
            finally
            {
                conexao.Close();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Medição Guardada!')", true);

            }
        }

        protected void ButtonMedicao_Click(object sender, EventArgs e)
        {
            LabelGravidez.Visible = true;
            LabelDtI.Visible = true;
            TextBoxGravidezdtI.Visible = true;
            LabelDtF.Visible = true;
            TextBoxGravidezdtF.Visible = true;
            ButtonMedicao.Visible = false;
            ButtonMensagens.Visible = false;
            ButtonHistorico.Visible = false;
            ButtonVoltar.Visible = false;
            LabelMedicoes.Visible = true;
            LabelDtMedicao.Visible = true;
            CalendarDtMedicao.Visible = true;
            LabelDtMedicao2.Visible = true;
            LabelParametro.Visible = true;
            DropDownParametro.Visible = true;
            LabelValor.Visible = true;
            TextBoxValor.Visible = true;
            ButtonSubmeter.Visible = true;
            ButtonVoltarB.Visible = true;


            //adiciona parametros
            string strcon = "Data Source=localhost;Initial Catalog=TP_ES;Integrated Security=True";

            SqlConnection conexao = new SqlConnection(strcon);
            try
            {
                conexao.Open();
                SqlCommand cmdA = new SqlCommand("SELECT DISTINCT COUNT(ParametroID) FROM Parametros", conexao);
                numParametros = cmdA.ExecuteScalar().ToString();
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi possível encontrar parametros!')", true);
            }
            finally
            {
                conexao.Close();
            }

            for (int i = 1; i <= int.Parse(numParametros); i++)
            {
                try
                {
                    parametroID = i.ToString();
                    conexao.Open();
                    SqlCommand cmdB = new SqlCommand("SELECT DescParametro FROM Parametros" + " WHERE ParametroID = '" + int.Parse(parametroID) + "'", conexao);
                    parametro = cmdB.ExecuteScalar().ToString();
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi carregados perfis!')", true);
                }
                finally
                {
                    conexao.Close();
                }

                if (IsPostBack)
                {
                    DropDownParametro.Items.Add(parametroID + "-" + parametro);
                }
            }
        }

        protected void ButtonVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void ButtonVoltarB_Click(object sender, EventArgs e)
        {
            Response.Redirect("MedicoesUtente.aspx?id=" + id + "&username=" + username);
        }

        protected void ButtonVoltarC_Click(object sender, EventArgs e)
        {
            Response.Redirect("MedicoesUtente.aspx?id=" + id + "&username=" + username);
        }

        protected void ButtonHistorico_Click(object sender, EventArgs e)
        {
            ListBoxHistorico.Items.Clear();
            ListBoxHistorico.Visible = true;
            ButtonHistorico.Visible = false;
            ButtonMedicao.Visible = false;
            ButtonMensagens.Visible = false;
            ButtonVoltar.Visible = false;
            ButtonVoltarC.Visible = true;
            Chart1.Visible = true;
            LabelP1.Visible = true;
            LabelP2.Visible = true;
            LabelP3.Visible = true;

         

            //Preencher com Dados
            string strcon = "Data Source=localhost;Initial Catalog=TP_ES;Integrated Security=True";

            SqlConnection conexao = new SqlConnection(strcon);
            try
            {
                conexao.Open();
                SqlCommand cmdA = new SqlCommand("SELECT DISTINCT COUNT(MediçoesID) FROM Medições" + " WHERE UtenteUtenteID = '" + int.Parse(id) + "'", conexao);
                numMedicoesA = cmdA.ExecuteScalar().ToString();
                numMedicoes = int.Parse(numMedicoesA);
                SqlCommand cmdB = new SqlCommand("SELECT MediçoesID FROM Medições" + " WHERE UtenteUtenteID = '" + int.Parse(id) + "'", conexao);
                numMedicoesB = cmdB.ExecuteScalar().ToString();
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi possível encontrar Medicoes!')", true);
            }
            finally
            {
                conexao.Close();
            }
            if (!string.IsNullOrEmpty(numMedicoesB))
            {
                for (int i = int.Parse(numMedicoesB); i <= numMedicoes; i++)
                {
                    try
                    {
                        conexao.Open();
                        SqlCommand cmdC = new SqlCommand("SELECT Valor FROM Medições " + "WHERE MediçoesID = '" + i + "'", conexao);
                        Valor = cmdC.ExecuteScalar().ToString();
                        SqlCommand cmdE = new SqlCommand("SELECT Data FROM Medições " + "WHERE MediçoesID = '" + i + "'", conexao);
                        Data = cmdE.ExecuteScalar().ToString();
                        SqlCommand cmdD = new SqlCommand("SELECT ParametrosParametroID FROM Medições " + "WHERE MediçoesID = '" + i + "'", conexao);
                        Parametro = cmdD.ExecuteScalar().ToString();
                    }
                    catch
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi possivel carregar histórico!')", true);
                    }
                    finally
                    {
                        conexao.Close();
                    }

                    if (IsPostBack)
                    {
                        ListBoxHistorico.Items.Add(i.ToString() + "-" + "Valor: " + Valor + "-" + "Parametro: " + Parametro + "-" + "Data: " + Data);
                    }
                }
            }

            int items = ListBoxHistorico.Items.Count;
            try
            {
                for (int i = 0; i < items; i++)
                {
                    string item = ListBoxHistorico.Items[i].ToString();
                    string[] ctdItems = item.Split('-');
                    string valor = ctdItems[1].ToString();
                    string[] valorA = valor.Split(':');
                    string valorFinal = valorA[1].ToString();
                    string parametro = ctdItems[2].ToString();
                    string[] parametroA = parametro.Split(':');
                    string parametroFinal = parametroA[1].ToString();


                    if (parametroFinal == " 1")
                    {
                        Chart1.Series.Add("Pressão Sistólica" + i.ToString());
                        Chart1.Series["Pressão Sistólica" + i.ToString()].ChartType = SeriesChartType.Column;
                        Chart1.Series["Pressão Sistólica" + i.ToString()].Points.AddY(int.Parse(valorFinal));
                        Chart1.Legends.Add("Pressão Sistólica" + i.ToString());
                        Chart1.Series["Pressão Sistólica" + i.ToString()].ChartArea = "ChartArea1";
                    }
                    else if (parametroFinal == " 2")
                    {
                        Chart1.Series.Add("Pressão Diastólica" + i.ToString());
                        Chart1.Series["Pressão Diastólica" + i.ToString()].ChartType = SeriesChartType.Column;
                        Chart1.Series["Pressão Diastólica" + i.ToString()].Points.AddY(int.Parse(valorFinal));
                        Chart1.Series["Pressão Diastólica" + i.ToString()].ChartArea = "ChartArea1";
                    }
                    else if (parametroFinal == " 3")
                    {
                        Chart1.Series.Add("Glicemia" + i.ToString());
                        Chart1.Series["Glicemia" + i.ToString()].ChartType = SeriesChartType.Column;
                        Chart1.Series["Glicemia" + i.ToString()].Points.AddY(int.Parse(valorFinal));
                        Chart1.Series["Glicemia" + i.ToString()].ChartArea = "ChartArea1";
                    }
                }
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi possivel carregar o gráfico!')", true);
            }
        }

        protected void ButtonMensagens_Click(object sender, EventArgs e)
        {
            ListBoxHistorico.Visible = true;
            ButtonHistorico.Visible = false;
            ButtonMedicao.Visible = false;
            ButtonMensagens.Visible = false;
            ButtonVoltar.Visible = false;
            ButtonVoltarC.Visible = false;
            ButtonVoltarB.Visible = true;
            ButtonEnviar.Visible = true;
            LabelMensagem.Visible = true;
            TextBoxMensagem.Visible = true;
            LabelParametro.Text = "Medico:";
            DropDownParametro.Items.Clear();
            LabelParametro.Visible = true;
            DropDownParametro.Visible = true;
            LabelDtMedicao.Visible = true;
            LabelDtMedicao2.Visible = true;
            CalendarDtMedicao.Visible = true;
            ButtonVerMensagem.Visible = true;        
            ListBoxHistorico.Items.Clear();


            string strcon = "Data Source=localhost;Initial Catalog=TP_ES;Integrated Security=True";

            SqlConnection conexao = new SqlConnection(strcon);
            try
            {
                conexao.Open();
                SqlCommand cmdA = new SqlCommand("SELECT DISTINCT COUNT(MedicoID) FROM Medico", conexao);
                numMedico = cmdA.ExecuteScalar().ToString();
                numMedicoA = int.Parse(numMedico);
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi possível encontrar Medicoes!')", true);
                throw;
            }
            finally
            {
                conexao.Close();
            }

            // preenchimento medicos
            for (int i = 1; i <= numMedicoA; i++)
            {
                try
                {
                    conexao.Open();
                    SqlCommand cmdC = new SqlCommand("SELECT Nome FROM Medico", conexao);
                    Nome = cmdC.ExecuteScalar().ToString();
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi encontrar medicos!')", true);
                    throw;
                }
                finally
                {
                    conexao.Close();
                }

                if(!string.IsNullOrEmpty(Nome))
                {
                    DropDownParametro.Items.Add(Nome);
                }
            }

            //preenchimento listbox mensagens
            try
            {
                conexao.Open();
                SqlCommand cmdA = new SqlCommand("SELECT DISTINCT COUNT(MensagemID) FROM Mensagens" + " WHERE UtenteUtenteID = '" + int.Parse(id) + "'", conexao);
                numMensagens = cmdA.ExecuteScalar().ToString();
                numMensagensA = int.Parse(numMensagens);
                SqlCommand cmdB = new SqlCommand("SELECT MensagemID FROM Mensagens" + " WHERE UtenteUtenteID = '" + int.Parse(id) + "'", conexao);
                mensagemA = cmdB.ExecuteScalar().ToString();
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi possível encontrar Mensagens!')", true);
            }
            finally
            {
                conexao.Close();
            }
            if (!string.IsNullOrEmpty(mensagemA))
            {
                for (int i = int.Parse(mensagemA); i <= numMensagensA; i++)
                {
                    try
                    {
                        conexao.Open();
                        SqlCommand cmdD = new SqlCommand("SELECT Conteudo FROM Mensagens" + " WHERE MensagemID = '" + i + "'", conexao);
                        Mensagens = cmdD.ExecuteScalar().ToString();
                        SqlCommand cmdE = new SqlCommand("SELECT MedicoMedicoID FROM Mensagens" + " WHERE MensagemID = '" + i + "'", conexao);
                        medicoID = cmdE.ExecuteScalar().ToString();
                        SqlCommand cmdF = new SqlCommand("SELECT nome FROM Medico" + " WHERE MedicoID = '" + medicoID + "'", conexao);
                        Nome = cmdF.ExecuteScalar().ToString();
                    }
                    catch
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi possível encontrar Mensagens!')", true);
                    }
                    finally
                    {
                        conexao.Close();
                    }
                    if (!string.IsNullOrEmpty(Mensagens))
                    {
                        ListBoxHistorico.Items.Add(Mensagens + "-" + " Medico:" + Nome);
                    }
                }
            }
        }

        protected void ButtonEnviar_Click(object sender, EventArgs e)
        {
            string strcon = "Data Source=localhost;Initial Catalog=TP_ES;Integrated Security=True";
            SqlConnection conexao = new SqlConnection(strcon);

            string nome = DropDownParametro.SelectedItem.ToString();
            string[] nomeB = nome.Split('-');
            string nomeFinal = nome;

            try
            {
                conexao.Open();
                SqlCommand cmdC = new SqlCommand("SELECT MedicoID FROM Medico" + " WHERE Nome = '" + nomeFinal + "'", conexao);
                medID= cmdC.ExecuteScalar().ToString();
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi encontrar o medico!')", true);
            }
            finally
            {
                conexao.Close();
            }

            try
            {
                conexao.Open();
                SqlCommand cmdC = new SqlCommand("INSERT INTO Mensagens(Conteudo, Data, MedicoMedicoID, UtenteUtenteID)" + " VALUES('" + TextBoxMensagem.Text + "','" + CalendarDtMedicao.Text + "','" + medID + "', '" + int.Parse(id) + "')", conexao);
                cmdC.ExecuteNonQuery();
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi enviar mensagem!')", true);
                throw;
            }
            finally
            {
                conexao.Close();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Mensagem enviada com sucesso!')", true);
            }
        }

        protected void ButtonVerMensagem_Click(object sender, EventArgs e)
        {
            TextBoxVerMensagem.Visible = true;
            if (ListBoxHistorico.SelectedItem != null)
            {
                string Mensagem = ListBoxHistorico.SelectedItem.ToString();
                string[] MensagemPartes = Mensagem.Split('-');
                TextBoxVerMensagem.Text = MensagemPartes[0].ToString();
            }
        }
    }
}
