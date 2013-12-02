using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR;
namespace HR_SYSTEM.views
{
    public partial class EmployeeAddRecord : System.Web.UI.Page
    {
        Employee employee = new Employee();
        protected void Page_Load(object sender, EventArgs e)
        {
            TypeDropDown.Items.Clear();
            TypeDropDown.Items.Add("Driving Licence");
            TypeDropDown.Items.Add("ID");
            TypeDropDown.Items.Add("Passport");
            TypeDropDown.Items.Add("Medical Insurance Card");

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
            int number = int.Parse(NumberTextBox.Text.ToString());
            DateTime issueDate = DateTime.Parse(IssueDateText.Text);
            DateTime expireDate = DateTime.Parse(ExpireDateText.Text);
            string type = TypeDropDown.SelectedItem.Text;
            string note = NotesTextBox.Text;
            int check = Record.create(employee.Id, number, issueDate, expireDate, type, note);

            if (check == 1)
            {
                header1.success("Record Created!");
            }
            else {
                header1.showAlert("Something went wrong!");
            }
        }
    }
}