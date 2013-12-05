using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using HRDatabase;
namespace HR
{
    public class EmployeesRecords : itemsCollection
    {
        private ArrayList items = new ArrayList();

        public EmployeesRecords(int employee_id) {
            init(employee_id);
        }


        /**
         * Init
         * This method will take care of getting all the records for an employee
         * 
         * @pram int id
         * @return none
         * */
        public void init(int employee_id){
            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("SELECT * FROM Record WHERE employee = @employee_id");
            handler.addParameter("@employee_id", employee_id.ToString());
            handler.queryExecute();

            while (handler.reader.Read()) {
                int id = int.Parse(handler.reader["record_id"].ToString());
                int number = int.Parse(handler.reader["record_number"].ToString());
                DateTime issueDate = DateTime.Parse(handler.reader["record_issue_date"].ToString());
                DateTime expireDate = DateTime.Parse(handler.reader["record_expire_date"].ToString());
                string type = handler.reader["record_type"].ToString();
                string note = handler.reader["record_note"].ToString();
                bool approved = (handler.reader["record_approved"].ToString() == "1");

                Record r = new Record(id,number,issueDate,expireDate,type,note,approved);
                items.Add(r);
            }
        }


        /**
         *  getByRecordId
         *  
         * This method should return the record with a specific id
         * If there are no records matches the id then return null
         * 
         * @pram int recordId
         * @return Record
         * 
         */
        public Record getByRecordId(int recordId){
            foreach (Record r in items)
            {
                if (r.ID == recordId)
                    return r;
            }
            return null;
        }

        /**
         *  getByRecordNumber
         *  
         * This method should return the record with a specific number
         * If there are no records matches the number then return null
         * 
         * @pram int number
         * @return Record
         * 
         */
        public Record getByRecordNumber(int number)
        {
            foreach (Record r in items)
            {
                if (r.Number == number)
                    return r;
            }
            return null;
        }

        /**
         * get ALL 
         * 
         * This method will get all the records for an employee
         * 
         * @return ArrayList of records
         */ 
        public ArrayList getALL(){
            return items;
        }

        /**
         * 
         * DELETE
         * 
         * The Record model will take care of the deletion from database
         * inside the method we will remove the item from the array
         * 
         * @pram int record_id
         * @return bool
         */ 
        public bool delete(int record_id){
            int deleteChecker = 0;
            foreach (Record r in items)
            {
                if (r.ID == record_id) {
                    deleteChecker = r.delete();
                    items.Remove(r);
                }
            }

            if (deleteChecker == 1)
                return true;
            else
                return false;
            
        }

        public void deleteALL()
        {
            foreach (Record d in items)
            {
                d.delete();
            }
        }

    }
}
