<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeAddDocument.aspx.cs" Inherits="HR_SYSTEM.views.EmployeeAddDocument" %>

<%@ Register src="header.ascx" tagname="header" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        
        <uc1:header ID="header2" runat="server" />
        <div class="container">
        <div class="well">
            
            <h3>
                Add Document
            </h3>

            <table class="table" style="border:0">
		<tr>
			<td>Name: </td>
            <td>
                <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
            </td>
		</tr>

		<tr>
			<td>File: </td>
            <td>
                
                <asp:FileUpload ID="FileUpload1" runat="server" />
                
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

