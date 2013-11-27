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

        public string getAddress1() {
            return this.address1;
        }

        public string getAddress2()
        {
            return this.address2;
        }

        public string getCity()
        {
            return this.city;
        }

        public string getState()
        {
            return this.state;
        }

        public int getZipCode()
        {
            return this.zipCode;
        }
    }
}