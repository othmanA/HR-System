using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRDatabase;
namespace HR
{
    public class TimeOff
    {
        private int id;
        private DateTime startDate;
        private DateTime endDate;
        private int paidDays;
        private int unPaidDays;
        private int totalDays;
        private string type;
        private bool approved;

        public TimeOff(int id, DateTime startDate, DateTime endDate, int paidDays, string type, bool approved) {
            this.id = id;
            this.startDate = startDate;
            this.endDate = endDate;
            this.paidDays = paidDays;
            this.type = type;
            this.approved = approved;

            calculateDays();
        }

        private void calculateDays() {
            totalDays = (endDate - startDate).Days;
            unPaidDays = totalDays - paidDays;
        }

        public static int create(int employee_id, DateTime startDate, DateTime endDate, int paidDays, string type) {
            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("INSERT INTO Time_off (employee, time_off_end_date, time_off_start_date, time_off_paid_days, time_off_type, time_off_approved) VALUES        (@employee_id,@endDate,@startDate,@paidDays,@type, 0)");

            handler.addParameter("employee_id", employee_id.ToString());
            handler.addParameter("endDate", endDate.Date.ToString());
            handler.addParameter("startDate", startDate.Date.ToString());
            handler.addParameter("paidDays", paidDays.ToString());
            handler.addParameter("type", type);

            return handler.ExecuteNonQuery();
        }

        public int delete()
        {
            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("DELETE FROM Time_off WHERE time_off_id = @id");
            handler.addParameter("@id", this.id.ToString());
            return handler.ExecuteNonQuery();
        }


        // -- GETTERS -- We don't need setters for this
        public int Id {
            get { return this.id; }
        }

        public DateTime StartDate {
            get { return this.startDate;}
        }

        public DateTime EndDate {
            get { return this.endDate;}
        }

        public int PaidDays{
            get { return this.paidDays; }
        }

        public int UnPaidDays {
            get { return this.unPaidDays; }
        }

        public int TotalDays {
            get { return this.totalDays; }
        }

        public string Type {
            get { return this.type; } 
        }

        public bool IsApproved {
            get { return this.approved; }
            private set { approved = value; }
        }

    }
}
