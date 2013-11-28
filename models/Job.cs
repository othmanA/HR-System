using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HR
{
    public class Job
    {
        private bool workingStatus;
        private string contract;
        private int hoursPerDay;
        private DateTime firstDayAtWork;
        private Position position;

        public Job(int status, string contract, int hoursPDay, string firstDay, int positionID)
        {
            setContract(contract);
            setHoursPerDay(hoursPDay);
            setFirstDayAtWork(firstDay);

            // this method is faster than if else.. we are passing the condition
            // status == 1 will be sent to the method as true or false
            setWorkingStatus((status == 1));
            this.position = new Position(positionID);
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

        public DateTime getFirstDayAtWork()
        {
            return this.firstDayAtWork;
        }

        public bool getWorkingStatus()
        {
            return workingStatus;
        }


        public void setContract(string contract) {
            this.contract = contract;
        }

        public string getContract() {
            return this.contract;
        }

        public void setHoursPerDay(int newHours) {
            hoursPerDay = newHours;
        }

        public int getHoursPerDay() {
            return hoursPerDay;
        }

        public Position getPosition() {
            return this.position;
        }

    }
}
