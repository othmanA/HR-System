using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR
{
    public class Address
    {
        private string address1;
        private string address2;
        private string city;
        private string state;
        private int zipCode;

        public Address(string a1, string a2, string city, string state, int zipCode) {
            this.address1 = a1;
            this.address2 = a2;
            this.state = state;
            this.city = city;
            this.zipCode = zipCode;
        }

        public string Address1 {
            get { return address1; }
            set { address1 = value; }
        }

        public string Address2
        {
            get { return address2; }
            set { address2 = value; }
        }


        public string City
        {
            get{ return this.city;}
            set { city = value; }
        }

        public string State
        {
            get { return this.state; }
            set { state = value; }
        }

        public int ZipCode
        {
            get { return this.zipCode; }
            set { zipCode = value; }
        }
    }
}