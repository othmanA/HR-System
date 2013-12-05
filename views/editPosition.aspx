<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editPosition.aspx.cs" Inherits="HR_SYSTEM.views.editPosition" %>

<%@ Register src="header.ascx" tagname="header" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:header ID="header1" runat="server" />
     <div class="container">
        <div class="well">
        <h4>Edit Position</h4>
        <hr />

        <table class="table">
        
        <tr>
            <td>Name: </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>Department: </td>
            <td>
              
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
              
            </td>
        </tr>
        
        <tr>
            <td colspan="2">
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Edit" CssClass="btn btn-info" />
            </td>
        </tr>


        </table>
        
        </div>
        </div>
    
    </div>
    </form>
</body>
</html>
