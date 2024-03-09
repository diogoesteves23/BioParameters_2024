using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Projecto_ES_12156_12161_12962
{
    public partial class Adminstrador : System.Web.UI.Page
    {
        string tipoPerfil;
        int utilizadorID;
        int codigoPostalID;
        string id;
        string username;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            id = Request.QueryString["id"];
            username = Request.QueryString["username"];

            if(!string.IsNullOrEmpty(username))
            {
                LabeluserADM.Text = "Bem vindo " + username;
            }
            else
            {
                LabeluserADM.Text = "";
            }
              
            LabelNome.Visible = false;
            TextBoxNome.Visible = false;
            LabelDtNascimento.Visible = false;
            LabelDtNascimento2.Visible = false;
            CalendarDtNascimento.Visible = false;
            LabelNrTelemovel.Visible = false;
            TextBoxNrTelemovel.Visible = false;
            LabelEmail.Visible = false;
            TextBoxEmail.Visible = false;
            LabelGenero.Visible = false;
            TextBoxGenero.Visible = false;
            LabelTipSangue.Visible = false;
            TextBoxTipoSangue.Visible = false;
            LabelMorada.Visible = false;
            TextBoxMorada.Visible = false;
            LabelCp.Visible = false;
            TextBoxCP.Visible = false;
            LabelLocal.Visible = false;
            TextBoxLocalidade.Visible = false;
            LabelCedProf.Visible = false;
            TextBoxCedulaPf.Visible = false;
            LabelUser.Visible = false;
            TextBoxUsernameR.Visible = false;
            ButtonDel.Visible = false;
            ButtonVal.Visible = false;
            ButtonUpd.Visible = false;
            ButtonBack.Visible = false;
            ButtonBack2.Visible = true;
            LabelTipoPerfil.Visible = false;
            CheckBoxAdmin.Visible = false;
            CheckBoxMed.Visible = false;
            CheckBoxUtente.Visible = false;
        }

        protected void ButtonSelect_Click(object sender, EventArgs e)
        {
            if (ListBoxPerfis.SelectedValue != null)
            {
                LabelNome.Visible = true;
                TextBoxNome.Visible = true;
                LabelDtNascimento.Visible = true;
                LabelDtNascimento2.Visible = true;
                CalendarDtNascimento.Visible = true;
                LabelNrTelemovel.Visible = true;
                TextBoxNrTelemovel.Visible = true;
                LabelEmail.Visible = true;
                TextBoxEmail.Visible = true;
                LabelGenero.Visible = true;
                TextBoxGenero.Visible = true;
                LabelTipSangue.Visible = true;
                TextBoxTipoSangue.Visible = true;
                LabelMorada.Visible = true;
                TextBoxMorada.Visible = true;
                LabelCp.Visible = true;
                TextBoxCP.Visible = true;
                LabelLocal.Visible = true;
                TextBoxLocalidade.Visible = true;
                LabelCedProf.Visible = true;
                TextBoxCedulaPf.Visible = true;
                LabelUser.Visible = true;
                TextBoxUsernameR.Visible = true;
                ButtonVal.Visible = true;
                ButtonSelect.Visible = false;
                ButtonEdi.Visible = false;
                ListBoxPerfis.Visible = false;
                ButtonBack.Visible = true;
                ButtonBack2.Visible = false;
                LabelTipoPerfil.Visible = true;
                CheckBoxAdmin.Visible = true;
                CheckBoxMed.Visible = true;
                CheckBoxUtente.Visible = true;

                string path = "~/Registos";

                string id = ListBoxPerfis.SelectedValue + ".xml";

                string pathFinal = Path.Combine(path, id);

                XmlDocument ficheiro = new XmlDocument();
                ficheiro.Load(Server.MapPath(pathFinal));
                XmlElement elemento = ficheiro.DocumentElement;

                foreach (XmlNode nodoraiz in elemento.ChildNodes)
                {
                    foreach (XmlNode nodo in nodoraiz.ChildNodes)
                    {
                        switch (nodo.Name)
                        {
                            case "NOME":
                                TextBoxNome.Text = nodo.InnerText.ToString();
                                break;
                            case "TELEMOVEL":
                                TextBoxNrTelemovel.Text = nodo.InnerText.ToString();
                                break;
                            case "DTNASCIMENTO":
                                CalendarDtNascimento.Text = nodo.InnerText.ToString();
                                break;
                            case "GENERO":
                                TextBoxGenero.Text = nodo.InnerText.ToString();
                                break;
                            case "EMAIL":
                                TextBoxEmail.Text = nodo.InnerText.ToString();
                                break;
                            case "TIPOSANGUE":
                                TextBoxTipoSangue.Text = nodo.InnerText.ToString();
                                break;
                            case "MORADA":
                                TextBoxMorada.Text = nodo.InnerText.ToString();
                                break;
                            case "CODPOSTAL":
                                TextBoxCP.Text = nodo.InnerText.ToString();
                                break;
                            case "LOCALIDADE":
                                TextBoxLocalidade.Text = nodo.InnerText.ToString();
                                break;
                            case "CEDPROF":
                                TextBoxCedulaPf.Text = nodo.InnerText.ToString();
                                if (String.IsNullOrEmpty(TextBoxCedulaPf.Text))
                                {
                                    CheckBoxMed.Visible = false;
                                    LabelCedProf.Visible = false;
                                    TextBoxCedulaPf.Visible = false;
                                }
                                else if (!String.IsNullOrEmpty(TextBoxCedulaPf.Text))
                                {
                                    CheckBoxAdmin.Visible = false;
                                    CheckBoxUtente.Visible = false;
                                }
                                break;
                            case "USERNAME":
                                TextBoxUsernameR.Text = nodo.InnerText.ToString();
                                break;
                            case "PASSWORD":
                                TextBoxPE.Text = nodo.InnerText.ToString();
                                break;
                        }
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecione um perfil!')", true);
            }
        }

        protected void ButtonEditar_Click(object sender, EventArgs e)
        {
            if (ListBoxPerfis.SelectedValue != null)
            {
                LabelPE.Visible = true;
                TextBoxPE.Visible = true;
                ButtonDel.Visible = true;
                LabelNome.Visible = true;
                TextBoxNome.Visible = true;
                TextBoxNome.ReadOnly = false;
                LabelDtNascimento.Visible = true;
                LabelDtNascimento2.Visible = true;
                CalendarDtNascimento.Visible = true;
                CalendarDtNascimento.ReadOnly = false;
                LabelNrTelemovel.Visible = true;
                TextBoxNrTelemovel.Visible = true;
                TextBoxNrTelemovel.ReadOnly = false;
                LabelEmail.Visible = true;
                TextBoxEmail.Visible = true;
                TextBoxEmail.ReadOnly = false;
                LabelGenero.Visible = true;
                TextBoxGenero.Visible = true;
                TextBoxGenero.ReadOnly = false;
                LabelTipSangue.Visible = true;
                TextBoxTipoSangue.Visible = true;
                TextBoxTipoSangue.ReadOnly = false;
                LabelMorada.Visible = true;
                TextBoxMorada.Visible = true;
                TextBoxMorada.ReadOnly = false;
                LabelCp.Visible = true;
                TextBoxCP.Visible = true;
                TextBoxCP.ReadOnly = false;
                LabelLocal.Visible = true;
                TextBoxLocalidade.Visible = true;
                TextBoxLocalidade.ReadOnly = false;
                LabelCedProf.Visible = true;
                TextBoxCedulaPf.Visible = true;
                TextBoxCedulaPf.ReadOnly = false;
                LabelUser.Visible = true;
                TextBoxUsernameR.Visible = true;
                TextBoxUsernameR.ReadOnly = true;
                ButtonVal.Visible = false;
                ButtonSelect.Visible = false;
                ButtonEdi.Visible = false;
                ButtonUpd.Visible = true;
                ListBoxPerfis.Visible = false;
                ButtonBack.Visible = true;
                ButtonBack2.Visible = false;
                LabelTipoPerfil.Visible = true;
                LabelTP.Visible = true;
                CheckBoxAdmin.Visible = false;
                CheckBoxMed.Visible = false;
                CheckBoxUtente.Visible = false;

                string path = "~/RegistosValidados";

                string id = ListBoxPerfis.SelectedValue + ".xml";

                string pathFinal = Path.Combine(path, id);

                XmlDocument ficheiro = new XmlDocument();
                ficheiro.Load(Server.MapPath(pathFinal));
                XmlElement elemento = ficheiro.DocumentElement;

                foreach (XmlNode nodoraiz in elemento.ChildNodes)
                {
                    foreach (XmlNode nodo in nodoraiz.ChildNodes)
                    {
                        switch (nodo.Name)
                        {
                            case "NOME":
                                TextBoxNome.Text = nodo.InnerText.ToString();
                                break;
                            case "TELEMOVEL":
                                TextBoxNrTelemovel.Text = nodo.InnerText.ToString();
                                break;
                            case "DTNASCIMENTO":
                                CalendarDtNascimento.Text = nodo.InnerText.ToString();
                                break;
                            case "GENERO":
                                TextBoxGenero.Text = nodo.InnerText.ToString();
                                break;
                            case "EMAIL":
                                TextBoxEmail.Text = nodo.InnerText.ToString();
                                break;
                            case "TIPOSANGUE":
                                TextBoxTipoSangue.Text = nodo.InnerText.ToString();
                                break;
                            case "MORADA":
                                TextBoxMorada.Text = nodo.InnerText.ToString();
                                break;
                            case "CODPOSTAL":
                                TextBoxCP.Text = nodo.InnerText.ToString();
                                break;
                            case "LOCALIDADE":
                                TextBoxLocalidade.Text = nodo.InnerText.ToString();
                                break;
                            case "CEDPROF":
                                TextBoxCedulaPf.Text = nodo.InnerText.ToString();
                                if (String.IsNullOrEmpty(TextBoxCedulaPf.Text))
                                {
                                    CheckBoxMed.Visible = false;
                                    LabelCedProf.Visible = false;
                                    TextBoxCedulaPf.Visible = false;
                                }
                                else if (!String.IsNullOrEmpty(TextBoxCedulaPf.Text))
                                {
                                    CheckBoxAdmin.Visible = false;
                                    CheckBoxUtente.Visible = false;
                                }
                                break;
                            case "USERNAME":
                                TextBoxUsernameR.Text = nodo.InnerText.ToString();
                                break;
                            case "PASSWORD":
                                TextBoxPE.Text = nodo.InnerText.ToString();
                                break;
                            case "TIPOPERFIL":
                                LabelTP.Text = nodo.InnerText.ToString();
                                break;
                        }
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecione um perfil!')", true);
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Adminstrador.aspx?id=" + id + "&username=" + username);
        }

        protected void ButtonVal_Click(object sender, EventArgs e)
        {
            string fileName = ListBoxPerfis.SelectedItem.ToString();

            string strcon = "Data Source=localhost;Initial Catalog=TP_ES;Integrated Security=True";

            if (CheckBoxAdmin.Checked == true)
            {
                tipoPerfil = "Administrador";
                SqlConnection conexao = new SqlConnection(strcon);

                try
                {
                    conexao.Open();
                    SqlCommand cmdC = new SqlCommand("INSERT INTO CodigoPostal(Codigo, Localidade)" + " VALUES('" + TextBoxCP.Text + "','" + TextBoxLocalidade.Text + "')", conexao);
                    cmdC.ExecuteNonQuery();
                    SqlCommand cmdE = new SqlCommand("SELECT CodigoPostalID FROM CodigoPostal" + " WHERE Codigo = '" + TextBoxCP.Text + "'", conexao);
                    codigoPostalID = (int)cmdE.ExecuteScalar();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Administrador(Nome, Genero, NrTelemovel, Email, DataNascimento, TipoSanguineo, Morada, CodigoPostalCodigoPostalID)" + " VALUES('" + TextBoxNome.Text + "','" + TextBoxGenero.Text + "','" + TextBoxNrTelemovel.Text + "', '" + TextBoxEmail.Text + "', '" + CalendarDtNascimento.Text + "','" + TextBoxTipoSangue.Text + "', '" + TextBoxMorada.Text + "','" + codigoPostalID + "' )", conexao);
                    cmd.ExecuteNonQuery();
                    SqlCommand cmdB = new SqlCommand("SELECT AdministradorID FROM Administrador" + " WHERE Email = '" + TextBoxEmail.Text + "'", conexao);
                    utilizadorID = (int)cmdB.ExecuteScalar();
                    SqlCommand cmdD = new SqlCommand("INSERT INTO Credenciais(username, password, AdministradorAdministradorID)" + "VALUES('" + TextBoxUsernameR.Text + "', '" + TextBoxPE.Text + "', '" + utilizadorID + "')", conexao);
                    cmdD.ExecuteNonQuery();
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi possível validar o perfil!')", true);
                }
                finally
                {
                    conexao.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Administrador Validado!')", true);
                    CheckBoxAdmin.Checked = false;
                    XmlDocument registo = new XmlDocument();
                    string pathFinal = Path.Combine("~/", "Registos", fileName + ".xml");

                    if (File.Exists(Server.MapPath(pathFinal)))
                    {
                        File.Delete(Server.MapPath(Path.Combine("~/", "Registos", fileName + ".xml")));

                        XmlDeclaration declaracao = registo.CreateXmlDeclaration("1.0", "UTF-8", string.Empty);
                        XmlElement raiz = registo.DocumentElement;
                        registo.InsertBefore(declaracao, raiz);

                        XmlElement elementoraiz = registo.CreateElement("RAIZ");
                        registo.AppendChild(elementoraiz);

                        XmlElement elemento_registo = registo.CreateElement("REGISTO");
                        XmlAttribute atributo = registo.CreateAttribute("REGID");
                        atributo.Value = fileName;
                        elemento_registo.Attributes.Append(atributo);
                        elementoraiz.AppendChild(elemento_registo);

                        XmlElement elemento_nome = registo.CreateElement("NOME");
                        XmlText texto_nome = registo.CreateTextNode(TextBoxNome.Text);
                        elemento_nome.AppendChild(texto_nome);
                        elemento_registo.AppendChild(elemento_nome);

                        XmlElement elemento_nrTelemovel = registo.CreateElement("TELEMOVEL");
                        XmlText texto_nrTelemovel = registo.CreateTextNode(TextBoxNrTelemovel.Text);
                        elemento_nrTelemovel.AppendChild(texto_nrTelemovel);
                        elemento_registo.AppendChild(elemento_nrTelemovel);

                        XmlElement elemento_DtNascimento = registo.CreateElement("DTNASCIMENTO");
                        XmlText texto_DtNascimento = registo.CreateTextNode(CalendarDtNascimento.Text);
                        elemento_DtNascimento.AppendChild(texto_DtNascimento);
                        elemento_registo.AppendChild(elemento_DtNascimento);

                        XmlElement elemento_genero = registo.CreateElement("GENERO");
                        XmlText texto_genero = registo.CreateTextNode(TextBoxGenero.Text);
                        elemento_genero.AppendChild(texto_genero);
                        elemento_registo.AppendChild(elemento_genero);

                        XmlElement elemento_email = registo.CreateElement("EMAIL");
                        XmlText texto_email = registo.CreateTextNode(TextBoxEmail.Text);
                        elemento_email.AppendChild(texto_email);
                        elemento_registo.AppendChild(elemento_email);

                        XmlElement elemento_tipoSangue = registo.CreateElement("TIPOSANGUE");
                        XmlText texto_tipoSangue = registo.CreateTextNode(TextBoxTipoSangue.Text);
                        elemento_tipoSangue.AppendChild(texto_tipoSangue);
                        elemento_registo.AppendChild(elemento_tipoSangue);

                        XmlElement elemento_morada = registo.CreateElement("MORADA");
                        XmlText texto_morada = registo.CreateTextNode(TextBoxMorada.Text);
                        elemento_morada.AppendChild(texto_morada);
                        elemento_registo.AppendChild(elemento_morada);

                        XmlElement elemento_CodPostal = registo.CreateElement("CODPOSTAL");
                        XmlText texto_CodPostal = registo.CreateTextNode(TextBoxCP.Text);
                        elemento_CodPostal.AppendChild(texto_CodPostal);
                        elemento_registo.AppendChild(elemento_CodPostal);

                        XmlElement elemento_localidade = registo.CreateElement("LOCALIDADE");
                        XmlText texto_localidade = registo.CreateTextNode(TextBoxLocalidade.Text);
                        elemento_localidade.AppendChild(texto_localidade);
                        elemento_registo.AppendChild(elemento_localidade);

                        XmlElement elemento_CedProf = registo.CreateElement("CEDPROF");
                        XmlText texto_CedProf = registo.CreateTextNode(TextBoxCedulaPf.Text);
                        elemento_CedProf.AppendChild(texto_CedProf);
                        elemento_registo.AppendChild(elemento_CedProf);

                        XmlElement elemento_Username = registo.CreateElement("USERNAME");
                        XmlText texto_Username = registo.CreateTextNode(TextBoxUsernameR.Text);
                        elemento_Username.AppendChild(texto_Username);
                        elemento_registo.AppendChild(elemento_Username);

                        XmlElement elemento_Password = registo.CreateElement("PASSWORD");
                        XmlText texto_Password = registo.CreateTextNode(TextBoxPE.Text);
                        elemento_Password.AppendChild(texto_Password);
                        elemento_registo.AppendChild(elemento_Password);

                        XmlElement elemento_TipoPerfil = registo.CreateElement("TIPOPERFIL");
                        XmlText texto_TipoPerfil = registo.CreateTextNode(tipoPerfil);
                        elemento_TipoPerfil.AppendChild(texto_TipoPerfil);
                        elemento_registo.AppendChild(elemento_TipoPerfil);

                        registo.Save(Server.MapPath(Path.Combine("~/", "RegistosValidados", fileName + ".xml")));
                    }

                }
            }
            else if(CheckBoxMed.Checked == true)
            {
                tipoPerfil = "Medico";
                //adiciona na tabela Medico
                SqlConnection conexao = new SqlConnection(strcon);

                try
                {
                    conexao.Open();
                    SqlCommand cmdC = new SqlCommand("INSERT INTO CodigoPostal(Codigo, Localidade)" + " VALUES('" + TextBoxCP.Text + "','" + TextBoxLocalidade.Text + "')", conexao);
                    cmdC.ExecuteNonQuery();
                    SqlCommand cmdE = new SqlCommand("SELECT CodigoPostalID FROM CodigoPostal" + " WHERE Codigo = '" + TextBoxCP.Text + "'", conexao);
                    codigoPostalID = (int)cmdE.ExecuteScalar();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Medico(Nome, Genero, NrTelemovel, Email, DataNascimento, TipoSanguineo, Morada, CedulaProf, CodigoPostalCodigoPostalID)" + " VALUES('" + TextBoxNome.Text + "','" + TextBoxGenero.Text + "','" + TextBoxNrTelemovel.Text + "', '" + TextBoxEmail.Text + "', '" + CalendarDtNascimento.Text + "','" + TextBoxTipoSangue.Text + "', '" + TextBoxMorada.Text + "', '" + TextBoxCedulaPf.Text + "','" + codigoPostalID + "' )", conexao);
                    cmd.ExecuteNonQuery();
                    SqlCommand cmdB = new SqlCommand("SELECT MedicoID FROM Medico" + " WHERE Email = '" + TextBoxEmail.Text + "'", conexao);
                    utilizadorID = (int)cmdB.ExecuteScalar();
                    SqlCommand cmdD = new SqlCommand("INSERT INTO Credenciais(username, password, MedicoMedicoID)" + "VALUES('" + TextBoxUsernameR.Text + "', '" + TextBoxPE.Text + "', '" + utilizadorID + "')", conexao);
                    cmdD.ExecuteNonQuery();
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi possível validar o perfil!')", true);
                }
                finally
                {
                    conexao.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Medico Validado!')", true);
                    CheckBoxMed.Checked = false;
                    XmlDocument registo = new XmlDocument();
                    string pathFinal = Path.Combine("~/", "Registos", fileName + ".xml");

                    if (File.Exists(Server.MapPath(pathFinal)))
                    {
                        File.Delete(Server.MapPath(Path.Combine("~/", "Registos", fileName + ".xml")));

                        XmlDeclaration declaracao = registo.CreateXmlDeclaration("1.0", "UTF-8", string.Empty);
                        XmlElement raiz = registo.DocumentElement;
                        registo.InsertBefore(declaracao, raiz);

                        XmlElement elementoraiz = registo.CreateElement("RAIZ");
                        registo.AppendChild(elementoraiz);

                        XmlElement elemento_registo = registo.CreateElement("REGISTO");
                        XmlAttribute atributo = registo.CreateAttribute("REGID");
                        atributo.Value = fileName;
                        elemento_registo.Attributes.Append(atributo);
                        elementoraiz.AppendChild(elemento_registo);

                        XmlElement elemento_nome = registo.CreateElement("NOME");
                        XmlText texto_nome = registo.CreateTextNode(TextBoxNome.Text);
                        elemento_nome.AppendChild(texto_nome);
                        elemento_registo.AppendChild(elemento_nome);

                        XmlElement elemento_nrTelemovel = registo.CreateElement("TELEMOVEL");
                        XmlText texto_nrTelemovel = registo.CreateTextNode(TextBoxNrTelemovel.Text);
                        elemento_nrTelemovel.AppendChild(texto_nrTelemovel);
                        elemento_registo.AppendChild(elemento_nrTelemovel);

                        XmlElement elemento_DtNascimento = registo.CreateElement("DTNASCIMENTO");
                        XmlText texto_DtNascimento = registo.CreateTextNode(CalendarDtNascimento.Text);
                        elemento_DtNascimento.AppendChild(texto_DtNascimento);
                        elemento_registo.AppendChild(elemento_DtNascimento);

                        XmlElement elemento_genero = registo.CreateElement("GENERO");
                        XmlText texto_genero = registo.CreateTextNode(TextBoxGenero.Text);
                        elemento_genero.AppendChild(texto_genero);
                        elemento_registo.AppendChild(elemento_genero);

                        XmlElement elemento_email = registo.CreateElement("EMAIL");
                        XmlText texto_email = registo.CreateTextNode(TextBoxEmail.Text);
                        elemento_email.AppendChild(texto_email);
                        elemento_registo.AppendChild(elemento_email);

                        XmlElement elemento_tipoSangue = registo.CreateElement("TIPOSANGUE");
                        XmlText texto_tipoSangue = registo.CreateTextNode(TextBoxTipoSangue.Text);
                        elemento_tipoSangue.AppendChild(texto_tipoSangue);
                        elemento_registo.AppendChild(elemento_tipoSangue);

                        XmlElement elemento_morada = registo.CreateElement("MORADA");
                        XmlText texto_morada = registo.CreateTextNode(TextBoxMorada.Text);
                        elemento_morada.AppendChild(texto_morada);
                        elemento_registo.AppendChild(elemento_morada);

                        XmlElement elemento_CodPostal = registo.CreateElement("CODPOSTAL");
                        XmlText texto_CodPostal = registo.CreateTextNode(TextBoxCP.Text);
                        elemento_CodPostal.AppendChild(texto_CodPostal);
                        elemento_registo.AppendChild(elemento_CodPostal);

                        XmlElement elemento_localidade = registo.CreateElement("LOCALIDADE");
                        XmlText texto_localidade = registo.CreateTextNode(TextBoxLocalidade.Text);
                        elemento_localidade.AppendChild(texto_localidade);
                        elemento_registo.AppendChild(elemento_localidade);

                        XmlElement elemento_CedProf = registo.CreateElement("CEDPROF");
                        XmlText texto_CedProf = registo.CreateTextNode(TextBoxCedulaPf.Text);
                        elemento_CedProf.AppendChild(texto_CedProf);
                        elemento_registo.AppendChild(elemento_CedProf);

                        XmlElement elemento_Username = registo.CreateElement("USERNAME");
                        XmlText texto_Username = registo.CreateTextNode(TextBoxUsernameR.Text);
                        elemento_Username.AppendChild(texto_Username);
                        elemento_registo.AppendChild(elemento_Username);

                        XmlElement elemento_Password = registo.CreateElement("PASSWORD");
                        XmlText texto_Password = registo.CreateTextNode(TextBoxPE.Text);
                        elemento_Password.AppendChild(texto_Password);
                        elemento_registo.AppendChild(elemento_Password);

                        XmlElement elemento_TipoPerfil = registo.CreateElement("TIPOPERFIL");
                        XmlText texto_TipoPerfil = registo.CreateTextNode(tipoPerfil);
                        elemento_TipoPerfil.AppendChild(texto_TipoPerfil);
                        elemento_registo.AppendChild(elemento_TipoPerfil);

                        registo.Save(Server.MapPath(Path.Combine("~/", "RegistosValidados", fileName + ".xml")));
                    }
                }
            }
            else if(CheckBoxUtente.Checked == true)
            {
                tipoPerfil = "Utente";
                //adiciona na tabela utente
                SqlConnection conexao = new SqlConnection(strcon);

                try
                {
                    conexao.Open();
                    SqlCommand cmdC = new SqlCommand("INSERT INTO CodigoPostal(Codigo, Localidade)" + " VALUES('" + TextBoxCP.Text + "','" + TextBoxLocalidade.Text + "')", conexao);
                    cmdC.ExecuteNonQuery();
                    SqlCommand cmdE = new SqlCommand("SELECT CodigoPostalID FROM CodigoPostal" + " WHERE Codigo = '" + TextBoxCP.Text + "'", conexao);
                    codigoPostalID = (int)cmdE.ExecuteScalar();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Utente(Nome, Genero, NrTelemovel, Email, DataNascimento, TipoSanguineo, Morada, CodigoPostalCodigoPostalID)" + " VALUES('" + TextBoxNome.Text + "','" + TextBoxGenero.Text + "','" + TextBoxNrTelemovel.Text + "', '" + TextBoxEmail.Text + "', '" + CalendarDtNascimento.Text + "','" + TextBoxTipoSangue.Text + "', '" + TextBoxMorada.Text + "', '" + codigoPostalID + "')", conexao);
                    cmd.ExecuteNonQuery();
                    SqlCommand cmdB = new SqlCommand("SELECT UtenteID FROM Utente" + " WHERE Email = '" + TextBoxEmail.Text + "'", conexao);
                    utilizadorID = (int)cmdB.ExecuteScalar();
                    SqlCommand cmdD = new SqlCommand("INSERT INTO Credenciais(username, password, UtenteUtenteID)" + "VALUES('" + TextBoxUsernameR.Text + "', '" + TextBoxPE.Text + "', '" + utilizadorID + "')", conexao);
                    cmdD.ExecuteNonQuery();
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi possível validar o perfil!')", true);
                }
                finally
                {
                    conexao.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Utente Validado!')", true);
                    CheckBoxUtente.Checked = false;
                    XmlDocument registo = new XmlDocument();
                    string pathFinal = Path.Combine("~/", "Registos", fileName + ".xml");

                    if (File.Exists(Server.MapPath(pathFinal)))
                    {
                        File.Delete(Server.MapPath(Path.Combine("~/", "Registos", fileName + ".xml")));

                        XmlDeclaration declaracao = registo.CreateXmlDeclaration("1.0", "UTF-8", string.Empty);
                        XmlElement raiz = registo.DocumentElement;
                        registo.InsertBefore(declaracao, raiz);

                        XmlElement elementoraiz = registo.CreateElement("RAIZ");
                        registo.AppendChild(elementoraiz);

                        XmlElement elemento_registo = registo.CreateElement("REGISTO");
                        XmlAttribute atributo = registo.CreateAttribute("REGID");
                        atributo.Value = fileName;
                        elemento_registo.Attributes.Append(atributo);
                        elementoraiz.AppendChild(elemento_registo);

                        XmlElement elemento_nome = registo.CreateElement("NOME");
                        XmlText texto_nome = registo.CreateTextNode(TextBoxNome.Text);
                        elemento_nome.AppendChild(texto_nome);
                        elemento_registo.AppendChild(elemento_nome);

                        XmlElement elemento_nrTelemovel = registo.CreateElement("TELEMOVEL");
                        XmlText texto_nrTelemovel = registo.CreateTextNode(TextBoxNrTelemovel.Text);
                        elemento_nrTelemovel.AppendChild(texto_nrTelemovel);
                        elemento_registo.AppendChild(elemento_nrTelemovel);

                        XmlElement elemento_DtNascimento = registo.CreateElement("DTNASCIMENTO");
                        XmlText texto_DtNascimento = registo.CreateTextNode(CalendarDtNascimento.Text);
                        elemento_DtNascimento.AppendChild(texto_DtNascimento);
                        elemento_registo.AppendChild(elemento_DtNascimento);

                        XmlElement elemento_genero = registo.CreateElement("GENERO");
                        XmlText texto_genero = registo.CreateTextNode(TextBoxGenero.Text);
                        elemento_genero.AppendChild(texto_genero);
                        elemento_registo.AppendChild(elemento_genero);

                        XmlElement elemento_email = registo.CreateElement("EMAIL");
                        XmlText texto_email = registo.CreateTextNode(TextBoxEmail.Text);
                        elemento_email.AppendChild(texto_email);
                        elemento_registo.AppendChild(elemento_email);

                        XmlElement elemento_tipoSangue = registo.CreateElement("TIPOSANGUE");
                        XmlText texto_tipoSangue = registo.CreateTextNode(TextBoxTipoSangue.Text);
                        elemento_tipoSangue.AppendChild(texto_tipoSangue);
                        elemento_registo.AppendChild(elemento_tipoSangue);

                        XmlElement elemento_morada = registo.CreateElement("MORADA");
                        XmlText texto_morada = registo.CreateTextNode(TextBoxMorada.Text);
                        elemento_morada.AppendChild(texto_morada);
                        elemento_registo.AppendChild(elemento_morada);

                        XmlElement elemento_CodPostal = registo.CreateElement("CODPOSTAL");
                        XmlText texto_CodPostal = registo.CreateTextNode(TextBoxCP.Text);
                        elemento_CodPostal.AppendChild(texto_CodPostal);
                        elemento_registo.AppendChild(elemento_CodPostal);

                        XmlElement elemento_localidade = registo.CreateElement("LOCALIDADE");
                        XmlText texto_localidade = registo.CreateTextNode(TextBoxLocalidade.Text);
                        elemento_localidade.AppendChild(texto_localidade);
                        elemento_registo.AppendChild(elemento_localidade);

                        XmlElement elemento_CedProf = registo.CreateElement("CEDPROF");
                        XmlText texto_CedProf = registo.CreateTextNode(TextBoxCedulaPf.Text);
                        elemento_CedProf.AppendChild(texto_CedProf);
                        elemento_registo.AppendChild(elemento_CedProf);

                        XmlElement elemento_Username = registo.CreateElement("USERNAME");
                        XmlText texto_Username = registo.CreateTextNode(TextBoxUsernameR.Text);
                        elemento_Username.AppendChild(texto_Username);
                        elemento_registo.AppendChild(elemento_Username);

                        XmlElement elemento_Password = registo.CreateElement("PASSWORD");
                        XmlText texto_Password = registo.CreateTextNode(TextBoxPE.Text);
                        elemento_Password.AppendChild(texto_Password);
                        elemento_registo.AppendChild(elemento_Password);

                        XmlElement elemento_TipoPerfil = registo.CreateElement("TIPOPERFIL");
                        XmlText texto_TipoPerfil = registo.CreateTextNode(tipoPerfil);
                        elemento_TipoPerfil.AppendChild(texto_TipoPerfil);
                        elemento_registo.AppendChild(elemento_TipoPerfil);

                        registo.Save(Server.MapPath(Path.Combine("~/", "RegistosValidados", fileName + ".xml")));

                    }
                }
            }
            else if(CheckBoxAdmin.Checked == false && CheckBoxMed.Checked == false && CheckBoxUtente.Checked == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecione um perfil!')", true);
            }
            ButtonValidate.BackColor = System.Drawing.Color.White;
        }

        protected void ButtonBack_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ListBoxPerfis.Items.Clear();
            ButtonValidate.BackColor = System.Drawing.Color.LightBlue;
            ButtonEditable.BackColor = System.Drawing.Color.White;
            ListBoxPerfis.Visible = true;
            ButtonEdi.Visible = false;
            ButtonSelect.Visible = true;

            string path = Path.Combine("~/", "Registos");
            string fileName;

            DirectoryInfo Dir = new DirectoryInfo(Server.MapPath(path));
            // Busca automaticamente todos os arquivos em todos os subdiretórios
            FileInfo[] Files = Dir.GetFiles("*.xml", SearchOption.AllDirectories);
            foreach (FileInfo File in Files)
            {
                // Retira o diretório iformado inicialmente
                fileName = File.Name;
                string[] name = fileName.Split('.');
                string file = name[0].ToString();
                ListBoxPerfis.Items.Add(file);
            }
        }

        protected void ButtonEditable_Click(object sender, EventArgs e)
        {
            ListBoxPerfis.Items.Clear();
            ButtonEditable.BackColor = System.Drawing.Color.LightBlue;
            ButtonValidate.BackColor = System.Drawing.Color.White;
            ListBoxPerfis.Visible = true;
            ButtonEdi.Visible = true;
            ButtonSelect.Visible = false;
            ButtonDel.Visible = true;

            
                string path = Path.Combine("~/", "RegistosValidados");
                string fileName;

                DirectoryInfo Dir = new DirectoryInfo(Server.MapPath(path));
                // Busca automaticamente todos os arquivos em todos os subdiretórios
                FileInfo[] Files = Dir.GetFiles("*.xml", SearchOption.AllDirectories);
                foreach (FileInfo File in Files)
                {
                    // Retira o diretório iformado inicialmente
                    fileName = File.Name;
                    string[] name = fileName.Split('.');
                    string file = name[0].ToString();
                    ListBoxPerfis.Items.Add(file);
                }       
        }

        protected void ButtonDel_Click(object sender, EventArgs e)
        {
            string fileName = ListBoxPerfis.SelectedItem.ToString();
            string username = TextBoxUsernameR.Text;
            string strcon = "Data Source=localhost;Initial Catalog=TP_ES;Integrated Security=True";
            SqlConnection conexao = new SqlConnection(strcon);

            if (LabelTP.Text == "Administrador")
            {
                try
                {
                    conexao.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Administrador WHERE NrTelemovel = '" + TextBoxNrTelemovel.Text + "'", conexao);
                    cmd.ExecuteNonQuery();
                    SqlCommand cmdD = new SqlCommand("DELETE FROM Credenciais WHERE username = '" + TextBoxUsernameR.Text + "'; ", conexao);
                    cmdD.ExecuteNonQuery();
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi possível eliminar o perfil!')", true);
                }
                finally
                {
                    conexao.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Administrador Eliminado!')", true);

                    string pathFinal = Path.Combine("~/", "Registos", fileName + ".xml");

                    if (File.Exists(Server.MapPath(pathFinal)))
                    {
                        File.Delete(Server.MapPath(Path.Combine("~/", "RegistosValidados", fileName + ".xml")));
                    }
                }
            }
            else if(LabelTP.Text == "Medico")
            {
                try
                {
                    conexao.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Medico WHERE NrTelemovel = '" + TextBoxNrTelemovel.Text + "'", conexao);
                    cmd.ExecuteNonQuery();
                    SqlCommand cmdD = new SqlCommand("DELETE FROM Credenciais WHERE username = '" + TextBoxUsernameR.Text + "'; ", conexao);
                    cmdD.ExecuteNonQuery();
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi possível eliminar o perfil!')", true);
                }
                finally
                {
                    conexao.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Medico Eliminado!')", true);

                    string pathFinal = Path.Combine("~/", "Registos", fileName + ".xml");

                    if (File.Exists(Server.MapPath(pathFinal)))
                    {
                        File.Delete(Server.MapPath(Path.Combine("~/", "RegistosValidados", fileName + ".xml")));
                    }
                }
            }
            else if(LabelTP.Text == "Utente")
            {
                try
                {
                    conexao.Open();
                    SqlCommand cmdD = new SqlCommand("DELETE FROM Credenciais WHERE username = '" + TextBoxUsernameR.Text + "'; ", conexao);
                    cmdD.ExecuteNonQuery();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Utente WHERE NrTelemovel = '" + TextBoxNrTelemovel.Text + "'", conexao);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi possível eliminar o perfil!')", true);
                }
                finally
                {
                    conexao.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Utente Eliminado!')", true);

                    string pathFinal = Path.Combine("~/", "RegistosValidados", fileName + ".xml");

                    if (File.Exists(Server.MapPath(pathFinal)))
                    {
                        File.Delete(Server.MapPath(Path.Combine("~/", "RegistosValidados", fileName + ".xml")));
                    }
                }
            }
            ButtonEditable.BackColor = System.Drawing.Color.White;
        }

        protected void ButtonUpd_Click(object sender, EventArgs e)
        {
            string fileName = ListBoxPerfis.SelectedItem.ToString();
            string username = TextBoxUsernameR.Text;

            string strcon = "Data Source=localhost;Initial Catalog=TP_ES;Integrated Security=True";
            SqlConnection conexao = new SqlConnection(strcon);

            if (LabelTP.Text == "Administrador")
            {
                try
                {
                    conexao.Open();
                    SqlCommand cmdA = new SqlCommand("SELECT AdministradorAdministradorID FROM Credenciais" + " WHERE username = '" + TextBoxUsernameR.Text + "'", conexao);
                    utilizadorID = (int)cmdA.ExecuteScalar();
                    SqlCommand cmdB = new SqlCommand("SELECT CodigoPostalCodigoPostalID FROM Administrador" + " WHERE AdministradorID = '" + utilizadorID + "'", conexao);
                    codigoPostalID = (int)cmdB.ExecuteScalar();
                    SqlCommand cmdC = new SqlCommand("UPDATE CodigoPostal SET Codigo ='" + TextBoxCP.Text + "', Localidade = '" + TextBoxLocalidade.Text + "' WHERE CodigoPostalID = '" + codigoPostalID + "'", conexao);
                    cmdC.ExecuteNonQuery();
                    SqlCommand cmdD = new SqlCommand("UPDATE Administrador SET Nome = '" + TextBoxNome.Text + "', Genero = '" + TextBoxGenero.Text + "', NrTelemovel = '" + TextBoxNrTelemovel.Text + "', Email = '" + TextBoxEmail.Text + "', DataNascimento = '" + CalendarDtNascimento.Text + "', TipoSanguineo = '" + TextBoxTipoSangue.Text + "', Morada = '" + TextBoxMorada.Text + "' WHERE AdministradorID = '" + utilizadorID + "'", conexao);
                    cmdD.ExecuteNonQuery();
                    SqlCommand cmdE = new SqlCommand("UPDATE Credenciais SET username = '" + TextBoxUsernameR.Text + "', password = '" + TextBoxPE.Text + "' WHERE AdministradorAdministradorID = '" + utilizadorID + "'", conexao);
                    cmdE.ExecuteNonQuery();
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi possível eliminar o perfil!')", true);
                }
                finally
                {
                    conexao.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Administrador Atualizado!')", true);
                    XmlDocument registo = new XmlDocument();
                    string pathFinal = Path.Combine("~/", "RegistosValidados", fileName + ".xml");

                        if (File.Exists(Server.MapPath(pathFinal)))
                        {
                            File.Delete(Server.MapPath(Path.Combine("~/", "RegistosValidados", fileName + ".xml")));

                            XmlDeclaration declaracao = registo.CreateXmlDeclaration("1.0", "UTF-8", string.Empty);
                            XmlElement raiz = registo.DocumentElement;
                            registo.InsertBefore(declaracao, raiz);

                            XmlElement elementoraiz = registo.CreateElement("RAIZ");
                            registo.AppendChild(elementoraiz);

                            XmlElement elemento_registo = registo.CreateElement("REGISTO");
                            XmlAttribute atributo = registo.CreateAttribute("REGID");
                            atributo.Value = fileName;
                            elemento_registo.Attributes.Append(atributo);
                            elementoraiz.AppendChild(elemento_registo);

                            XmlElement elemento_nome = registo.CreateElement("NOME");
                            XmlText texto_nome = registo.CreateTextNode(TextBoxNome.Text);
                            elemento_nome.AppendChild(texto_nome);
                            elemento_registo.AppendChild(elemento_nome);

                            XmlElement elemento_nrTelemovel = registo.CreateElement("TELEMOVEL");
                            XmlText texto_nrTelemovel = registo.CreateTextNode(TextBoxNrTelemovel.Text);
                            elemento_nrTelemovel.AppendChild(texto_nrTelemovel);
                            elemento_registo.AppendChild(elemento_nrTelemovel);

                            XmlElement elemento_DtNascimento = registo.CreateElement("DTNASCIMENTO");
                            XmlText texto_DtNascimento = registo.CreateTextNode(CalendarDtNascimento.Text);
                            elemento_DtNascimento.AppendChild(texto_DtNascimento);
                            elemento_registo.AppendChild(elemento_DtNascimento);

                            XmlElement elemento_genero = registo.CreateElement("GENERO");
                            XmlText texto_genero = registo.CreateTextNode(TextBoxGenero.Text);
                            elemento_genero.AppendChild(texto_genero);
                            elemento_registo.AppendChild(elemento_genero);

                            XmlElement elemento_email = registo.CreateElement("EMAIL");
                            XmlText texto_email = registo.CreateTextNode(TextBoxEmail.Text);
                            elemento_email.AppendChild(texto_email);
                            elemento_registo.AppendChild(elemento_email);

                            XmlElement elemento_tipoSangue = registo.CreateElement("TIPOSANGUE");
                            XmlText texto_tipoSangue = registo.CreateTextNode(TextBoxTipoSangue.Text);
                            elemento_tipoSangue.AppendChild(texto_tipoSangue);
                            elemento_registo.AppendChild(elemento_tipoSangue);

                            XmlElement elemento_morada = registo.CreateElement("MORADA");
                            XmlText texto_morada = registo.CreateTextNode(TextBoxMorada.Text);
                            elemento_morada.AppendChild(texto_morada);
                            elemento_registo.AppendChild(elemento_morada);

                            XmlElement elemento_CodPostal = registo.CreateElement("CODPOSTAL");
                            XmlText texto_CodPostal = registo.CreateTextNode(TextBoxCP.Text);
                            elemento_CodPostal.AppendChild(texto_CodPostal);
                            elemento_registo.AppendChild(elemento_CodPostal);

                            XmlElement elemento_localidade = registo.CreateElement("LOCALIDADE");
                            XmlText texto_localidade = registo.CreateTextNode(TextBoxLocalidade.Text);
                            elemento_localidade.AppendChild(texto_localidade);
                            elemento_registo.AppendChild(elemento_localidade);

                            XmlElement elemento_CedProf = registo.CreateElement("CEDPROF");
                            XmlText texto_CedProf = registo.CreateTextNode(TextBoxCedulaPf.Text);
                            elemento_CedProf.AppendChild(texto_CedProf);
                            elemento_registo.AppendChild(elemento_CedProf);

                            XmlElement elemento_Username = registo.CreateElement("USERNAME");
                            XmlText texto_Username = registo.CreateTextNode(TextBoxUsernameR.Text);
                            elemento_Username.AppendChild(texto_Username);
                            elemento_registo.AppendChild(elemento_Username);

                            XmlElement elemento_Password = registo.CreateElement("PASSWORD");
                            XmlText texto_Password = registo.CreateTextNode(TextBoxPE.Text);
                            elemento_Password.AppendChild(texto_Password);
                            elemento_registo.AppendChild(elemento_Password);

                            XmlElement elemento_TipoPerfil = registo.CreateElement("TIPOPERFIL");
                            XmlText texto_TipoPerfil = registo.CreateTextNode(LabelTP.Text);
                            elemento_TipoPerfil.AppendChild(texto_TipoPerfil);
                            elemento_registo.AppendChild(elemento_TipoPerfil);

                            registo.Save(Server.MapPath(Path.Combine("~/", "RegistosValidados", fileName + ".xml")));
                        }
                }
            }
            else if (LabelTP.Text == "Medico")
            {
                try
                {
                    conexao.Open();
                    SqlCommand cmdA = new SqlCommand("SELECT MedicoMedicoID FROM Credenciais" + " WHERE username = '" + TextBoxUsernameR.Text + "'", conexao);
                    utilizadorID = (int)cmdA.ExecuteScalar();
                    SqlCommand cmdB = new SqlCommand("SELECT CodigoPostalCodigoPostalID FROM Medico" + " WHERE MedicoID = '" + utilizadorID + "'", conexao);
                    codigoPostalID = (int)cmdB.ExecuteScalar();
                    SqlCommand cmdC = new SqlCommand("UPDATE CodigoPostal SET Codigo ='" + TextBoxCP.Text + "', Localidade = '" + TextBoxLocalidade.Text + "' WHERE CodigoPostalID = '" + codigoPostalID + "'", conexao);
                    cmdC.ExecuteNonQuery();
                    SqlCommand cmdD = new SqlCommand("UPDATE Medico SET Nome = '" + TextBoxNome.Text + "', Genero = '" + TextBoxGenero.Text + "', NrTelemovel = '" + TextBoxNrTelemovel.Text + "', Email = '" + TextBoxEmail.Text + "', DataNascimento = '" + CalendarDtNascimento.Text + "', TipoSanguineo = '" + TextBoxTipoSangue.Text + "', Morada = '" + TextBoxMorada.Text + "' WHERE MedicoID = '" + utilizadorID + "'", conexao);
                    cmdD.ExecuteNonQuery();
                    SqlCommand cmdE = new SqlCommand("UPDATE Credenciais SET username = '" + TextBoxUsernameR.Text + "', password = '" + TextBoxPE.Text + "' WHERE MedicoMedicoID = '" + utilizadorID + "'", conexao);
                    cmdE.ExecuteNonQuery();
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi possível eliminar o perfil!')", true);
                }
                finally
                {
                    conexao.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Medico Atualizado!')", true);
                    XmlDocument registo = new XmlDocument();
                    string pathFinal = Path.Combine("~/", "RegistosValidados", fileName + ".xml");

                    if (File.Exists(Server.MapPath(pathFinal)))
                    {
                        File.Delete(Server.MapPath(Path.Combine("~/", "RegistosValidados", fileName + ".xml")));

                        XmlDeclaration declaracao = registo.CreateXmlDeclaration("1.0", "UTF-8", string.Empty);
                        XmlElement raiz = registo.DocumentElement;
                        registo.InsertBefore(declaracao, raiz);

                        XmlElement elementoraiz = registo.CreateElement("RAIZ");
                        registo.AppendChild(elementoraiz);

                        XmlElement elemento_registo = registo.CreateElement("REGISTO");
                        XmlAttribute atributo = registo.CreateAttribute("REGID");
                        atributo.Value = fileName;
                        elemento_registo.Attributes.Append(atributo);
                        elementoraiz.AppendChild(elemento_registo);

                        XmlElement elemento_nome = registo.CreateElement("NOME");
                        XmlText texto_nome = registo.CreateTextNode(TextBoxNome.Text);
                        elemento_nome.AppendChild(texto_nome);
                        elemento_registo.AppendChild(elemento_nome);

                        XmlElement elemento_nrTelemovel = registo.CreateElement("TELEMOVEL");
                        XmlText texto_nrTelemovel = registo.CreateTextNode(TextBoxNrTelemovel.Text);
                        elemento_nrTelemovel.AppendChild(texto_nrTelemovel);
                        elemento_registo.AppendChild(elemento_nrTelemovel);

                        XmlElement elemento_DtNascimento = registo.CreateElement("DTNASCIMENTO");
                        XmlText texto_DtNascimento = registo.CreateTextNode(CalendarDtNascimento.Text);
                        elemento_DtNascimento.AppendChild(texto_DtNascimento);
                        elemento_registo.AppendChild(elemento_DtNascimento);

                        XmlElement elemento_genero = registo.CreateElement("GENERO");
                        XmlText texto_genero = registo.CreateTextNode(TextBoxGenero.Text);
                        elemento_genero.AppendChild(texto_genero);
                        elemento_registo.AppendChild(elemento_genero);

                        XmlElement elemento_email = registo.CreateElement("EMAIL");
                        XmlText texto_email = registo.CreateTextNode(TextBoxEmail.Text);
                        elemento_email.AppendChild(texto_email);
                        elemento_registo.AppendChild(elemento_email);

                        XmlElement elemento_tipoSangue = registo.CreateElement("TIPOSANGUE");
                        XmlText texto_tipoSangue = registo.CreateTextNode(TextBoxTipoSangue.Text);
                        elemento_tipoSangue.AppendChild(texto_tipoSangue);
                        elemento_registo.AppendChild(elemento_tipoSangue);

                        XmlElement elemento_morada = registo.CreateElement("MORADA");
                        XmlText texto_morada = registo.CreateTextNode(TextBoxMorada.Text);
                        elemento_morada.AppendChild(texto_morada);
                        elemento_registo.AppendChild(elemento_morada);

                        XmlElement elemento_CodPostal = registo.CreateElement("CODPOSTAL");
                        XmlText texto_CodPostal = registo.CreateTextNode(TextBoxCP.Text);
                        elemento_CodPostal.AppendChild(texto_CodPostal);
                        elemento_registo.AppendChild(elemento_CodPostal);

                        XmlElement elemento_localidade = registo.CreateElement("LOCALIDADE");
                        XmlText texto_localidade = registo.CreateTextNode(TextBoxLocalidade.Text);
                        elemento_localidade.AppendChild(texto_localidade);
                        elemento_registo.AppendChild(elemento_localidade);

                        XmlElement elemento_CedProf = registo.CreateElement("CEDPROF");
                        XmlText texto_CedProf = registo.CreateTextNode(TextBoxCedulaPf.Text);
                        elemento_CedProf.AppendChild(texto_CedProf);
                        elemento_registo.AppendChild(elemento_CedProf);

                        XmlElement elemento_Username = registo.CreateElement("USERNAME");
                        XmlText texto_Username = registo.CreateTextNode(TextBoxUsernameR.Text);
                        elemento_Username.AppendChild(texto_Username);
                        elemento_registo.AppendChild(elemento_Username);

                        XmlElement elemento_Password = registo.CreateElement("PASSWORD");
                        XmlText texto_Password = registo.CreateTextNode(TextBoxPE.Text);
                        elemento_Password.AppendChild(texto_Password);
                        elemento_registo.AppendChild(elemento_Password);

                        XmlElement elemento_TipoPerfil = registo.CreateElement("TIPOPERFIL");
                        XmlText texto_TipoPerfil = registo.CreateTextNode(LabelTP.Text);
                        elemento_TipoPerfil.AppendChild(texto_TipoPerfil);
                        elemento_registo.AppendChild(elemento_TipoPerfil);

                        registo.Save(Server.MapPath(Path.Combine("~/", "RegistosValidados", fileName + ".xml")));
                    }
                }
                
            }
            else if (LabelTP.Text == "Utente")
            {
                try
                {
                    conexao.Open();
                    SqlCommand cmdA = new SqlCommand("SELECT UtenteUtenteID FROM Credenciais" + " WHERE username = '" + TextBoxUsernameR.Text + "'", conexao);
                    utilizadorID = (int)cmdA.ExecuteScalar();
                    SqlCommand cmdB = new SqlCommand("SELECT CodigoPostalCodigoPostalID FROM Utente" + " WHERE UtenteID = '" + utilizadorID + "'", conexao);
                    codigoPostalID = (int)cmdB.ExecuteScalar();
                    SqlCommand cmdC = new SqlCommand("UPDATE CodigoPostal SET Codigo ='" + TextBoxCP.Text + "', Localidade = '" + TextBoxLocalidade.Text + "' WHERE CodigoPostalID = '" + codigoPostalID + "'", conexao);
                    cmdC.ExecuteNonQuery();
                    SqlCommand cmdD = new SqlCommand("UPDATE Utente SET Nome = '" + TextBoxNome.Text + "', Genero = '" + TextBoxGenero.Text + "', NrTelemovel = '" + TextBoxNrTelemovel.Text + "', Email = '" + TextBoxEmail.Text + "', DataNascimento = '" + CalendarDtNascimento.Text + "', TipoSanguineo = '" + TextBoxTipoSangue.Text + "', Morada = '" + TextBoxMorada.Text + "' WHERE UtenteID = '" + utilizadorID + "'", conexao);
                    cmdD.ExecuteNonQuery();
                    SqlCommand cmdE = new SqlCommand("UPDATE Credenciais SET username = '" + TextBoxUsernameR.Text + "', password = '" + TextBoxPE.Text + "' WHERE UtenteUtenteID = '" + utilizadorID + "'", conexao);
                    cmdE.ExecuteNonQuery();
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi possível eliminar o perfil!')", true);
                }
                finally
                {
                    conexao.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Utente Atualizado!')", true);
                    XmlDocument registo = new XmlDocument();
                    string pathFinal = Path.Combine("~/", "RegistosValidados", fileName + ".xml");

                    if (File.Exists(Server.MapPath(pathFinal)))
                    {
                        File.Delete(Server.MapPath(Path.Combine("~/", "RegistosValidados", fileName + ".xml")));

                        XmlDeclaration declaracao = registo.CreateXmlDeclaration("1.0", "UTF-8", string.Empty);
                        XmlElement raiz = registo.DocumentElement;
                        registo.InsertBefore(declaracao, raiz);

                        XmlElement elementoraiz = registo.CreateElement("RAIZ");
                        registo.AppendChild(elementoraiz);

                        XmlElement elemento_registo = registo.CreateElement("REGISTO");
                        XmlAttribute atributo = registo.CreateAttribute("REGID");
                        atributo.Value = fileName;
                        elemento_registo.Attributes.Append(atributo);
                        elementoraiz.AppendChild(elemento_registo);

                        XmlElement elemento_nome = registo.CreateElement("NOME");
                        XmlText texto_nome = registo.CreateTextNode(TextBoxNome.Text);
                        elemento_nome.AppendChild(texto_nome);
                        elemento_registo.AppendChild(elemento_nome);

                        XmlElement elemento_nrTelemovel = registo.CreateElement("TELEMOVEL");
                        XmlText texto_nrTelemovel = registo.CreateTextNode(TextBoxNrTelemovel.Text);
                        elemento_nrTelemovel.AppendChild(texto_nrTelemovel);
                        elemento_registo.AppendChild(elemento_nrTelemovel);

                        XmlElement elemento_DtNascimento = registo.CreateElement("DTNASCIMENTO");
                        XmlText texto_DtNascimento = registo.CreateTextNode(CalendarDtNascimento.Text);
                        elemento_DtNascimento.AppendChild(texto_DtNascimento);
                        elemento_registo.AppendChild(elemento_DtNascimento);

                        XmlElement elemento_genero = registo.CreateElement("GENERO");
                        XmlText texto_genero = registo.CreateTextNode(TextBoxGenero.Text);
                        elemento_genero.AppendChild(texto_genero);
                        elemento_registo.AppendChild(elemento_genero);

                        XmlElement elemento_email = registo.CreateElement("EMAIL");
                        XmlText texto_email = registo.CreateTextNode(TextBoxEmail.Text);
                        elemento_email.AppendChild(texto_email);
                        elemento_registo.AppendChild(elemento_email);

                        XmlElement elemento_tipoSangue = registo.CreateElement("TIPOSANGUE");
                        XmlText texto_tipoSangue = registo.CreateTextNode(TextBoxTipoSangue.Text);
                        elemento_tipoSangue.AppendChild(texto_tipoSangue);
                        elemento_registo.AppendChild(elemento_tipoSangue);

                        XmlElement elemento_morada = registo.CreateElement("MORADA");
                        XmlText texto_morada = registo.CreateTextNode(TextBoxMorada.Text);
                        elemento_morada.AppendChild(texto_morada);
                        elemento_registo.AppendChild(elemento_morada);

                        XmlElement elemento_CodPostal = registo.CreateElement("CODPOSTAL");
                        XmlText texto_CodPostal = registo.CreateTextNode(TextBoxCP.Text);
                        elemento_CodPostal.AppendChild(texto_CodPostal);
                        elemento_registo.AppendChild(elemento_CodPostal);

                        XmlElement elemento_localidade = registo.CreateElement("LOCALIDADE");
                        XmlText texto_localidade = registo.CreateTextNode(TextBoxLocalidade.Text);
                        elemento_localidade.AppendChild(texto_localidade);
                        elemento_registo.AppendChild(elemento_localidade);

                        XmlElement elemento_CedProf = registo.CreateElement("CEDPROF");
                        XmlText texto_CedProf = registo.CreateTextNode(TextBoxCedulaPf.Text);
                        elemento_CedProf.AppendChild(texto_CedProf);
                        elemento_registo.AppendChild(elemento_CedProf);

                        XmlElement elemento_Username = registo.CreateElement("USERNAME");
                        XmlText texto_Username = registo.CreateTextNode(TextBoxUsernameR.Text);
                        elemento_Username.AppendChild(texto_Username);
                        elemento_registo.AppendChild(elemento_Username);

                        XmlElement elemento_Password = registo.CreateElement("PASSWORD");
                        XmlText texto_Password = registo.CreateTextNode(TextBoxPE.Text);
                        elemento_Password.AppendChild(texto_Password);
                        elemento_registo.AppendChild(elemento_Password);

                        XmlElement elemento_TipoPerfil = registo.CreateElement("TIPOPERFIL");
                        XmlText texto_TipoPerfil = registo.CreateTextNode(LabelTP.Text);
                        elemento_TipoPerfil.AppendChild(texto_TipoPerfil);
                        elemento_registo.AppendChild(elemento_TipoPerfil);

                        registo.Save(Server.MapPath(Path.Combine("~/", "RegistosValidados", fileName + ".xml")));
                    }
                }
            }
            ButtonEditable.BackColor = System.Drawing.Color.White;
        }

    }  
}