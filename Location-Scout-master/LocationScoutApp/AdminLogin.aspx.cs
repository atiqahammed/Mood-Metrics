using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocationScoutApp
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        private static string ADMIN_USERNAME = "";
        private static string ADMIN_PASSWORD = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            string userName = loginControl.UserName;
            string password = loginControl.Password;

            ADMIN_USERNAME = System.Web.Configuration.WebConfigurationManager.AppSettings["adminUsername"];
            ADMIN_PASSWORD  = System.Web.Configuration.WebConfigurationManager.AppSettings["adminPassword"]; ;

            if (userName.Equals("") || password.Equals(""))
            {
                LabelLoginError.Visible = true;
                LabelLoginError.Text = "Please enter username & password";

            }
            else if (userName.Equals(ADMIN_USERNAME) && password.Equals(ADMIN_PASSWORD))
            {
                Response.Redirect("~/StaffRegistration.aspx");
            }
        }
    }
}