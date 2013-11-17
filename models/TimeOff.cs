using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HR
{
    class TimeOff
    {
        public string startDate { get; set; }
        public string endDate { get; set; }
        public int paidDays { get; set; }
        public bool status { get; set; }
        public string type { get; set; } 

        public static void create(DateTime sDate, DateTime eDate, int pDays, string type)
        {
            return;
        }

    }
}
