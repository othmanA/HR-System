using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR
{
    public class Employee
    {

        private int SSN {get; set;}
        private string firstName {get; set;}
        private char middleInitial {get; set;}
        private string lastName { get; set; }
        private string dob {get; set;}


        public static bool create(int SSN) {


            // INSERT THE SSN INTO THE DATABASE
            return true;
        }
        
        
        // this method will do this 
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
