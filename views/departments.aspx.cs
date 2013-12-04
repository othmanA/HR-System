using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HR;
namespace HR_SYSTEM.views
{
    public partial class departments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Creating a row
            TableRow headerRow = new TableRow();

            // Creating the cells
            TableHeaderCell idHeader = new TableHeaderCell();
            TableHeaderCell nameHeader = new TableHeaderCell();
            TableHeaderCell editHeader = new TableHeaderCell();
            TableHeaderCell deleteHeader = new TableHeaderCell();

            // Adding the text to each cell
            idHeader.Text = "ID#";
            nameHeader.Text = "Name";
            editHeader.Text = "Edit";
            deleteHeader.Text = "Delete";


            // add the cells to the row
            headerRow.Cells.Add(idHeader);
            headerRow.Cells.Add(nameHeader);
            headerRow.Cells.Add(editHeader);
            headerRow.Cells.Add(deleteHeader);

            // Add the row to the table
            Table1.Rows.Add(headerRow);


            // Arraylist of departments
            ArrayList deps = new ArrayList();
            deps = Department.getALL();

            foreach(Department d in deps){
                TableRow row = new TableRow();

                TableCell id = new TableCell();
                TableCell name = new TableCell();
                TableCell edit = new TableCell();
                TableCell delete = new TableCell();

                id.Text = d.ID.ToString();
                name.Text = d.Name;
                edit.Text = "Edit";
                delete.Text = "Delete";

                row.Cells.Add(id);
                row.Cells.Add(name);
                row.Cells.Add(edit);
                row.Cells.Add(delete);

                Table1.Rows.Add(row);
            }

            Table1.CssClass = "table";

        }
    }
}