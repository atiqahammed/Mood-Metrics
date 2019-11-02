using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocationScoutApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelSessionCount.Text = Convert.ToString(Application["numOfSessions"]);
        }

        protected void ButtonMemLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MemberLogin.aspx");
        }

        protected void ButtonMemPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Member.aspx");
        }

        protected void ButtonMemRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ImageVerifier.aspx");
            //Response.Redirect("~/MemberRegisteration.aspx");
        }

        protected void ButtonStaffLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StaffLogin.aspx");
        }

        protected void ButtonStaffPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Staff.aspx");
        }

        protected void ButtonAdminLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminLogin.aspx");
        }

    }
}