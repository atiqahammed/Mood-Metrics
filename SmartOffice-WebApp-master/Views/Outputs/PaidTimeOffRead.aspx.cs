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
    public partial class PaidTimeOffRead : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                    string queryDecisionStatus = "SELECT DecisionStatus FROM LeavingApproval WHERE LAppId = @LAppId";

                    SqlCommand sqlCmdRequesterEpNm = new SqlCommand(queryRequesterEpNm, sqlCon);
                    SqlCommand sqlCmdDpmtName = new SqlCommand(queryDpmtName, sqlCon);
                    SqlCommand sqlCmdApproverEpNm = new SqlCommand(queryApproverEpNm, sqlCon);
                    SqlCommand sqlCmdLeaveType = new SqlCommand(queryLeaveType, sqlCon);
                    SqlCommand sqlCmdFromDate = new SqlCommand(queryFromDate, sqlCon);
                    SqlCommand sqlCmdToDate = new SqlCommand(queryToDate, sqlCon);
                    SqlCommand sqlCmdDestination = new SqlCommand(queryDestination, sqlCon);
                    SqlCommand sqlCmdReason = new SqlCommand(queryReason, sqlCon);
                    SqlCommand sqlCmdDecisionStatus = new SqlCommand(queryDecisionStatus, sqlCon);

                    sqlCmdRequesterEpNm.Parameters.AddWithValue("@LAppId", lAppId);
                    sqlCmdDpmtName.Parameters.AddWithValue("@LAppId", lAppId);
                    sqlCmdApproverEpNm.Parameters.AddWithValue("@LAppId", lAppId);
                    sqlCmdLeaveType.Parameters.AddWithValue("@LAppId", lAppId);
                    sqlCmdFromDate.Parameters.AddWithValue("@LAppId", lAppId);
                    sqlCmdToDate.Parameters.AddWithValue("@LAppId", lAppId);
                    sqlCmdDestination.Parameters.AddWithValue("@LAppId", lAppId);
                    sqlCmdReason.Parameters.AddWithValue("@LAppId", lAppId);
                    sqlCmdDecisionStatus.Parameters.AddWithValue("@LAppId", lAppId);

                    string RequesterEpNm = (string)sqlCmdRequesterEpNm.ExecuteScalar();
                    string DpmtName = (string)sqlCmdDpmtName.ExecuteScalar();
                    string ApproverEpNm = (string)sqlCmdApproverEpNm.ExecuteScalar();
                    string LeaveType = (string)sqlCmdLeaveType.ExecuteScalar();
                    DateTime FromDate = (DateTime)sqlCmdFromDate.ExecuteScalar();
                    DateTime ToDate = (DateTime)sqlCmdToDate.ExecuteScalar();
                    string Destination = (string)sqlCmdDestination.ExecuteScalar();
                    string Reason = (string)sqlCmdReason.ExecuteScalar();
                    Boolean DecisionStatus = (Boolean)sqlCmdDecisionStatus.ExecuteScalar();

                    string DecisionStatus_str = "";
                    if (DecisionStatus == true)
                    {
                        DecisionStatus_str = "Approved";
                    }
                    else if (DecisionStatus == false)
                    {
                        DecisionStatus_str = "Rejected";
                    }
                    else
                    {
                        DecisionStatus_str = "Undecided";
                    }

                    lblRequesterEpNmS.Text = RequesterEpNm;
                    lblDpmtNameS.Text = DpmtName;
                    lblApproverEpNmS.Text = ApproverEpNm;
                    lblLeaveTypeS.Text = LeaveType;
                    lblFromDateS.Text = FromDate.ToString();
                    lblToDateS.Text = ToDate.ToString();
                    lblDestinationS.Text = Destination;
                    lblReasonS.Text = Reason;
                    lblDecisionStatusS.Text = DecisionStatus_str;

                    sqlCon.Close();
                }
            }
        }
    }
}