using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR;
namespace HR_SYSTEM.views
{
    public partial class EmployeeAddDocument : System.Web.UI.Page
    {
        Employee employee = new Employee();
        protected void Page_Load(object sender, EventArgs e)
        {
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
            // THIS can not work during the devolpment stage.
            try
            {
                string name = nameTextBox.Text;
                string path = FileUpload1.FileName;
                FileUpload1.SaveAs("C:\\upload\\" + FileUpload1.FileName.ToString());
                int size = FileUpload1.PostedFile.ContentLength;
                string note = "";
                int check = Document.create(employee.Id, name, path, size, note);
                if (check == 1)
                {
                    header2.success("Document Added");
                }
                else {
                    header2.showAlert("Something went WRong!");
                }
            }
            catch (Exception ex) {
                header2.showAlert(ex.Message);
            }
            
        }
    }
}