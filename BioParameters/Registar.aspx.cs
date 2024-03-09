using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace BioParameters
{
    public partial class Registar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelNome.Visible = false;
            TextBoxNome.Visible = false;
            LabelNrTelemovel.Visible = false;
            TextBoxNrTelemovel.Visible = false;
            LabelDtNascimento.Visible = false;
            CalendarDtNascimento.Visible = false;
            LabelDtNascimento2.Visible = false;
            LabelEmail.Visible = false;
            TextBoxEmail.Visible = false;
            LabelGenero.Visible = false;
            CheckBoxF.Visible = false;
            CheckBoxM.Visible = false;
            LabelTipoSanguineo.Visible = false;
            DropDownTS.Visible = false;
            LabelMorada.Visible = false;
            TextBoxMorada.Visible = false;
            LabelCp.Visible = false;
            TextBoxCP.Visible = false;
            LabelLocal.Visible = false;
            TextBoxLocalidade.Visible = false;
            LabelCedProf.Visible = false;
            TextBoxCedulaPf.Visible = false;
            LabelUsername.Visible = false;
            LabelPassword.Visible = false;
            LabelPasswordRC.Visible = false;
            TextBoxUsernameR.Visible = false;
            TextBoxPassR.Visible = false;
            TextBoxPassRC.Visible = false;
            Button3.Visible = false;

            if (!IsPostBack)
            {
                List<ListItem> tipoSanguineo = new List<ListItem>
                {
                new ListItem("A+", "A+"),
                new ListItem("A-", "A-"),
                new ListItem("B+", "B+"),
                new ListItem("B-", "B-"),
                new ListItem("AB+", "AB+"),
                new ListItem("AB-", "AB-"),
                new ListItem("O+", "O+"),
                new ListItem("O-", "O-")
                };
                DropDownTS.Items.AddRange(tipoSanguineo.ToArray());
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string nomeRegisto = TextBoxNome.Text;
            string dtNascimento = CalendarDtNascimento.Text;
            int NrTelemovel = int.Parse(TextBoxNrTelemovel.Text);
            string email = TextBoxEmail.Text;

            string genero = "";

            if (CheckBoxF.Checked)
            {
                genero = "F";
            }
            else if (CheckBoxM.Checked)
            {
                genero = "M";
            }

            string tipoSanguineo = DropDownTS.SelectedItem.Text;
            string morada = TextBoxMorada.Text;
            string codPostal = TextBoxCP.Text;
            string localidade = TextBoxLocalidade.Text;
            string CedProf = TextBoxCedulaPf.Text;
            string usernameRegisto = TextBoxUsernameR.Text;

            string passwordR = TextBoxPassR.Text;
            string passwordRegConf = TextBoxPassRC.Text;
            string passwordFinal;

            if (passwordR == passwordRegConf)
            {
                passwordFinal = TextBoxPassR.Text;

                string path = "~/Registos";

                XmlDocument registo = new XmlDocument();
                string id = usernameRegisto;
                string pathFinal = Path.Combine(path, id);


                if (File.Exists(Server.MapPath(pathFinal + ".xml")))
                {
                    registo.Load(Server.MapPath(path + usernameRegisto + ".xml"));
                    XmlElement elementoraiz = registo.DocumentElement;

                    XmlElement elemento_registo = registo.CreateElement("REGISTO");
                    XmlAttribute atributo = registo.CreateAttribute("REGID");
                    atributo.Value = usernameRegisto;
                    elemento_registo.Attributes.Append(atributo);
                    elementoraiz.AppendChild(elemento_registo);

                    XmlElement elemento_nome = registo.CreateElement("NOME");
                    XmlText texto_nome = registo.CreateTextNode(nomeRegisto);
                    elemento_nome.AppendChild(texto_nome);
                    elemento_registo.AppendChild(elemento_nome);

                    XmlElement elemento_nrTelemovel = registo.CreateElement("TELEMOVEL");
                    XmlText texto_nrTelemovel = registo.CreateTextNode(NrTelemovel.ToString());
                    elemento_nrTelemovel.AppendChild(texto_nrTelemovel);
                    elemento_registo.AppendChild(elemento_nrTelemovel);

                    XmlElement elemento_DtNascimento = registo.CreateElement("DTNASCIMENTO");
                    XmlText texto_DtNascimento = registo.CreateTextNode("");
                    elemento_DtNascimento.AppendChild(texto_DtNascimento);
                    elemento_registo.AppendChild(elemento_DtNascimento);

                    XmlElement elemento_genero = registo.CreateElement("GENERO");
                    XmlText texto_genero = registo.CreateTextNode(genero);
                    elemento_genero.AppendChild(texto_genero);
                    elemento_registo.AppendChild(elemento_genero);

                    XmlElement elemento_tipoSangue = registo.CreateElement("TIPOSANGUE");
                    XmlText texto_tipoSangue = registo.CreateTextNode(tipoSanguineo);
                    elemento_tipoSangue.AppendChild(texto_tipoSangue);
                    elemento_registo.AppendChild(elemento_tipoSangue);

                    XmlElement elemento_morada = registo.CreateElement("MORADA");
                    XmlText texto_morada = registo.CreateTextNode(morada);
                    elemento_morada.AppendChild(texto_morada);
                    elemento_registo.AppendChild(elemento_morada);

                    XmlElement elemento_CedProf = registo.CreateElement("CEDPROF");
                    XmlText texto_CedProf = registo.CreateTextNode(CedProf);
                    elemento_CedProf.AppendChild(texto_CedProf);
                    elemento_registo.AppendChild(elemento_CedProf);

                    XmlElement elemento_email = registo.CreateElement("EMAIL");
                    XmlText texto_email = registo.CreateTextNode("");
                    elemento_email.AppendChild(texto_email);
                    elemento_registo.AppendChild(elemento_email);

                    XmlElement elemento_Username = registo.CreateElement("USERNAME");
                    XmlText texto_Username = registo.CreateTextNode(usernameRegisto);
                    elemento_Username.AppendChild(texto_Username);
                    elemento_registo.AppendChild(elemento_Username);

                    XmlElement elemento_Password = registo.CreateElement("PASSWORD");
                    XmlText texto_Password = registo.CreateTextNode(TextBoxPassR.Text);
                    elemento_Password.AppendChild(texto_Password);
                    elemento_registo.AppendChild(elemento_Password);

                    XmlElement elemento_TipoPerfil = registo.CreateElement("TIPOPERFIL");
                    XmlText texto_TipoPerfil = registo.CreateTextNode("");
                    elemento_TipoPerfil.AppendChild(texto_TipoPerfil);
                    elemento_registo.AppendChild(elemento_TipoPerfil);

                    registo.Save(Server.MapPath(path + usernameRegisto + ".xml"));

                }
                else
                {
                    XmlDeclaration declaracao = registo.CreateXmlDeclaration("1.0", "UTF-8", string.Empty);
                    XmlElement raiz = registo.DocumentElement;
                    registo.InsertBefore(declaracao, raiz);

                    XmlElement elementoraiz = registo.CreateElement("RAIZ");
                    registo.AppendChild(elementoraiz);

                    XmlElement elemento_registo = registo.CreateElement("REGISTO");
                    XmlAttribute atributo = registo.CreateAttribute("REGID");
                    atributo.Value = usernameRegisto;
                    elemento_registo.Attributes.Append(atributo);
                    elementoraiz.AppendChild(elemento_registo);

                    XmlElement elemento_nome = registo.CreateElement("NOME");
                    XmlText texto_nome = registo.CreateTextNode(nomeRegisto);
                    elemento_nome.AppendChild(texto_nome);
                    elemento_registo.AppendChild(elemento_nome);

                    XmlElement elemento_nrTelemovel = registo.CreateElement("TELEMOVEL");
                    XmlText texto_nrTelemovel = registo.CreateTextNode(NrTelemovel.ToString());
                    elemento_nrTelemovel.AppendChild(texto_nrTelemovel);
                    elemento_registo.AppendChild(elemento_nrTelemovel);

                    XmlElement elemento_DtNascimento = registo.CreateElement("DTNASCIMENTO");
                    XmlText texto_DtNascimento = registo.CreateTextNode(CalendarDtNascimento.Text);
                    elemento_DtNascimento.AppendChild(texto_DtNascimento);
                    elemento_registo.AppendChild(elemento_DtNascimento);

                    XmlElement elemento_genero = registo.CreateElement("GENERO");
                    XmlText texto_genero = registo.CreateTextNode(genero);
                    elemento_genero.AppendChild(texto_genero);
                    elemento_registo.AppendChild(elemento_genero);

                    XmlElement elemento_email = registo.CreateElement("EMAIL");
                    XmlText texto_email = registo.CreateTextNode(email);
                    elemento_email.AppendChild(texto_email);
                    elemento_registo.AppendChild(elemento_email);

                    XmlElement elemento_tipoSangue = registo.CreateElement("TIPOSANGUE");
                    XmlText texto_tipoSangue = registo.CreateTextNode(tipoSanguineo);
                    elemento_tipoSangue.AppendChild(texto_tipoSangue);
                    elemento_registo.AppendChild(elemento_tipoSangue);

                    XmlElement elemento_morada = registo.CreateElement("MORADA");
                    XmlText texto_morada = registo.CreateTextNode(morada);
                    elemento_morada.AppendChild(texto_morada);
                    elemento_registo.AppendChild(elemento_morada);

                    XmlElement elemento_CodPostal = registo.CreateElement("CODPOSTAL");
                    XmlText texto_CodPostal = registo.CreateTextNode(codPostal);
                    elemento_CodPostal.AppendChild(texto_CodPostal);
                    elemento_registo.AppendChild(elemento_CodPostal);

                    XmlElement elemento_localidade = registo.CreateElement("LOCALIDADE");
                    XmlText texto_localidade = registo.CreateTextNode(localidade);
                    elemento_localidade.AppendChild(texto_localidade);
                    elemento_registo.AppendChild(elemento_localidade);

                    XmlElement elemento_CedProf = registo.CreateElement("CEDPROF");
                    XmlText texto_CedProf = registo.CreateTextNode(CedProf);
                    elemento_CedProf.AppendChild(texto_CedProf);
                    elemento_registo.AppendChild(elemento_CedProf);

                    XmlElement elemento_Username = registo.CreateElement("USERNAME");
                    XmlText texto_Username = registo.CreateTextNode(usernameRegisto);
                    elemento_Username.AppendChild(texto_Username);
                    elemento_registo.AppendChild(elemento_Username);

                    XmlElement elemento_Password = registo.CreateElement("PASSWORD");
                    XmlText texto_Password = registo.CreateTextNode(TextBoxPassR.Text);
                    elemento_Password.AppendChild(texto_Password);
                    elemento_registo.AppendChild(elemento_Password);

                    XmlElement elemento_TipoPerfil = registo.CreateElement("TIPOPERFIL");
                    XmlText texto_TipoPerfil = registo.CreateTextNode("");
                    elemento_TipoPerfil.AppendChild(texto_TipoPerfil);
                    elemento_registo.AppendChild(elemento_TipoPerfil);

                    registo.Save(Server.MapPath(pathFinal + ".xml"));

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registo Concluido Com Sucesso! Aguarde Validação')", true);

                    TextBoxNome.Text = "";
                    CalendarDtNascimento.Text = "";
                    TextBoxCP.Text = "";
                    TextBoxEmail.Text = "";
                    TextBoxLocalidade.Text = "";
                    TextBoxNrTelemovel.Text = "";
                    CheckBoxF.Checked = false;
                    CheckBoxM.Checked = false;
                    DropDownTS.SelectedValue = null;
                    TextBoxMorada.Text = "";
                    TextBoxCedulaPf.Text = "";
                    TextBoxUsernameR.Text = "";
                    TextBoxPassR.Text = "";
                    TextBoxPassRC.Text = "";
                    
                }
            }
            else if (passwordR == "" || passwordRegConf == "")
            {
                LabelErrorPassword.Visible = true;
                LabelErrorPassword.Text = "Um dos campos não está preenchido!";

            }
            else if (passwordR != passwordRegConf)
            {
                LabelErrorPassword.Visible = true;
                LabelErrorPassword.Text = "Passwords não coincidem!";
            }
            

            LabelErrorPassword.Visible = false;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void ButtonUtente_Click(object sender, EventArgs e)
        {
            LabelNome.Visible = true;
            TextBoxNome.Visible = true;
            LabelEmail.Visible = true;
            TextBoxEmail.Visible = true;
            LabelDtNascimento.Visible = true;
            CalendarDtNascimento.Visible = true;
            LabelDtNascimento2.Visible = true;
            LabelNrTelemovel.Visible = true;
            TextBoxNrTelemovel.Visible = true;
            LabelGenero.Visible = true;
            CheckBoxF.Visible = true;
            CheckBoxM.Visible = true;
            LabelTipoSanguineo.Visible = true;
            DropDownTS.Visible = true;
            LabelMorada.Visible = true;
            TextBoxMorada.Visible = true;
            LabelCp.Visible = true;
            TextBoxCP.Visible = true;
            LabelLocal.Visible = true;
            TextBoxLocalidade.Visible = true;
            LabelCedProf.Visible = false;
            TextBoxCedulaPf.Visible = false;
            LabelUsername.Visible = true;
            LabelPassword.Visible = true;
            LabelPasswordRC.Visible = true;
            TextBoxUsernameR.Visible = true;
            TextBoxPassR.Visible = true;
            TextBoxPassRC.Visible = true;
            Button3.Visible = true;
        }

        protected void ButtonMedico_Click(object sender, EventArgs e)
        {
            LabelNome.Visible = true;
            TextBoxNome.Visible = true;
            LabelEmail.Visible = true;
            TextBoxEmail.Visible = true;
            LabelDtNascimento.Visible = true;
            CalendarDtNascimento.Visible = true;
            LabelDtNascimento2.Visible = true;
            LabelNrTelemovel.Visible = true;
            TextBoxNrTelemovel.Visible = true;
            LabelGenero.Visible = true;
            CheckBoxF.Visible = true;
            CheckBoxM.Visible = true;
            LabelTipoSanguineo.Visible = true;
            DropDownTS.Visible = true;
            LabelMorada.Visible = true;
            TextBoxMorada.Visible = true;
            LabelCp.Visible = true;
            TextBoxCP.Visible = true;
            LabelLocal.Visible = true;
            TextBoxLocalidade.Visible = true;
            LabelCedProf.Visible = true;
            TextBoxCedulaPf.Visible = true;
            LabelUsername.Visible = true;
            LabelPassword.Visible = true;
            LabelPasswordRC.Visible = true;
            TextBoxUsernameR.Visible = true;
            TextBoxPassR.Visible = true;
            TextBoxPassRC.Visible = true;
            Button3.Visible = true;
        }

    }
}