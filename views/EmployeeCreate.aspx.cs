using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR;
namespace HR_SYSTEM.views
{
    public partial class EmployeeCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // This panel is for errors messaages.
            Panel1.Visible = false;

            


            // We need to fill all the dropdowns before while we load the page.
            FillPositions();
            FillContractTypes();
            FillWorkingHours();
            FillWorkingStatus();
        }

        protected void FillPositions() {
            ArrayList l = Position.getALL();
            foreach (Position p in l) {
                ListItem i = new ListItem(p.Name, p.ID.ToString());
                PositionsDropDownList.Items.Add(i);
            }
        }

        protected void FillContractTypes() { 
            ContractTypeDropDown.Items.Add("Full-Time");
            ContractTypeDropDown.Items.Add("Part-Time");
        }

        protected void FillWorkingHours()
        {
            for (int i = 1; i <= 12; i++) {
                WorkingHoursDropDown.Items.Add(i.ToString());
            }
        }

        protected void FillWorkingStatus()
        {
            WorkingStatusDropDown.Items.Add("Working");
            WorkingStatusDropDown.Items.Add("Not Working");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Testing 
            Label1.Text = ContractTypeDropDown.SelectedItem.Text.ToString();
            Panel1.Visible = true;
        }
    }
}