using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR;
namespace HR_SYSTEM.views
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EmployeesCollection collection = new EmployeesCollection();
            Label1.Text = collection.getCountOfEmployees().ToString();

            Label2.Text = "$" + EmployeesIncome.getALLMontly().ToString();
            Label3.Text = "$" + EmployeesIncome.getALLAn().ToString();
        }
    }
}