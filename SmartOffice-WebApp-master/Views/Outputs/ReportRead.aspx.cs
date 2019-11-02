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
    public partial class ReportRead : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

                    string queryLogTime = "SELECT LogTime FROM LogReport WHERE LogId = @LogId";
                    string queryLogType = "SELECT LogType FROM LogReport WHERE LogId = @LogId";
                    string queryComplete = "SELECT Complete FROM LogReport WHERE LogId = @LogId";
                    string queryIncomplete = "SELECT Incomplete FROM LogReport WHERE LogId = @LogId";
                    string queryPending = "SELECT Pending FROM LogReport WHERE LogId = @LogId";
                    string queryNextPlan = "SELECT NextPlan FROM LogReport WHERE LogId = @LogId";
                    string queryNote = "SELECT Note FROM LogReport WHERE LogId = @LogId";
                    string queryReporterEpNm = "SELECT ReporterEpNm FROM LogReport WHERE LogId = @LogId";
                    string queryRecipientEpNm = "SELECT RecipientEpNm FROM LogReport WHERE LogId = @LogId";
                    string queryComments = "SELECT Comments FROM LogReport WHERE LogId = @LogId";

                    SqlCommand sqlCmdLogTime = new SqlCommand(queryLogTime, sqlCon);
                    SqlCommand sqlCmdLogType = new SqlCommand(queryLogType, sqlCon);
                    SqlCommand sqlCmdComplete = new SqlCommand(queryComplete, sqlCon);
                    SqlCommand sqlCmdIncomplete = new SqlCommand(queryIncomplete, sqlCon);
                    SqlCommand sqlCmdPending = new SqlCommand(queryPending, sqlCon);
                    SqlCommand sqlCmdNextPlan = new SqlCommand(queryNextPlan, sqlCon);
                    SqlCommand sqlCmdNote = new SqlCommand(queryNote, sqlCon);
                    SqlCommand sqlCmdReporterEpNm = new SqlCommand(queryReporterEpNm, sqlCon);
                    SqlCommand sqlCmdRecipientEpNm = new SqlCommand(queryRecipientEpNm, sqlCon);
                    SqlCommand sqlCmdComments = new SqlCommand(queryComments, sqlCon);

                    sqlCmdLogTime.Parameters.AddWithValue("@LogId", logId);
                    sqlCmdLogType.Parameters.AddWithValue("@LogId", logId);
                    sqlCmdComplete.Parameters.AddWithValue("@LogId", logId);
                    sqlCmdIncomplete.Parameters.AddWithValue("@LogId", logId);
                    sqlCmdPending.Parameters.AddWithValue("@LogId", logId);
                    sqlCmdNextPlan.Parameters.AddWithValue("@LogId", logId);
                    sqlCmdNote.Parameters.AddWithValue("@LogId", logId);
                    sqlCmdReporterEpNm.Parameters.AddWithValue("@LogId", logId);
                    sqlCmdRecipientEpNm.Parameters.AddWithValue("@LogId", logId);
                    sqlCmdComments.Parameters.AddWithValue("@LogId", logId);

                    sqlCmdLogTime.ExecuteNonQuery();
                    string LogType = (string)sqlCmdLogType.ExecuteScalar();
                    string Complete = (string)sqlCmdComplete.ExecuteScalar();
                    string Incomplete = (string)sqlCmdIncomplete.ExecuteScalar();
                    string pending = (string)sqlCmdPending.ExecuteScalar();
                    string NextPlan = (string)sqlCmdNextPlan.ExecuteScalar();
                    string Note = (string)sqlCmdNote.ExecuteScalar();
                    string Reporter = (string)sqlCmdReporterEpNm.ExecuteScalar();
                    string Recipient = (string)sqlCmdRecipientEpNm.ExecuteScalar();
                    string Comments = (string)sqlCmdComments.ExecuteScalar();

                    lblLogTypeS.Text = LogType;
                    lblCompleteS.Text = Complete;
                    lblIncompleteS.Text = Incomplete;
                    lblPendingS.Text = pending;
                    lblNextPlanS.Text = NextPlan;
                    lblNoteS.Text = Note;
                    lblReporterEpNmS.Text = Reporter;
                    lblRecipientEpNmS.Text = Recipient;
                    lblCommentsS.Text = Comments;

                    sqlCon.Close();
                }
            }
        }
    }
}