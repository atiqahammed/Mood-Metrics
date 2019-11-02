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
    public partial class BorrowItemsUnreadS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            Uri myUri = new Uri(url);
            string bAppId = HttpUtility.ParseQueryString(myUri.Query).Get("BAppId");
            int count = 0;
            while (count < 5)
            {
                bAppId = bAppId.Remove(bAppId.Length - 1, 1);
                count += 1;
            }

            if (!IsPostBack)
            {
                using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SmartOffice_ConnectionString"].ConnectionString))
                {
                    sqlCon.Open();

                    string queryRequesterEpNm = "SELECT RequesterEpNm FROM BorrowItemsApproval WHERE BAppId = @BAppId";
                    string queryDpmtName = "SELECT DpmtName FROM BorrowItemsApproval WHERE BAppId = @BAppId";
                    string queryApproverEpNm = "SELECT ApproverEpNm FROM BorrowItemsApproval WHERE BAppId = @BAppId";
                    string queryItem = "SELECT BAppItem FROM BorrowItemsApproval WHERE BAppId = @BAppId";
                    string queryFromDate = "SELECT BAppStartDate FROM BorrowItemsApproval WHERE BAppId = @BAppId";
                    string queryToDate = "SELECT BAppEndDate FROM BorrowItemsApproval WHERE BAppId = @BAppId";
                    string queryDetails = "SELECT BDetails FROM BorrowItemsApproval WHERE BAppId = @BAppId";
                    string queryDecisionStatus = "SELECT DecisionStatus FROM BorrowItemsApproval WHERE BAppId = @BAppId";

                    SqlCommand sqlCmdRequesterEpNm = new SqlCommand(queryRequesterEpNm, sqlCon);
                    SqlCommand sqlCmdDpmtName = new SqlCommand(queryDpmtName, sqlCon);
                    SqlCommand sqlCmdApproverEpNm = new SqlCommand(queryApproverEpNm, sqlCon);
                    SqlCommand sqlCmdItem = new SqlCommand(queryItem, sqlCon);
                    SqlCommand sqlCmdFromDate = new SqlCommand(queryFromDate, sqlCon);
                    SqlCommand sqlCmdToDate = new SqlCommand(queryToDate, sqlCon);
                    SqlCommand sqlCmdDetails = new SqlCommand(queryDetails, sqlCon);
                    SqlCommand sqlCmdDecisionStatus = new SqlCommand(queryDecisionStatus, sqlCon);

                    sqlCmdRequesterEpNm.Parameters.AddWithValue("@BAppId", bAppId);
                    sqlCmdDpmtName.Parameters.AddWithValue("@BAppId", bAppId);
                    sqlCmdApproverEpNm.Parameters.AddWithValue("@BAppId", bAppId);
                    sqlCmdItem.Parameters.AddWithValue("@BAppId", bAppId);
                    sqlCmdFromDate.Parameters.AddWithValue("@BAppId", bAppId);
                    sqlCmdToDate.Parameters.AddWithValue("@BAppId", bAppId);
                    sqlCmdDetails.Parameters.AddWithValue("@BAppId", bAppId);
                    sqlCmdDecisionStatus.Parameters.AddWithValue("@BAppId", bAppId);

                    string RequesterEpNm = (string)sqlCmdRequesterEpNm.ExecuteScalar();
                    string DpmtName = (string)sqlCmdDpmtName.ExecuteScalar();
                    string ApproverEpNm = (string)sqlCmdApproverEpNm.ExecuteScalar();
                    string Item = (string)sqlCmdItem.ExecuteScalar();
                    DateTime FromDate = (DateTime)sqlCmdFromDate.ExecuteScalar();
                    DateTime ToDate = (DateTime)sqlCmdToDate.ExecuteScalar();
                    string Details = (string)sqlCmdDetails.ExecuteScalar();
                    string DecisionStatus = "Undecided";

                    lblRequesterEpNmS.Text = RequesterEpNm;
                    lblDpmtNameS.Text = DpmtName;
                    lblApproverEpNmS.Text = ApproverEpNm;
                    lblItemS.Text = Item;
                    lblFromDateS.Text = FromDate.ToString();
                    lblToDateS.Text = ToDate.ToString();
                    lblDetailsS.Text = Details;
                    lblDecisionStatusS.Text = DecisionStatus;

                    sqlCon.Close();
                }
            }
        }
    }
}