using System;
using System.Collections;
using System.Linq;
using System.Web;
using HRDatabase;
namespace HR
{
    public class Department
    {
        private int id;
        private string name;

        public Department(int id, string name) {
            this.name = name;
            this.id = id;
        }

        public Department(int id) {
            this.id = id;
            this.init();
        }

        private void init(){
            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("SELECT * FROM [Department] WHERE department_id = @id");
            handler.addParameter("@id",this.id.ToString());
            handler.queryExecute();
            while (handler.reader.Read()) {
                this.name = handler.reader["department_name"].ToString();
            }
        }

        public static ArrayList getALL() {
            ArrayList departments = new ArrayList();

            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("SELECT * FROM [Department] ORDER BY department_name");
            handler.queryExecute();

            while (handler.reader.Read()) {

                string department_name = handler.reader["department_name"].ToString();
                int department_id = int.Parse(handler.reader["department_id"].ToString());

                Department d = new Department(department_id,department_name);
                departments.Add(d);
            }

            return departments;
        }



        public static int create(string department_name) {
            DatabaseHandler handler = new DatabaseHandler();

            handler.setSQL("INSERT INTO [Department] (department_name) VALUES (@name)");
            handler.addParameter("@name", department_name);
            
            return handler.ExecuteNonQuery();
        }

        public string Name {
            get { return name; }
        }

        public int ID {
            get { return id; }
        }
    }
}