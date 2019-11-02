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
    public partial class BorrowItemsUnread : System.Web.UI.Page
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

                    SqlCommand sqlCmdRequesterEpNm = new SqlCommand(queryRequesterEpNm, sqlCon);
                    SqlCommand sqlCmdDpmtName = new SqlCommand(queryDpmtName, sqlCon);
                    SqlCommand sqlCmdApproverEpNm = new SqlCommand(queryApproverEpNm, sqlCon);
                    SqlCommand sqlCmdItem = new SqlCommand(queryItem, sqlCon);
                    SqlCommand sqlCmdFromDate = new SqlCommand(queryFromDate, sqlCon);
                    SqlCommand sqlCmdToDate = new SqlCommand(queryToDate, sqlCon);
                    SqlCommand sqlCmdDetails = new SqlCommand(queryDetails, sqlCon);

                    sqlCmdRequesterEpNm.Parameters.AddWithValue("@BAppId", bAppId);
                    sqlCmdDpmtName.Parameters.AddWithValue("@BAppId", bAppId);
                    sqlCmdApproverEpNm.Parameters.AddWithValue("@BAppId", bAppId);
                    sqlCmdItem.Parameters.AddWithValue("@BAppId", bAppId);
                    sqlCmdFromDate.Parameters.AddWithValue("@BAppId", bAppId);
                    sqlCmdToDate.Parameters.AddWithValue("@BAppId", bAppId);
                    sqlCmdDetails.Parameters.AddWithValue("@BAppId", bAppId);

                    string RequesterEpNm = (string)sqlCmdRequesterEpNm.ExecuteScalar();
                    string DpmtName = (string)sqlCmdDpmtName.ExecuteScalar();
                    string ApproverEpNm = (string)sqlCmdApproverEpNm.ExecuteScalar();
                    string Item = (string)sqlCmdItem.ExecuteScalar();
                    DateTime FromDate = (DateTime)sqlCmdFromDate.ExecuteScalar();
                    DateTime ToDate = (DateTime)sqlCmdToDate.ExecuteScalar();
                    string Details = (string)sqlCmdDetails.ExecuteScalar();

                    lblRequesterEpNmC.Text = RequesterEpNm;
                    lblDpmtNameC.Text = DpmtName;
                    lblApproverEpNmC.Text = ApproverEpNm;
                    lblItemC.Text = Item;
                    lblFromDateC.Text = FromDate.ToString();
                    lblToDateC.Text = ToDate.ToString();
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
            string bAppId = HttpUtility.ParseQueryString(myUri.Query).Get("BAppId");
            int count = 0;
            while (count < 5)
            {
                bAppId = bAppId.Remove(bAppId.Length - 1, 1);
                count += 1;
            }

            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SmartOffice_ConnectionString"].ConnectionString))
            {
                sqlCon.Open();
                string query = "UPDATE BorrowItemsApproval SET DecisionStatus = @DecisionStatus" +
                    " WHERE BAppId = @BAppId";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                sqlCmd.Parameters.AddWithValue("@DecisionStatus", DecisionStatus);
                sqlCmd.Parameters.AddWithValue("@BAppId", bAppId);

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
            string bAppId = HttpUtility.ParseQueryString(myUri.Query).Get("BAppId");
            int count = 0;
            while (count < 5)
            {
                bAppId = bAppId.Remove(bAppId.Length - 1, 1);
                count += 1;
            }

            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SmartOffice_ConnectionString"].ConnectionString))
            {
                sqlCon.Open();
                string query = "UPDATE BorrowItemsApproval SET DecisionStatus = @DecisionStatus" +
                    " WHERE BAppId = @BAppId";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                sqlCmd.Parameters.AddWithValue("@DecisionStatus", DecisionStatus);
                sqlCmd.Parameters.AddWithValue("@BAppId", bAppId);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();

                Response.Redirect("~/Views/Info.aspx");
            }
        }
    }
}