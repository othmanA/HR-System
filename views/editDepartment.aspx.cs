using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR;
namespace HR_SYSTEM.views
{
    public partial class editDepartment : System.Web.UI.Page
    {
        Department department;
        int department_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get the id of the employee from the url and pass it to the employee object
            // Also we are saving the object in the class because we need to use it in all the moethds.
            try
            {
                    department_id = int.Parse(Request.QueryString["id"]);
                    this.department = new Department(department_id);
                    
                    if(!Page.IsPostBack)
                        TextBox1.Text = department.Name;
            }
            catch (Exception exce)
            {
                Response.Redirect("departments.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            int check = Department.updateName(department_id,TextBox1.Text);
            if (check == 1)
            {
                Response.Redirect("departments.aspx");
            }
            else {
                header1.showAlert("Something went wrong!");
            }
        }
    }
}