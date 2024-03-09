using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projecto_ES_12156_12161_12962
{
    public partial class AreaMedico : System.Web.UI.Page
    {
        string idQ;
        string usernameQ;
        string numParametros;
        string id;
        string utenteID;
        string utente;
        string utenteNomeSelect;
        string utenteIDSelect;
        string parametro;
        string parametroID;
        int numMedicoes;
        string numMedicoesA;
        string numMedicoesB;
        string medID;
        string Data;
        string Valor;
        string Parametro;
        string Mensagem;
        string medicI;
        string iMed;
        string utenteUtenteID;

        protected void Page_Load(object sender, EventArgs e)
        {
            idQ = Request.QueryString["id"];
            usernameQ = Request.QueryString["username"];
            LabelUser.Text = "Bem vindo " + usernameQ;

            //Preenchimento List Box com utentes
            string strcon = "Data Source=localhost;Initial Catalog=TP_ES;Integrated Security=True";

            SqlConnection conexao = new SqlConnection(strcon);
            try
            {
                conexao.Open();
                SqlCommand cmdA = new SqlCommand("SELECT DISTINCT COUNT(UtenteID) FROM Utente", conexao);
                id = cmdA.ExecuteScalar().ToString();

            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi possível encontrar o perfil!')", true);
            }
            finally
            {
                conexao.Close();
            }

            for (int i = 1; i <= int.Parse(id); i++)
            {
                try
                {
                    conexao.Open();
                    SqlCommand cmdD = new SqlCommand("SELECT UtenteID FROM Utente", conexao);
                    utenteID = cmdD.ExecuteScalar().ToString();
                    SqlCommand cmdB = new SqlCommand("SELECT Nome FROM Utente", conexao);
                    utente = cmdB.ExecuteScalar().ToString();
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi possível encontrar o perfil!')", true);
                }
                finally
                {
                    conexao.Close();
                }

                if (!IsPostBack)
                {
                    ListBoxUtentes.Items.Add(utenteID + "-" + utente);
                }
            }

        }

        protected void ButtonVoltarA_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void ButtonSelecionarUtente_Click(object sender, EventArgs e)
        {
            if (ListBoxUtentes.SelectedItem != null)
            {
                //Design
                ButtonVoltarA.Visible = false;
                ButtonSelecionarUtente.Visible = false;
                ButtonHistorico.Visible = false;
                ButtonMensagens.Visible = false;
                ListBoxUtentes.Visible = false;
                ButtonVoltarB.Visible = true;
                ButtonConsulta.Visible = true;
                LabelDados.Visible = true;
                LabelDtConsulta.Visible = true;
                LabelDtConsulta2.Visible = true;
                CalendarDtConsulta.Visible = true;
                LabelObs.Visible = true;
                TextBoxObs.Visible = true;
                LabelParametro.Visible = true;
                DropDownParametro.Visible = true;
                LabelValor.Visible = true;
                TextBoxValor.Visible = true;
                ButtonInsMed.Visible = true;
                LabelIcd10.Visible = true;
                DropDownListIDC10.Visible = true;
                LabelEstado.Visible = true;
                DropDownListEstado.Visible = true;

                //Preenchimento DropEstados
                if (IsPostBack)
                {
                    DropDownListEstado.Items.Add("Ativo");
                    DropDownListEstado.Items.Add("Resolvido");
                    DropDownListEstado.Items.Add("Cancelado");
                }

                //Preenchimento DropParametros
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

                //Preenchimento DropICD10
                if (IsPostBack)
                {
                    DropDownListIDC10.Items.Add("I-Certain infectious and parasitic diseases");
                    DropDownListIDC10.Items.Add("II-Neoplasms");
                    DropDownListIDC10.Items.Add("III-Diseases of the blood and blood-forming organs and certain disorders involving the immune mechanism");
                    DropDownListIDC10.Items.Add("IV-Endocrine, nutritional and metabolic diseases");
                    DropDownListIDC10.Items.Add("V-Mental and behavioural disorders");
                    DropDownListIDC10.Items.Add("VI-Diseases of the nervous system ");
                    DropDownListIDC10.Items.Add("VII-Diseases of the eye and adnexa");
                    DropDownListIDC10.Items.Add("VIII-Diseases of the ear and mastoid process");
                    DropDownListIDC10.Items.Add("IX-Diseases of the circulatory system");
                    DropDownListIDC10.Items.Add("X-Diseases of the respiratory system");
                    DropDownListIDC10.Items.Add("XI-Diseases of the digestive system ");
                    DropDownListIDC10.Items.Add("XII-Diseases of the skin and subcutaneous tissue");
                    DropDownListIDC10.Items.Add("XIII-Diseases of the musculoskeletal system and connective tissue");
                    DropDownListIDC10.Items.Add("XIV-Diseases of the genitourinary system");
                    DropDownListIDC10.Items.Add("XV-Pregnancy, childbirth and the puerperium");
                    DropDownListIDC10.Items.Add("XVI-Certain conditions originating in the perinatal period ");
                    DropDownListIDC10.Items.Add("XVII-Congenital malformations, deformations and chromosomal abnormalities");
                    DropDownListIDC10.Items.Add("XVIII-Symptoms, signs and abnormal clinical and laboratory findings, not elsewhere classified");
                    DropDownListIDC10.Items.Add("XIX-Injury, poisoning and certain other consequences of external causes");
                    DropDownListIDC10.Items.Add("XX-External causes of morbidity and mortality");
                    DropDownListIDC10.Items.Add("XXI-Factors influencing health status and contact with health services");
                    DropDownListIDC10.Items.Add("XXII-Codes for special purposes");
                }

                //Utente Selecionado
                string utenteSelect;
                utenteSelect = ListBoxUtentes.SelectedItem.ToString();
                LabelUteSelecionado.Text = "Utente Selecionado:" + utenteSelect;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi selecionado um utente!')", true);
            }
        }

        protected void ButtonVoltarB_Click(object sender, EventArgs e)
        {
            Response.Redirect("AreaMedico.aspx?id=" + idQ + "&username=" + usernameQ);
        }

        protected void ButtonConsulta_Click(object sender, EventArgs e)
        {
            string utenteSelect;
            utenteSelect = ListBoxUtentes.SelectedItem.ToString();
            string[] info = utenteSelect.Split('-');
            utenteIDSelect = info[0].ToString();

            //RegistoConsulta
            string strcon = "Data Source=localhost;Initial Catalog=TP_ES;Integrated Security=True";
            SqlConnection conexao = new SqlConnection(strcon);
            try
            {
                conexao.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Consulta(DataConsulta, Observacoes, ICD10, Estado, MedicoMedicoID, UtenteUtenteID)" + " VALUES('" + CalendarDtConsulta.Text + "','" + TextBoxObs.Text + "','" + DropDownListIDC10.SelectedItem.ToString() + "', '" + DropDownListEstado.SelectedItem.ToString() + "', '" + int.Parse(idQ) + "','" + int.Parse(utenteIDSelect) + "')", conexao);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi possível encontrar o perfil!')", true);
            }
            finally
            {
                conexao.Close();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Consulta Guardada!')", true);

            }
        }

        protected void ButtonHistorico_Click(object sender, EventArgs e)
        {
            if (ListBoxUtentes.SelectedItem != null)
            {
                string utenteSelect;
                utenteSelect = ListBoxUtentes.SelectedItem.ToString();
                LabelUteSelecionado.Text = "Utente Selecionado:" + utenteSelect;


                string utenteSelectID;
                utenteSelectID = ListBoxUtentes.SelectedItem.ToString();
                string[] info = utenteSelectID.Split('-');
                utenteIDSelect = info[0].ToString();

                //Design
                ButtonVoltarA.Visible = false;
                ButtonSelecionarUtente.Visible = false;
                ButtonHistorico.Visible = false;
                ButtonMensagens.Visible = false;
                ListBoxUtentes.Visible = true;
                ButtonVoltarB.Visible = false;
                ButtonVoltarC.Visible = true;
                ButtonConsulta.Visible = false;
                LabelDados.Visible = false;
                LabelDtConsulta.Visible = false;
                LabelDtConsulta2.Visible = false;
                CalendarDtConsulta.Visible = false;
                LabelObs.Visible = false;
                TextBoxObs.Visible = false;
                LabelIcd10.Visible = false;
                DropDownListIDC10.Visible = false;
                LabelEstado.Visible = false;
                DropDownListEstado.Visible = false;
                LabelP1.Visible = true;
                LabelP2.Visible = true;
                LabelP3.Visible = true;
                ListBoxUtentes.Items.Clear();



                //Preencher com Dados
                string strcon = "Data Source=localhost;Initial Catalog=TP_ES;Integrated Security=True";

                SqlConnection conexao = new SqlConnection(strcon);
                try
                {
                    conexao.Open();
                    SqlCommand cmdA = new SqlCommand("SELECT DISTINCT COUNT(MediçoesID) FROM Medições" + " WHERE UtenteUtenteID = '" + int.Parse(utenteIDSelect) + "'", conexao);
                    numMedicoesA = cmdA.ExecuteScalar().ToString();
                    numMedicoes = int.Parse(numMedicoesA);
                    SqlCommand cmdB = new SqlCommand("SELECT MediçoesID FROM Medições" + " WHERE UtenteUtenteID = '" + int.Parse(utenteIDSelect) + "'", conexao);
                    numMedicoesB = cmdB.ExecuteScalar().ToString();
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi possível encontrar MEdicoes!')", true);

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
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi carregados perfis!')", true);

                        }
                        finally
                        {
                            conexao.Close();
                        }

                        if (IsPostBack)
                        {
                            ListBoxUtentes.Items.Add(i.ToString() + "-" + "Valor: " + Valor + "-" + "Parametro: " + Parametro + "-" + "Data: " + Data);
                        }
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi selecionado um utente!')", true);
            }
        }

        protected void ButtonSelectMedi_Click(object sender, EventArgs e)
        {
            //carrega parametros das medições
        }

        protected void ButtonInsMed_Click(object sender, EventArgs e)
        {
            string[] info = LabelUteSelecionado.Text.Split(':');
            utenteIDSelect = info[0].ToString();
            utenteNomeSelect = info[1].ToString();
            string[] utenteB = utenteNomeSelect.Split('-');
            string utenteSelecionadoB = utenteB[0].ToString();

            string parametro = DropDownParametro.SelectedItem.ToString();
            string[] p = parametro.Split('-');
            int pID = int.Parse(p[0]);

            string strcon = "Data Source=localhost;Initial Catalog=TP_ES;Integrated Security=True";
            SqlConnection conexao = new SqlConnection(strcon);

            try
            {
                conexao.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Medições(Data, Valor, MedicoMedicoID, UtenteUtenteID, ParametrosParametroID)" + " VALUES('" + CalendarDtConsulta.Text + "','" + TextBoxValor.Text + "','" + int.Parse(idQ) + "', '" + int.Parse(utenteSelecionadoB) + "', '" + pID + "')", conexao);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi possível registar medição!')", true);
            }
            finally
            {
                conexao.Close();
                TextBoxValor.Text = "";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Medição Guardada!')", true);

            }
        }

        protected void ButtonVoltarC_Click(object sender, EventArgs e)
        {
            Response.Redirect("AreaMedico.aspx?id=" + idQ + "&username=" + usernameQ);
        }

        protected void ButtonMensagens_Click(object sender, EventArgs e)
        {
            if (ListBoxUtentes.SelectedItem != null)
            {
                string utenteSelect;
                utenteSelect = ListBoxUtentes.SelectedItem.ToString();
                LabelUteSelecionado.Text = "Utente Selecionado:" + utenteSelect;


                string utenteSelectID;
                utenteSelectID = ListBoxUtentes.SelectedItem.ToString();
                string[] info = utenteSelectID.Split('-');
                utenteIDSelect = info[0].ToString();

                //Design
                ButtonVoltarA.Visible = false;
                ButtonSelecionarUtente.Visible = false;
                ButtonHistorico.Visible = false;
                ButtonMensagens.Visible = false;
                ListBoxUtentes.Visible = true;
                ButtonVoltarB.Visible = true;
                ButtonVoltarC.Visible = false;
                ButtonConsulta.Visible = false;
                LabelDados.Visible = false;
                LabelDtConsulta.Visible = true;
                LabelDtConsulta2.Visible = true;
                CalendarDtConsulta.Visible = true;
                LabelObs.Visible = false;
                TextBoxObs.Visible = false;
                LabelIcd10.Visible = false;
                DropDownListIDC10.Visible = false;
                LabelEstado.Visible = false;
                LabelMensagem.Visible = true;
                TextBoxMensagem.Visible = true;
                ButtonEnviar.Visible = true;
                DropDownListEstado.Visible = false;
                LabelP1.Visible = false;
                LabelP2.Visible = false;
                LabelP3.Visible = false;
                DropDownParametro.Items.Clear();
                ListBoxUtentes.Items.Clear();
                ButtonVerMensagem.Visible = true;

                //Preencher com Dados
                string strcon = "Data Source=localhost;Initial Catalog=TP_ES;Integrated Security=True";

                SqlConnection conexao = new SqlConnection(strcon);
                try
                {
                    conexao.Open();
                    SqlCommand cmdA = new SqlCommand("SELECT DISTINCT COUNT(MensagemID) FROM Mensagens" + " WHERE UtenteUtenteID = '" + int.Parse(utenteIDSelect) + "' AND MedicoMedicoID = '" + int.Parse(idQ) + "'", conexao);
                    numMedicoesA = cmdA.ExecuteScalar().ToString();
                    numMedicoes = int.Parse(numMedicoesA);
                    SqlCommand cmdB = new SqlCommand("SELECT MensagemID FROM Mensagens" + " WHERE UtenteUtenteID = '" + int.Parse(utenteIDSelect) + "' AND MedicoMedicoID = '" + int.Parse(idQ) + "'", conexao);
                    numMedicoesB = cmdB.ExecuteScalar().ToString();
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi possível encontrar Mensagens!')", true);
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
                            SqlCommand cmdD = new SqlCommand("SELECT Conteudo FROM Mensagens" + " WHERE UtenteUtenteID = '" + int.Parse(utenteIDSelect) + "' AND MedicoMedicoID = '" + int.Parse(idQ) + "' AND MensagemID = '" + i + "'", conexao);
                            Mensagem = cmdD.ExecuteScalar().ToString();

                        }
                        catch
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi carregados perfis!')", true);
                            throw;
                        }
                        finally
                        {
                            conexao.Close();
                        }

                        if (IsPostBack)
                        {
                            ListBoxUtentes.Items.Add("ID: " + i.ToString() + "- Mensagem: " + Mensagem);
                        }
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi selecionado um utente!')", true);
            }
        }

        protected void ButtonEnviar_Click(object sender, EventArgs e)
        {

            string nomeUtente = LabelUteSelecionado.Text;
            string[] nome = nomeUtente.Split('-');
            string nomeUtenteA = nome[1].ToString();


            string strcon = "Data Source=localhost;Initial Catalog=TP_ES;Integrated Security=True";

            SqlConnection conexao = new SqlConnection(strcon);
            try
            {
                conexao.Open();
                SqlCommand cmdC = new SqlCommand("SELECT UtenteID FROM Utente" + " WHERE Nome = '" + nomeUtenteA + "'", conexao);
                utenteID = cmdC.ExecuteScalar().ToString();
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
                SqlCommand cmdC = new SqlCommand("INSERT INTO Mensagens(Conteudo, Data, MedicoMedicoID, UtenteUtenteID)" + " VALUES('" + TextBoxMensagem.Text + "','" + CalendarDtConsulta.Text + "','" + int.Parse(idQ)+ "', '" + int.Parse(utenteID) + "')", conexao);
                cmdC.ExecuteNonQuery();
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi enviar mensagem!')", true);
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
            if (ListBoxUtentes.SelectedItem != null)
            {
                string Mensagem = ListBoxUtentes.SelectedItem.ToString();
                string[] MensagemPartes = Mensagem.Split('-');
                string mensagemB = MensagemPartes[1].ToString();
                string[] mensagemFinal = mensagemB.Split(':');
                TextBoxVerMensagem.Text = mensagemFinal[1].ToString();
             }
        }

        protected void ButtonAlertas_Click(object sender, EventArgs e)
        {
            //Design
            ButtonVoltarA.Visible = false;
            ButtonSelecionarUtente.Visible = false;
            ButtonHistorico.Visible = false;
            ButtonMensagens.Visible = false;
            ListBoxUtentes.Visible = true;
            ButtonVoltarB.Visible = false;
            ButtonVoltarC.Visible = true;
            ButtonConsulta.Visible = false;
            LabelDados.Visible = false;
            LabelDtConsulta.Visible = false;
            LabelDtConsulta2.Visible = false;
            CalendarDtConsulta.Visible = false;
            LabelObs.Visible = false;
            TextBoxObs.Visible = false;
            LabelIcd10.Visible = false;
            DropDownListIDC10.Visible = false;
            LabelEstado.Visible = false;
            DropDownListEstado.Visible = false;
            ListBoxUtentes.Items.Clear();
            ButtonAlertas.Visible = false;
            LabelAlertas.Visible = true;
            

            string strcon = "Data Source=localhost;Initial Catalog=TP_ES;Integrated Security=True";

            SqlConnection conexao = new SqlConnection(strcon);
            try
            {
                conexao.Open();
                SqlCommand cmdC = new SqlCommand("SELECT DISTINCT(MediçoesID) FROM Medições", conexao);
                medicI = cmdC.ExecuteScalar().ToString();
                SqlCommand cmdD = new SqlCommand("SELECT MediçoesID FROM Medições", conexao);
                iMed = cmdD.ExecuteScalar().ToString();
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foram encontrados alertas!')", true);
            }
            finally
            {
                conexao.Close();
            }

            if(!string.IsNullOrEmpty(medicI) && !string.IsNullOrEmpty(iMed))
            {
                for(int i = int.Parse(iMed); i <= int.Parse(medicI); i++)
                {
                    try
                    {
                        conexao.Open();
                        SqlCommand cmdC = new SqlCommand("SELECT UtenteUtenteID FROM Medições WHERE '" + i + "' MediçoesID =  (ParametrosParametroID = 1 AND Valor > 120) OR (ParametrosParametroID = 2 AND Valor > 80) OR (ParametrosParametroID = 3 AND Valor > 70 AND Valor < 140)", conexao);
                        utenteUtenteID = cmdC.ExecuteScalar().ToString();
                    }
                    catch
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foram encontradas medições excessivas!')", true);
                    }
                    finally
                    {
                        conexao.Close();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Medições Adicionadas!')", true);
                    }

                    if(!string.IsNullOrEmpty(utenteUtenteID))
                    {
                        ListBoxUtentes.Items.Add(utenteUtenteID);
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foram encontradas alertas!')", true);
            }
        }
    }
}