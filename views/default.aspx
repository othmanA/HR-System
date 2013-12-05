<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HR_SYSTEM.views.Default" %>

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
        <div class="row">
        
        <div class="span4">
        <div class="well">
            <center><h5>Employees Count: 
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </h5></center>
        </div>
        </div>

                <div class="span4">
        <div class="well">
            <center><h5>Total Monthly Payments: 
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </h5></center>
        </div>
        </div>

                <div class="span4">
        <div class="well">
            <center><h5>Total Annually Payments: <asp:Label ID="Label3" runat="server" 
                    Text="Label"></asp:Label>
                </h5></center>
        </div>
        </div>
        </div>

    </div>
    </div>
    </form>
</body>
</html>
