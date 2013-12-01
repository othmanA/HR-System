<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeView.aspx.cs" Inherits="HR_SYSTEM.views.EmployeeView" %>

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
    
    
        <asp:Table ID="ButtonsTable" runat="server">
        </asp:Table>
        
        
        
        
        
    
    
    </div>

    <div class="well">
    <h3>Employee Personal Information</h3>
    

    <asp:Table ID="InformationTable" runat="server">
        </asp:Table>

        <hr />
        <h3>Job Information:</h3>
        

        <asp:Table ID="JobTable" runat="server">
        </asp:Table>

        <hr />
        <h3>Contact Information:</h3>
       

        <asp:Table ID="AddressTable" runat="server">
        </asp:Table>
    </div>


        <div class="well">
    <h3>Employee Records</h3>
    

    <asp:Table ID="RecordsTable" runat="server">
        </asp:Table>
    </div>

     <div class="well">
    <h3>Employee Income</h3>
 

    <asp:Table ID="IncomeTable" runat="server">
        </asp:Table>
    </div>

        <div class="well">
    <h3>Employee Time Off</h3>
  

    <asp:Table ID="TimeOffTable" runat="server">
        </asp:Table>
    </div>


        <div class="well">
    <h3>Employee Documents</h3>
   

    <asp:Table ID="DocumentsTable" runat="server">
        </asp:Table>
    </div>
    </div>

    </div>
    </form>
</body>
</html>
