using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR;
namespace HR_SYSTEM.views
{
    public partial class approveEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int employee_id = int.Parse(Request.QueryString["id"]);
            int check = Employee.approve(employee_id);

            Response.Redirect("Employees.aspx");
        }
    }
}