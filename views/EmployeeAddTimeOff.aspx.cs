using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR;
namespace HR_SYSTEM.views
{
    public partial class EmployeeAddTimeOff : System.Web.UI.Page
    {
        Employee employee = new Employee();
        protected void Page_Load(object sender, EventArgs e)
        {
            TypeDropDown.Items.Clear();
            TypeDropDown.Items.Add("Vacation");

            // Get the id of the employee from the url and pass it to the employee object
            // Also we are saving the object in the class because we need to use it in all the moethds.
            try
            {
                this.employee.findById(int.Parse(Request.QueryString["id"]));
            }
            catch (Exception exce)
            {
                Response.Redirect("Employees.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            DateTime startDate = DateTime.Parse(StartText.Text);
            DateTime endDate = DateTime.Parse(EndDateText.Text);
            int paid = int.Parse(PaidText.Text.ToString());
            string type = TypeDropDown.SelectedItem.Text;
            int check = TimeOff.create(employee.Id, startDate, endDate, paid, type);

            if (check == 1)
            {
                header1.success("Time-Off Created!");
            }
            else
            {
                header1.showAlert("Something went wrong!");
            }
        }
    }
}