using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HR
{
    public class User
    {
        public User(){
        }
        public int id { get; set; }
        public String username { get; set; }

        public String email { get; set; }
        public String fullName { get; set; }

        public int Authenticate(String username, String password){
            return 1;
        }
        public bool Create(String username, String password)
        {
            return false;
        }
        public bool Save() {
            return true; 
        }




    }
}
