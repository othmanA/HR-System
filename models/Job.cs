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

        public Job(bool workingStatus, string contract, int hoursPerDay, DateTime firstDayAtWork, int positionID)
        {
            this.contract = contract;
            this.workingStatus = workingStatus;
            this.hoursPerDay = hoursPerDay;
            this.firstDayAtWork = firstDayAtWork;

            this.position = new Position(positionID);
        }

        public DateTime FirstDayAtWork {
            get { return this.firstDayAtWork; }
            set { firstDayAtWork = value; }
        }

        public bool WorkingStatus {
            get { return workingStatus; }
            set { workingStatus = value; }
        }

        public string Contract {
            get { return contract; }
            set { contract = value; }
        }

        public int HoursPerDay {
            get { return hoursPerDay; }
            set { hoursPerDay = value; }
        }

        public Position Position {
            get { return position; }
            private set { position = value; }
        }

    }
}
