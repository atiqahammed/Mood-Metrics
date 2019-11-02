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
    public partial class PaidTimeOff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LACalFrom_SelectionChanged1(object sender, EventArgs e)
        {
            if (LACalFrom.Visible)
                txtLAppStartTime.Text = LACalFrom.SelectedDate.ToString();
        }
        protected void LAselectfrmdtlkbtn_Click(object sender, EventArgs e)
        {
            LACalFrom.Visible = true;
        }

        protected void LACalTo_SelectionChanged(object sender, EventArgs e)
        {
            if (LACalTo.Visible)
                txtLAppEndTime.Text = LACalTo.SelectedDate.ToString();
        }
        protected void slctdttolkbtn_Click(object sender, EventArgs e)
        {
            LACalTo.Visible = true;
        }
        protected void subbi_Click1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SmartOffice_ConnectionString"].ConnectionString);

            con.Open();
            string query1 = "insert into LeavingApproval (LAppTime,DpmtId,DpmtName,LAppType," +
                "LDestination,LAppStartTime,LAppEndTime,LReason,RequesterEpId,RequesterEpNm,ApproverEpId,ApproverEpNm)" + "values (@LAppTime, (Select DpmtId FROM Department WHERE DpmtName = @ddlDpmtName)," +
                "@ddlDpmtName,@ddlLAppType,@txtLDestination,@txtLAppStratTime," +
                "@txtLAppEndTime,@txtLreason,(SELECT EmpyId FROM Employee WHERE EmpyName = @ddlRequesterEpNm),@ddlRequesterEpNm,(SELECT EmpyId FROM Employee WHERE EmpyName = @ddlApproverEpNm),@ddlApproverEpNm)";
            SqlCommand cmd1 = new SqlCommand(query1, con);

            // Insert parameters
            cmd1.Parameters.AddWithValue("@LAppTime", DateTime.Now);
            cmd1.Parameters.AddWithValue("@ddlDpmtName", ddlDpmtName.SelectedValue);
            cmd1.Parameters.AddWithValue("@ddlLAppType", ddlLAppType.SelectedValue);
            cmd1.Parameters.AddWithValue("@txtLDestination", txtLDestination.Text);
            cmd1.Parameters.AddWithValue("@txtLAppStratTime", txtLAppStartTime.Text);
            cmd1.Parameters.AddWithValue("@txtLAppEndTime", txtLAppEndTime.Text);
            cmd1.Parameters.AddWithValue("@txtLReason", txtLreason.Text);
            cmd1.Parameters.AddWithValue("@ddlRequesterEpNm", ddlRequesterEpNm.SelectedValue);
            cmd1.Parameters.AddWithValue("@ddlApproverEpNm", ddlApproverEpNm.SelectedValue);

            cmd1.ExecuteNonQuery();
            con.Close();

            Response.Redirect("~/Views/Info.aspx");
        }

        protected void rstbi_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Inputs/PaidTimeOff.aspx");
        }

        protected void LACalFrom_DayRender(object sender, DayRenderEventArgs e)
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

        protected void LACalTo_DayRender(object sender, DayRenderEventArgs e)
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