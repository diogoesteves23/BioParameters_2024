using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BioParameters
{
    public partial class RecupPassword : System.Web.UI.Page
    {
        string password;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            
            string strcon = "Data Source=localhost;Initial Catalog=TP_ES;Integrated Security=True";
            SqlConnection conexao = new SqlConnection(strcon);

            if (!String.IsNullOrEmpty(TextBoxUsernameR.Text))
            {
                try
                {
                    conexao.Open();
                    SqlCommand cmdA = new SqlCommand("SELECT password FROM Credenciais" + " WHERE username = '" + TextBoxUsernameR.Text + "'", conexao);
                    password = cmdA.ExecuteScalar().ToString();

                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Não foi possível encontrar o perfil!')", true);
                    throw;
                }
                finally
                {
                    LabelPassword.Text = password;
                    LabelPassword.Visible = true;
                    LabelP.Visible = true;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Insira um Username Válido!')", true);
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}