using SmOffice.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmOffice.Views
{
    public partial class DashBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button btnOvertime = new Button()
            {
                ID = "btnOvertime",
                Text = "Overtime"
            };

            btnOvertime.Click += new EventHandler(this.btnOvertime_Click);

            Button btnReport = new Button()
            {
                ID = "btnReport",
                Text = "Report"
            };

            btnReport.Click += new EventHandler(this.btnReport_Click);

            Button btnBorrowItems = new Button()
            {
                ID = "btnBorrowItems",
                Text = "Borrow Items"
            };

            btnBorrowItems.Click += new EventHandler(this.btnBorrowItems_Click);

            Button btnContract = new Button()
            {
                ID = "btnContract",
                Text = "Contract"
            };

            btnContract.Click += new EventHandler(this.btnContract_Click);

            Button btnPaidTimeOff = new Button()
            {
                ID = "btnPaidTimeOff",
                Text = "Paid Time Off"
            };

            btnPaidTimeOff.Click += new EventHandler(this.btnPaidTimeOff_Click);

            Button btnReimbursement = new Button()
            {
                ID = "btnReimbursement",
                Text = "Reimbursement"
            };

            btnReimbursement.Click += new EventHandler(this.btnReimbursement_Click);

        }

        protected void btnOvertime_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Inputs/Overtime.aspx");
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Inputs/Report.aspx");
        }

        protected void btnBorrowItems_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Inputs/BorrowItems.aspx");
        }

        protected void btnContract_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Inputs/Contract.aspx");
        }

        protected void btnPaidTimeOff_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Inputs/PaidTimeOff.aspx");
        }

        protected void btnReimbursement_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Inputs/Reimbursement.aspx");
        }
    }
}