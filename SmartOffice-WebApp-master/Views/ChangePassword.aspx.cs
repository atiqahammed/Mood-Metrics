using SmOffice.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace SmOffice.Views
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button btnSubmit = new Button()
            {
                ID = "btnSubmit",
                Text = "Submit"
            };

            btnSubmit.Click += new EventHandler(this.btnSubmit_Click);

            lblErrorMessage.Visible = false;

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SmartOffice_ConnectionString"].ConnectionString))
            {
                sqlCon.Open();
                string query = "UPDATE Employee SET EmpyPwHash=@EmpyPwHash, EmpyPwSalt=@EmpyPwSalt WHERE EmpyEmail=@EmpyEmail";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@EmpyEmail", txtEmpyEmail.Text.Trim());

                if (txtNewEmpyPwd.Text.Trim() == txtConNewEmpyPwd.Text.Trim())
                {
                    byte[] salt = Utility.GenerateSalt();
                    byte[] hash = Utility.ComputeHash(txtNewEmpyPwd.Text.Trim(), salt);

                    sqlCmd.Parameters.Add("@EmpyPwHash", SqlDbType.Binary, hash.Length).Value = hash;
                    sqlCmd.Parameters.Add("@EmpyPwSalt", SqlDbType.Binary, salt.Length).Value = salt;
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();

                    Response.Redirect("Login.aspx");
                }
                else
                {
                    lblErrorMessage.Visible = true;
                }

            }
        }
    }
}