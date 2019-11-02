using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocationScoutApp
{
    public partial class LoginControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string UserName
        {
            get { return MyUserName.Text; }
            set { MyUserName.Text = value; }
        }
        public string Password
        {
            get { return MyPassword.Text; }
            set { MyPassword.Text = value; }
        }
    }
}