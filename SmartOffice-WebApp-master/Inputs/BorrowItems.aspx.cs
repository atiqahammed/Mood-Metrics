using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

namespace SmOffice.Inputs
{
    public partial class BorrowItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void frmdtlkbtn_Click(object sender, EventArgs e)
        {
            CalFrom.Visible = true;
        }

        protected void CalFrom_SelectionChanged(object sender, EventArgs e)
        {
            if (CalFrom.Visible)
                txtBAppStartDate.Text = CalFrom.SelectedDate.ToString();
        }

        protected void slctdttolkbtn_Click(object sender, EventArgs e)
        {
            CalTo.Visible = true;
        }

        protected void calTo_SelectionChanged(object sender, EventArgs e)
        {
            if (CalTo.Visible)
                txtBAppEndDate.Text = CalTo.SelectedDate.ToString();
        }

        protected void subbi_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SmartOffice_ConnectionString"].ConnectionString);

            con.Open();

            string query1 = "insert into BorrowItemsApproval (BAppTime,DpmtId,DpmtName,BAppItemId," +
                "BAppItem,BAppStartDate,BAppEndDate,BDetails,RequesterEpId,RequesterEpNm,ApproverEpId,ApproverEpNm)" + "values (@BAppTime, (Select DpmtId FROM Department WHERE DpmtName = @ddlDpmtName)," +
                "@ddlDpmtName,(Select ItemId FROM BorrowItemList WHERE ItemName = @ddlBAppItem),@ddlBAppItem,@txtBAppStartDate," +
                "@txtBAppEndDate,@txtBDetails,(SELECT EmpyId FROM Employee WHERE EmpyName = @ddlRequesterEpNm),@ddlRequesterEpNm,(SELECT EmpyId FROM Employee WHERE EmpyName = @ddlApproverEpNm),@ddlApproverEpNm)";

            SqlCommand cmd1 = new SqlCommand(query1, con);

            // Insert parameters
            cmd1.Parameters.AddWithValue("@BAppTime", DateTime.Now);
            cmd1.Parameters.AddWithValue("@ddlDpmtName", ddlDpmtName.SelectedValue);
            cmd1.Parameters.AddWithValue("@ddlBAppItem", ddlBAppItem.SelectedValue);
            cmd1.Parameters.AddWithValue("@txtBAppStartDate", txtBAppStartDate.Text);
            cmd1.Parameters.AddWithValue("@txtBAppEndDate", txtBAppEndDate.Text);
            cmd1.Parameters.AddWithValue("@txtBDetails", txtBDetails.Text);
            cmd1.Parameters.AddWithValue("@ddlRequesterEpNm", ddlRequesterEpNm.SelectedValue);
            cmd1.Parameters.AddWithValue("@ddlApproverEpNm", ddlApproverEpNm.SelectedValue);

            cmd1.ExecuteNonQuery();
            con.Close();

            Response.Redirect("~/Views/Info.aspx");
        }

        protected void rstbi_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Inputs/BorrowItems.aspx");
        }

        protected void CalFrom_DayRender(object sender, DayRenderEventArgs e)
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

        protected void CalTo_DayRender(object sender, DayRenderEventArgs e)
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
