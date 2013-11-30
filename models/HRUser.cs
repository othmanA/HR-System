using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using HRDatabase;
namespace HR
{
    public class HRUser
    {
        private int id;
        private string username;
        private string password;
        private string fullName;
        private string email;

        public HRUser(int user_id)
        {
            this.id = user_id;
            this.init();
        }

        private void init() {
            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("SELECT * FROM User WHERE user_id = @id");
            handler.addParameter("@id", id.ToString());
            while (handler.reader.Read()) {
                username = handler.reader["user_name"].ToString();
                password = handler.reader["user_password"].ToString();
                fullName = handler.reader["user_full_name"].ToString();
                email = handler.reader["user_email"].ToString();
                
            }
        }
        

        // This method will return null if the user informaiton are incorrect
        public static HRUser authenticate(string username, string password)
        {

            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("SELECT * FROM User WHERE user_name = @name AND user_password = @password");
            handler.addParameter("@name", username);
            handler.addParameter("@password", password);
            
            while (handler.reader.Read()) {
                HRUser u = new HRUser(int.Parse(handler.reader["user_id"].ToString()));
                return u;
            }

            return null;
        }


        /// <summary>
        ///   This method should create any new user. Return the number of rows affected.. Should be 1
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="full_name"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public static int create(string username, string password, string full_name, string email) {
            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("INSERT INTO [User](user_name, user_password, user_email, user_full_name) VALUES        (@name,@pass,@email,@fullname)");
            handler.addParameter("@name", username);
            handler.addParameter("@pass", password);
            handler.addParameter("@fullname", full_name);
            handler.addParameter("@email", email);

            return handler.ExecuteNonQuery();
        }




    }
}
