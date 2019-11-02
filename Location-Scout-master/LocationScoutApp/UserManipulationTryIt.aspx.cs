using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocationScoutApp
{
    public partial class UserManipulationTryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAuthenticateUser_Click(object sender, EventArgs e)
        {
            String password = txtPassword.Text;
            String username = txtUsername.Text;
            UserXmlManipulation obj = new UserXmlManipulation();
            lblAuthMsg.Visible = false;
            int memberFlag = 1;
            if (obj.AuthenticateUserCredential(username, password, memberFlag))
            {
                lblAuthMsg.Visible = true;
                lblAuthMsg.Text = "Authentication Successful!!";
            }
            else
            {
                lblAuthMsg.Visible = true;
                lblAuthMsg.Text = "Authentication Failed !!!";
            }       
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            String password = txtPassword.Text;
            String username = txtUsername.Text;
            lblAddUserMsg.Visible = false;
            int memberFlag = 1;
            UserXmlManipulation obj = new UserXmlManipulation();
            if (obj.addUserCredential(username, password, memberFlag))
            {
                lblAddUserMsg.Visible = true;
                lblAddUserMsg.Text = "Successfully Added!!";
            }
            else
            {
                lblAddUserMsg.Visible = true;
                lblAddUserMsg.Text = "Unable to Add" + txtUsername.Text + "!!! Try Again";
            } 
        }
    }
}