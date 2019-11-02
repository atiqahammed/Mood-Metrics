using SmOffice.Models;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System;

namespace SmOffice.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SmartOffice_ConnectionString"].ConnectionString))
            {
                sqlCon.Open();
                string query1 = "SELECT EmpyPwHash FROM Employee WHERE EmpyEmail=@EmpyEmail";
                SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon);
                sqlCmd1.Parameters.AddWithValue("@EmpyEmail", txtEmpyEmail.Text.Trim());
                string query2 = "SELECT EmpyPwSalt FROM Employee WHERE EmpyEmail=@EmpyEmail";
                SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);
                sqlCmd2.Parameters.AddWithValue("@EmpyEmail", txtEmpyEmail.Text.Trim());

                string password = txtEmpyPwd.Text.Trim();

                byte[] hash = (byte[])sqlCmd1.ExecuteScalar();
                byte[] salt = (byte[])sqlCmd2.ExecuteScalar();

                bool verify = Utility.VerifyPassword(password, salt, hash);

                if (verify == true)
                {
                    Session["EmpyEmail"] = txtEmpyEmail.Text.Trim();

                    Response.Redirect("Dashboard.aspx");
                }
                else { lblErrorMessage.Visible = true; }

                sqlCon.Close();

            }
        }


    }
}