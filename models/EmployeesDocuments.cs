using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using HRDatabase;

namespace HR
{
    public class EmployeesDocuments : itemsCollection
    {

        private ArrayList items = new ArrayList();

        public EmployeesDocuments(int employee_id)
        {
            init(employee_id);
        }


        /**
         * Init
         * This method will take care of getting all the Documents for an employee
         * 
         * @pram int id
         * @return none
         * */
        public void init(int employee_id)
        {
            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("SELECT * FROM Document WHERE employee = @employee_id");
            handler.addParameter("@employee_id", employee_id.ToString());
            handler.queryExecute();

            while (handler.reader.Read())
            {
                int id = int.Parse(handler.reader["document_id"].ToString());
                string name = handler.reader["document_name"].ToString();
                string path = handler.reader["document_path"].ToString();
                string note = handler.reader["document_note"].ToString();
                int size = int.Parse(handler.reader["document_size"].ToString());

                Document d = new Document(id, name, path, note, size);
                items.Add(d);
            }
        }

        /**
         *  getById
         *  
         * This method should return the document with a specific id
         * If there are no documents matches the id then return null
         * 
         * @pram int document_id
         * @return Document
         * 
         */
        public Document getById(int document_id)
        {
            foreach (Document d in items)
            {
                if (d.Id == document_id)
                    return d;
            }
            return null;
        }


        /**
         * get ALL 
         * 
         * This method will get all the documents for an employee
         * 
         * @return ArrayList of documents
         */
        public ArrayList getALL()
        {
            return items;
        }


        /**
         * 
         * DELETE
         * 
         * The Document model will take care of the deletion from database
         * The Docuemnt Controller will take care of deleting the file
         * inside the method we will remove the item from the array
         * 
         * @pram int document_id
         * @return bool
         */
        public bool delete(int document_id)
        {
            int deleteChecker = 0;
            foreach (Document d in items)
            {
                if (d.Id == document_id)
                {
                    deleteChecker = d.delete();
                    items.Remove(d);
                }
            }

            if (deleteChecker == 1)
                return true;
            else
                return false;

        }

        public void deleteALL() {
            foreach (Document d in items) {
                d.delete();
            }
        }

    }
}
