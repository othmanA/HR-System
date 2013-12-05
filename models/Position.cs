using System;
using System.Collections;
using System.Linq;
using System.Text;
using HRDatabase;
namespace HR
{
    public class Position
    {
        private string name;
        private int id;
        private Department department;

        public Position(int positionID) {
            this.id = positionID;
            this.init();
        }

        public Position(int id, string name, Department department) {
            this.id = id;
            this.name = name;
            this.department = department;
        }

        private void init(){
            if (this.id != 0) {
                DatabaseHandler handler = new DatabaseHandler();
                handler.setSQL("SELECT * FROM Position WHERE position_id = @id");
                handler.addParameter("@id", this.id.ToString());
                handler.queryExecute();
                while (handler.reader.Read()) {
                    this.name = handler.reader["position_name"].ToString();
                    int dep_id = int.Parse(handler.reader["position_department"].ToString());
                    Department d = new Department(dep_id);
                    this.department = d;
                }
            }
        }

        public int ID {
            get { return id; }
            private set { id = value; }
        }

        public string Name {
            get { return name; }
            set { name = value; } 
        }

        public Department Department {
            get { return department; }
            private set { department = value; }
        }

        /// <summary>
        /// This will return an arraylist that contains the name and id and the department for each 
        /// </summary>
        /// <returns></returns>
        public static ArrayList getALL() {
            ArrayList list = new ArrayList();

            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("SELECT * FROM Position ORDER BY position_department");
            handler.queryExecute();
            while (handler.reader.Read()) {

                int id = int.Parse(handler.reader["position_id"].ToString());
                string name = handler.reader["position_name"].ToString();
                int department_id = int.Parse(handler.reader["position_department"].ToString());
                Position p = new Position(id,name,new Department(department_id));
                list.Add(p);
            }

            return list;
        }


        /// <summary>
        /// This will return an arraylist that contains the name and id and the department for each 
        /// </summary>
        /// <returns></returns>
        public static ArrayList getByDepartmentID(int department_id)
        {
            ArrayList list = new ArrayList();

            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("SELECT * FROM Position WHERE position_department = @id");
            handler.addParameter("@id", department_id.ToString());
            handler.queryExecute();
            while (handler.reader.Read())
            {

                int id = int.Parse(handler.reader["position_id"].ToString());
                string name = handler.reader["position_name"].ToString();
                Position p = new Position(id, name, new Department(department_id));
                list.Add(p);
            }

            return list;
        }

        public static int create(string position_name, int department_id)
        {
            DatabaseHandler handler = new DatabaseHandler();

            handler.setSQL("INSERT INTO [Position] (position_name,position_department) VALUES (@name,@id)");
            handler.addParameter("@name", position_name);
            handler.addParameter("@id", department_id.ToString());

            return handler.ExecuteNonQuery();
        }

        public int getCountOfEmployees() {

            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("SELECT COUNT(employee_id) AS countpositions FROM            Employee WHERE        (employee_position = @id)");
            handler.addParameter("@id", this.id.ToString());
            handler.queryExecute();
            int count = 0;
            while (handler.reader.Read())
            {
                count = int.Parse(handler.reader["countpositions"].ToString());
            }
            return count;
        }

        public static int update(int positionID, string newName, int newDepartmentID) {
            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("UPDATE [Position] SET position_name = @name, position_department = @department WHERE (position_id = @id)");

            handler.addParameter("@id", positionID.ToString());
            handler.addParameter("@name", newName);
            handler.addParameter("@department", newDepartmentID.ToString());

            return handler.ExecuteNonQuery();
        }

        public static int delete(int id)
        {
            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("DELETE FROM [Position] WHERE position_id = @id");
            handler.addParameter("@id", id.ToString());

            return handler.ExecuteNonQuery();
        }
    }
}
