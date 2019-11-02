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
    public partial class ReportUnread : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button btnSubmit = new Button()
            {
                ID = "btnSubmit",
                Text = "Submit"
            };

            btnSubmit.Click += new EventHandler(this.btnSubmit_Click);

            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            Uri myUri = new Uri(url);
            string logId = HttpUtility.ParseQueryString(myUri.Query).Get("LogId");
            int count = 0;
            while (count < 5)
            {
                logId = logId.Remove(logId.Length - 1, 1);
                count += 1;
            }

            if (!IsPostBack)
            {
                using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SmartOffice_ConnectionString"].ConnectionString))
                {
                    sqlCon.Open();

                    string queryLogType = "SELECT LogType FROM LogReport WHERE LogId = @LogId";
                    string queryComplete = "SELECT Complete FROM LogReport WHERE LogId = @LogId";
                    string queryIncomplete = "SELECT Incomplete FROM LogReport WHERE LogId = @LogId";
                    string queryPending = "SELECT Pending FROM LogReport WHERE LogId = @LogId";
                    string queryNextPlan = "SELECT NextPlan FROM LogReport WHERE LogId = @LogId";
                    string queryNote = "SELECT Note FROM LogReport WHERE LogId = @LogId";
                    string queryReporterEpNm = "SELECT ReporterEpNm FROM LogReport WHERE LogId = @LogId";
                    string queryRecipientEpNm = "SELECT RecipientEpNm FROM LogReport WHERE LogId = @LogId";

                    SqlCommand sqlCmdLogType = new SqlCommand(queryLogType, sqlCon);
                    SqlCommand sqlCmdComplete = new SqlCommand(queryComplete, sqlCon);
                    SqlCommand sqlCmdIncomplete = new SqlCommand(queryIncomplete, sqlCon);
                    SqlCommand sqlCmdPending = new SqlCommand(queryPending, sqlCon);
                    SqlCommand sqlCmdNextPlan = new SqlCommand(queryNextPlan, sqlCon);
                    SqlCommand sqlCmdNote = new SqlCommand(queryNote, sqlCon);
                    SqlCommand sqlCmdReporterEpNm = new SqlCommand(queryReporterEpNm, sqlCon);
                    SqlCommand sqlCmdRecipientEpNm = new SqlCommand(queryRecipientEpNm, sqlCon);

                    sqlCmdLogType.Parameters.AddWithValue("@LogId", logId);
                    sqlCmdComplete.Parameters.AddWithValue("@LogId", logId);
                    sqlCmdIncomplete.Parameters.AddWithValue("@LogId", logId);
                    sqlCmdPending.Parameters.AddWithValue("@LogId", logId);
                    sqlCmdNextPlan.Parameters.AddWithValue("@LogId", logId);
                    sqlCmdNote.Parameters.AddWithValue("@LogId", logId);
                    sqlCmdReporterEpNm.Parameters.AddWithValue("@LogId", logId);
                    sqlCmdRecipientEpNm.Parameters.AddWithValue("@LogId", logId);

                    string LogType = (string)sqlCmdLogType.ExecuteScalar();
                    string Complete = (string)sqlCmdComplete.ExecuteScalar();
                    string Incomplete = (string)sqlCmdIncomplete.ExecuteScalar();
                    string pending = (string)sqlCmdPending.ExecuteScalar();
                    string NextPlan = (string)sqlCmdNextPlan.ExecuteScalar();
                    string Note = (string)sqlCmdNote.ExecuteScalar();
                    string Reporter = (string)sqlCmdReporterEpNm.ExecuteScalar();
                    string Recipient = (string)sqlCmdRecipientEpNm.ExecuteScalar();

                    lblLogTypeC.Text = LogType;
                    lblCompleteC.Text = Complete;
                    lblIncompleteC.Text = Incomplete;
                    lblPendingC.Text = pending;
                    lblNextPlanC.Text = NextPlan;
                    lblNoteC.Text = Note;
                    lblReporterEpNmC.Text = Reporter;
                    lblRecipientEpNmC.Text = Recipient;

                    sqlCon.Close();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string rbtPublicHolidayYN = string.Empty;
            if (rbtnyes.Checked)
            {
                rbtPublicHolidayYN = "1";
            }
            else if (rbtnno.Checked)
            {
                rbtPublicHolidayYN = "0";
            }

            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            Uri myUri = new Uri(url);
            string logId = HttpUtility.ParseQueryString(myUri.Query).Get("LogId");
            int count = 0;
            while (count < 5)
            {
                logId = logId.Remove(logId.Length - 1, 1);
                count += 1;
            }

            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SmartOffice_ConnectionString"].ConnectionString))
            {
                sqlCon.Open();
                string query = "UPDATE LogReport SET Comments = @Comments, ReadStatus = @ReadStatus" +
                    " WHERE LogId = @LogId";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                sqlCmd.Parameters.AddWithValue("@Comments", txtComments.Text);
                sqlCmd.Parameters.AddWithValue("@ReadStatus", rbtPublicHolidayYN);
                sqlCmd.Parameters.AddWithValue("@LogId", logId);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();

                Response.Redirect("~/Views/Info.aspx");
            }
        }
    }
}