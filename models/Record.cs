using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR_SYSTEM.models
{
    public class Record
    {
        private DateTime issueDate{get; set;}
        private DateTime expireDate{get; set;}
        private String type{get; set;}
        private String note{get; set;}
        private bool status{get; set;}

        public static bool checkStatus()
        {
            return true;
        }

        public static save(){}

        public static create(DateTime iDate, DateTime eDate, String type){}

    }
}