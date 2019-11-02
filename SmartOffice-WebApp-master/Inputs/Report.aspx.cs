using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace SmOffice.Inputs
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button btnSubmit = new Button()
            {
                ID = "btnSubmit",
                Text = "Submit"
            };

            btnSubmit.Click += new EventHandler(this.btnSubmit_Click);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["SmartOffice_ConnectionString"].ConnectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO LogReport (LogTime,LogType,Complete,Incomplete,Pending,NextPlan,Note,ReporterEpId,ReporterEpNm,RecipientEpId,RecipientEpNm)" +
                    "VALUES (@LogTime,@LogType,@Complete,@Incomplete,@Pending,@NextPlan,@Note,(SELECT EmpyId FROM Employee WHERE EmpyName = @ReporterEpNm),@ReporterEpNm,(SELECT EmpyId FROM Employee WHERE EmpyName = @RecipientEpNm),@RecipientEpNm)";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                sqlCmd.Parameters.AddWithValue("@LogTime", DateTime.Now);
                sqlCmd.Parameters.AddWithValue("@LogType", txtLogType.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Complete", txtComplete.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Incomplete", txtIncomplete.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Pending", txtPending.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@NextPlan", txtNextPlan.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Note", txtNote.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@ReporterEpNm", ddlReporterEpNm.SelectedValue);
                sqlCmd.Parameters.AddWithValue("@RecipientEpNm", ddlRecipientEpNm.SelectedValue);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();

                Response.Redirect("~/Views/Info.aspx");

            }
        }

        protected void rstbi_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Inputs/Report.aspx");
        }
    }
}