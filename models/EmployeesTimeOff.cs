using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using HRDatabase;
namespace HR
{
    public class EmployeesTimeOff : itemsCollection
    {
        private ArrayList items = new ArrayList();

        public EmployeesTimeOff(int employee_id)
        {
            init(employee_id);
        }



        /**
         * Init
         * This method will take care of getting all the Time Offs for an employee
         * 
         * @pram int id
         * @return none
         * */
        public void init(int employee_id)
        {
            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("SELECT * FROM Time_off WHERE employee = @employee_id");
            handler.addParameter("@employee_id", employee_id.ToString());
            handler.queryExecute();

            while (handler.reader.Read())
            {
                int id = int.Parse(handler.reader["time_off_id"].ToString());
                DateTime startDate = DateTime.Parse(handler.reader["time_off_start_date"].ToString());
                DateTime endDate = DateTime.Parse(handler.reader["time_off_end_date"].ToString());
                string type = handler.reader["time_off_type"].ToString();
                int paidDays = int.Parse(handler.reader["time_off_paid_days"].ToString());
                bool approved = (handler.reader["time_off_approved"].ToString() == "1");

                TimeOff t = new TimeOff(id,startDate,endDate,paidDays,type,approved);
                items.Add(t);
            }
        }

        /**
         *  getById
         *  
         * This method should return the time_off with a specific id
         * If there are no time_off matches the id then return null
         * 
         * @pram int time_off_id
         * @return TimeOff
         * 
         */
        public TimeOff getById(int timeOffId)
        {
            foreach (TimeOff r in items)
            {
                if (r.Id == timeOffId)
                    return r;
            }
            return null;
        }


        /**
         * get ALL 
         * 
         * This method will get all the TimeOff for an employee
         * 
         * @return ArrayList of TimeOff
         */
        public ArrayList getALL()
        {
            return items;
        }


        /**
         * 
         * DELETE
         * 
         * The Time Off model will take care of the deletion from database
         * inside the method we will remove the item from the array
         * 
         * @pram int timeOffId
         * @return bool
         */
        public bool delete(int timeOffId)
        {
            int deleteChecker = 0;
            foreach (TimeOff r in items)
            {
                if (r.Id == timeOffId)
                {
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
            foreach (TimeOff d in items)
            {
                d.delete();
            }
        }

    }
}
