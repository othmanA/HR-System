using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR;
namespace HR_SYSTEM.views
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel1.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {

                string username = TextBox1.Text;
                string password = TextBox2.Text;
                HRUser user = HRUser.authenticate(username, password);
                if (user == null)
                {
                    Label2.Text = "Username and Password are incorrect!";
                    Panel1.Visible = true;
                    Session["user"] = null;
                }
                else {
                    Session["user"] = user;
                    Session["admin"] = user.isAdmin().ToString();
                    Response.Redirect("Default.aspx");
                }

            }catch(Exception exception){
                Panel1.Visible = true;
                Label2.Text = exception.Message + exception.StackTrace;
                
            }
        }
    }
}