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
        private int SSN;
        private string firstName;
        private char middleInitial;
        private string lastName;
        private DateTime dob;
        private char gender;
        private int approved;
        private DateTime created_at;
        private string phone;

        private Job job;
        private Address address;

        /**
         * Constructor
         * 
         */
        public Employee() {
          
        }


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
         * This method should set the data from any SQL reader
         */
        private void setObject(SqlDataReader r)
        {
            this.firstName = r["employee_firstName"].ToString();

            // Converting the object to char
            string m = r["employee_middleInitial"].ToString();
            this.middleInitial = m[0];

            this.lastName = r["Employee_lastName"].ToString();
            this.dob = DateTime.Parse(r["employee_firstName"].ToString());

            // converting the object ot char (gender)
            string g = r["employee_gender"].ToString();
            this.gender = g[0];

            this.approved = int.Parse(r["employee_approved"].ToString());
            this.created_at = DateTime.Parse(r["employee_created_at"].ToString());
            this.phone = r["employee_phone"].ToString();

            // Preparing the variables for the Job constructor
            int workingStatus = int.Parse(r["employee_working_status"].ToString());
            string contract = r["employee_contract"].ToString();
            int hoursPerDay = int.Parse(r["employee_hoursPerDay"].ToString());
            string firstDay = r["employee_firstDay"].ToString();

            // Setting the objects
            this.job = new Job(workingStatus,contract,hoursPerDay,firstDay);
        }

    }
}
