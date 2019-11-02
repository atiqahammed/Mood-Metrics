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
    public partial class ReimbursementUnreadS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                    string queryDecisionStatus = "SELECT DecisionStatus FROM ReimburseApproval WHERE RAppId = @RAppId";

                    SqlCommand sqlCmdRequesterEpNm = new SqlCommand(queryRequesterEpNm, sqlCon);
                    SqlCommand sqlCmdDpmtName = new SqlCommand(queryDpmtName, sqlCon);
                    SqlCommand sqlCmdApproverEpNm = new SqlCommand(queryApproverEpNm, sqlCon);
                    SqlCommand sqlCmdAmount = new SqlCommand(queryAmount, sqlCon);
                    SqlCommand sqlCmdDetails = new SqlCommand(queryDetails, sqlCon);
                    SqlCommand sqlCmdDecisionStatus = new SqlCommand(queryDecisionStatus, sqlCon);

                    sqlCmdRequesterEpNm.Parameters.AddWithValue("@RAppId", rAppId);
                    sqlCmdDpmtName.Parameters.AddWithValue("@RAppId", rAppId);
                    sqlCmdApproverEpNm.Parameters.AddWithValue("@RAppId", rAppId);
                    sqlCmdAmount.Parameters.AddWithValue("@RAppId", rAppId);
                    sqlCmdDetails.Parameters.AddWithValue("@RAppId", rAppId);
                    sqlCmdDecisionStatus.Parameters.AddWithValue("@RAppId", rAppId);

                    string RequesterEpNm = (string)sqlCmdRequesterEpNm.ExecuteScalar();
                    string DpmtName = (string)sqlCmdDpmtName.ExecuteScalar();
                    string ApproverEpNm = (string)sqlCmdApproverEpNm.ExecuteScalar();
                    int Amount = (int)sqlCmdAmount.ExecuteScalar();
                    string Details = (string)sqlCmdDetails.ExecuteScalar();
                    string DecisionStatus = "Undecided";

                    lblRequesterEpNmC.Text = RequesterEpNm;
                    lblDpmtNameC.Text = DpmtName;
                    lblApproverEpNmC.Text = ApproverEpNm;
                    lblAmountC.Text = Amount.ToString();
                    lblDetailsC.Text = Details;
                    lblDecisionStatusS.Text = DecisionStatus;

                    sqlCon.Close();
                }
            }
        }
    }
}