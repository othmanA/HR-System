<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="HR_SYSTEM.views.Employees" %>

<%@ Register src="header.ascx" tagname="header" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:header ID="header1" runat="server" />

        <div class="container">

        <asp:Panel ID="panel1" runat="server">
        
        <div class="well">
        <h4>Un Approved Employees</h4>
                    <asp:Table ID="Table2" runat="server" CssClass="table">
            </asp:Table>
        
        
        </div>
        </asp:Panel>

        <div class="well">
        <h4>Employees</h4>


            <asp:Table ID="Table1" runat="server" CssClass="table">
            </asp:Table>
        
        </div>
        </div>
    
    </div>
   
    </form>
</body>
</html>
