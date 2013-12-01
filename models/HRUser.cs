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
        private int role;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="user_id"></param>
        public HRUser(int user_id)
        {
            this.id = user_id;
            this.init();
        }

        /// <summary>
        /// Getting the user information from the database
        /// </summary>
        private void init() {
            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("SELECT * FROM [User] WHERE user_id = @id");
            handler.addParameter("@id", id.ToString());
            handler.queryExecute();
            while (handler.reader.Read()) {
                username = handler.reader["user_name"].ToString();
                password = handler.reader["user_password"].ToString();
                fullName = handler.reader["user_full_name"].ToString();
                email = handler.reader["user_email"].ToString();
                role = int.Parse(handler.reader["user_role"].ToString());
            }
        }
        

        /// <summary>
        /// This method will return an object of class user if the user found. Otherwise it will return null
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <param name="password">The password of the user</param>
        /// <returns></returns>
        public static HRUser authenticate(string username, string password)
        {

            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("SELECT * FROM [User] WHERE user_name = @name AND user_password = @password");
            handler.addParameter("@name", username);
            handler.addParameter("@password", password);
            handler.queryExecute();
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


        /// <summary>
        /// Saving the information to the database (Except for the password)
        /// </summary>
        /// <returns></returns>
        public bool save() {
            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("UPDATE [User] SET user_name = @u, user_email = @e, user_full_name = @f WHERE user_id = @id");
            handler.addParameter("@u", username);
            handler.addParameter("@e", email);
            handler.addParameter("@f", fullName);
            handler.addParameter("@id", id.ToString());

            return (handler.ExecuteNonQuery() == 1);
        }


        public bool updatePassword(string oldPassword, string newPassword) {

            if (this.password == oldPassword)
            {
                DatabaseHandler handler = new DatabaseHandler();
                handler.setSQL("UPDATE [User] SET user_password = @pass WHERE user_id = @id");
                handler.addParameter("@pass", newPassword);
                handler.addParameter("@id", id.ToString());

                return (handler.ExecuteNonQuery() == 1);
            }
            else {
                return false;
            }
        }

        public bool isAdmin() {
            if (role == 1)
                return true;
            else
                return false;
        }

        public bool isUser()
        {
            if (role == 0)
                return true;
            else
                return false;
        }

        //----- GETTERS AND SETTERS -----//
        public int ID {
            get { return id; }
            private set { id = value; }
        }

        public string Username {
            get { return username; }
            set { username = value; }
        }


        public string Email {
            get { return email; }
            set { email = value; }
        }

        public string Name {
            get { return fullName; }
            set { fullName = value;  }
        }



    }
}
