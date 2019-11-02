using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace SmOffice.Inputs
{
    public partial class Contract : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void frmdtlkbtn_Click(object sender, EventArgs e)
        {
            CalSignDate.Visible = true;
        }

        protected void CalSignDate_SelectionChanged(object sender, EventArgs e)
        {
            if (CalSignDate.Visible)
                txtSignDate.Text = CalSignDate.SelectedDate.ToString();
        }

        protected void subbi_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SmartOffice_ConnectionString"].ConnectionString);

            con.Open();

            string query1 = "INSERT INTO ContractApproval (CAppTime,DpmtId,DpmtName,CAppSignDate," +
                "MyPartyName,MyPartyEpId,MyPartyEpNm,OppPartyName,OppPartyEpNm,CAppContent,RequesterEpId,RequesterEpNm,ApproverEpId,ApproverEpNm)" + "VALUES (@CAppTime,(Select DpmtId FROM Department WHERE DpmtName = @DpmtName)," +
                "@DpmtName,@CAppSignDate,@MyPartyName,(Select EmpyId FROM Employee WHERE EmpyName = @MyPartyEpNm),@MyPartyEpNm,@OppPartyName,@OppPartyEpNm,@CAppContent," +
                "(SELECT EmpyId FROM Employee WHERE EmpyName = @RequesterEpNm),@RequesterEpNm,(SELECT EmpyId FROM Employee WHERE EmpyName = @ApproverEpNm),@ApproverEpNm)";

            SqlCommand cmd1 = new SqlCommand(query1, con);

            // Insert parameters
            cmd1.Parameters.AddWithValue("@CAppTime", DateTime.Now);
            cmd1.Parameters.AddWithValue("@DpmtName", ddlDpmtName.SelectedValue);
            cmd1.Parameters.AddWithValue("@CAppSignDate", txtSignDate.Text);
            cmd1.Parameters.AddWithValue("@MyPartyName", txtMyPartyName.Text);
            cmd1.Parameters.AddWithValue("@MyPartyEpNm", ddlMyPartyEpNm.SelectedValue);
            cmd1.Parameters.AddWithValue("@OppPartyName", txtOppPartyName.Text);
            cmd1.Parameters.AddWithValue("@OppPartyEpNm", txtOppPartyEpNm.Text);
            cmd1.Parameters.AddWithValue("@CAppContent", txtContent.Text);
            cmd1.Parameters.AddWithValue("@RequesterEpNm", ddlRequesterEpNm.SelectedValue);
            cmd1.Parameters.AddWithValue("@ApproverEpNm", ddlApproverEpNm.SelectedValue);

            cmd1.ExecuteNonQuery();
            con.Close();

            Response.Redirect("~/Views/Info.aspx");
        }

        protected void rstbi_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Inputs/Contract.aspx");
        }

        protected void CalSignDate_DayRender(object sender, DayRenderEventArgs e)
        {
            DateTime pastday = e.Day.Date;
            DateTime date = DateTime.Now;
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;
            DateTime today = new DateTime(year, month, day);
            if (pastday.CompareTo(today) < 0)
            {
                e.Cell.BackColor = System.Drawing.Color.Gray;
                e.Day.IsSelectable = false;
            }
        }
    }
}