using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocationScoutApp
{
    public partial class Staff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // checking if the user is in active session, if not redirecting to login page
                if (Session["StaffAccount"] != null)
                {
                    GeneralUserClass staff = (GeneralUserClass)Session["StaffAccount"];
                    LabelUsername.Text = staff.username;
                }
                else
                    Response.Redirect("~/StaffLogin.aspx");
            }
        }

        protected void HomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("StaffAccount");
            Response.Redirect("~/StaffLogin.aspx");
        }
    }
}