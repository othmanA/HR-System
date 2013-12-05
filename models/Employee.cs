using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRDatabase;
using System.Data.SqlClient;

namespace HR
{
    public class Employee
    {

        private int id;
        private string _SSN;
        private string firstName;
        private char middleInitial;
        private string lastName;
        private DateTime dob;
        private char gender;
        private bool approved;
        private DateTime created_at;
        private string phone;

        private Job job;
        private Address address;
        private EmployeesRecords records;
        private EmployeesTimeOff timeOff;
        private EmployeesDocuments documents;
        private EmployeesIncome income;

        /**
         * Find By ID
         * 
         * This method should take an id as an argument and get the employee from database 
         * 
         */ 
        public void findById(int id) {
            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("SELECT * FROM Employee WHERE employee_id = @id");
            handler.addParameter("@id", id.ToString());
            handler.queryExecute();

            while (handler.reader.Read()) {
                // Sending all the data to the big setter
                setObject(handler.reader);
            }

           
        }


        /**
         * Find By SSN
         * 
         * This method should take the SSN as an argument and get the employee from database 
         * 
         */
        public void findBySSN(int SSN)
        {
            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("SELECT * FROM Employee WHERE employee_SSN = @SSN");
            handler.addParameter("@SSN", SSN.ToString());
            handler.queryExecute();

            while (handler.reader.Read())
            {
                // Sending all the data to the big setter
                setObject(handler.reader);
            }
        }



        /**
         * This method should set the data from any SQL reader
         */
        private void setObject(SqlDataReader r)
        {
            this.id = int.Parse(r["employee_id"].ToString());
            this.SSN = r["employee_SSN"].ToString();
            this.firstName = r["employee_firstName"].ToString();
            this.lastName = r["Employee_lastName"].ToString();
            this.dob = DateTime.Parse(r["employee_dob"].ToString());
            this.created_at = DateTime.Parse(r["employee_created_at"].ToString());
            this.phone = r["employee_phone"].ToString();


            // Converting the object to char -- Middle Initial 
            string m = r["employee_middleInital"].ToString();
            this.middleInitial = m[0];



            // converting the object ot char (gender)
            string g = r["employee_gender"].ToString();
            this.gender = g[0];

            // The approved status is data of type bool. 
            string approvedStatus = r["employee_approved"].ToString();
            this.approved = (approvedStatus == "True");



            // Preparing the variables for the Job constructor
            bool workingStatus = true;

            string workingStatusAsString = r["employee_working_status"].ToString();
            if (workingStatusAsString == "0")
                workingStatus = false;

            string contract = r["employee_contract"].ToString();
            int hoursPerDay = int.Parse(r["employee_hoursPerDay"].ToString());
            DateTime firstDay = DateTime.Parse(r["employee_firstDay"].ToString());
            int position_id = int.Parse(r["employee_position"].ToString());
            // Setting the job object
            this.job = new Job(workingStatus,contract,hoursPerDay,firstDay,position_id);


            // Preparing the varirables for the address constructor
            string address1 = r["employee_address1"].ToString();
            string address2 = r["employee_address2"].ToString();
            string city = r["employee_city"].ToString();
            string state = r["employee_state"].ToString();
            int zipCode = int.Parse(r["employee_zip_code"].ToString());
            this.address = new Address(address1, address2, city, state, zipCode);

            // Get the records
            records = new EmployeesRecords(this.id);

            // Get the time off
            timeOff = new EmployeesTimeOff(this.id);

            // Get the documents
            documents = new EmployeesDocuments(this.id);

            // Get the income
            income = new EmployeesIncome(this.id);

        }


        /**
         * create
         * 
         * IS A static method that will return 0 if the creations has not compleated or the ID of the new Employee if the employee was created Successfully 
         */
        public static int create(string SSN, string FirstName, char middleInitial, string lastName, DateTime dob, char gender, string phone, Job job, Address address) {
            
            DatabaseHandler handler = new DatabaseHandler();

            string insertSt = "INSERT INTO Employee (employee_SSN, employee_firstName, employee_middleInital, employee_lastName, employee_dob, employee_working_status, employee_contract, employee_hoursPerDay, employee_firstDay, employee_gender, employee_position, employee_approved, employee_created_at, employee_address1, employee_address2, employee_city, employee_state, employee_zip_code, employee_phone) VALUES        (@SSN,@firstName,@middleInitial,@lastName,@DOB,@workingStatus,@contract,@hoursPerDay,@firstDay,@gender,@position,@approved,@created_at,@address1,@address2,@city,@state,@zipCode,@phone)";
            handler.setSQL(insertSt);

            //Adding the employee information
            handler.addParameter("@SSN", SSN);
            handler.addParameter("@firstName", FirstName);
            handler.addParameter("@middleInitial", middleInitial.ToString());
            handler.addParameter("@lastName", lastName);
            handler.addParameter("@DOB", dob.Date.ToString());
            handler.addParameter("@gender", gender.ToString());
            handler.addParameter("@approved", "0");
            string created = DateTime.Now.ToString();
            handler.addParameter("@created_at", created);
            handler.addParameter("@phone", phone.ToString());

            bool workingStatus = job.WorkingStatus;
            string WorkingstatusToInt;

            if(workingStatus)
                WorkingstatusToInt = "1";
            else
                WorkingstatusToInt = "0";

            // JOB 
            handler.addParameter("@workingStatus", WorkingstatusToInt);
            handler.addParameter("@contract", job.Contract);
            handler.addParameter("@hoursPerDay", job.HoursPerDay.ToString());
            handler.addParameter("@firstDay", job.FirstDayAtWork.Date.ToString());
            handler.addParameter("@position", job.Position.ID.ToString());

            // ADDRESS
            handler.addParameter("@address1", address.Address1);
            handler.addParameter("@address2", address.Address2);
            handler.addParameter("@city", address.City);
            handler.addParameter("@state", address.State);
            handler.addParameter("@zipCode", address.ZipCode.ToString());
            

            int rows = handler.ExecuteNonQuery();
            return rows;


        }


        /**
         * This method should save all the data
         * @return the number of rows affected (IT SHOULD BE 1 OR 0)
         */ 
        public int save() {
            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("UPDATE Employee SET  employee_SSN = @SSN, employee_firstName = @firstName, employee_middleInital = @middleInitial, employee_lastName = @lastName, employee_dob = @dob, employee_gender = @gender, employee_working_status = @workingStatus, employee_contract = @contract, employee_hoursPerDay = @hoursPerDay, employee_firstDay = @firstDay, employee_position = @position, employee_approved = @approved, employee_address1 = @address1,  employee_address2 = @address2, employee_city = @city, employee_state = @state, employee_zip_code = @zipCode, employee_phone = @phone WHERE employee_id = @id");
            handler.addParameter("@id", this.id.ToString());

            // EMPLOYEE INFO
            handler.addParameter("@SSN", this.SSN);
            handler.addParameter("@firstName", this.firstName);
            handler.addParameter("@middleInitial", middleInitial.ToString());
            handler.addParameter("@lastName", this.lastName);
            handler.addParameter("@dob", dob.Date.ToString());
            handler.addParameter("@gender", this.gender.ToString());
            handler.addParameter("@phone", this.phone);

            int approvedStatus = 1;
            if (this.approved == false)
                approvedStatus = 0;

            handler.addParameter("@approved", approvedStatus.ToString());

            // JOB INFO

            int workingStatus = 1;
            if (Job.WorkingStatus == false)
                workingStatus = 0;

            handler.addParameter("@workingStatus", workingStatus.ToString());
            handler.addParameter("@contract", Job.Contract);
            handler.addParameter("@hoursPerDay ", Job.HoursPerDay.ToString());
            handler.addParameter("@firstDay", Job.FirstDayAtWork.Date.ToString());
            handler.addParameter("@position", Job.Position.ID.ToString());
            
            // ADDRESS INFO
            handler.addParameter("@address1", Address.Address1);
            handler.addParameter("@address2", Address.Address2);
            handler.addParameter("@state", Address.State);
            handler.addParameter("@city", Address.City);
            handler.addParameter("@zipCode", Address.ZipCode.ToString());




            return handler.ExecuteNonQuery();
        }

        public int delete() {
            records.deleteALL();
            timeOff.deleteALL();
            documents.deleteALL();
            income.deleteALL();

            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("DELETE FROM Employee WHERE employee_id = @id");
            handler.addParameter("@id", this.id.ToString());
            return handler.ExecuteNonQuery();
        }

        public static int approve(int id) {
            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("UPDATE Employee SET employee_approved = 1 WHERE employee_id = @id");
            handler.addParameter("@id", id.ToString());
            return handler.ExecuteNonQuery();
        }


        //----------------------- GETTERS AND SETTERS ----------------------\\
        public string FirstName {
            get { return this.firstName; }
            set { firstName = value; }
        }

        public string SSN {
            get { return _SSN; }
            set { _SSN = value; }
        }

        public int Id {
            get {return this.id; }
            private set {id = value;}
        }

        public char MiddleInitial {
            get { return this.middleInitial; }
            set { middleInitial = value; }
        }

        public string LastName {
            get { return this.lastName; }
            set { lastName = value; }
        }

        public DateTime Dob {
            get {return this.dob; }
            set {dob = value;}
        }

        public char Gender {
            get { return this.gender; }
            set {gender = value;}
        }

        public bool IsApproved {
            get {return this.approved;}
            private set {approved = value;}
        }

        public DateTime Created_at {
            get { return this.created_at; }
            private set {created_at = value;}
        }

        public string Phone {
            get { return this.phone; }
            set {phone = value;}
        }

        public Address Address {
            get {return this.address; }
            private set {address = value;}
        }

        public Job Job {
            get {return job; }
            private set {job = value;}
        }

        public EmployeesRecords Records {
            get {return records;}
            private set {records = value;}
        }

        public EmployeesTimeOff TimeOff {
            get {return timeOff; }
            private set {timeOff = value;}
        }


        public EmployeesDocuments Documents
        {
            get { return documents; }
            private set { documents = value; }
        }

        public EmployeesIncome Income
        {
            get { return income; }
            private set { income = value; }
        }


        // TO get the full name Directly
        public string FullName {
            get {
               string name; 
               name = this.firstName + " " + this.middleInitial.ToString() + ". " + this.lastName;
               return name;
            }
        }
    }
}
