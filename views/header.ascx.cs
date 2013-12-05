using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR;
namespace HR_SYSTEM.views
{
    public partial class header : System.Web.UI.UserControl
    {

        protected bool admin;

        protected void Page_Load(object sender, EventArgs e)
        {
            AlertErrorPanel.Visible = false;
            AlertSuccessPanel.Visible = false;
            if (Session["user"] == null) {
                Response.Redirect("Login.aspx");
            }
            HRUser currentUser = (HRUser) Session["user"];
            UserFullNameLabel.Text = currentUser.Name;

            if (currentUser.isAdmin())
            {
                admin = true;
            }
            else {
                admin = false;
            }
            
        }

        public void showAlert(string text) {
            AlertErrorLabel.Text = text;
            AlertErrorPanel.Visible = true;
        }

        public void success(string text) {
            AlertSuccessLabel.Text = text;
            AlertSuccessPanel.Visible = true;
        }

        public bool IsAdmin() {
            return this.admin;
        }

        
    }
}