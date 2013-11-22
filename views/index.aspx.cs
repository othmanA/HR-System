using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatabaseHandlerTester;

namespace HR_SYSTEM.views
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DatabaseHandler d = new  DatabaseHandler();
            d.setSQL("SELECT * FROM Employee");
            d.queryExecute();

            while (d.reader.Read()) {
               Label1.Text = d.reader["Employee_firstNAme"].ToString();
               DropDownList1.Items.Add("aa");
            }
        }
    }
}