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
    public partial class Reimbursement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void subbi_Click1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SmartOffice_ConnectionString"].ConnectionString);

            con.Open();
            string query1 = "insert into ReimburseApproval (RAppTime,DpmtId,DpmtName," +
                "RAppAmount,RExpDetails,RequesterEpId,RequesterEpNm,ApproverEpId,ApproverEpNm)" + "values (@RAppTime, (Select DpmtId FROM Department WHERE DpmtName = @ddlDpmtName)," +
                "@ddlDpmtName,@txtRAppAmount,@txtRExpDetails," +
                "(SELECT EmpyId FROM Employee WHERE EmpyName = @ddlRequesterEpNm),@ddlRequesterEpNm,(SELECT EmpyId FROM Employee WHERE EmpyName = @ddlApproverEpNm),@ddlApproverEpNm)";
            SqlCommand cmd1 = new SqlCommand(query1, con);

            // Insert parameters
            cmd1.Parameters.AddWithValue("@RAppTime", DateTime.Now);
            cmd1.Parameters.AddWithValue("@ddlDpmtName", ddlDpmtName.SelectedValue);
            cmd1.Parameters.AddWithValue("@txtRAppAmount", txtRAppAmount.Text);
            cmd1.Parameters.AddWithValue("@txtRExpDetails", txtRExpDetails.Text);
            cmd1.Parameters.AddWithValue("@ddlRequesterEpNm", ddlRequesterEpNm.SelectedValue);
            cmd1.Parameters.AddWithValue("@ddlApproverEpNm", ddlApproverEpNm.SelectedValue);

            cmd1.ExecuteNonQuery();
            con.Close();

            Response.Redirect("~/Views/Info.aspx");
        }

        protected void rstbi_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Inputs/Reimbursement.aspx");
        }
    }
}