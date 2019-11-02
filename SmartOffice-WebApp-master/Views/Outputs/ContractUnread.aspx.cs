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
    public partial class ContractUnread : System.Web.UI.Page
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
            string cAppId = HttpUtility.ParseQueryString(myUri.Query).Get("CAppId");
            int count = 0;
            while (count < 5)
            {
                cAppId = cAppId.Remove(cAppId.Length - 1, 1);
                count += 1;
            }

            if (!IsPostBack)
            {
                using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SmartOffice_ConnectionString"].ConnectionString))
                {
                    sqlCon.Open();

                    string queryDpmtName = "SELECT DpmtName FROM ContractApproval WHERE CAppId = @CAppId";
                    string querySignDate = "SELECT CAppSignDate FROM ContractApproval WHERE CAppId = @CAppId";
                    string queryMyPartyName = "SELECT MyPartyName FROM ContractApproval WHERE CAppId = @CAppId";
                    string queryMyPartyEpNm = "SELECT MyPartyEpNm FROM ContractApproval WHERE CAppId = @CAppId";
                    string queryOppPartyName = "SELECT OppPartyName FROM ContractApproval WHERE CAppId = @CAppId";
                    string queryOppPartyEpNm = "SELECT OppPartyEpNm FROM ContractApproval WHERE CAppId = @CAppId";
                    string queryCAppContent = "SELECT CAppContent FROM ContractApproval WHERE CAppId = @CAppId";
                    string queryRequesterEpNm = "SELECT RequesterEpNm FROM ContractApproval WHERE CAppId = @CAppId";
                    string queryApproverEpNm = "SELECT ApproverEpNm FROM ContractApproval WHERE CAppId = @CAppId";

                    SqlCommand sqlCmdDpmtName = new SqlCommand(queryDpmtName, sqlCon);
                    SqlCommand sqlCmdSignDate = new SqlCommand(querySignDate, sqlCon);
                    SqlCommand sqlCmdMyPartyName = new SqlCommand(queryMyPartyName, sqlCon);
                    SqlCommand sqlCmdMyPartyEpNm = new SqlCommand(queryMyPartyEpNm, sqlCon);
                    SqlCommand sqlCmdOppPartyName = new SqlCommand(queryOppPartyName, sqlCon);
                    SqlCommand sqlCmdOppPartyEpNm = new SqlCommand(queryOppPartyEpNm, sqlCon);
                    SqlCommand sqlCmdCAppContent = new SqlCommand(queryCAppContent, sqlCon);
                    SqlCommand sqlCmdRequesterEpNm = new SqlCommand(queryRequesterEpNm, sqlCon);
                    SqlCommand sqlCmdApproverEpNm = new SqlCommand(queryApproverEpNm, sqlCon);

                    sqlCmdDpmtName.Parameters.AddWithValue("@CAppId", cAppId);
                    sqlCmdSignDate.Parameters.AddWithValue("@CAppId", cAppId);
                    sqlCmdMyPartyName.Parameters.AddWithValue("@CAppId", cAppId);
                    sqlCmdMyPartyEpNm.Parameters.AddWithValue("@CAppId", cAppId);
                    sqlCmdOppPartyName.Parameters.AddWithValue("@CAppId", cAppId);
                    sqlCmdOppPartyEpNm.Parameters.AddWithValue("@CAppId", cAppId);
                    sqlCmdCAppContent.Parameters.AddWithValue("@CAppId", cAppId);
                    sqlCmdRequesterEpNm.Parameters.AddWithValue("@CAppId", cAppId);
                    sqlCmdApproverEpNm.Parameters.AddWithValue("@CAppId", cAppId);

                    string DpmtName = (string)sqlCmdDpmtName.ExecuteScalar();
                    DateTime SignDate = (DateTime)sqlCmdSignDate.ExecuteScalar();
                    string MyPartyName = (string)sqlCmdMyPartyName.ExecuteScalar();
                    string MyPartyEpNm = (string)sqlCmdMyPartyEpNm.ExecuteScalar();
                    string OppPartyName = (string)sqlCmdOppPartyName.ExecuteScalar();
                    string OppPartyEpNm = (string)sqlCmdOppPartyEpNm.ExecuteScalar();
                    string CAppContent = (string)sqlCmdCAppContent.ExecuteScalar();
                    string RequesterEpNm = (string)sqlCmdRequesterEpNm.ExecuteScalar();
                    string ApproverEpNm = (string)sqlCmdApproverEpNm.ExecuteScalar();

                    lblDpmtNameC.Text = DpmtName;
                    lblSignDateC.Text = SignDate.ToString();
                    lblMyPartyNameC.Text = MyPartyName;
                    lblMyPartyEpNmC.Text = MyPartyEpNm;
                    lblOppPartyNameC.Text = OppPartyName;
                    lblOppPartyEpNmC.Text = OppPartyEpNm;
                    lblContentC.Text = CAppContent;
                    lblRequesterEpNmC.Text = RequesterEpNm;
                    lblApproverEpNmC.Text = ApproverEpNm;

                    sqlCon.Close();
                }
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            string DecisionStatus = "1";

            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            Uri myUri = new Uri(url);
            string cAppId = HttpUtility.ParseQueryString(myUri.Query).Get("CAppId");
            int count = 0;
            while (count < 5)
            {
                cAppId = cAppId.Remove(cAppId.Length - 1, 1);
                count += 1;
            }

            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SmartOffice_ConnectionString"].ConnectionString))
            {
                sqlCon.Open();
                string query = "UPDATE ContractApproval SET DecisionStatus = @DecisionStatus" +
                    " WHERE CAppId = @CAppId";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                sqlCmd.Parameters.AddWithValue("@DecisionStatus", DecisionStatus);
                sqlCmd.Parameters.AddWithValue("@CAppId", cAppId);

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
            string cAppId = HttpUtility.ParseQueryString(myUri.Query).Get("CAppId");
            int count = 0;
            while (count < 5)
            {
                cAppId = cAppId.Remove(cAppId.Length - 1, 1);
                count += 1;
            }

            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SmartOffice_ConnectionString"].ConnectionString))
            {
                sqlCon.Open();
                string query = "UPDATE ContractApproval SET DecisionStatus = @DecisionStatus" +
                    " WHERE CAppId = @CAppId";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                sqlCmd.Parameters.AddWithValue("@DecisionStatus", DecisionStatus);
                sqlCmd.Parameters.AddWithValue("@CAppId", cAppId);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();

                Response.Redirect("~/Views/Info.aspx");
            }
        }
    }
}