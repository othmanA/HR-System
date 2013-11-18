using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HR
{
    public class Job
    {
        private bool workingStatus;
        private String contract { get; set; }
        private int hoursPerDay { get; set; }
        private DateTime firstDayAtWork;

        public Job(int status, String contract, int hoursPDay, String firstDay)
        {
            // the contract and hoursPerDay should be set from here
            this.hoursPerDay = hoursPDay;
            this.contract = contract;

            // use the setter to set the date
            setFirstDayAtWork(firstDay);

            // use the setter to set the boolean value
            if (status == 1)
                setWorkingStatus(true);
            else
                setWorkingStatus(false);
        }

        public void setFirstDayAtWork(String firstDayAtWork)
        {
            this.firstDayAtWork = DateTime.Parse(firstDayAtWork);
        }

        // The value coming from the database is 1 or 0, convert it to boolean
        public void setWorkingStatus(bool status)
        {
            this.workingStatus = status;
        }

        // And create your getter
        // Because if we created our setter we need also to create the getter

        public string getFirstDayAtWork()
        {
            return this.firstDayAtWork.toString();
        }

        public bool getWorkingStatus()
        {
            return this.status;
        }
    }
}
