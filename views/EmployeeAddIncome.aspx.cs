using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR;
namespace HR_SYSTEM.views
{
    public partial class EmployeeAddIncome : System.Web.UI.Page
    {
        Employee employee = new Employee();
        string per;
        protected void Page_Load(object sender, EventArgs e)
        {
            TypeDropDown.Items.Clear();
            TypeDropDown.Items.Add("Salary");

            if (!Page.IsPostBack) {
                paymentDropDown.Items.Clear();
                ListItem mItem = new ListItem("Monthly", "Monthly");
                ListItem aItem = new ListItem("Annually", "Annually");
                paymentDropDown.Items.Add(mItem);
                paymentDropDown.Items.Add(aItem);
            }



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
            float amount = float.Parse(amountTextBox.Text);
            string type = TypeDropDown.SelectedItem.Text;
            string per = paymentDropDown.SelectedValue;

            int check = Income.create(employee.Id, type, per, amount);

            if (check == 1)
            {
                header1.success("Income Added!");
            }
            else {
                header1.showAlert("Error");
            }
        }

        protected void paymentDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}