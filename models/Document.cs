using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRDatabase;
namespace HR
{
    public class Document
    {
        private int id;
        private string name;
        private string path;
        private string note;
        private int size;

        public Document(int id, string name, string path, string note, int size) {
            this.id = id;
            this.name = name;
            this.path = path;
            this.note = note;
            this.size = size;
        }

        public static int create(int employee_id, string name, string path, int size, string note){
            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("INSERT INTO [Document] (employee, document_name, document_path, document_size, document_note) VALUES        (@employee_id,@name,@path,@size,@note)");
            
            handler.addParameter("@employee_id",employee_id.ToString());
            handler.addParameter("@name",name);
            handler.addParameter("@path",path);
            handler.addParameter("@size",size.ToString());
            handler.addParameter("@note",note);

            return handler.ExecuteNonQuery();
        }

        // The controller should delete the file first.
        public int delete()
        {
            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("DELETE FROM Document WHERE document_id = @id");
            handler.addParameter("@id", this.id.ToString());
            return handler.ExecuteNonQuery();
        }


        //----- GETTERS AND SETTERS -----//
        public int Id{
            get { return id; }
            private set { id = value; }
        }

        public string Name {
            get { return name; }
            private set { name = value; }
        }

        public string Path {
            get { return path; }
            private set { path = value; }
        }

        public string Note {
            get { return note; }
            private set { note = value; }
        }

        public int Size {
            get { return size; }
            private set { size = value; }
        }
    }
}