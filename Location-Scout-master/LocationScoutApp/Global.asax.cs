using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace LocationScoutApp
{
    public class Global : System.Web.HttpApplication
    {
        // to keep a counter on number of sessions started
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["numOfSessions"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();
            Application["numOfSessions"] = (int)Application["numOfSessions"] + 1;
            Application.UnLock();
        }
    }
}