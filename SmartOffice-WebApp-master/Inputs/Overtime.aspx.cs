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
    public partial class Overtime : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OTselectfrmdtlkbtn_Click(object sender, EventArgs e)
        {
            OTCalFrom.Visible = true;
        }

        protected void OTCalFrom_SelectionChanged(object sender, EventArgs e)
        {
            if (OTCalFrom.Visible)
                txtOAppStartTime.Text = OTCalFrom.SelectedDate.ToString();
        }

        protected void OTselectTodtlkbtn_Click(object sender, EventArgs e)
        {
            OTCalTo.Visible = true;
        }

        protected void OTCalTo_SelectionChanged(object sender, EventArgs e)
        {
            if (OTCalTo.Visible)
                txtOAppEndTime.Text = OTCalTo.SelectedDate.ToString();
        }

        protected void subbi_Click(object sender, EventArgs e)
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

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SmartOffice_ConnectionString"].ConnectionString);

            con.Open();
            string query1 = "insert into OvertimeApproval (OAppTime,DpmtId,DpmtName,PublicHolidayYN," +
                "OAppStartTime,OAppEndTime,OReason,RequesterEpId,RequesterEpNm,ApproverEpId,ApproverEpNm)" + "values (@OAppTime, (Select DpmtId FROM Department WHERE DpmtName = @ddlDpmtName)," +
                "@ddlDpmtName,@rbtPublicHolidayYN,@txtOAppStratTime," +
                "@txtOAppEndTime,@txtOReason,(SELECT EmpyId FROM Employee WHERE EmpyName = @ddlRequesterEpNm),@ddlRequesterEpNm,(SELECT EmpyId FROM Employee WHERE EmpyName = @ddlApproverEpNm),@ddlApproverEpNm)";
            SqlCommand cmd1 = new SqlCommand(query1, con);

            // Insert parameters
            cmd1.Parameters.AddWithValue("@OAppTime", DateTime.Now);
            cmd1.Parameters.AddWithValue("@ddlDpmtName", ddlDpmtName.SelectedValue);
            cmd1.Parameters.AddWithValue("@txtOAppStratTime", txtOAppStartTime.Text);
            cmd1.Parameters.AddWithValue("@rbtPublicHolidayYN", rbtPublicHolidayYN);
            cmd1.Parameters.AddWithValue("@txtOAppEndTime", txtOAppEndTime.Text);
            cmd1.Parameters.AddWithValue("@txtOReason", txtOReason.Text);
            cmd1.Parameters.AddWithValue("@ddlRequesterEpNm", ddlRequesterEpNm.SelectedValue);
            cmd1.Parameters.AddWithValue("@ddlApproverEpNm", ddlApproverEpNm.SelectedValue);

            cmd1.ExecuteNonQuery();
            con.Close();

            Response.Redirect("~/Views/Info.aspx");
        }

        protected void rstbi_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Inputs/Overtime.aspx");
        }

        protected void OTCalFrom_DayRender(object sender, DayRenderEventArgs e)
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

        protected void OTCalTo_DayRender(object sender, DayRenderEventArgs e)
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