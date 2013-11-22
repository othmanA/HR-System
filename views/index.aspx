<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="HR_SYSTEM.views.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../assets/css/bootstrap.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Welcome, </h1>
    </div>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" 
        CssClass="btn btn-primary" />
    <br />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <br />
    <asp:DropDownList ID="DropDownList1" runat="server">
    </asp:DropDownList>
    <br />
    <br />
    <br />
    <br />
    <asp:TextBox ID="TextBox1" runat="server" ToolTip="Enter your name" placeholder="Enter your name"></asp:TextBox>
    <br />
    <br />
    <br />
    </form>
</body>
</html>
