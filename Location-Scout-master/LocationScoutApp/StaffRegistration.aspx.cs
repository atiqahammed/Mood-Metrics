using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocationScoutApp
{
    public partial class StaffRegistration : System.Web.UI.Page
    {
        private const int STAFF_XML = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelErrorMessage.Visible = false;
            LabelUserAdded.Visible = false;
        }

        protected void ButtonHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            string userName = TextBoxUsername.Text;
            string email = TextBoxEmail.Text;
            string password = TextBoxPassword.Text;
            string confirmPassword = TextBoxConfirmPassword.Text;

            if (userName.Equals("") || password.Equals("'") || confirmPassword.Equals(""))
            {
                LabelErrorMessage.Visible = true;
                LabelErrorMessage.Text = "Please enter the required fields marked with asterisk(*)";
            }
            else if (!password.Equals(confirmPassword))
            {
                LabelErrorMessage.Visible = true;
                LabelErrorMessage.Text = "Password mismatch..Please try again";
            }
            else
            {
                UserXmlManipulation memberXml = new UserXmlManipulation();
                bool isMemberAdded = memberXml.addUserCredential(userName, password, STAFF_XML);

                if (isMemberAdded)
                {
                    LabelUserAdded.Visible = true;
                    LabelUserAdded.Text = userName + " Added Successfully";
                }
                else
                {
                    LabelErrorMessage.Visible = true;
                    LabelErrorMessage.Text = "User already exists or an error at backend";
                }

            }
        }
    }
}