using SmOffice.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SmOffice.Views
{
    public partial class ApprovalRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string constr = ConfigurationManager.ConnectionStrings["SmartOffice_ConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT [OAppId],[OAppTime] FROM [OvertimeApproval] WHERE [ApproverEpNm] = (SELECT EmpyName FROM Employee WHERE EmpyEmail = '" + Session["EmpyEmail"].ToString() + "')AND ([DecisionStatus] = 1 OR [DecisionStatus] = 0)", con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            RepeaterOvertimeRead.DataSource = dt;
                            RepeaterOvertimeRead.DataBind();
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand("SELECT [OAppId],[OAppTime] [OAppTime]FROM [OvertimeApproval] WHERE [ApproverEpNm] = (SELECT EmpyName FROM Employee WHERE EmpyEmail = '" + Session["EmpyEmail"].ToString() + "') AND [DecisionStatus] is null", con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            RepeaterOvertimeUnread.DataSource = dt;
                            RepeaterOvertimeUnread.DataBind();
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand("SELECT [LogId],[LogTime] FROM [LogReport] WHERE [RecipientEpNm] = (SELECT EmpyName FROM Employee WHERE EmpyEmail = '" + Session["EmpyEmail"].ToString() + "') AND ([ReadStatus] =1 OR [ReadStatus] = 0)", con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            RepeaterReportRead.DataSource = dt;
                            RepeaterReportRead.DataBind();
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand("SELECT [LogId],[LogTime] FROM [LogReport] WHERE [RecipientEpNm] = (SELECT EmpyName FROM Employee WHERE EmpyEmail = '" + Session["EmpyEmail"].ToString() + "') AND [ReadStatus] is null", con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            RepeaterReportUnread.DataSource = dt;
                            RepeaterReportUnread.DataBind();
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand("SELECT [BAppId],[BAppTime] FROM [BorrowItemsApproval] WHERE [ApproverEpNm] = (SELECT EmpyName FROM Employee WHERE EmpyEmail = '" + Session["EmpyEmail"].ToString() + "') AND ([DecisionStatus] = 1 OR [DecisionStatus] = 0)", con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            RepeaterBorrowItemsRead.DataSource = dt;
                            RepeaterBorrowItemsRead.DataBind();
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand("SELECT [BAppId],[BAppTime] FROM [BorrowItemsApproval] WHERE [ApproverEpNm] = (SELECT EmpyName FROM Employee WHERE EmpyEmail = '" + Session["EmpyEmail"].ToString() + "') AND [DecisionStatus] is null", con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            RepeaterBorrowItemsUnread.DataSource = dt;
                            RepeaterBorrowItemsUnread.DataBind();
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand("SELECT [CAppId],[CAppTime] FROM [ContractApproval] WHERE [ApproverEpNm] = (SELECT EmpyName FROM Employee WHERE EmpyEmail = '" + Session["EmpyEmail"].ToString() + "') AND ([DecisionStatus] = 1 OR [DecisionStatus] = 0)", con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            RepeaterContractRead.DataSource = dt;
                            RepeaterContractRead.DataBind();
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand("SELECT [CAppId],[CAppTime] FROM [ContractApproval] WHERE [ApproverEpNm] = (SELECT EmpyName FROM Employee WHERE EmpyEmail = '" + Session["EmpyEmail"].ToString() + "') AND [DecisionStatus] is null", con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            RepeaterContractUnread.DataSource = dt;
                            RepeaterContractUnread.DataBind();
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand("SELECT [LAppId],[LAppTime] FROM [LeavingApproval] WHERE [ApproverEpNm] = (SELECT EmpyName FROM Employee WHERE EmpyEmail = '" + Session["EmpyEmail"].ToString() + "') AND ([DecisionStatus] = 1 OR [DecisionStatus] = 0)", con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            RepeaterPaidTimeOffRead.DataSource = dt;
                            RepeaterPaidTimeOffRead.DataBind();
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand("SELECT [LAppId],[LAppTime] FROM [LeavingApproval] WHERE [ApproverEpNm] = (SELECT EmpyName FROM Employee WHERE EmpyEmail = '" + Session["EmpyEmail"].ToString() + "') AND [DecisionStatus] is null", con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            RepeaterPaidTimeOffUnread.DataSource = dt;
                            RepeaterPaidTimeOffUnread.DataBind();
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand("SELECT [RAppId],[RAppTime] FROM [ReimburseApproval] WHERE [ApproverEpNm] = (SELECT EmpyName FROM Employee WHERE EmpyEmail = '" + Session["EmpyEmail"].ToString() + "') AND ([DecisionStatus] = 1 OR [DecisionStatus] = 0)", con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            RepeaterReimbursementRead.DataSource = dt;
                            RepeaterReimbursementRead.DataBind();
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand("SELECT [RAppId],[RAppTime] FROM [ReimburseApproval] WHERE [ApproverEpNm] = (SELECT EmpyName FROM Employee WHERE EmpyEmail = '" + Session["EmpyEmail"].ToString() + "') AND [DecisionStatus] is null", con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            RepeaterReimbursementUnread.DataSource = dt;
                            RepeaterReimbursementUnread.DataBind();
                        }
                    }
                }
            }
        }
    }
}