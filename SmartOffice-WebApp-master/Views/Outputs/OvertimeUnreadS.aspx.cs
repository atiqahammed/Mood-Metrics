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
    public partial class OvertimeUnreadS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            Uri myUri = new Uri(url);
            string oAppId = HttpUtility.ParseQueryString(myUri.Query).Get("OAppId");
            int count = 0;
            while (count < 5)
            {
                oAppId = oAppId.Remove(oAppId.Length - 1, 1);
                count += 1;
            }

            if (!IsPostBack)
            {
                using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SmartOffice_ConnectionString"].ConnectionString))
                {
                    sqlCon.Open();

                    string queryRequesterEpNm = "SELECT RequesterEpNm FROM OvertimeApproval WHERE OAppId = @OAppId";
                    string queryDpmtName = "SELECT DpmtName FROM OvertimeApproval WHERE OAppId = @OAppId";
                    string queryApproverEpNm = "SELECT ApproverEpNm FROM OvertimeApproval WHERE OAppId = @OAppId";
                    string queryPublicHolidayYN = "SELECT PublicHolidayYN FROM OvertimeApproval WHERE OAppId = @OAppId";
                    string queryFromDate = "SELECT OAppStartTime FROM OvertimeApproval WHERE OAppId = @OAppId";
                    string queryToDate = "SELECT OAppEndTime FROM OvertimeApproval WHERE OAppId = @OAppId";
                    string queryReason = "SELECT OReason FROM OvertimeApproval WHERE OAppId = @OAppId";
                    string queryDecisionStatus = "SELECT DecisionStatus FROM OvertimeApproval WHERE OAppId = @OAppId";

                    SqlCommand sqlCmdRequesterEpNm = new SqlCommand(queryRequesterEpNm, sqlCon);
                    SqlCommand sqlCmdDpmtName = new SqlCommand(queryDpmtName, sqlCon);
                    SqlCommand sqlCmdApproverEpNm = new SqlCommand(queryApproverEpNm, sqlCon);
                    SqlCommand sqlCmdPublicHolidayYN = new SqlCommand(queryPublicHolidayYN, sqlCon);
                    SqlCommand sqlCmdFromDate = new SqlCommand(queryFromDate, sqlCon);
                    SqlCommand sqlCmdToDate = new SqlCommand(queryToDate, sqlCon);
                    SqlCommand sqlCmdReason = new SqlCommand(queryReason, sqlCon);
                    SqlCommand sqlCmdDecisionStatus = new SqlCommand(queryDecisionStatus, sqlCon);

                    sqlCmdRequesterEpNm.Parameters.AddWithValue("@OAppId", oAppId);
                    sqlCmdDpmtName.Parameters.AddWithValue("@OAppId", oAppId);
                    sqlCmdApproverEpNm.Parameters.AddWithValue("@OAppId", oAppId);
                    sqlCmdPublicHolidayYN.Parameters.AddWithValue("@OAppId", oAppId);
                    sqlCmdFromDate.Parameters.AddWithValue("@OAppId", oAppId);
                    sqlCmdToDate.Parameters.AddWithValue("@OAppId", oAppId);
                    sqlCmdReason.Parameters.AddWithValue("@OAppId", oAppId);
                    sqlCmdDecisionStatus.Parameters.AddWithValue("@OAppId", oAppId);

                    string RequesterEpNm = (string)sqlCmdRequesterEpNm.ExecuteScalar();
                    string DpmtName = (string)sqlCmdDpmtName.ExecuteScalar();
                    string ApproverEpNm = (string)sqlCmdApproverEpNm.ExecuteScalar();
                    Boolean PublicHolidayYN = (Boolean)sqlCmdPublicHolidayYN.ExecuteScalar();
                    DateTime FromDate = (DateTime)sqlCmdFromDate.ExecuteScalar();
                    DateTime ToDate = (DateTime)sqlCmdToDate.ExecuteScalar();
                    string Reason = (string)sqlCmdReason.ExecuteScalar();

                    string PublicHolidayYN_str = "";
                    if (PublicHolidayYN == true)
                    {
                        PublicHolidayYN_str = "Yes";
                    }
                    else if (PublicHolidayYN == false)
                    {
                        PublicHolidayYN_str = "No";
                    }
                    else
                    {
                        PublicHolidayYN_str = "N/A";
                    }

                    string DecisionStatus = "Undecided";

                    lblRequesterEpNmS.Text = RequesterEpNm;
                    lblDpmtNameS.Text = DpmtName;
                    lblApproverEpNmS.Text = ApproverEpNm;
                    lblPublicHolidayYNS.Text = PublicHolidayYN_str;
                    lblFromDateS.Text = FromDate.ToString();
                    lblToDateS.Text = ToDate.ToString();
                    lblReasonS.Text = Reason;
                    lblDecisionStatusS.Text = DecisionStatus;

                    sqlCon.Close();
                }
            }
        }
    }
}