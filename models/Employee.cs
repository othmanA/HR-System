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
        private string SSN;
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
            int workingStatus = int.Parse(r["employee_working_status"].ToString());
            string contract = r["employee_contract"].ToString();
            int hoursPerDay = int.Parse(r["employee_hoursPerDay"].ToString());
            string firstDay = r["employee_firstDay"].ToString();

            // Setting the job object
            this.job = new Job(workingStatus,contract,hoursPerDay,firstDay);


            // Preparing the varirables for the address constructor
            string address1 = r["employee_address1"].ToString();
            string address2 = r["employee_address2"].ToString();
            string city = r["employee_city"].ToString();
            string state = r["employee_state"].ToString();
            int zipCode = int.Parse(r["employee_zip_code"].ToString());
            this.address = new Address(address1, address2, city, state, zipCode);

        }


        /**
         * create
         */
        public bool create() {
            if (this.id == null) {
                DatabaseHandler handler = new DatabaseHandler();

                string insertSt = "INSERT INTO Employee (employee_id, employee_SSN, employee_firstName, employee_middleInital, employee_lastName, employee_dob, employee_working_status, employee_contract, employee_hoursPerDay, employee_firstDay, employee_gender, employee_position, employee_approved, employee_created_at, employee_address1, employee_address2, employee_city, employee_state, employee_zip_code, employee_phone) VALUES        (NULL,@SSN,@firstName,@middleInitial,@lastName,@DOB,@workingStatus,@contract,@hoursPerDay,@firstDay,@gender,@position,@approved,@created_at,@address1,@address2,@city,@state,@zipCode,@phone)";
                handler.setSQL(insertSt);

                // TO DO .. Working on the parameters

            }

            return false;
        }


        //----------------------- GETTERS ----------------------\\
        public string getFirstName() {
            return this.firstName;
        }

        public string getSSN() {
            return this.SSN;
        }

        public int getID() {
            return this.id;
        }

        public char getMiddleInitial() {
            return this.middleInitial;
        }

        public string getLastName() {
            return this.lastName;
        }

        public DateTime getDob() {
            return this.dob;
        }

        public char getGender() {
            return this.gender;
        }

        public bool getApprovedStatus() {
            return this.approved;
        }

        public DateTime getCreatedDateAndTime() {
            return this.created_at;
        }

        public string getPhone() {
            return this.phone;
        }

        public Address getAddress() {
            return this.address;
        }

        public Job getJob() {
            return this.job;
        }


        //----------------------- SETTERS ----------------------\\
        // WE DON't NEED TO SET the created_at and the id or the approved

        public void setFirstName(string firstName) {
            this.firstName = firstName;
        }

        public void setMiddleInitial(char m) {
            this.middleInitial = m;
        }

        public void setLastName(string lastName) {
            this.lastName = lastName;
        }

        public void setSSN(string SSN) {
            this.SSN = SSN;
        }

        public void setDob(DateTime dob) {
            this.dob = dob;
        }

        public void setGender(char g) {
            this.gender = g;
        }

        public void setPhone(string phone) {
            this.phone = phone;
        }

        public void setJob(Job job) {
            this.job = job;
        }

        public void setAddress(Address address) {
            this.address = address;
        }


    }
}
