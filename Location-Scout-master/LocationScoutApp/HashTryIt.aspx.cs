using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HashClassLibrary;

namespace LocationScoutApp
{
    public partial class HashTryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetHash_Click(object sender, EventArgs e)
        {
            SecretHash obj = new SecretHash();
            txtHashOutput.Text = obj.getHashValue(txtInput.Text);
        }
    }
}