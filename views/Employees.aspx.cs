using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR;
namespace HR_SYSTEM.views
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillTableHeaders();
            FillEmployees();
            

        }

        protected void FillTableHeaders() {
            // Creating a row
            TableRow row = new TableRow();

            // Creating the cells
            TableHeaderCell id = new TableHeaderCell();
            TableHeaderCell name = new TableHeaderCell();
            TableHeaderCell position = new TableHeaderCell();
            TableHeaderCell view = new TableHeaderCell();

            // Adding the text to each cell
            id.Text = "ID#";
            name.Text = "Name";
            position.Text = "Position";
            view.Text = "Options";

            // Adding the cells to the row
            row.Cells.Add(id);
            row.Cells.Add(name);
            row.Cells.Add(position);
            row.Cells.Add(view);

            // Add the row to the table
            Table1.Rows.Add(row);
        }

        protected void FillEmployees() { 
            EmployeesCollection employeesCollectionHandler = new EmployeesCollection();
            ArrayList employees = employeesCollectionHandler.getALL();

            foreach(Employee e in employees){
                // Creating the objects that we are going to fill in the Table
                TableRow row = new TableRow();
                TableCell id = new TableCell();
                TableCell name = new TableCell();
                TableCell position = new TableCell();
                TableCell view = new TableCell();

                // Fill The cells
                id.Text         = e.Id.ToString();
                name.Text       = e.FullName;
                position.Text   = e.Job.Position.Name;
                view.Text       = @"<a class='btn btn-info btn-small' href=employees.aspx?id="+ e.Id +">View</a>";

                // Add the cells to the row
                row.Cells.Add(id);
                row.Cells.Add(name);
                row.Cells.Add(position);
                row.Cells.Add(view);

               
                Table1.Rows.Add(row);
            }
        }
    }
}