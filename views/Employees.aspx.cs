using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_SYSTEM.views
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillTableHeaders();

        }

        protected void FillTableHeaders() {
            // Creating a row
            TableRow row = new TableRow();

            // Creating the cells
            TableHeaderCell id = new TableHeaderCell();
            TableHeaderCell name = new TableHeaderCell();
            TableHeaderCell position = new TableHeaderCell();
            TableHeaderCell view = new TableHeaderCell();

            // Adding the text to each cell
            id.Text = "ID#";
            name.Text = "Name";
            position.Text = "Position";
            view.Text = "Options";

            // Adding the cells to the row
            row.Cells.Add(id);
            row.Cells.Add(name);
            row.Cells.Add(position);
            row.Cells.Add(view);

            // Add the row to the table
            Table1.Rows.Add(row);
        }
    }
}