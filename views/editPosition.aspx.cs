using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR;
namespace HR_SYSTEM.views
{
    public partial class editPosition : System.Web.UI.Page
    {
        Position position;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get the id of the employee from the url and pass it to the employee object
            // Also we are saving the object in the class because we need to use it in all the moethds.
            try
            {
                int position_id = int.Parse(Request.QueryString["id"]);
                position = new Position(position_id);

                if (!Page.IsPostBack) {
                    TextBox1.Text = position.Name;
                    ArrayList departments = new ArrayList();
                    departments = Department.getALL();

                    foreach (Department d in departments) {
                        ListItem item = new ListItem(d.Name, d.ID.ToString());
                        DropDownList1.Items.Add(item);
                    }

                    // Make sure to show the department of the position as the selected value
                    DropDownList1.Items.FindByValue(position.Department.ID.ToString()).Selected = true;
                }
                    
            }
            catch (Exception exce)
            {
                Response.Redirect("departments.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = TextBox1.Text;
                int department_value = int.Parse(DropDownList1.SelectedItem.Value);

                int check = Position.update(position.ID, name, department_value);

                if (check == 1)
                {
                    Response.Redirect("positions.aspx");
                }
                else
                {
                    header1.showAlert("ERROR");
                }
            }
            catch (Exception ex) {
                header1.showAlert(ex.Message);
            }
        }
    }
}