<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeAddRecord.aspx.cs" Inherits="HR_SYSTEM.views.EmployeeAddRecord" %>

<%@ Register src="header.ascx" tagname="header" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:header ID="header1" runat="server" />
        
        <div class="container">
        <div class="well">
            <h3>Create An Employee
            </h3>

            <table class="table" style="border:0">
		<tr>
			<td>Number: </td>
            <td>
                <asp:TextBox ID="NumberTextBox" runat="server"></asp:TextBox>
            </td>
		</tr>

		<tr>
			<td>Issue Date: </td>
            <td>
                <asp:TextBox ID="IssueDateText" runat="server"></asp:TextBox>
            </td>
		</tr>

        

		<tr>
			<td>Expire Date: </td>
            <td>
                <asp:TextBox ID="ExpireDateText" runat="server"></asp:TextBox>
            </td>
		</tr>

        <script>
            $("#IssueDateText").datepicker({ changeYear: true, changeMonth: true });
            $("#ExpireDateText").datepicker({ changeYear: true, changeMonth: true });
                </script>

		<tr>
			<td>Type: </td>
            <td>
                <asp:DropDownList ID="TypeDropDown" runat="server">
                </asp:DropDownList>
            </td>
		</tr>

		<tr>
			<td>Notes: </td>
            <td>
                <asp:TextBox ID="NotesTextBox" runat="server"></asp:TextBox>
            </td>
		</tr>

		<tr>
			<td colspan="2">
				
				
			    <br />
                <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" 
                     Text="Add" onclick="Button1_Click" />
				
				
			</td>
		</tr>
        </table>
        </div>
        
        </div>
    </div>
    </form>
</body>
</html>
