using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR;

namespace HR_SYSTEM.views
{
    public partial class EmployeeView : System.Web.UI.Page
    {
        private Employee employee = new Employee(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get the id of the employee from the url and pass it to the employee object
            // Also we are saving the object in the class because we need to use it in all the moethds.
            try
            {
                this.employee.findById(int.Parse(Request.QueryString["id"]));
            }
            catch (Exception exce) {
                Response.Redirect("Employees.aspx");
            }

            // We need to fill all table when the page load
            fillButtons();
            fillInformation();

        }

        protected void fillButtons() {
            // Create the row
            // We are going to use one row only
            TableRow row = new TableRow();

            // Create the cells
            TableHeaderCell addRecordsCell = new TableHeaderCell();
            TableHeaderCell addTimeOffCell = new TableHeaderCell();
            TableHeaderCell addIncomeCell = new TableHeaderCell();
            TableHeaderCell addDocumentCell = new TableHeaderCell();

            // Add the links to cells Text
            addRecordsCell.Text = @"<a class='btn btn-warning' href='EmployeeAddRecord.aspx?id='"+employee.Id+">Add a Record</a>";
            addTimeOffCell.Text = @"<a class='btn btn-warning' href='EmployeeAddTimeOff.aspx?id='" + employee.Id + ">Add a Time Off</a>";
            addIncomeCell.Text = @"<a class='btn btn-warning' href='EmployeeAddIncome.aspx?id='" + employee.Id + ">Add an Income</a>";
            addDocumentCell.Text = @"<a class='btn btn-warning' href='EmployeeAddDocument.aspx?id='" + employee.Id + ">Add a Document</a>";

            // Add the cells to the row
            row.Cells.Add(addRecordsCell);
            row.Cells.Add(addTimeOffCell);
            row.Cells.Add(addIncomeCell);
            row.Cells.Add(addDocumentCell);

            // Add the row to the table
            ButtonsTable.Rows.Add(row);

            // Add the bootstrap table class to the table
            ButtonsTable.CssClass = "table centerTD";
        }

        protected void fillInformation() { 
            // We need to show these variables in the employee personal information
            // 1. Employee Name
            // 2. Employee SSN
            // 3. Employee Date Of Birth
            // 4. Employee Gender

            // Create two rows to show theses variables 
            // The first row is for the headers
            // The second for the variables
            TableRow headerRow = new TableRow();
            TableRow valuesRow = new TableRow();
            
            // Create a header Cells
            TableHeaderCell nameHeaderCell = new TableHeaderCell();
            TableHeaderCell ssnHeaderCell = new TableHeaderCell();
            TableHeaderCell dobHeaderCell = new TableHeaderCell();
            TableHeaderCell genderHeaderCell = new TableHeaderCell();

            // Create the Cells that will contain the variables
            TableCell nameCell = new TableCell();
            TableCell ssnCell = new TableCell();
            TableCell dobCell = new TableCell();
            TableCell genderCell = new TableCell();

            // Add the text to the headers
            // Make them upper case
            nameHeaderCell.Text = "Name".ToUpper();
            ssnHeaderCell.Text = "social security number".ToUpper();
            dobHeaderCell.Text = "date of birth".ToUpper();
            genderHeaderCell.Text = "Gender".ToUpper();

            //Add the variables to the cells
            nameCell.Text = employee.FullName;
            ssnCell.Text = employee.SSN;
            dobCell.Text = employee.Dob.Date.ToString();
            genderCell.Text = employee.Gender.ToString();

            // Add the headers to the row
            headerRow.Cells.Add(nameHeaderCell);
            headerRow.Cells.Add(ssnHeaderCell);
            headerRow.Cells.Add(dobHeaderCell);
            headerRow.Cells.Add(genderHeaderCell);

            // Add the values to the row
            valuesRow.Cells.Add(nameCell);
            valuesRow.Cells.Add(ssnCell);
            valuesRow.Cells.Add(dobCell);
            valuesRow.Cells.Add(genderCell);

            // Add the two rows to the table
            InformationTable.Rows.Add(headerRow);
            InformationTable.Rows.Add(valuesRow);

            // add the bootstrap class to the table
            InformationTable.CssClass = "table centerTD";

        }

        protected void fillRecords() { 
        
        }

        protected void fillIncome() { 
        
        }

        protected void fillTimeOff() { 
        
        }

        protected void fillDocuments() { 
        
        }
    }
}