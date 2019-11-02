using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace SmOffice.Views.Outputs
{
    public partial class ReimbursementUnread : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button btnApprove = new Button()
            {
                ID = "btnApprove",
                Text = "Approve"
            };

            btnApprove.Click += new EventHandler(this.btnApprove_Click);

            Button btnReject = new Button()
            {
                ID = "btnReject",
                Text = "Reject"
            };

            btnReject.Click += new EventHandler(this.btnReject_Click);

            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            Uri myUri = new Uri(url);
            string rAppId = HttpUtility.ParseQueryString(myUri.Query).Get("RAppId");
            int count = 0;
            while (count < 5)
            {
                rAppId = rAppId.Remove(rAppId.Length - 1, 1);
                count += 1;
            }

            if (!IsPostBack)
            {
                using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SmartOffice_ConnectionString"].ConnectionString))
                {
                    sqlCon.Open();

                    string queryRequesterEpNm = "SELECT RequesterEpNm FROM ReimburseApproval WHERE RAppId = @RAppId";
                    string queryDpmtName = "SELECT DpmtName FROM ReimburseApproval WHERE RAppId = @RAppId";
                    string queryApproverEpNm = "SELECT ApproverEpNm FROM ReimburseApproval WHERE RAppId = @RAppId";
                    string queryAmount = "SELECT RAppAmount FROM ReimburseApproval WHERE RAppId = @RAppId";
                    string queryDetails = "SELECT RExpDetails FROM ReimburseApproval WHERE RAppId = @RAppId";

                    SqlCommand sqlCmdRequesterEpNm = new SqlCommand(queryRequesterEpNm, sqlCon);
                    SqlCommand sqlCmdDpmtName = new SqlCommand(queryDpmtName, sqlCon);
                    SqlCommand sqlCmdApproverEpNm = new SqlCommand(queryApproverEpNm, sqlCon);
                    SqlCommand sqlCmdAmount = new SqlCommand(queryAmount, sqlCon);
                    SqlCommand sqlCmdDetails = new SqlCommand(queryDetails, sqlCon);

                    sqlCmdRequesterEpNm.Parameters.AddWithValue("@RAppId", rAppId);
                    sqlCmdDpmtName.Parameters.AddWithValue("@RAppId", rAppId);
                    sqlCmdApproverEpNm.Parameters.AddWithValue("@RAppId", rAppId);
                    sqlCmdAmount.Parameters.AddWithValue("@RAppId", rAppId);
                    sqlCmdDetails.Parameters.AddWithValue("@RAppId", rAppId);

                    string RequesterEpNm = (string)sqlCmdRequesterEpNm.ExecuteScalar();
                    string DpmtName = (string)sqlCmdDpmtName.ExecuteScalar();
                    string ApproverEpNm = (string)sqlCmdApproverEpNm.ExecuteScalar();
                    int Amount = (int)sqlCmdAmount.ExecuteScalar();
                    string Details = (string)sqlCmdDetails.ExecuteScalar();

                    lblRequesterEpNmC.Text = RequesterEpNm;
                    lblDpmtNameC.Text = DpmtName;
                    lblApproverEpNmC.Text = ApproverEpNm;
                    lblAmountC.Text = Amount.ToString();
                    lblDetailsC.Text = Details;

                    sqlCon.Close();
                }
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            string DecisionStatus = "1";

            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            Uri myUri = new Uri(url);
            string rAppId = HttpUtility.ParseQueryString(myUri.Query).Get("RAppId");
            int count = 0;
            while (count < 5)
            {
                rAppId = rAppId.Remove(rAppId.Length - 1, 1);
                count += 1;
            }

            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SmartOffice_ConnectionString"].ConnectionString))
            {
                sqlCon.Open();
                string query = "UPDATE ReimburseApproval SET DecisionStatus = @DecisionStatus" +
                    " WHERE RAppId = @RAppId";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                sqlCmd.Parameters.AddWithValue("@DecisionStatus", DecisionStatus);
                sqlCmd.Parameters.AddWithValue("@RAppId", rAppId);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();

                Response.Redirect("~/Views/Info.aspx");
            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            string DecisionStatus = "0";

            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            Uri myUri = new Uri(url);
            string rAppId = HttpUtility.ParseQueryString(myUri.Query).Get("RAppId");
            int count = 0;
            while (count < 5)
            {
                rAppId = rAppId.Remove(rAppId.Length - 1, 1);
                count += 1;
            }

            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SmartOffice_ConnectionString"].ConnectionString))
            {
                sqlCon.Open();
                string query = "UPDATE ReimburseApproval SET DecisionStatus = @DecisionStatus" +
                    " WHERE RAppId = @RAppId";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                sqlCmd.Parameters.AddWithValue("@DecisionStatus", DecisionStatus);
                sqlCmd.Parameters.AddWithValue("@RAppId", rAppId);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();

                Response.Redirect("~/Views/Info.aspx");
            }
        }
    }
}