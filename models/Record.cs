using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRDatabase;
namespace HR
{
    public class Record
    {
        private int id;
        private int number;
        private DateTime issueDate;
        private DateTime expireDate;
        private string type;
        private string note;
        private bool approved;

        public Record(int id, int number, DateTime issueDate, DateTime expireDate, string type, string note, bool approved) {
            this.id = id;
            this.number = number;
            this.issueDate = issueDate;
            this.expireDate = expireDate;
            this.type = type;
            this.note = note;
            this.approved = approved;
        }


        /*
         * Record Creator
         * 
         * @return int number of rows affected -- Should be 1 if everyting is ok
         */
        public static int create(int employee_id, int number, DateTime issueDate, DateTime expireDate, string type, string note){

            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("INSERT INTO Record (employee, record_number, record_issue_date, record_expire_date, record_type, record_note, record_approved) VALUES        (@employee,@number,@issue,@expire,@type,@note, 0)");
            //(@employee,@number,@issue,@expire,@type,@note, 0)
            handler.addParameter("@employee", employee_id.ToString());
            handler.addParameter("@number", number.ToString());
            handler.addParameter("@issue", issueDate.Date.ToString());
            handler.addParameter("@expire", expireDate.Date.ToString());
            handler.addParameter("@type", type);
            handler.addParameter("@note", note);

            return handler.ExecuteNonQuery();
        }

        public int delete() {
            DatabaseHandler handler = new DatabaseHandler();
            handler.setSQL("DELETE FROM Record WHERE record_id = @id");
            handler.addParameter("@id", this.id.ToString());
            return handler.ExecuteNonQuery();
        }


        // ---- GETTERS ----
        public int getID() {
            return this.id;
        }

        public int getNumber() {
            return number;
        }

        public DateTime getIssueDate() {
            return issueDate;
        }

        public DateTime getExpireDate() {
            return expireDate;
        }

        public string getType() { 
            return type;
        }

        public string getNote(){
            return note;
        }

        public bool getApprovedStatus() {
            return this.approved;
        }


        //---- SETTERS ----
        // There is no need to set the id
        public void setNumber(int number) {
            this.number = number;
        }

        public void setIssueDate(DateTime issueDate) {
            this.issueDate = issueDate;
        }

        public void setExpireDate(DateTime expireDate)
        {
            this.expireDate = expireDate;
        }

        public void setType(string newType) {
            type = newType;
        }

        public void setNote(string newNote) {
            note = newNote;
        }

        public void setApprovedStatus(bool newStatus) {
            approved = newStatus;
        }

    }
}