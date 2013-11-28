using System;
using System.Collections.Generic;
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
    }
}
