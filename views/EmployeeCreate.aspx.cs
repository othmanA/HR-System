using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR;
namespace HR_SYSTEM.views
{
    public partial class EmployeeCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            

            // We need to fill all the dropdowns before while we load the page.
            if(!Page.IsPostBack)
                FillDepartments();
            FillContractTypes();
            FillWorkingHours();
            FillWorkingStatus();
            FillGender();

            // We are filling the positions only when the selected index for the department drop down is changed!
        }


        protected void FillDepartments()
        {
            DepartmentDropDown.Items.Clear();
            ArrayList l = Department.getALL();
            foreach (Department d in l)
            {
                ListItem i = new ListItem(d.Name,d.ID.ToString());
                DepartmentDropDown.Items.Add(i);
            }
        }


        protected void FillPositions() {
            PositionsDropDownList.Items.Clear();
            ArrayList l = Position.getByDepartmentID(int.Parse(DepartmentDropDown.SelectedItem.Value));
            foreach (Position p in l) {
                ListItem i = new ListItem(p.Name, p.ID.ToString());
                PositionsDropDownList.Items.Add(i);
            }
        }

        protected void FillContractTypes() {
            ContractTypeDropDown.Items.Clear();
            ContractTypeDropDown.Items.Add("Full-Time");
            ContractTypeDropDown.Items.Add("Part-Time");
        }

        protected void FillGender()
        {
            GenderDropDown.Items.Clear();
            GenderDropDown.Items.Add("Male");
            GenderDropDown.Items.Add("Female");
        }

        protected void FillWorkingHours()
        {
            WorkingHoursDropDown.Items.Clear();
            for (int i = 1; i <= 12; i++) {
                WorkingHoursDropDown.Items.Add(i.ToString());
            }
        }

        protected void FillWorkingStatus()
        {
            WorkingStatusDropDown.Items.Clear();
            WorkingStatusDropDown.Items.Add("Working");
            WorkingStatusDropDown.Items.Add("Not Working");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            // Getting the employee Information
            
                // Employee Information
                string SSN = SSNTextBox.Text;
                string firstName = FirstNameTextBox.Text;
                char middleInitial = MiddleInitialTextBox.Text.ToCharArray()[0];
                string lastName = LastNameTextBox.Text;
                DateTime dob = DateTime.Parse(DOBTextBox.Text.ToString());
                string phone = PhoneNumberTextBox.Text;
                char gender = GenderDropDown.SelectedItem.Text.ToCharArray()[0];

                // Address Parsing 
                string address1 = Address1TextBox.Text;
                string address2 = Address2TextBox.Text;
                string city = CityTextBox.Text;
                string state = StateTextBox.Text;
                int zipCode = int.Parse(ZipCodeTextBox.Text);

                // JOB 
                int position_id = int.Parse(PositionsDropDownList.SelectedItem.Value);
                string contract = ContractTypeDropDown.SelectedItem.Text;
                int workingHours = int.Parse(WorkingHoursDropDown.SelectedItem.Text);
                bool workingStatus = (WorkingStatusDropDown.SelectedItem.Text == "Working");
                DateTime firstDay = DateTime.Parse(FirstDayTextBox.Text.ToString());

                //Creating a new Job Instance
                Job j = new Job(workingStatus, contract, workingHours, firstDay, position_id);

                //Creating the Address instance
                Address a = new Address(address1, address2, city, state, zipCode);

                int check = Employee.create(SSN, firstName, middleInitial, lastName, dob, gender, phone, j, a);
                if (check == 1)
                {
                    header1.success("Employee Created!");
                }
                else {
                    header1.showAlert("Employee was not created because of en error!");
                }
                
            
            
            
        }

        protected void DepartmentDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillPositions();
        }
    }
}