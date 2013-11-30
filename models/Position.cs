using System;
using System.Collections;
using System.Linq;
using System.Text;
using HRDatabase;
namespace HR
{
    public class Position
    {
        private String name;
        private int id;

        public Position(int positionID) {
            this.id = positionID;
            this.init();
        }

        public Position(int id, string name) {
            this.id = id;
            this.name = name;
        }

        private void init(){
            if (this.id != 0) {
                DatabaseHandler handler = new DatabaseHandler();
                handler.setSQL("SELECT position_name FROM Position WHERE position_id = @id");
                handler.addParameter("@id", this.id.ToString());
                handler.queryExecute();
                while (handler.reader.Read()) {
                    this.name = handler.reader["position_name"].ToString();
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

        /// <summary>
        /// This will return an arraylist contain the name and id for each 
        /// </summary>
        /// <returns></returns>
        public static ArrayList getALL() {
            ArrayList list = new ArrayList();

            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("SELECT * FROM Position");
            handler.queryExecute();
            while (handler.reader.Read()) {

                int id = int.Parse(handler.reader["position_id"].ToString());
                string name = handler.reader["position_name"].ToString();
                Position p = new Position(id,name);
                list.Add(p);
            }

            return list;
        }
    }
}
