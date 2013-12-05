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
            panel1.Visible = false;

            if (Session["admin"].ToString() == "True") {
                fillUnApprovedEmployees();
                panel1.Visible = true;
            }
        }

        protected void FillTableHeaders() {
            // Creating a row
            TableRow row = new TableRow();

            // Creating the cells
            TableHeaderCell id = new TableHeaderCell();
            TableHeaderCell name = new TableHeaderCell();
            TableHeaderCell department = new TableHeaderCell();
            TableHeaderCell position = new TableHeaderCell();
            TableHeaderCell view = new TableHeaderCell();

            // Adding the text to each cell
            id.Text = "ID#";
            name.Text = "Name";
            department.Text = "Department";
            position.Text = "Position";
            view.Text = "Options";
            

            // add the cells to the row
            row.Cells.Add(id);
            row.Cells.Add(name);
            row.Cells.Add(department);
            row.Cells.Add(position);
            row.Cells.Add(view);


            // CREATE A CELL FOR ADMIN DELETE
            try
            {
                if (Session["admin"].ToString() == "True")
                {
                    TableHeaderCell deleteHeader = new TableHeaderCell();
                    deleteHeader.Text = "Delete";
                    row.Cells.Add(deleteHeader);
                }
            }
            catch (Exception e) {
                Response.Redirect("login.aspx");
            }



            // Add the row to the table
            Table1.Rows.Add(row);
        }

        protected void FillEmployees() { 
            EmployeesCollection employeesCollectionHandler = new EmployeesCollection();
            ArrayList employees;
            employees = employeesCollectionHandler.getApproved();

            foreach(Employee e in employees){
                // Creating the objects that we are going to fill in the Table
                TableRow row = new TableRow();
                TableCell id = new TableCell();
                TableCell name = new TableCell();
                TableCell department = new TableCell();
                TableCell position = new TableCell();
                TableCell view = new TableCell();

                // Fill The cells
                id.Text         = e.Id.ToString();
                name.Text       = e.FullName;
                department.Text = e.Job.Position.Department.Name;
                position.Text   = e.Job.Position.Name;
                view.Text       = @"<a class='btn btn-info btn-small' href=EmployeeView.aspx?id="+ e.Id +">View</a>";

                // Add the cells to the row
                row.Cells.Add(id);
                row.Cells.Add(name);
                row.Cells.Add(department);
                row.Cells.Add(position);
                row.Cells.Add(view);

                // FOR ADMIN DELETE
                if (Session["admin"].ToString() == "True") {
                    TableCell delete = new TableCell();
                    delete.Text = "<a href='deleteEmployee.aspx?id=" + e.Id.ToString() + "' class='btn btn-small btn-danger'>Delete</a>";
                    row.Cells.Add(delete);
                }

               
                Table1.Rows.Add(row);
            }
        }

        protected void fillUnApprovedEmployees() {
            // Creating a row
            TableRow row = new TableRow();

            // Creating the cells
            TableHeaderCell id = new TableHeaderCell();
            TableHeaderCell name = new TableHeaderCell();
            TableHeaderCell department = new TableHeaderCell();
            TableHeaderCell position = new TableHeaderCell();
            TableHeaderCell view = new TableHeaderCell();
            TableHeaderCell approveHeader = new TableHeaderCell();
            // Adding the text to each cell
            id.Text = "ID#";
            name.Text = "Name";
            department.Text = "Department";
            position.Text = "Position";
            view.Text = "Options";
            approveHeader.Text = "Approve";

            // add the cells to the row
            row.Cells.Add(id);
            row.Cells.Add(name);
            row.Cells.Add(department);
            row.Cells.Add(position);
            row.Cells.Add(view);
            row.Cells.Add(approveHeader);

            TableHeaderCell deleteHeader = new TableHeaderCell();
            deleteHeader.Text = "Delete";
            row.Cells.Add(deleteHeader);

            // Add the row to the table
            Table2.Rows.Add(row);



            EmployeesCollection employeesCollectionHandler = new EmployeesCollection();
            ArrayList employees;
            employees = employeesCollectionHandler.getUnApproved();
            if (employees.Count == 0)
                panel1.Visible = false;

            foreach (Employee e in employees)
            {
                // Creating the objects that we are going to fill in the Table
                TableRow valuesRow = new TableRow();
                TableCell idvalue = new TableCell();
                TableCell namevalue = new TableCell();
                TableCell departmentvalue = new TableCell();
                TableCell positionvalue = new TableCell();
                TableCell viewvalue = new TableCell();
                TableCell approve = new TableCell();

                // Fill The cells
                idvalue.Text = e.Id.ToString();
                namevalue.Text = e.FullName;
                departmentvalue.Text = e.Job.Position.Department.Name;
                positionvalue.Text = e.Job.Position.Name;
                viewvalue.Text = @"<a class='btn btn-info btn-small' href=EmployeeView.aspx?id=" + e.Id + ">View</a>";
                approve.Text = @"<a class='btn btn-warning btn-small' href=approveEmployee.aspx?id=" + e.Id + "><i class='icon-ok icon-white'></i> Approve</a>";

                // Add the cells to the row
                valuesRow.Cells.Add(idvalue);
                valuesRow.Cells.Add(namevalue);
                valuesRow.Cells.Add(departmentvalue);
                valuesRow.Cells.Add(positionvalue);
                valuesRow.Cells.Add(viewvalue);
                valuesRow.Cells.Add(approve);

                TableCell delete = new TableCell();
                delete.Text = "<a href='deleteEmployee.aspx?id=" + e.Id.ToString() + "' class='btn btn-small btn-danger'>Delete</a>";
                valuesRow.Cells.Add(delete);


                Table2.Rows.Add(valuesRow);
            }
        }
    }
}