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
    public partial class PaidTimeOffUnread : System.Web.UI.Page
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
            string lAppId = HttpUtility.ParseQueryString(myUri.Query).Get("LAppId");
            int count = 0;
            while (count < 5)
            {
                lAppId = lAppId.Remove(lAppId.Length - 1, 1);
                count += 1;
            }

            if (!IsPostBack)
            {
                using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SmartOffice_ConnectionString"].ConnectionString))
                {
                    sqlCon.Open();

                    string queryRequesterEpNm = "SELECT RequesterEpNm FROM LeavingApproval WHERE LAppId = @LAppId";
                    string queryDpmtName = "SELECT DpmtName FROM LeavingApproval WHERE LAppId = @LAppId";
                    string queryApproverEpNm = "SELECT ApproverEpNm FROM LeavingApproval WHERE LAppId = @LAppId";
                    string queryLeaveType = "SELECT LAppType FROM LeavingApproval WHERE LAppId = @LAppId";
                    string queryFromDate = "SELECT LAppStartTime FROM LeavingApproval WHERE LAppId = @LAppId";
                    string queryToDate = "SELECT LAppEndTime FROM LeavingApproval WHERE LAppId = @LAppId";
                    string queryDestination = "SELECT LDestination FROM LeavingApproval WHERE LAppId = @LAppId";
                    string queryReason = "SELECT LReason FROM LeavingApproval WHERE LAppId = @LAppId";

                    SqlCommand sqlCmdRequesterEpNm = new SqlCommand(queryRequesterEpNm, sqlCon);
                    SqlCommand sqlCmdDpmtName = new SqlCommand(queryDpmtName, sqlCon);
                    SqlCommand sqlCmdApproverEpNm = new SqlCommand(queryApproverEpNm, sqlCon);
                    SqlCommand sqlCmdLeaveType = new SqlCommand(queryLeaveType, sqlCon);
                    SqlCommand sqlCmdFromDate = new SqlCommand(queryFromDate, sqlCon);
                    SqlCommand sqlCmdToDate = new SqlCommand(queryToDate, sqlCon);
                    SqlCommand sqlCmdDestination = new SqlCommand(queryDestination, sqlCon);
                    SqlCommand sqlCmdReason = new SqlCommand(queryReason, sqlCon);

                    sqlCmdRequesterEpNm.Parameters.AddWithValue("@LAppId", lAppId);
                    sqlCmdDpmtName.Parameters.AddWithValue("@LAppId", lAppId);
                    sqlCmdApproverEpNm.Parameters.AddWithValue("@LAppId", lAppId);
                    sqlCmdLeaveType.Parameters.AddWithValue("@LAppId", lAppId);
                    sqlCmdFromDate.Parameters.AddWithValue("@LAppId", lAppId);
                    sqlCmdToDate.Parameters.AddWithValue("@LAppId", lAppId);
                    sqlCmdDestination.Parameters.AddWithValue("@LAppId", lAppId);
                    sqlCmdReason.Parameters.AddWithValue("@LAppId", lAppId);

                    string RequesterEpNm = (string)sqlCmdRequesterEpNm.ExecuteScalar();
                    string DpmtName = (string)sqlCmdDpmtName.ExecuteScalar();
                    string ApproverEpNm = (string)sqlCmdApproverEpNm.ExecuteScalar();
                    string LeaveType = (string)sqlCmdLeaveType.ExecuteScalar();
                    DateTime FromDate = (DateTime)sqlCmdFromDate.ExecuteScalar();
                    DateTime ToDate = (DateTime)sqlCmdToDate.ExecuteScalar();
                    string Destination = (string)sqlCmdDestination.ExecuteScalar();
                    string Reason = (string)sqlCmdReason.ExecuteScalar();

                    lblRequesterEpNmC.Text = RequesterEpNm;
                    lblDpmtNameC.Text = DpmtName;
                    lblApproverEpNmC.Text = ApproverEpNm;
                    lblLeaveTypeC.Text = LeaveType;
                    lblFromDateC.Text = FromDate.ToString();
                    lblToDateC.Text = ToDate.ToString();
                    lblDestinationC.Text = Destination;
                    lblReasonC.Text = Reason;

                    sqlCon.Close();
                }
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            string DecisionStatus = "1";

            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            Uri myUri = new Uri(url);
            string lAppId = HttpUtility.ParseQueryString(myUri.Query).Get("LAppId");
            int count = 0;
            while (count < 5)
            {
                lAppId = lAppId.Remove(lAppId.Length - 1, 1);
                count += 1;
            }

            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SmartOffice_ConnectionString"].ConnectionString))
            {
                sqlCon.Open();
                string query = "UPDATE LeavingApproval SET DecisionStatus = @DecisionStatus" +
                    " WHERE LAppId = @LAppId";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                sqlCmd.Parameters.AddWithValue("@DecisionStatus", DecisionStatus);
                sqlCmd.Parameters.AddWithValue("@LAppId", lAppId);

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
            string lAppId = HttpUtility.ParseQueryString(myUri.Query).Get("LAppId");
            int count = 0;
            while (count < 5)
            {
                lAppId = lAppId.Remove(lAppId.Length - 1, 1);
                count += 1;
            }

            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SmartOffice_ConnectionString"].ConnectionString))
            {
                sqlCon.Open();
                string query = "UPDATE LeavingApproval SET DecisionStatus = @DecisionStatus" +
                    " WHERE LAppId = @LAppId";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                sqlCmd.Parameters.AddWithValue("@DecisionStatus", DecisionStatus);
                sqlCmd.Parameters.AddWithValue("@LAppId", lAppId);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();

                Response.Redirect("~/Views/Info.aspx");
            }
        }
    }
}