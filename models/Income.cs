using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRDatabase;
namespace HR
{
    public class Income
    {
        private int id;
        private string type;
        private string per;
        private float amount;

        public Income(int id, string type, string per, float amount) { 
            this.id = id;
            this.type = type;
            this.per = per;
            this.amount = amount;
        }

        public static int create(int employee_id, string type, string per, float amount) {
            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("INSERT INTO Income (employee, income_type, income_amount, income_per) VALUES (@employee_id,@type,@amount,@per)");

            handler.addParameter("@employee_id", employee_id.ToString());
            handler.addParameter("@type", type);
            handler.addParameter("@amount", amount.ToString());
            handler.addParameter("@per", per);


            return handler.ExecuteNonQuery();
        }

        public int delete()
        {
            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("DELETE FROM Income WHERE income_id = @id");
            handler.addParameter("@id", this.id.ToString());
            return handler.ExecuteNonQuery();
        }


        public int Id{
            get {return id;}
        }

        public string Type{
            get {return type;}
        }

        public string Per{
            get {return per;}
        }

        public float Amount{
            get{return amount;}
        }
        
    }
}