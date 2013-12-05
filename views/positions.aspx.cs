using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR;
namespace HR_SYSTEM.views
{
    public partial class positions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ArrayList departments = new ArrayList();
            departments = Department.getALL();

            foreach (Department d in departments) { 
                ListItem item = new ListItem(d.Name,d.ID.ToString());
                DropDownList1.Items.Add(item);
            }


            // Get all the positions 
            ArrayList positions = new ArrayList();
            positions = Position.getALL();


            TableHeaderCell positionIdHeader = new TableHeaderCell();
            TableHeaderCell positionNameHeader = new TableHeaderCell();
            TableHeaderCell positionDepHeader = new TableHeaderCell();
            TableHeaderCell positionCountEmployeesHeader = new TableHeaderCell();
            TableHeaderCell positionEditHeader = new TableHeaderCell();
            TableHeaderCell positionDeleteHeader = new TableHeaderCell();

            positionIdHeader.Text = "ID#".ToUpper();
            positionNameHeader.Text = "Name".ToUpper();
            positionDepHeader.Text = "Department".ToUpper();
            positionEditHeader.Text = "Edit".ToUpper();
            positionDeleteHeader.Text = "delete".ToUpper();
            positionCountEmployeesHeader.Text = "Number Of Employees".ToUpper();


            TableRow header = new TableRow();

            header.Cells.Add(positionIdHeader);
            header.Cells.Add(positionNameHeader);
            header.Cells.Add(positionDepHeader);
            header.Cells.Add(positionCountEmployeesHeader);
            header.Cells.Add(positionEditHeader);
            header.Cells.Add(positionDeleteHeader);

            Table1.Rows.Add(header);

            foreach (Position p in positions)
            {
                TableCell id = new TableCell();
                TableCell name = new TableCell();
                TableCell department = new TableCell();
                TableCell number = new TableCell();
                TableCell edit = new TableCell();
                TableCell delete = new TableCell();

                id.Text = p.ID.ToString();
                name.Text = p.Name;
                department.Text = p.Department.Name;
                int employeesCount = p.getCountOfEmployees();
                number.Text = employeesCount.ToString();
                edit.Text = "<a href='editPosition.aspx?id=" + p.ID.ToString() + "' class='btn btn-small btn-warning'>Edit</a>";

                if (employeesCount == 0)
                    delete.Text = "<a href='deletePosition.aspx?id=" + p.ID.ToString() + "' class='btn btn-small btn-danger'>Delete</a>";
                else
                    delete.Text = "<a href='#' disabled='disabled' class='btn btn-small btn-danger'>Position Must be Empty</a>";

                TableRow values = new TableRow();
                values.Cells.Add(id);
                values.Cells.Add(name);
                values.Cells.Add(department);
                values.Cells.Add(number);
                values.Cells.Add(edit);
                values.Cells.Add(delete);

                Table1.Rows.Add(values);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = TextBox1.Text;
            int department_id = int.Parse(DropDownList1.SelectedItem.Value.ToString());

            int check = Position.create(name, department_id);

            if (check == 1)
            {
                Response.Redirect("positions.aspx");
            }
            else {
                header1.showAlert("Something went wrong!");
            }
        }
    }
}