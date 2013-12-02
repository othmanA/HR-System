using System;
using System.Collections;
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
            fillJob();
            fillContact();
            fillRecords();
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
            addRecordsCell.Text = @"<a class='btn btn-warning' href='EmployeeAddRecord.aspx?id="+employee.Id+"'>Add a Record</a>";
            addTimeOffCell.Text = @"<a class='btn btn-warning' href='EmployeeAddTimeOff.aspx?id=" + employee.Id + "'>Add a Time Off</a>";
            addIncomeCell.Text = @"<a class='btn btn-warning' href='EmployeeAddIncome.aspx?id=" + employee.Id + "'>Add an Income</a>";
            addDocumentCell.Text = @"<a class='btn btn-warning' href='EmployeeAddDocument.aspx?id=" + employee.Id + "'>Add a Document</a>";

            // Add the cells to the row
            row.Cells.Add(addRecordsCell);
            row.Cells.Add(addTimeOffCell);
            row.Cells.Add(addIncomeCell);
            row.Cells.Add(addDocumentCell);

            // Add the row to the table
            ButtonsTable.Rows.Add(row);

            // Add the bootstrap table class to the table
            ButtonsTable.CssClass = "table centerTD no-border-table";
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
            dobCell.Text = employee.Dob.ToShortDateString();
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

        protected void fillJob() {
            TableRow headerRow = new TableRow();
            TableRow valuesRow = new TableRow();

            TableHeaderCell jobDepartmentHeader = new TableHeaderCell();
            TableHeaderCell jobPositionHeader = new TableHeaderCell();
            TableHeaderCell jobWorkingHoursHeader = new TableHeaderCell();
            TableHeaderCell jobWorkingStatusHeader = new TableHeaderCell();
            TableHeaderCell jobContractHeader = new TableHeaderCell();
            TableHeaderCell jobFirstDayHeader = new TableHeaderCell();

            TableCell department = new TableCell();
            TableCell position = new TableCell();
            TableCell workingHours = new TableCell();
            TableCell status = new TableCell();
            TableCell contract = new TableCell();
            TableCell firstDay = new TableCell();

            jobDepartmentHeader.Text = "Department".ToUpper();
            jobPositionHeader.Text = "Position".ToUpper();
            jobWorkingHoursHeader.Text = "Working Hours".ToUpper();
            jobWorkingStatusHeader.Text = "Status".ToUpper();
            jobContractHeader.Text = "Contract".ToUpper();
            jobFirstDayHeader.Text = "FirstDay".ToUpper();

            department.Text = employee.Job.Position.Department.Name;
            position.Text = employee.Job.Position.Name;
            workingHours.Text = employee.Job.HoursPerDay.ToString();
            status.Text = employee.Job.WorkingStatus.ToString();
            contract.Text = employee.Job.Contract.ToString();
            firstDay.Text = employee.Job.FirstDayAtWork.ToShortDateString();

            headerRow.Cells.Add(jobDepartmentHeader);
            headerRow.Cells.Add(jobPositionHeader);
            headerRow.Cells.Add(jobWorkingHoursHeader);
            headerRow.Cells.Add(jobWorkingStatusHeader);
            headerRow.Cells.Add(jobContractHeader);
            headerRow.Cells.Add(jobFirstDayHeader);


            valuesRow.Cells.Add(department);
            valuesRow.Cells.Add(position);
            valuesRow.Cells.Add(workingHours);
            valuesRow.Cells.Add(status);
            valuesRow.Cells.Add(contract);
            valuesRow.Cells.Add(firstDay);

            JobTable.Rows.Add(headerRow);
            JobTable.Rows.Add(valuesRow);

            JobTable.CssClass = "table";




        }

        protected void fillContact() {
            TableRow headerRow = new TableRow();
            TableRow valuesRow = new TableRow();

            TableHeaderCell address1Header = new TableHeaderCell();
            TableHeaderCell address2Header = new TableHeaderCell();
            TableHeaderCell cityHeader = new TableHeaderCell();
            TableHeaderCell stateHeader = new TableHeaderCell();
            TableHeaderCell zipHeader = new TableHeaderCell();
            TableHeaderCell phoneHeader = new TableHeaderCell();

            TableCell address1 = new TableCell();
            TableCell address2 = new TableCell();
            TableCell city = new TableCell();
            TableCell status = new TableCell();
            TableCell zipcode = new TableCell();
            TableCell phone = new TableCell();

            address1Header.Text = "Address 1".ToUpper();
            address2Header.Text = "Address 2".ToUpper();
            cityHeader.Text = "City".ToUpper();
            stateHeader.Text = "State".ToUpper();
            zipHeader.Text = "Zip Code".ToUpper();
            phoneHeader.Text = "Phone".ToUpper();

            address1.Text = employee.Address.Address1;
            address2.Text = employee.Address.Address2;
            city.Text = employee.Address.City;
            status.Text = employee.Address.State;
            zipcode.Text = employee.Address.ZipCode.ToString();
            phone.Text = employee.Phone;

            headerRow.Cells.Add(address1Header);
            headerRow.Cells.Add(address2Header);
            headerRow.Cells.Add(cityHeader);
            headerRow.Cells.Add(stateHeader);
            headerRow.Cells.Add(zipHeader);
            headerRow.Cells.Add(phoneHeader);


            valuesRow.Cells.Add(address1);
            valuesRow.Cells.Add(address2);
            valuesRow.Cells.Add(city);
            valuesRow.Cells.Add(status);
            valuesRow.Cells.Add(zipcode);
            valuesRow.Cells.Add(phone);

            AddressTable.Rows.Add(headerRow);
            AddressTable.Rows.Add(valuesRow);

            AddressTable.CssClass = "table";
        }

        protected void fillRecords() {
            ArrayList records = new ArrayList();
            records = employee.Records.getALL();

            TableRow headerRow = new TableRow();
            TableRow valuesRow = new TableRow();

            TableHeaderCell NumberHeader = new TableHeaderCell();
            TableHeaderCell issueHeader = new TableHeaderCell();
            TableHeaderCell expireHeader = new TableHeaderCell();
            TableHeaderCell typeHeader = new TableHeaderCell();
            TableHeaderCell noteHeader = new TableHeaderCell();

            TableCell number = new TableCell();
            TableCell issueDate = new TableCell();
            TableCell expireDate = new TableCell();
            TableCell type = new TableCell();
            TableCell note = new TableCell();

            NumberHeader.Text = "Number".ToUpper();
            issueHeader.Text = "Issue date".ToUpper();
            expireHeader.Text = "Expire date".ToUpper();
            typeHeader.Text = "type date".ToUpper();
            noteHeader.Text = "note date".ToUpper();

            headerRow.Cells.Add(NumberHeader);
            headerRow.Cells.Add(issueHeader);
            headerRow.Cells.Add(expireHeader);
            headerRow.Cells.Add(typeHeader);
            headerRow.Cells.Add(noteHeader);

            RecordsTable.Rows.Add(headerRow);


            foreach (Record r in records) {
                number.Text = r.Number.ToString();
                issueDate.Text = r.IssueDate.ToShortDateString();
                expireDate.Text = r.ExpireDate.ToShortDateString();
                type.Text = r.Type;
                note.Text = r.Note;

                valuesRow.Cells.Add(number);
                valuesRow.Cells.Add(issueDate);
                valuesRow.Cells.Add(expireDate);
                valuesRow.Cells.Add(type);
                valuesRow.Cells.Add(note);

                RecordsTable.Rows.Add(valuesRow);
            }

            RecordsTable.CssClass = "table";
        }

        protected void fillIncome() { 
        
        }

        protected void fillTimeOff() { 
        
        }

        protected void fillDocuments() { 
        
        }
    }
}