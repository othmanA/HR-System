using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR
{
    public class Employee
    {

        private int SSN;
        private string firstName;
        private char middleInitial;
        private string lastName;
        private string dob;


        public Employee()
        {
           
        }

        private void setSSN(int ssn)
        {
            this.SSN = ssn;
        }

        public int getSSN()
        {
            return this.SSN;
        }

        public void setFirstName(string name)
        {
            this.firstName = name;
        }

        public string getFirstName()
        {
            return this.firstName;
        }

        public void setMiddleInitial(char m)
        {
            this.middleInitial = m;
        }

        public char getMiddleInitial()
        {
            return this.middleInitial;
        }

        public void setLastName(string lastName)
        {
            this.lastName = lastName;
        }

        public string getLastName()
        {
            return this.lastName;
        }

        public void setDob(string dob)
        {
            this.dob = dob;
        }

        public string getDob()
        {
            return this.dob;
        }


        public static bool create(int SSN) {


            // INSERT THE SSN INTO THE DATABASE
            return true;
        }

        public static Employee[] getALL() {

            // EXAMPLE
            Employee e = new Employee();
            Employee[] array = new Employee[10];
            array[0] = e;
            return array;
        }

        /*
         * This method should migrate the information in this class with the database information.
         * 
         * */
        public bool save() { 
            // TO DO

            return true;
        }



        /**
         * This will find an employee by SSN
         * Not working yet
         * */
        public static Employee find(string SSN){

            Employee e = new Employee();
            return e;
        }
    }
}