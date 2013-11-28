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

        public int getID(){
            return this.id;
        }

        public void setID(int newId) {
            this.id = newId;

            // we need to get the new name for this id as soon as possible
            // we are calling the init again to get the name
            this.init();
        }

        public void setName(string name) {
            this.name = name;
        }

        public string getName() {
            return this.name;
        }
    }
}
