using System;
using System.Collections;
using System.Linq;
using System.Web;
using HRDatabase;
namespace HR
{
    public class EmployeesCollection
    {
        private int employeesCount = 0;
        private int employeesApprovedCount = 0;

        private ArrayList items = new ArrayList();

        private void clartItems() {
            items.Clear();
        }

        public ArrayList getALL() {
            clartItems();
            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("SELECT        employee_id AS Expr1, employee_lastName FROM            Employee WHERE        (employee_working_status = 1) ORDER BY employee_lastName");
            handler.queryExecute();

            while (handler.reader.Read()) {
                int employee_id = int.Parse(handler.reader["Expr1"].ToString());
                Employee e = new Employee();
                e.findById(employee_id);
                items.Add(e);
            }

            return items;
        }

        public ArrayList getNotWorkingEmployees() {
            clartItems();
            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("SELECT employee_id FROM Employee WHERE employee_working_status = 1 ORDER BY employee_last_name");
            handler.queryExecute();

            while (handler.reader.Read())
            {
                int employee_id = int.Parse(handler.reader["employee_id"].ToString());
                Employee e = new Employee();
                e.findById(employee_id);
                items.Add(e);
            }


            return items;
        }

        public ArrayList getInTimeOff() {

            return items;
        }

        public ArrayList getUnApprovedEmployees(){
            clartItems();
            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("SELECT employee_id FROM Employee WHERE employee_approved = FALSE ORDER BY employee_last_name");
            handler.queryExecute();

            while (handler.reader.Read())
            {
                int employee_id = int.Parse(handler.reader["employee_id"].ToString());
                Employee e = new Employee();
                e.findById(employee_id);
                items.Add(e);
            }


            return items;
        }
        
    }
}