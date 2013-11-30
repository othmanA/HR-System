using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_SYSTEM.views
{
    public partial class header : System.Web.UI.UserControl
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
            AlertErrorPanel.Visible = false;
            AlertSuccessPanel.Visible = false;
        }

        public void showAlert(string text) {
            AlertErrorLabel.Text = text;
            AlertErrorPanel.Visible = true;
        }

        public void success(string text) {
            AlertSuccessLabel.Text = text;
            AlertSuccessPanel.Visible = true;
        }
    }
}