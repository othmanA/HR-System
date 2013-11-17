using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HR
{
    public class Job
    {
        private bool workingStatus { get; set; }
        private String contract { get; set; }
        private int hoursPerDay { get; set; }
        private DateTime firstDayAtWork { get; set; }

        public Job(int status, String contract, int hoursPDay, String firstDay)
        {
            if (status == 0)
            {
                bool workingStatus = true;
            }
            else
            {
                bool workingStatus = false;
            }


            this.firstDayAtWork = DateTime.Parse(firstDay);


        }


    }
}
