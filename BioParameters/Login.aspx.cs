using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace BioParameters
{
    public partial class _Default : Page
    {
        string userMed;
        string userUte;
        string userAdm;
        string username;
        string password;

        protected void Page_Load(object sender, EventArgs e)
        {

            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
                string strcon = "Data Source=localhost;Initial Catalog=TP_ES;Integrated Security=True";

                SqlConnection conexao = new SqlConnection(strcon);
                try
                {
                    conexao.Open();
                    SqlCommand cmdA = new SqlCommand("SELECT AdministradorAdministradorID FROM Credenciais" + " WHERE username = '" + TextBoxUsername.Text + "'", conexao);
                    userAdm = cmdA.ExecuteScalar().ToString();
                    SqlCommand cmdB = new SqlCommand("SELECT MedicoMedicoID FROM Credenciais" + " WHERE username = '" + TextBoxUsername.Text + "'", conexao);
                    userMed = cmdB.ExecuteScalar().ToString();
                    SqlCommand cmdC = new SqlCommand("SELECT UtenteUtenteID FROM Credenciais" + " WHERE username = '" + TextBoxUsername.Text + "'", conexao);
                    userUte = cmdC.ExecuteScalar().ToString();
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi possível encontrar o perfil!')", true);
                }
                finally
                {
                    conexao.Close();
                }

                if (!string.IsNullOrEmpty(userAdm))
                {
                    try
                    {
                        conexao.Open();
                        SqlCommand cmdA = new SqlCommand("SELECT username FROM Credenciais" + " WHERE AdministradorAdministradorID = '" + int.Parse(userAdm) + "'", conexao);
                        username = cmdA.ExecuteScalar().ToString();
                        SqlCommand cmdB = new SqlCommand("SELECT password FROM Credenciais" + " WHERE AdministradorAdministradorID = '" + int.Parse(userAdm) + "'", conexao);
                        password = cmdB.ExecuteScalar().ToString();
                    }
                    catch
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi possível encontrar o perfil!')", true);
                    }
                    finally
                    {
                        conexao.Close();
                    }

                    if (TextBoxUsername.Text == username && TextBoxPassword.Text == password)
                    {
                        Response.Redirect("Adminstrador.aspx?id=" + userAdm + "&username=" + username);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Username ou Palavra-passe incorrectos!')", true);
                    }

                }
                else if (!string.IsNullOrEmpty(userMed))
                {
                    //medicoes medico
                    try
                    {
                        conexao.Open();
                        SqlCommand cmdA = new SqlCommand("SELECT username FROM Credenciais" + " WHERE MedicoMedicoID = '" + int.Parse(userMed) + "'", conexao);
                        username = cmdA.ExecuteScalar().ToString();
                        SqlCommand cmdB = new SqlCommand("SELECT password FROM Credenciais" + " WHERE MedicoMedicoID = '" + int.Parse(userMed) + "'", conexao);
                        password = cmdB.ExecuteScalar().ToString();
                    }
                    catch
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi possível encontrar o perfil!')", true);
                    }
                    finally
                    {
                        conexao.Close();
                    }

                    if (TextBoxUsername.Text == username && TextBoxPassword.Text == password)
                    {
                        Response.Redirect("AreaMedico.aspx?id=" + userMed + "&username=" + username);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Username ou Palavra-passe incorrectos!')", true);
                    }
                }
                else if (!string.IsNullOrEmpty(userUte))
                {
                    try
                    {
                        conexao.Open();
                        SqlCommand cmdA = new SqlCommand("SELECT username FROM Credenciais" + " WHERE UtenteUtenteID = '" + int.Parse(userUte) + "'", conexao);
                        username = cmdA.ExecuteScalar().ToString();
                        SqlCommand cmdB = new SqlCommand("SELECT password FROM Credenciais" + " WHERE UtenteUtenteID = '" + int.Parse(userUte) + "'", conexao);
                        password = cmdB.ExecuteScalar().ToString();
                    }
                    catch
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi possível encontrar o perfil!')", true);
                    }
                    finally
                    {
                        conexao.Close();
                    }

                    if (TextBoxUsername.Text == username && TextBoxPassword.Text == password)
                    {
                        Response.Redirect("MedicoesUtente.aspx?id=" + userUte + "&username=" + username);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Username ou Palavra-passe incorrectos!')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Perfil inexistente!')", true);
                }
           TextBoxUsername.Text = "";
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Registar.aspx");
        }

        protected void LinkButtonRecover_Click(object sender, EventArgs e)
        {
            Response.Redirect("RecupPassword.aspx");
        }
    }
}