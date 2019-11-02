<%@ Register TagPrefix="user" TagName="LoginControl" Src="~/LoginControl.ascx" %>
<%@ Register TagPrefix="header" TagName="PageHeaderControl" Src="~/PageHeaderControl.ascx" %>
<%@ Import Namespace="LocationScoutApp" %>


<!DOCTYPE html>

<%@ Page Language="C#" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Location Scout</title>
</head>
<body>
    <header:PageHeaderControl runat="server" />
    <h3>Member Login&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </h3>
    <hr />
    <form runat="server" visible="True">
        <user:LoginControl ID="loginControl" BackColor="#ccccff" runat="server" />
        &nbsp;&nbsp; &nbsp;<asp:Label ID="LabelLoginError" runat="server" ForeColor="Red" Text="LabelLoginError" Visible="False"></asp:Label>
        &nbsp;&nbsp;&nbsp;<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:CheckBox ID="CheckBoxSaveUsername" runat="server" Text="Save Username" />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonLogin" runat="server" Text="Log In" OnClick="ButtonLogin_Click" Width="104px" />
        &nbsp;&nbsp;&nbsp;
        <br />
        <br />
        &nbsp;<asp:Label ID="LabelCookie" runat="server" Text="Username saved successfully" Visible="False"></asp:Label>
        <hr />
        <p>
            <asp:Button ID="ButtonHome" runat="server" OnClick="ButtonHome_Click" Text="Home" Width="118px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="ButtonRegister" runat="server" Text="Register" Width="112px" OnClick="ButtonRegister_Click" />
        </p>
    </form>

</body>
</html>

<script runat="server">

    // displaying the stored username value in the cookie
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie myCookies = Request.Cookies["memberLoginCookie"];
        if (myCookies != null)
        {
            LabelCookie.Visible = true;
            LabelCookie.Text = "Last saved username: " + myCookies["UserName"];
        }
    }

    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        int MEMBER_XML = 1;

        string userName = loginControl.UserName;
        string password = loginControl.Password;

        if (userName.Equals("") || password.Equals(""))
        {
            LabelLoginError.Visible = true;
            LabelLoginError.Text = "Please enter username & password";
        }
        else
        {
            UserXmlManipulation memberXml = new UserXmlManipulation();
            bool isValidUser = memberXml.AuthenticateUserCredential(userName, password, MEMBER_XML);

            if (isValidUser)
            {
                // storing the user information in the session for future use
                GeneralUserClass member = new GeneralUserClass();
                member.username = userName;
                Session["MemberAccount"] = member;

                // storing username in a cookie if user checks the checkbox at UI
                if (CheckBoxSaveUsername.Checked == true)
                {
                    HttpCookie myCookies = new HttpCookie("memberLoginCookie");
                    myCookies["UserName"] = loginControl.UserName;
                    myCookies.Expires = DateTime.Now.AddMinutes(5);
                    Response.Cookies.Add(myCookies);
                }
                Response.Redirect("~/Member.aspx");
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

    protected void ButtonRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MemberRegisteration.aspx");
    }
    
</script>


