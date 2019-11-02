using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocationScoutApp
{
    public partial class StaffLogin : System.Web.UI.Page
    {
        private const int STAFF_XML = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookies = Request.Cookies["staffLoginCookie"];
            if (myCookies != null)
            {
                LabelCookie.Visible = true;
                LabelCookie.Text = "Last saved username: " + myCookies["UserName"];
            }
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            string userName = loginControl.UserName;
            string password = loginControl.Password;

            if (userName.Equals("") || password.Equals(""))
            {
                LabelLoginError.Visible = true;
                LabelLoginError.Text = "Please enter username & password";
            }
            else
            {
                UserXmlManipulation staffXml = new UserXmlManipulation();
                bool isValidUser = staffXml.AuthenticateUserCredential(userName, password, STAFF_XML);

                if (isValidUser)
                {
                    // storing the user information in the session for future use
                    GeneralUserClass staff = new GeneralUserClass();
                    staff.username = userName;
                    Session["StaffAccount"] = staff;

                    // storing username in a cookie if user checks the checkbox at UI
                    if (CheckBoxSaveUsername.Checked == true)
                    {
                        HttpCookie myCookies = new HttpCookie("staffLoginCookie");
                        myCookies["UserName"] = loginControl.UserName;
                        myCookies.Expires = DateTime.Now.AddMinutes(5);
                        Response.Cookies.Add(myCookies);
                    }
                    Response.Redirect("~/Staff.aspx");
                }
                else
                {
                    LabelCookie.Visible = true;
                    LabelCookie.Text = "Wrong username/password entered..!";
                }
            }
        }

        protected void ButtonHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

    }
}