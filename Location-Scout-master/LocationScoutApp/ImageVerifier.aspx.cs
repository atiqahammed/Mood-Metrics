using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LocationScoutApp.ImageVerifierServiceRef;
using System.IO;

namespace LocationScoutApp
{
    public partial class ImageVerifier : System.Web.UI.Page
    {
        private static String verificationString;
        private const String verifierLength = "5";
        private const string imagePath = @"Images\";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CaptchaImage.Visible = true;
                ImageVerifierServiceRef.ServiceClient client = new ImageVerifierServiceRef.ServiceClient();
                verificationString = client.GetVerifierString(verifierLength);
                Stream stream = client.GetImage(verificationString);
                Random rnd = new Random();
                String imageName = rnd.Next(1, 10000000).ToString() + rnd.Next(100, 100000000) + ".jpg";
                string savePath = Server.MapPath(imagePath + imageName);
                System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
                image.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                CaptchaImage.ImageUrl = "~/Images/" + imageName;
            }
        }

        private void setCaptcha()
        {
            CaptchaImage.Visible = true;
            ImageVerifierServiceRef.ServiceClient client = new ImageVerifierServiceRef.ServiceClient();
            verificationString = client.GetVerifierString(verifierLength);
            Stream stream = client.GetImage(verificationString);
            Random rnd = new Random();
            String imageName = rnd.Next(1, 10000000).ToString() + rnd.Next(100, 100000000) + ".jpg";
            string savePath = Server.MapPath(imagePath + imageName);
            System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
            image.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            CaptchaImage.ImageUrl = "~/Images/" + imageName;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string userSubmitted = txtVerification.Text.Trim();
            if (userSubmitted.Equals(verificationString))
            {
                CaptchaImage.Visible = false;
                Response.Redirect("~/MemberRegisteration.aspx");
            }
            else
            {
                lblVerify.Text = "Wrong captcha Try Again!!!";
                this.setCaptcha();
            }
        }
    }
}