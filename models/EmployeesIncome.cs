using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using HRDatabase;
namespace HR
{
    public class EmployeesIncome
    {
        private ArrayList items = new ArrayList();

        public EmployeesIncome(int employee_id)
        {
            init(employee_id);
        }


        /**
         * Init
         * */
        private void init(int employee_id)
        {
            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("SELECT * FROM Income WHERE income_id = @employee_id");
            handler.addParameter("@employee_id", employee_id.ToString());
            handler.queryExecute();

            while (handler.reader.Read())
            {
                int id = int.Parse(handler.reader["income_id"].ToString());
                string type = handler.reader["income_type"].ToString();
                string per = handler.reader["income_per"].ToString();
                float amount = float.Parse(handler.reader["income_amount"].ToString());

                Income income = new Income(id, type, per, amount);
                items.Add(income);
            }
        }


        /**
         *  getById
         */
        public Income getById(int income_id)
        {
            foreach (Income d in items)
            {
                if (d.Id == income_id)
                    return d;
            }
            return null;
        }


        /**
         * get ALL 
         */
        public ArrayList getALL()
        {
            return items;
        }


        /**
         * 
         * DELETE
         */
        public bool delete(int income_id)
        {
            int deleteChecker = 0;
            foreach (Income d in items)
            {
                if (d.Id == income_id)
                {
                    deleteChecker = d.delete();
                    items.Remove(d);
                }
            }

            if (deleteChecker == 1)
                return true;
            else
                return false;

        }

    }
}
